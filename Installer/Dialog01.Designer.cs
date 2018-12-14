namespace Source_Engin_Moder
{
    partial class Dialog01
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
            this.b_next = new System.Windows.Forms.Button();
            this.B_back = new System.Windows.Forms.Button();
            this.b_cancle = new System.Windows.Forms.Button();
            this.open = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // b_next
            // 
            this.b_next.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.b_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_next.Location = new System.Drawing.Point(322, 435);
            this.b_next.Name = "b_next";
            this.b_next.Size = new System.Drawing.Size(75, 22);
            this.b_next.TabIndex = 0;
            this.b_next.Text = "Next ->";
            this.b_next.UseVisualStyleBackColor = true;
            this.b_next.Click += new System.EventHandler(this.b_next_Click);
            // 
            // B_back
            // 
            this.B_back.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.B_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_back.Location = new System.Drawing.Point(241, 435);
            this.B_back.Name = "B_back";
            this.B_back.Size = new System.Drawing.Size(75, 22);
            this.B_back.TabIndex = 1;
            this.B_back.Text = "<- Back";
            this.B_back.UseVisualStyleBackColor = true;
            this.B_back.Click += new System.EventHandler(this.B_back_Click);
            // 
            // b_cancle
            // 
            this.b_cancle.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.b_cancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_cancle.Location = new System.Drawing.Point(403, 435);
            this.b_cancle.Name = "b_cancle";
            this.b_cancle.Size = new System.Drawing.Size(75, 22);
            this.b_cancle.TabIndex = 2;
            this.b_cancle.Text = "Abbrechen";
            this.b_cancle.UseVisualStyleBackColor = true;
            this.b_cancle.Click += new System.EventHandler(this.b_cancle_Click);
            // 
            // open
            // 
            this.open.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.open.Location = new System.Drawing.Point(323, 295);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(140, 25);
            this.open.TabIndex = 4;
            this.open.Text = "instalations Anweisungen";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(27, 298);
            this.textBox1.MinimumSize = new System.Drawing.Size(4, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 20);
            this.textBox1.TabIndex = 3;
            // 
            // ofd
            // 
            this.ofd.Filter = "Installationsanversung (*.inst)|*.inst";
            // 
            // Dialog01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 469);
            this.Controls.Add(this.open);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.b_cancle);
            this.Controls.Add(this.B_back);
            this.Controls.Add(this.b_next);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "Dialog01";
            this.ShowIcon = false;
            this.Text = "Dialog01";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dialog01_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_next;
        private System.Windows.Forms.Button B_back;
        private System.Windows.Forms.Button b_cancle;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog ofd;
    }
}