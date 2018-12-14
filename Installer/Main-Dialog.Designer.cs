namespace Source_Engin_Moder
{
    partial class Main_Dialog
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
            this.Text = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.open = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Text
            // 
            this.Text.AutoSize = true;
            this.Text.Location = new System.Drawing.Point(9, 9);
            this.Text.Name = "Text";
            this.Text.Size = new System.Drawing.Size(161, 13);
            this.Text.TabIndex = 0;
            this.Text.Text = "Bitte Wählen sie alle dateien aus";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(279, 20);
            this.textBox1.TabIndex = 1;
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(297, 46);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(126, 20);
            this.open.TabIndex = 2;
            this.open.Text = "instalations datei öffnen";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Installationsanversung (*.inst)|*.inst";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(345, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(297, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 20);
            this.button2.TabIndex = 5;
            this.button2.Text = "install verzeichnis";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 72);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(279, 20);
            this.textBox2.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 128);
            this.progressBar1.MarqueeAnimationSpeed = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(411, 10);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(297, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 20);
            this.button3.TabIndex = 9;
            this.button3.Text = "Dateien Quelle öffnen";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 98);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(279, 20);
            this.textBox3.TabIndex = 8;
            // 
            // Main_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 179);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.open);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Text);
            this.Name = "Main_Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private new System.Windows.Forms.Label Text;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox3;
    }
}