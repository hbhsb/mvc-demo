using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.International.Converters.PinYinConverter;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ChineseChar chinese=new ChineseChar(textBox1.Text[0]);
            var pinyin = chinese.Pinyins;
            foreach (string s in pinyin)
            {
                textBox2.Text += s + " ";
            }
        }
    }
}
