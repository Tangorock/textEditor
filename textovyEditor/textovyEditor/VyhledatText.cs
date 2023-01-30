using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textovyEditor
{
    public partial class VyhledatText : Form
    {
        public RichTextBox rtb;
        public VyhledatText()
        {
            InitializeComponent();
        }

        // vytvoření instance třídy LamaPadClass
        LamaPadClass lamaPad = new LamaPadClass();

        // funkce čistě pro hledání v textu
        private void button_hledej_Click(object sender, EventArgs e)
        {
            lamaPad.VyhledatText(richTextBox_hledej.Text, rtb);
        }

        // funkce, která nahradí vyhledaný text
        private void button_nahradit_Click(object sender, EventArgs e)
        {
            lamaPad.NahraditText(richTextBox_hledej.Text, richTextBox_nahradit.Text, rtb);   
        }

        // při zavření okna, se všechno zvýraznění textu zruší
        private void VyhledatText_FormClosing(object sender, FormClosingEventArgs e)
        {
            rtb.SelectAll();
            rtb.SelectionBackColor = Color.Transparent;
            rtb.DeselectAll();
        }
    }
}
