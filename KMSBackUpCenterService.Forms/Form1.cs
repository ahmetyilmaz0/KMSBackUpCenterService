using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMSBackUpCenterService.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path;
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open File";
            openFileDialog1.Filter = "All Files|*.*";
            openFileDialog1.FileName = "";
            try
            {
                openFileDialog1.InitialDirectory = "C:\\Temp";
            }
            catch
            {
                // skip it  
            }
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == "")
                return;
            else
                path = openFileDialog1.FileName;

            textBox1.Text = path;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            if (path != string.Empty)
            {
                textBox1.Text = path;
                UploadFile UploadFile = new UploadFile();
                var result = UploadFile.Upload(path, textBox4.Text, textBox3.Text, textBox2.Text);
                if (await result == "OK")
                {
                    MessageBox.Show("Created!");
                }
                else
                    MessageBox.Show("Error!");
            }
            else
                MessageBox.Show("You must select a file first.", "No File Selected!");
            splashScreenManager1.CloseWaitForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = path;
            textBox2.Text = "C:\\Users\\ahmet\\Backups\\";
            textBox4.Text = "4c0f43d2-27ee-4cee-b86b-3f4b10905362";
            textBox3.Text = "AHMET";

        }
    }
}
