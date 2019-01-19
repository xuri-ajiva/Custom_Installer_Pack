using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIO;

namespace Creator
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Update.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string part;
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                part = f.SelectedPath;
                try
                {
                    foreach (var fn in Directory.GetFiles(part, "*.*", SearchOption.AllDirectories))
                    {
                        listBox1.Items.Add("." + fn.Substring(part.Length));
                    }
                }
                catch
                {
                    Console.WriteLine("Error");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            listBox1.Width = (groupBox1.Width / 2) - 15;
            listBox2.Width = (groupBox1.Width / 2) - 15;
            button5.Location = new Point(groupBox2.Location.X + groupBox2.Width / 2 - button5.Width / 2, groupBox2.Location.Y + groupBox2.Height / 2 - button5.Height / 2);
            //listBox2.Items.Add(button5.Location.X + "    " + button5.Location.Y);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            foreach ( var z in listBox1.Items)
            {
                listBox2.Items.Add(z);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string part;
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                part = f.SelectedPath;
                try
                {
                    foreach (var fn in Directory.GetFiles(part, "*.*", SearchOption.AllDirectories))
                    {
                        listBox2.Items.Add("." + fn.Substring(part.Length));
                    }
                }
                catch
                {
                    Console.WriteLine("Error");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string[] x= new string[listBox2.Items.Count];
            for (int i = 0; i< listBox2.Items.Count;i++)
            {
                x[i] = listBox2.Items[i].ToString();
            }
            listBox2.Items.Clear();
            foreach (var z in x)
            { 
                listBox2.Items.Add(textBox1.Text + z);
            }
        }
        string t1;
        string t5;

        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random(); 
            textBox5.Text = ("Random Name: " + r.NextDouble()).Replace('\\','-').Replace('/', '-').Replace(':', '-').Replace('*', '-').Replace('?', '-').Replace('<', '-').Replace('>', '-').Replace('|', '-');
            t1 = textBox2.Text;
            t5 = textBox5.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != t1 && textBox5.Text !=t5)
            {
                string[] x = new string[99999];
                for (int i = VAR.interduction; i < ((listBox1.Items.Count >= listBox2.Items.Count) ? listBox1.Items.Count : listBox2.Items.Count); i++)
                {
                    x[i] = "#" + listBox1.Items[i] + ">" + listBox2.Items[i];
                }
                x[0] = "#" + textBox2.Text;
                x[1] = "#" + textBox3.Text;
                x[2] = "#" + textBox4.Text;
                x[3] = "#" + textBox5.Text.Replace('\\', '-').Replace('/', '-').Replace(':', '-').Replace('*', '-').Replace('?', '-').Replace('<', '-').Replace('>', '-').Replace('|', '-');
                x[4] = "#" + (checkBox1.Checked ? "this" : "null");
                x[5] = "#";

                SaveFileDialog s = new SaveFileDialog
                {
                    Filter = "Installationsanversung(*.inst) | *.inst"
                };
                if (s.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllLines(s.FileName, x);
                }
            }
            else
                MessageBox.Show("Bitte einen eigenen Namen und eine andere beschreibung wählen Wählen!","Error",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            
        }
    }
}
