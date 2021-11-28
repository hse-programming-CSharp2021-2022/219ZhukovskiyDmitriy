using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StringBuilder sb = new();
        int p = 0;
        int k = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (p == 0)
            {
                sb.Append(label1.Text);
                p++;
            }
            if (sb.Length > 0)
                sb.Remove(sb.Length - 1, 1);
            label1.Text = sb.ToString();
            if (sb.Length == 0 && k < 10)
            {
                Opacity = Opacity - 0.1;
                k++;
            }
            if (Opacity < 1 && k == 10)
            {
                Form1_Load(sender, e);
            }
            if (Opacity == 1 && k == 10)
            {
                label1.Text = "Кот уже ушел!";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Opacity = Opacity + 0.2;


        }
    }
}