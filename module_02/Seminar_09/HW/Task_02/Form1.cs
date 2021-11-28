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
        private string[] _nums = new string[] { "один", "два", "три", "четыре", "пять", "шесть", "семь" };
        public Form1()
        {
            InitializeComponent();
            info.Items.AddRange(_nums);            
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (info.SelectedIndex == -1)
            {
                MessageBox.Show("Список пуст или\nнет выделенного элемента!");
                return;
            }
            info.Items.RemoveAt(info.SelectedIndex);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            info.Items.Clear();
            info.Items.AddRange(_nums);
        }
    }
}
