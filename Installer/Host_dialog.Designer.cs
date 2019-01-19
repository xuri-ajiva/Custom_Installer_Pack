namespace Installer
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
            this.Grid = new System.Windows.Forms.Panel();
            this.update = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.Location = new System.Drawing.Point(0, 0);
            this.Grid.Size = new System.Drawing.Size(500, 500);
            this.Grid.TabIndex = 0;
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
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.Grid);
            this.Name = "Host_dialog";
            this.Text = "Host_dialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Host_dialog_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Grid;
        private System.Windows.Forms.Timer update;
    }
}