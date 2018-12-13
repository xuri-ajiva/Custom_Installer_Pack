namespace Source_Engin_Moder
{
    partial class Host_dialog
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
            this.components = new System.ComponentModel.Container();
            this.dialog11 = new Source_Engin_Moder.Dialog1();
            this.Grid = new System.Windows.Forms.Panel();
            this.final1 = new Source_Engin_Moder.Final();
            this.dialog31 = new Source_Engin_Moder.Dialog3();
            this.dialog21 = new Source_Engin_Moder.Dialog2();
            this.update = new System.Windows.Forms.Timer(this.components);
            this.Grid.SuspendLayout();
            this.SuspendLayout();
            // 
            // dialog11
            // 
            this.dialog11.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dialog11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dialog11.Location = new System.Drawing.Point(3, 3);
            this.dialog11.Name = "dialog11";
            this.dialog11.Size = new System.Drawing.Size(500, 500);
            this.dialog11.TabIndex = 0;
            // 
            // Grid
            // 
            this.Grid.Controls.Add(this.final1);
            this.Grid.Controls.Add(this.dialog31);
            this.Grid.Controls.Add(this.dialog21);
            this.Grid.Controls.Add(this.dialog11);
            this.Grid.Location = new System.Drawing.Point(1, 1);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(1518, 543);
            this.Grid.TabIndex = 1;
            // 
            // final1
            // 
            this.final1.Location = new System.Drawing.Point(500, 11);
            this.final1.Name = "final1";
            this.final1.Size = new System.Drawing.Size(500, 500);
            this.final1.TabIndex = 3;
            // 
            // dialog31
            // 
            this.dialog31.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dialog31.Location = new System.Drawing.Point(1006, 3);
            this.dialog31.Name = "dialog31";
            this.dialog31.Size = new System.Drawing.Size(500, 500);
            this.dialog31.TabIndex = 2;
            // 
            // dialog21
            // 
            this.dialog21.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dialog21.Location = new System.Drawing.Point(500, 3);
            this.dialog21.Name = "dialog21";
            this.dialog21.Size = new System.Drawing.Size(500, 500);
            this.dialog21.TabIndex = 1;
            // 
            // update
            // 
            this.update.Interval = 10;
            this.update.Tick += new System.EventHandler(this.update_Tick);
            // 
            // Host_dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 513);
            this.Controls.Add(this.Grid);
            this.Name = "Host_dialog";
            this.Text = "Host_dialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Host_dialog_FormClosing);
            this.Grid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Dialog1 dialog11;
        private System.Windows.Forms.Panel Grid;
        private Dialog2 dialog21;
        private Dialog3 dialog31;
        private System.Windows.Forms.Timer update;
        private Final final1;
    }
}