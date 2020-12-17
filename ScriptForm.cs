using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SQLScriptRunner
{
    public partial class ScriptForm : Form
    {

        #region sp - run scripts on your db from RequiredScripts folder
        private readonly string spDBScriptHistoryValidation = "spValidateScriptNameList";
        private readonly string spDBScriptHistoryInsert = "spInsertScriptNameIntoDBScriptHistoryTable";
        #endregion

        #region ctor
        public ScriptForm()
        {
            InitializeComponent();
        }
        #endregion

        private void SelectFolder_Click(object sender, EventArgs e)
        {
            // Open FolderBrowserDialogBox
            folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath;
            pathName.Text = path;

        }

        private void Execute_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(connectionStringTextBox.Text))
            {
                //Executing.Text = "Started executing, Please wait..."; //WINDOW REFRESH ISSUE?
                string path = folderBrowserDialog1.SelectedPath;

                if (!String.IsNullOrEmpty(path))
                {
                    var expectionOccured = false;
                    string sqlConnectionString = connectionStringTextBox.Text;

                    #region SortFiles
                    var listOfFiles = Directory.GetFiles(path).ToList();
                    List<string> scriptName = new List<string>();
                    foreach (var name in listOfFiles)
                    {
                        //extract file name from the complete file path
                        int index = name.LastIndexOf('\\');
                        scriptName.Add(name.Substring(index + 1));
                    }
                    var sortedList = NaturalSort(scriptName);
                    #endregion

                    // use a using for all disposable objects, so that you are sure that they are disposed properly
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        conn.Open();
                        try
                        {
                            #region Validate scripts
                            var existingScripts = ValidateDBScriptHistoryTable(conn, spDBScriptHistoryValidation);
                            var nonExistingScripts = sortedList.Except(existingScripts).ToList();
                            #endregion

                            if (nonExistingScripts != null && nonExistingScripts.Count > 0)
                            {
                                foreach (var sqlFile in nonExistingScripts)
                                {
                                    if (sqlFile.Contains(".sql"))
                                    {
                                        try
                                        {
                                            var completeFilePath = $"{path}\\{sqlFile}"; 
                                            string script = File.ReadAllText(completeFilePath); // file to be read should include complete file path not just its name!
                                            if (!String.IsNullOrEmpty(script))
                                            {
                                                //Execute script read from .sql file
                                                using (SqlCommand cmd = new SqlCommand(script, conn))
                                                {
                                                    cmd.ExecuteNonQuery();
                                                    cmd.Dispose();
                                                    AddEntryToDBScriptHistoryTable(conn, spDBScriptHistoryInsert, sqlFile);
                                                }

                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            expectionOccured = true;
                                            ExceptionBox.Text = "Error occured on file: " + sqlFile + "\n" + ex.ToString();
                                            break;
                                        }
                                        
                                    }

                                }


                            }
                            //else
                            //{
                            //    Executing.Text = "Scripts has already been runned before"; //WINDOW REFRESH ISSUE?
                            //}
                        }
                        catch (Exception ex)
                        {
                            expectionOccured = true;
                            ExceptionBox.Text = ex.ToString();
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }

                    if (!expectionOccured)
                        Executing.Text = "Execution completed successfully";
                    else
                        Executing.Text = "Please refer below exception box for details";
                }
                else
                {
                    Executing.Text = "Please select a folder";
                }
            }
            else
            {
                Executing.Text = "Please enter a connection string";
            }

        }

        private List<string> NaturalSort(List<string> files)
        {
            for (int i = 0; i < files.Count; i++)
            {
                for (int j = i + 1; j < files.Count; j++)
                {
                    //Extract decimals and integer from string using regex
                    var pattern = @"\d+\.*\d*";
                    var valueAtI = Regex.Match(files[i], pattern).Value;
                    var valueAtJ = Regex.Match(files[j], pattern).Value;
                    if (!String.IsNullOrEmpty(valueAtI) && !String.IsNullOrEmpty(valueAtJ))
                    {
                        if (Convert.ToDecimal(valueAtI) > Convert.ToDecimal(valueAtJ))
                        {
                            //swap element at i position with j 
                            var temp = files[i];
                            files[i] = files[j];
                            files[j] = temp;

                        }
                    }
                }
            }
            return files;
        }

        private List<string> ValidateDBScriptHistoryTable(SqlConnection conn, string sqlCommand)
        {
            using (SqlCommand val_sql_cmnd = new SqlCommand(sqlCommand, conn))
            {
                val_sql_cmnd.CommandType = CommandType.StoredProcedure;
                List<string> files = new List<string>();
                using (SqlDataReader reader = val_sql_cmnd.ExecuteReader())  
                {
                    while (reader.Read())
                    {
                        files.Add(reader.GetString(0)); //Here, 0 represnts the first column of the query's result-set
                    }
                    reader.Close();
                }
                
                return files;

            }
        }

        private void AddEntryToDBScriptHistoryTable(SqlConnection conn, string sqlCommand, string scriptName)
        {
            using (SqlCommand sql_cmnd = new SqlCommand(sqlCommand, conn))
            {
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@scriptName", scriptName);
                sql_cmnd.Parameters.AddWithValue("@currentDateTime", DateTime.Now);
                sql_cmnd.ExecuteNonQuery();
                sql_cmnd.Dispose();
            }

        }

    }
}

