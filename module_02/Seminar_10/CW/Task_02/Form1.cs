using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonShow.Visible = false;
        }
        string[] lines = { "один", "два", "три", "четыре", "пять" };

        private void buttonInit_Click(object sender, EventArgs e)
        {
            textBox1.Lines = lines;
            buttonShow.Visible = true;
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            string res = string.Join(" ", textBox1.Lines);
            MessageBox.Show($"Результат изменений:\r\n{res}");
        }
    }
}
