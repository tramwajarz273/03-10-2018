using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Dodawanie
{
    public partial class Form1 : Form
    {
        string[] lines;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                    lines = File.ReadAllLines(openFileDialog1.FileName).ToArray();
                    foreach (string line in lines)
                        textBox1.AppendText(line+'\n');
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Form1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string number;
            foreach (string line in lines)
            { 
                number = line;
                    int n=Convert.ToInt32(number);
                    string w="";
                    while(n>0)
                    {
                        int a = n % 2;
                        string x = Convert.ToString(a);
                        w = w + x;
                        n/=2;   
                    }
                    int c = w.Length;
                    char[] b = new char[c];
                    int licznik = 0;
                    while(licznik < w.Length)
                    {
                        char d = w[w.Length-licznik-1];
                        string f = Convert.ToString(d);
                        textBox2.AppendText(f);
                        licznik += 1;
                    }
                    textBox2.AppendText(Environment.NewLine);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                    sw.Write(textBox2.Text);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Form1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hello! First you must open the file!");
            {
                textBox1.Clear();
                textBox2.Clear();
                try
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                        lines = File.ReadAllLines(openFileDialog1.FileName).ToArray();
                        foreach (string line in lines)
                            textBox1.AppendText(line + '\n');
                    }
                    else
                    {
                        MessageBox.Show("Application must be closed!", "Critical error: No file load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Convert your value into binary number!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
