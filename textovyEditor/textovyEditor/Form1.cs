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
    public partial class Form1_LamaPad : Form
    {
        public Form1_LamaPad()
        {
            InitializeComponent();
        }

        // vytvoření instance třídy LamaPadClass
        LamaPadClass lamaPad = new LamaPadClass();

        private void novýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text != "" && lamaPad.ulozeno == false)
            {
                // pokud vytvářím nový soubor a aktuální soubor není uložen, uživatel má možnost uložit aktuální soubor
                lamaPad.ukladaniNovy = MessageBox.Show("Soubor není uložen, chcete ho uložit?", "SOUBOR NEULOŽEN", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                // soubor se uloží
                if (lamaPad.ukladaniNovy == DialogResult.Yes)
                {
                    if (lamaPad.ulozeno == false && lamaPad.cestaSouboru == "")
                    {
                        lamaPad.UlozitDataDialog(saveFileDialog1, richTextBox1);
                        lamaPad.ulozeno = true;
                    }
                    else
                    {
                        lamaPad.UlozitData(saveFileDialog1, richTextBox1);
                    }
                }
                // soubor se neuloží
                else if (lamaPad.ukladaniNovy == DialogResult.No) richTextBox1.Clear();
            }
            else if(richTextBox1.Text == "" && lamaPad.ulozeno == false)
            {
                richTextBox1.Clear();
                lamaPad.ulozeno = false;
            }
            else if (richTextBox1.Text != "" && lamaPad.ulozeno == true)
            {
                richTextBox1.Clear();
                lamaPad.ulozeno = false;
            }
        }

        private void otevřítToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // zavolání funkce pro načtení dat/souborů
            lamaPad.NacistData(openFileDialog1, richTextBox1);
        }

        // funkce pro tist souboru/dokumentu
        private void tiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lamaPad.Tisk(printDialog1, printDocument1,richTextBox1);
        }

        // ULOŽIT JAKO
        private void uložitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // zavolání funkce pro uložení dat/souborů
            lamaPad.UlozitDataDialog(saveFileDialog1, richTextBox1);
        }

        // ULOŽIT
        private void uložitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lamaPad.UlozitData(saveFileDialog1, richTextBox1);
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // zavolání funkce pro výběr fontu
            lamaPad.VyberFont(fontDialog1, richTextBox1);
        }

        private void barvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // zavolání funkce pro výběr barvy
            lamaPad.VyberBarvy(colorDialog1, richTextBox1);
        }

        // zobrazení nového onka - Info 
        private void nápovědaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInfo formInfo = new FormInfo();
            formInfo.ShowDialog();
        }

        // zobrazení okna pro vyhledání textu
        private void vyhledatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VyhledatText formVyhledatText = new VyhledatText();
            formVyhledatText.rtb = richTextBox1;
            formVyhledatText.Show();
        }

        private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lamaPad.JazykHTLM(richTextBox1);
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lamaPad.JazykCsharp(richTextBox1);
        }

        // zarovnání textu doleva
        private void dolevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lamaPad.ZarovnatDoleva(richTextBox1);
        }

        // zarovnání textu na střed
        private void naStředToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lamaPad.ZarovnatNaStred(richTextBox1);
        }

        // zarovnání textu doprava
        private void dopravaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lamaPad.ZarovnatDoprava(richTextBox1);
        }

        private void Form1_LamaPad_FormClosing(object sender, FormClosingEventArgs e)
        {
            lamaPad.cestaSouboru = "";

            if (richTextBox1.Text != "" && lamaPad.ulozeno == false)
            {
                // pokud vytvářím nový soubor a aktuální soubor není uložen, uživatel má možnost uložit aktuální soubor
                lamaPad.ukladaniNovy = MessageBox.Show("Soubor není uložen, chcete ho uložit?", "SOUBOR NEULOŽEN", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);


                // soubor se uloží
                if (lamaPad.ukladaniNovy == DialogResult.Yes)
                {
                    if (lamaPad.ulozeno == false && lamaPad.cestaSouboru == "")
                    {
                        lamaPad.UlozitDataDialog(saveFileDialog1, richTextBox1);
                        lamaPad.ulozeno = true;
                    }
                    else
                    {
                        lamaPad.UlozitData(saveFileDialog1, richTextBox1);
                    }
                }
                // soubor se neuloží
                else if (lamaPad.ukladaniNovy == DialogResult.No) richTextBox1.Clear();

                else if (lamaPad.ukladaniNovy == DialogResult.Cancel) e.Cancel = true;
            }
            else if (richTextBox1.Text == "" && lamaPad.ulozeno == false)
            {
                richTextBox1.Clear();
                lamaPad.ulozeno = false;
            }
            else if (richTextBox1.Text != "" && lamaPad.ulozeno == true)
            {
                richTextBox1.Clear();
                lamaPad.ulozeno = false;
            }
        }

        private void Form1_LamaPad_Load(object sender, EventArgs e)
        {
            richTextBox1.Focus();
            lamaPad.cestaSouboru = "";
            lamaPad.ulozeno = false;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            lamaPad.ulozeno = false;
        }
    }
}
