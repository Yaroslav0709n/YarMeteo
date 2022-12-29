using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weather
{
    public partial class SearchCity : Form
    {
        public SearchCity()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 form = new Form1();
            form.label1.Text = textBox1.Text;
            form.ShowDialog();

 
        }

        private void SearchCity_Load(object sender, EventArgs e)
        {

        }
    }
}
