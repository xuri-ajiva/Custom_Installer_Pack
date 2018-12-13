namespace Source_Engin_Moder
{
    partial class Dialog3
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.open = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.b_cancle = new System.Windows.Forms.Button();
            this.B_back = new System.Windows.Forms.Button();
            this.b_next = new System.Windows.Forms.Button();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // open
            // 
            this.open.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.open.Location = new System.Drawing.Point(335, 328);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(140, 25);
            this.open.TabIndex = 10;
            this.open.Text = "Dateien Quelle öffnen";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(39, 331);
            this.textBox1.MinimumSize = new System.Drawing.Size(4, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 20);
            this.textBox1.TabIndex = 9;
            // 
            // b_cancle
            // 
            this.b_cancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_cancle.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.b_cancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_cancle.Location = new System.Drawing.Point(415, 468);
            this.b_cancle.Margin = new System.Windows.Forms.Padding(10);
            this.b_cancle.Name = "b_cancle";
            this.b_cancle.Size = new System.Drawing.Size(75, 22);
            this.b_cancle.TabIndex = 8;
            this.b_cancle.Text = "Abbrechen";
            this.b_cancle.UseVisualStyleBackColor = true;
            this.b_cancle.Click += new System.EventHandler(this.b_cancle_Click);
            // 
            // B_back
            // 
            this.B_back.DialogResult = System.Windows.Forms.DialogResult.No;
            this.B_back.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.B_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_back.Location = new System.Drawing.Point(253, 468);
            this.B_back.Name = "B_back";
            this.B_back.Size = new System.Drawing.Size(75, 22);
            this.B_back.TabIndex = 7;
            this.B_back.Text = "<- Back";
            this.B_back.UseVisualStyleBackColor = true;
            this.B_back.Click += new System.EventHandler(this.B_back_Click);
            // 
            // b_next
            // 
            this.b_next.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.b_next.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.b_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_next.Location = new System.Drawing.Point(335, 468);
            this.b_next.Name = "b_next";
            this.b_next.Size = new System.Drawing.Size(75, 22);
            this.b_next.TabIndex = 6;
            this.b_next.Text = "Next ->";
            this.b_next.UseVisualStyleBackColor = true;
            this.b_next.Click += new System.EventHandler(this.b_next_Click);
            // 
            // Dialog3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.open);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.b_cancle);
            this.Controls.Add(this.B_back);
            this.Controls.Add(this.b_next);
            this.Name = "Dialog3";
            this.Size = new System.Drawing.Size(500, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button b_cancle;
        private System.Windows.Forms.Button B_back;
        private System.Windows.Forms.Button b_next;
        private System.Windows.Forms.FolderBrowserDialog fbd;
    }
}
