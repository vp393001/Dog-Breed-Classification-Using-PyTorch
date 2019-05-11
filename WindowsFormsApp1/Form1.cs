using Python.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command = @"C:\ProgramData\Anaconda3\python.exe ~\predict.py --path " + textBox1.Text;
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c" + command);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            Process p = new Process();
            p.StartInfo = procStartInfo;
            p.Start();
            string predicted_label = p.StandardOutput.ReadToEnd();
            label1.Text = predicted_label;

            pictureBox1.Image = Image.FromFile(textBox1.Text);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String path = null;
            openFileDialog1.InitialDirectory = @"v:\";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
            }

            string command = @"C:\ProgramData\Anaconda3\python.exe C:\Users\vp393001\Downloads\predict.py --path " + path;
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c" + command);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            Process p = new Process();
            p.StartInfo = procStartInfo;
            p.Start();
            string predicted_label = p.StandardOutput.ReadToEnd();
            label1.Text = predicted_label;

            pictureBox1.Image = Image.FromFile(path);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
