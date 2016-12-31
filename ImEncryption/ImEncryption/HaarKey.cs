using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImEncryption
{
    public partial class HaarKey : Form
    {
        public HaarKey()
        {
            InitializeComponent();
        }
        public string getX
        {
            get { return textBox1.Text;}
        }
         
        public string getY
        {
            get{return textBox2.Text;}
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
