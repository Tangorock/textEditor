namespace textovyEditor
{
    partial class VyhledatText
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VyhledatText));
            this.richTextBox_hledej = new System.Windows.Forms.RichTextBox();
            this.button_hledej = new System.Windows.Forms.Button();
            this.button_nahradit = new System.Windows.Forms.Button();
            this.label_pocetNalezeni = new System.Windows.Forms.Label();
            this.richTextBox_nahradit = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox_hledej
            // 
            this.richTextBox_hledej.Location = new System.Drawing.Point(12, 27);
            this.richTextBox_hledej.Name = "richTextBox_hledej";
            this.richTextBox_hledej.Size = new System.Drawing.Size(259, 25);
            this.richTextBox_hledej.TabIndex = 0;
            this.richTextBox_hledej.Text = "";
            // 
            // button_hledej
            // 
            this.button_hledej.Location = new System.Drawing.Point(12, 58);
            this.button_hledej.Name = "button_hledej";
            this.button_hledej.Size = new System.Drawing.Size(259, 23);
            this.button_hledej.TabIndex = 1;
            this.button_hledej.Text = "Hledat";
            this.button_hledej.UseVisualStyleBackColor = true;
            this.button_hledej.Click += new System.EventHandler(this.button_hledej_Click);
            // 
            // button_nahradit
            // 
            this.button_nahradit.Location = new System.Drawing.Point(8, 176);
            this.button_nahradit.Name = "button_nahradit";
            this.button_nahradit.Size = new System.Drawing.Size(259, 23);
            this.button_nahradit.TabIndex = 2;
            this.button_nahradit.Text = "Nahradit";
            this.button_nahradit.UseVisualStyleBackColor = true;
            this.button_nahradit.Click += new System.EventHandler(this.button_nahradit_Click);
            // 
            // label_pocetNalezeni
            // 
            this.label_pocetNalezeni.AutoSize = true;
            this.label_pocetNalezeni.Location = new System.Drawing.Point(323, 13);
            this.label_pocetNalezeni.Name = "label_pocetNalezeni";
            this.label_pocetNalezeni.Size = new System.Drawing.Size(0, 13);
            this.label_pocetNalezeni.TabIndex = 4;
            // 
            // richTextBox_nahradit
            // 
            this.richTextBox_nahradit.Location = new System.Drawing.Point(9, 145);
            this.richTextBox_nahradit.Name = "richTextBox_nahradit";
            this.richTextBox_nahradit.Size = new System.Drawing.Size(259, 25);
            this.richTextBox_nahradit.TabIndex = 5;
            this.richTextBox_nahradit.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Hledej slovo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nahraď hledané slovo:";
            // 
            // VyhledatText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 205);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox_nahradit);
            this.Controls.Add(this.label_pocetNalezeni);
            this.Controls.Add(this.button_nahradit);
            this.Controls.Add(this.button_hledej);
            this.Controls.Add(this.richTextBox_hledej);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VyhledatText";
            this.Text = "Vyhledat Text";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VyhledatText_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_hledej;
        private System.Windows.Forms.Button button_hledej;
        private System.Windows.Forms.Button button_nahradit;
        private System.Windows.Forms.Label label_pocetNalezeni;
        private System.Windows.Forms.RichTextBox richTextBox_nahradit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}