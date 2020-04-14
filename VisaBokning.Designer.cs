namespace Sjukhus
{
    partial class VisaBokning
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxTelefon = new System.Windows.Forms.TextBox();
            this.tbxAdress = new System.Windows.Forms.TextBox();
            this.tbxPersonnummer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxEfternamn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxNamn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BokadeTider = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(22, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Telefonnummer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(22, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Adress";
            // 
            // tbxTelefon
            // 
            this.tbxTelefon.Location = new System.Drawing.Point(150, 190);
            this.tbxTelefon.Name = "tbxTelefon";
            this.tbxTelefon.ReadOnly = true;
            this.tbxTelefon.Size = new System.Drawing.Size(100, 20);
            this.tbxTelefon.TabIndex = 17;
            // 
            // tbxAdress
            // 
            this.tbxAdress.Location = new System.Drawing.Point(150, 150);
            this.tbxAdress.Name = "tbxAdress";
            this.tbxAdress.ReadOnly = true;
            this.tbxAdress.Size = new System.Drawing.Size(100, 20);
            this.tbxAdress.TabIndex = 16;
            // 
            // tbxPersonnummer
            // 
            this.tbxPersonnummer.Location = new System.Drawing.Point(150, 110);
            this.tbxPersonnummer.Name = "tbxPersonnummer";
            this.tbxPersonnummer.ReadOnly = true;
            this.tbxPersonnummer.Size = new System.Drawing.Size(100, 20);
            this.tbxPersonnummer.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(22, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Personnummer";
            // 
            // tbxEfternamn
            // 
            this.tbxEfternamn.Location = new System.Drawing.Point(150, 70);
            this.tbxEfternamn.Name = "tbxEfternamn";
            this.tbxEfternamn.ReadOnly = true;
            this.tbxEfternamn.Size = new System.Drawing.Size(100, 20);
            this.tbxEfternamn.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(22, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Efternamn";
            // 
            // tbxNamn
            // 
            this.tbxNamn.Location = new System.Drawing.Point(150, 30);
            this.tbxNamn.Name = "tbxNamn";
            this.tbxNamn.ReadOnly = true;
            this.tbxNamn.Size = new System.Drawing.Size(100, 20);
            this.tbxNamn.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Namn";
            // 
            // BokadeTider
            // 
            this.BokadeTider.FormattingEnabled = true;
            this.BokadeTider.Location = new System.Drawing.Point(300, 36);
            this.BokadeTider.Name = "BokadeTider";
            this.BokadeTider.Size = new System.Drawing.Size(260, 173);
            this.BokadeTider.TabIndex = 20;
            // 
            // VisaBokning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 264);
            this.Controls.Add(this.BokadeTider);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxTelefon);
            this.Controls.Add(this.tbxAdress);
            this.Controls.Add(this.tbxPersonnummer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxEfternamn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxNamn);
            this.Controls.Add(this.label1);
            this.Name = "VisaBokning";
            this.Text = "Visa Bokning";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxTelefon;
        private System.Windows.Forms.TextBox tbxAdress;
        private System.Windows.Forms.TextBox tbxPersonnummer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxEfternamn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxNamn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox BokadeTider;
    }
}