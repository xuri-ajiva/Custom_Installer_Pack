﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AIO;

namespace Installer
{
    public partial class Dialog3 : UserControl
    {
        public static bool skip = false;
        public Dialog3()
        {
            InitializeComponent();
            textBox1.Text = VAR.installfiles;
        }
        private void b_cancle_Click(object sender, EventArgs e)
        {
            s();
            exit ex = new exit();
            if (ex.ShowDialog() == DialogResult.OK)
            {
                Environment.Exit(VAR.error);
            }
            else
            {

            }
        }
        private void open_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
                s();
            }
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            s();
            VAR.page = 4;
        }

        private void B_back_Click(object sender, EventArgs e)
        {
            s();
            VAR.page = 2;
        }

        private void Dialog01_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit ex = new exit();
            if (ex.ShowDialog() == DialogResult.OK)
            {
                Environment.Exit(VAR.error);
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void s()
        {
            VAR.installfiles = textBox1.Text;
        }

        private void Dialog3_Load(object sender, EventArgs e)
        {
            if (skip)
            {
                textBox1.Text = Path.GetDirectoryName(VAR.installfile) + @"\";
                b_next_Click(null, null);
            }
        }
    }
}

