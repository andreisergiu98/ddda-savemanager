namespace ddda_savemanager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.setSave = new System.Windows.Forms.Button();
            this.currentSave = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.saveList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // setSave
            // 
            this.setSave.Location = new System.Drawing.Point(12, 7);
            this.setSave.Name = "setSave";
            this.setSave.Size = new System.Drawing.Size(109, 23);
            this.setSave.TabIndex = 1;
            this.setSave.Text = "Load  Save";
            this.setSave.UseVisualStyleBackColor = true;
            this.setSave.Click += new System.EventHandler(this.setSave_Click);
            // 
            // currentSave
            // 
            this.currentSave.AutoSize = true;
            this.currentSave.Location = new System.Drawing.Point(145, 12);
            this.currentSave.Name = "currentSave";
            this.currentSave.Size = new System.Drawing.Size(70, 13);
            this.currentSave.TabIndex = 3;
            this.currentSave.Text = "Current save:";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(483, 12);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(37, 13);
            this.status.TabIndex = 4;
            this.status.Text = "Status";
            // 
            // saveList
            // 
            this.saveList.HideSelection = false;
            this.saveList.LabelEdit = true;
            this.saveList.Location = new System.Drawing.Point(12, 36);
            this.saveList.Name = "saveList";
            this.saveList.Size = new System.Drawing.Size(585, 431);
            this.saveList.TabIndex = 0;
            this.saveList.UseCompatibleStateImageBehavior = false;
            this.saveList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.saveList_AfterLabelEdit);
            this.saveList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.saveList_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(609, 479);
            this.Controls.Add(this.status);
            this.Controls.Add(this.currentSave);
            this.Controls.Add(this.setSave);
            this.Controls.Add(this.saveList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "DDDA Save Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button setSave;
        private System.Windows.Forms.Label currentSave;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.ListView saveList;
    }
}

