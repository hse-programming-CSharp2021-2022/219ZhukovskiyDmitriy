using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_03
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Rate rate = new();
        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Visible = !button1.Visible;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = rate.Hits++.ToString();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            label2.Text = rate.Fails++.ToString();
        }
    }
}
