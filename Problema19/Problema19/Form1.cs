using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;

namespace Problema19
{
    public partial class Form1 : Form
    {
        public ResourceManager res_man;
        public CultureInfo cul;

        public void show()
        {
            textBox1.Text = res_man.GetString("Hello", cul);
        }

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
