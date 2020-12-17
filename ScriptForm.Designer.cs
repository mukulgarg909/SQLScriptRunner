
using System.Windows.Forms;

namespace SQLScriptRunner
{
    partial class ScriptForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.connectionStringTextBox = new System.Windows.Forms.TextBox();
            this.Execute = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Executing = new System.Windows.Forms.Label();
            this.pathName = new System.Windows.Forms.Label();
            this.ExceptionBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectFolder
            // 
            this.SelectFolder.Location = new System.Drawing.Point(498, 219);
            this.SelectFolder.Name = "SelectFolder";
            this.SelectFolder.Size = new System.Drawing.Size(102, 23);
            this.SelectFolder.TabIndex = 0;
            this.SelectFolder.Text = "Select Folder";
            this.SelectFolder.UseVisualStyleBackColor = true;
            this.SelectFolder.Click += new System.EventHandler(this.SelectFolder_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(124, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Connection string";
            // 
            // connectionStringTextBox
            // 
            this.connectionStringTextBox.Location = new System.Drawing.Point(324, 163);
            this.connectionStringTextBox.Name = "connectionStringTextBox";
            this.connectionStringTextBox.Size = new System.Drawing.Size(276, 23);
            this.connectionStringTextBox.TabIndex = 2;
            // 
            // Execute
            // 
            this.Execute.Location = new System.Drawing.Point(499, 266);
            this.Execute.Name = "Execute";
            this.Execute.Size = new System.Drawing.Size(101, 23);
            this.Execute.TabIndex = 4;
            this.Execute.Text = "Execute";
            this.Execute.UseVisualStyleBackColor = true;
            this.Execute.Click += new System.EventHandler(this.Execute_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Selected path:";
            // 
            // Executing
            // 
            this.Executing.AutoSize = true;
            this.Executing.Location = new System.Drawing.Point(324, 313);
            this.Executing.Name = "Executing";
            this.Executing.Size = new System.Drawing.Size(0, 15);
            this.Executing.TabIndex = 6;
            // 
            // pathName
            // 
            this.pathName.AutoSize = true;
            this.pathName.Location = new System.Drawing.Point(211, 219);
            this.pathName.Name = "pathName";
            this.pathName.Size = new System.Drawing.Size(0, 15);
            this.pathName.TabIndex = 8;
            // 
            // ExceptionBox
            // 
            this.ExceptionBox.Location = new System.Drawing.Point(324, 352);
            this.ExceptionBox.Multiline = true;
            this.ExceptionBox.Name = "ExceptionBox";
            this.ExceptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ExceptionBox.Size = new System.Drawing.Size(276, 97);
            this.ExceptionBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Exception (if any)";
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 476);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ExceptionBox);
            this.Controls.Add(this.pathName);
            this.Controls.Add(this.Executing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Execute);
            this.Controls.Add(this.connectionStringTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectFolder);
            this.Name = "ScriptForm";
            this.Text = "SQL Script Runner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox connectionStringTextBox;
        private System.Windows.Forms.Button Execute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Executing;
        private System.Windows.Forms.Label pathName;
        private System.Windows.Forms.TextBox ExceptionBox;
        private Label label3;
    }
}

