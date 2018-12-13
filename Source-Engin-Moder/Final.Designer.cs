namespace Source_Engin_Moder
{
    partial class Final
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
            this.components = new System.ComponentModel.Container();
            this.PB = new System.Windows.Forms.ProgressBar();
            this.b_cancle = new System.Windows.Forms.Button();
            this.B_back = new System.Windows.Forms.Button();
            this.b_next = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Timer(this.components);
            this.log = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PB
            // 
            this.PB.Location = new System.Drawing.Point(30, 422);
            this.PB.MarqueeAnimationSpeed = 1;
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(436, 21);
            this.PB.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.PB.TabIndex = 17;
            this.PB.Visible = false;
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
            this.b_cancle.TabIndex = 14;
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
            this.B_back.TabIndex = 13;
            this.B_back.Text = "<- Back";
            this.B_back.UseVisualStyleBackColor = true;
            this.B_back.Click += new System.EventHandler(this.B_back_Click);
            // 
            // b_next
            // 
            this.b_next.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.b_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_next.Location = new System.Drawing.Point(334, 468);
            this.b_next.Name = "b_next";
            this.b_next.Size = new System.Drawing.Size(75, 22);
            this.b_next.TabIndex = 12;
            this.b_next.Text = "Install";
            this.b_next.UseVisualStyleBackColor = true;
            this.b_next.Click += new System.EventHandler(this.b_next_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 153);
            this.label4.Margin = new System.Windows.Forms.Padding(10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 186);
            this.label5.Margin = new System.Windows.Forms.Padding(10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "label5";
            // 
            // update
            // 
            this.update.Interval = 10;
            this.update.Tick += new System.EventHandler(this.update_Tick);
            // 
            // log
            // 
            this.log.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.log.ForeColor = System.Drawing.Color.Green;
            this.log.FormattingEnabled = true;
            this.log.Location = new System.Drawing.Point(30, 238);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(436, 160);
            this.log.TabIndex = 23;
            this.log.Visible = false;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(10, 468);
            this.button1.Margin = new System.Windows.Forms.Padding(10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 24;
            this.button1.Text = "Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Final
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.log);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PB);
            this.Controls.Add(this.b_cancle);
            this.Controls.Add(this.B_back);
            this.Controls.Add(this.b_next);
            this.Name = "Final";
            this.Size = new System.Drawing.Size(500, 500);
            this.Load += new System.EventHandler(this.Final_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar PB;
        private System.Windows.Forms.Button b_cancle;
        private System.Windows.Forms.Button B_back;
        private System.Windows.Forms.Button b_next;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer update;
        private System.Windows.Forms.ListBox log;
        private System.Windows.Forms.Button button1;
    }
}
