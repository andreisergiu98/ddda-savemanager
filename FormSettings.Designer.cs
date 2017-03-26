namespace ddda_savemanager
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.browsePath = new System.Windows.Forms.Button();
            this.path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.interval = new System.Windows.Forms.NumericUpDown();
            this.maxSaves = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.interval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSaves)).BeginInit();
            this.SuspendLayout();
            // 
            // browsePath
            // 
            this.browsePath.Location = new System.Drawing.Point(12, 12);
            this.browsePath.Name = "browsePath";
            this.browsePath.Size = new System.Drawing.Size(91, 23);
            this.browsePath.TabIndex = 0;
            this.browsePath.Text = "Browse Path";
            this.browsePath.UseVisualStyleBackColor = true;
            this.browsePath.Click += new System.EventHandler(this.browsePath_Click);
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(123, 14);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(335, 20);
            this.path.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Maximum number of saves:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Checking interval (seconds):";
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(123, 147);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 4;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(272, 147);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(285, 84);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(37, 13);
            this.status.TabIndex = 8;
            this.status.Text = "Status";
            // 
            // interval
            // 
            this.interval.Location = new System.Drawing.Point(172, 57);
            this.interval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.interval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.interval.Name = "interval";
            this.interval.Size = new System.Drawing.Size(63, 20);
            this.interval.TabIndex = 10;
            this.interval.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // maxSaves
            // 
            this.maxSaves.Location = new System.Drawing.Point(172, 107);
            this.maxSaves.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.maxSaves.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxSaves.Name = "maxSaves";
            this.maxSaves.Size = new System.Drawing.Size(63, 20);
            this.maxSaves.TabIndex = 11;
            this.maxSaves.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 182);
            this.Controls.Add(this.maxSaves);
            this.Controls.Add(this.interval);
            this.Controls.Add(this.status);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.path);
            this.Controls.Add(this.browsePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.interval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSaves)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browsePath;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.NumericUpDown interval;
        private System.Windows.Forms.NumericUpDown maxSaves;
    }
}