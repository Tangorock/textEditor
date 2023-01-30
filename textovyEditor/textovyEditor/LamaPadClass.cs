using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

/*
 * Hotové funkce:
 * OTEVŘÍT
 * NOVÝ
 * ULOŽIT
 * ULOŽIT JAKO
 * ZAROVNÁNÍ TEXTU
 * FONT, BARVA, VELIKOST TEXTU
 * SYNTAXE C#
 * SYNTAXE HTML
 * 
 * ----------------------------------------
 * 
 * TISK
 */

namespace textovyEditor
{
    class LamaPadClass
    {
        // deklarace proměnných
        public DialogResult ukladaniNovy;

        int pozice = 0;

        public string cestaSouboru = "";

        public bool ulozeno = false;

        //funkce pro načtení dat/souboru
        public void NacistData(OpenFileDialog ofd, RichTextBox tb)
        {
            ofd.Title = "Otevřít soubor";
            // filter pro vyhledávání jenom textových souborů
            ofd.Filter = "(*.txt)|*.txt|(*.rtf)|*.rtf|(*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tb.LoadFile(ofd.FileName);
                cestaSouboru = ofd.FileName;
            }
        }

        // funkce pro ukládání dat/souboru | ULOŽIT JAKO
        public void UlozitDataDialog(SaveFileDialog sfd, RichTextBox tb)
        {
            sfd.Title = "Uložit jako";
            // koncovka souboru .txt (textový soubor)
            sfd.DefaultExt = "txt";
            // filter pro ukládání jenom souboru .txt a .rtf
            sfd.Filter = "(*.txt)|*.txt|(*.rtf)|*.rtf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                tb.SaveFile(sfd.FileName);
                cestaSouboru = sfd.FileName;
                ulozeno = true;
            }
        }

        // funkce pro ukládání dat/souboru | ULOŽIT
        public void UlozitData(SaveFileDialog sfd, RichTextBox tb)
        {
            if (cestaSouboru != "")
            {
                tb.SaveFile(cestaSouboru);
                ulozeno = true;
            }
            else
            {
                sfd.Title = "Uložit jako";
                // koncovka souboru .txt (textový soubor)
                sfd.DefaultExt = "txt";
                // filter pro ukládání jenom souboru .txt a .rtf
                sfd.Filter = "(*.txt)|*.txt|(*.rtf)|*.rtf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    tb.SaveFile(sfd.FileName);
                    cestaSouboru = sfd.FileName;
                    ulozeno = true;
                }
            }
        }

        // funkce pro zvolení fontu
        public void VyberFont(FontDialog fd, RichTextBox tb)
        {
            if (fd.ShowDialog() == DialogResult.OK)
            {
                // pokud je označený nějaký text, tak změny se aplikují jenom na tento text
                if (tb.SelectedText != null)
                {
                    tb.SelectionFont = fd.Font;
                    tb.SelectionColor = fd.Color;
                }
            }
        }

        // funkce s tistku nefunguje -> 
        public void Tisk(PrintDialog pd, PrintDocument pDoc, RichTextBox tb)
        {
            pd.Document = pDoc;
            pd.AllowSelection = true;
            pd.AllowSomePages = true;

            if (pd.ShowDialog() == DialogResult.OK)
            {
                pDoc.Print();
            }
        }

        // funkce pro výběr barvy
        public void VyberBarvy(ColorDialog cd, RichTextBox tb)
        {
            if (cd.ShowDialog() == DialogResult.OK)
            {
                tb.SelectionColor = cd.Color;
            }
        }

        // funkce pro zarovnání textu doleva
        public void ZarovnatDoleva(RichTextBox tb)
        {
            if (tb.SelectedText != null)
            {
                tb.SelectionAlignment = HorizontalAlignment.Left;
            }
        }

        // funkce pro zarovnání textu na střed
        public void ZarovnatNaStred(RichTextBox tb)
        {
            if (tb.SelectedText != null)
            {
                tb.SelectionAlignment = HorizontalAlignment.Center;
            }
        }

        // funkce pro zarovnání textu doprava
        public void ZarovnatDoprava(RichTextBox tb)
        {
            if (tb.SelectedText != null)
            {
                tb.SelectionAlignment = HorizontalAlignment.Right;
            }
        }

        /*
         * vyhledávání celých slov funguje
         * nefunguje vyhledavání částí slov - např. v textu "auto je modre" hledám "ut" -> funkce zvýrazní "au" místo "ut" 
         */

        // funkce pro vyhledání textu
        public void VyhledatText(string hledatText, RichTextBox tb)
        {
            tb.SelectAll();
            tb.SelectionBackColor = Color.Transparent;
            tb.DeselectAll();

            // pozice slova vždy začíná na nule (začátek textu)
            pozice = 0;
            // do pole textArr se po provedení funkce Split vloží všechna slova z richTextBoxu 
            string[] textArr = tb.Text.Split(new string[] { " ", "\n", "\t" }, StringSplitOptions.None);

            for (int i = 0; i < textArr.Length; i++)
            {
                // pokud hledané slovo (text) se nachází v poli textArr (=> nachází se v richTextBoxu)
                if (textArr[i].IndexOf(hledatText) >= 0)
                {
                    // označení textu začíná na pozici (začátek slova)
                    tb.SelectionStart = pozice;
                    // označení je dlouhé, tak jak je dlouhé slovo (délka slova)
                    tb.SelectionLength = hledatText.Length;
                    // pro lepší orientaci v textu se hledané slovo zvýrazní tak, že se pozadí slova změní na žluto
                    tb.SelectionBackColor = Color.Yellow;
                    // hledáný text v richTextBoxu se zamění na zvýraznění text
                    tb.SelectedText.Replace(hledatText, tb.SelectedText);
                    // všechen text se ododznačí pro další práci
                    tb.DeselectAll();
                }
                // přičítání pozice podle délky slova + mezera
                pozice += textArr[i].Length + 1;
            }
        }

        // funckce k nazhrazení textu
        public void NahraditText(string hledatText, string nahraditText, RichTextBox tb)
        {
            int hledanaSlova = 0;

            pozice = 0;
            string[] textArr = tb.Text.Split(new string[] { " ", "\n", "\t" }, StringSplitOptions.None);

            for (int i = 0; i < textArr.Length; i++)
            {
                if (textArr[i].IndexOf(hledatText) >= 0) hledanaSlova++;
            }

            // když je v textu více mež 1 slovo, které chceme změnit
            if (hledanaSlova > 1)
            {
                tb.SelectionStart = pozice;
                tb.SelectionLength = hledatText.Length;

                tb.Text = tb.Text.Replace(tb.SelectedText, nahraditText);

                for (int i = 0; i < textArr.Length; i++)
                {
                    if (textArr[i].IndexOf(hledatText) >= 0)
                    {
                        tb.SelectionStart = pozice;
                        tb.SelectionLength = nahraditText.Length;
                        tb.SelectionBackColor = Color.YellowGreen;

                        tb.DeselectAll();
                    }
                    // přičítání pozice podle délky slova + mezera
                    pozice += textArr[i].Length + 1;
                }
            }
            else
            {
                for (int i = 0; i < textArr.Length; i++)
                {
                    if (textArr[i].IndexOf(hledatText) >= 0)
                    {
                        tb.SelectionStart = pozice;
                        tb.SelectionLength = hledatText.Length;

                        tb.Text = tb.Text.Replace(tb.SelectedText, nahraditText);

                        tb.SelectionStart = pozice;
                        tb.SelectionLength = nahraditText.Length;
                        tb.SelectionBackColor = Color.YellowGreen;

                        tb.DeselectAll();
                    }
                    // přičítání pozice podle délky slova + mezera
                    pozice += textArr[i].Length + 1;
                }
            }
        }

        /*
         * Zvýraznění syntaxe funguje, ale funkce potřebuje předělat
         * když přidám do pole tag <a> a potom v podmínce budu konrolovat, zda textArr[i] == "a" -> tak se zvýrazní i text mimo tag.
         */

        // fukce pro syntaxi jazyka HTML
        public void JazykHTLM(RichTextBox tb)
        {
            // před zvýrazněním do syntaxe jazyka HTML, odzvýraznit všechen text
            tb.SelectAll();
            tb.SelectionColor = Color.Black;
            tb.DeselectAll();

            pozice = 0;

            bool prvniTag = false;

            string[] textArr = tb.Text.Split(new string[] { " ", "\n", "\t", "<", ">", "/"}, StringSplitOptions.None);
            string[] tagy = { "html", "body", "h", "p", "img" };

            for (int i = 0; i < textArr.Length; i++)
            {
                for (int j = 0; j < tagy.Length; j++)
                {
                    if (tagy[j] == textArr[i])
                    {
                        if (textArr[i].IndexOf(tagy[j]) >= 0)
                        {
                            if (textArr[i] == "html" || textArr[i] == "body" || textArr[i] == "h" || textArr[i] == "p" || textArr[i] == "img")
                            {
                                if (prvniTag == false)
                                {
                                    tb.SelectionStart = pozice - 1;
                                    tb.SelectionLength = tagy[j].Length + 2;
                                    prvniTag = true;
                                }
                                else
                                {
                                    tb.SelectionStart = pozice - 2;
                                    tb.SelectionLength = tagy[j].Length + 3;
                                }
                                
                                tb.SelectionColor = Color.Red;
                                tb.SelectedText.Replace(textArr[i], tb.SelectedText);
                                tb.DeselectAll();
                            }
                        }
                    }
                }
                //přičítání pozice podle délky slova + mezera
                pozice += textArr[i].Length + 1;
            }
        }

        // funkce pro syntaxi jazyka C#
        //
        // jak vyhledávání funguje, je popsáno ve funkci VyhledatText();
        public void JazykCsharp(RichTextBox tb)
        {
            // před zvýrazněním do syntaxe jazyka C#, odzvýraznit všechen text
            tb.SelectAll();
            tb.SelectionColor = Color.Black;
            tb.DeselectAll();

            pozice = 0;

            string[] textArr = tb.Text.Split(new string[] { " ", "\n", "\t", "(", ")", "[", "]", "{", "}" }, StringSplitOptions.None);
            string[] znaky = { "namespace", "if", "else", "for", "foreach", "switch", "break", "default", "public", "private", "void", "string", "bool", "int", "char" };

            for (int i = 0; i < textArr.Length; i++)
            {
                for (int j = 0; j < znaky.Length; j++)
                {
                    if (znaky[j] == textArr[i])
                    {
                        if (textArr[i].IndexOf(znaky[j]) >= 0)
                        {
                            if (textArr[i].Contains("namespace"))
                            {
                                tb.SelectionStart = pozice;
                                tb.SelectionLength = znaky[j].Length;
                                tb.SelectionColor = Color.LightBlue;
                                tb.SelectedText.Replace(textArr[i], tb.SelectedText);
                                tb.DeselectAll();
                            }
                            else if (textArr[i] == "if" || textArr[i] == "else" || textArr[i] == "for" || textArr[i] == "foreach" || textArr[i] == "switch" || textArr[i] == "break" || textArr[i] == "default")
                            {
                                tb.SelectionStart = pozice;
                                tb.SelectionLength = znaky[j].Length;
                                tb.SelectionColor = Color.FromArgb(118, 98, 164);
                                tb.SelectedText.Replace(textArr[i], tb.SelectedText);
                                tb.DeselectAll();
                            }
                            else if (textArr[i] == "public" || textArr[i] == "private" || textArr[i] == "void")
                            {
                                tb.SelectionStart = pozice;
                                tb.SelectionLength = znaky[j].Length;
                                tb.SelectionColor = Color.FromArgb(66, 150, 205);
                                tb.SelectedText.Replace(textArr[i], tb.SelectedText);
                                tb.DeselectAll();
                            }
                            else if (textArr[i] == "string" || textArr[i] == "bool" || textArr[i] == "int" || textArr[i] == "char")
                            {
                                tb.SelectionStart = pozice;
                                tb.SelectionLength = znaky[j].Length;
                                tb.SelectionColor = Color.FromArgb(30, 77, 167);
                                tb.SelectedText.Replace(textArr[i], tb.SelectedText);
                                tb.DeselectAll();
                            }
                        }
                    }
                }
                // přičítání pozice podle délky slova + mezera
                pozice += textArr[i].Length + 1;
            }
        }
    }
}
