using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog1;
        string filename;
        Thread thread;
        public Form1()
        {
            InitializeComponent();
            openFileDialog1=new OpenFileDialog();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            thread = new Thread(Worker);
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            filename = openFileDialog1.FileName;
            label1.Text = openFileDialog1.FileName;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // thread.Start();
            Thread myThread = new Thread(Worker); //Создаем новый объект потока (Thread)
            myThread.Start(); //запускаем поток
        }
        private void Worker()
        {
            string str = textBox1.Text;
            
             textBox2.Text = " ";
            foreach (string s in System.IO.File.ReadAllLines(filename))
            {
                if (s == str)
                {
                    foreach (char c in s)
                    {
                        
                        textBox2.Text += c + " ";
                    }
                }
            }
        }
    }
}
