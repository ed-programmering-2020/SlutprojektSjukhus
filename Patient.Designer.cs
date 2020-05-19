namespace Sjukhus
{
    partial class Patient
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
            this.btnVisaLäkartid = new System.Windows.Forms.Button();
            this.tbxLäkarTid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBokaTid = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRingAmbulans = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxIPAdress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnVisaLäkartid
            // 
            this.btnVisaLäkartid.Location = new System.Drawing.Point(62, 111);
            this.btnVisaLäkartid.Name = "btnVisaLäkartid";
            this.btnVisaLäkartid.Size = new System.Drawing.Size(110, 30);
            this.btnVisaLäkartid.TabIndex = 0;
            this.btnVisaLäkartid.Text = "Visa Läkartid";
            this.btnVisaLäkartid.UseVisualStyleBackColor = true;
            this.btnVisaLäkartid.Click += new System.EventHandler(this.btnVisaLäkartid_Click);
            // 
            // tbxLäkarTid
            // 
            this.tbxLäkarTid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLäkarTid.Location = new System.Drawing.Point(45, 83);
            this.tbxLäkarTid.Name = "tbxLäkarTid";
            this.tbxLäkarTid.ShortcutsEnabled = false;
            this.tbxLäkarTid.Size = new System.Drawing.Size(156, 22);
            this.tbxLäkarTid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Redan bokad läkartid";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Boka läkartid";
            // 
            // btnBokaTid
            // 
            this.btnBokaTid.Location = new System.Drawing.Point(62, 226);
            this.btnBokaTid.Name = "btnBokaTid";
            this.btnBokaTid.Size = new System.Drawing.Size(110, 30);
            this.btnBokaTid.TabIndex = 4;
            this.btnBokaTid.Text = "Boka";
            this.btnBokaTid.UseVisualStyleBackColor = true;
            this.btnBokaTid.Click += new System.EventHandler(this.btnBokaTid_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(252, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Akut Ambulans";
            // 
            // btnRingAmbulans
            // 
            this.btnRingAmbulans.Location = new System.Drawing.Point(239, 165);
            this.btnRingAmbulans.Name = "btnRingAmbulans";
            this.btnRingAmbulans.Size = new System.Drawing.Size(86, 32);
            this.btnRingAmbulans.TabIndex = 6;
            this.btnRingAmbulans.Text = "Ring Ambulans";
            this.btnRingAmbulans.UseVisualStyleBackColor = true;
            this.btnRingAmbulans.Click += new System.EventHandler(this.btnRingAmbulans_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(331, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Status...";
            // 
            // tbxIPAdress
            // 
            this.tbxIPAdress.Location = new System.Drawing.Point(239, 212);
            this.tbxIPAdress.Name = "tbxIPAdress";
            this.tbxIPAdress.Size = new System.Drawing.Size(100, 20);
            this.tbxIPAdress.TabIndex = 8;
            // 
            // Patient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 321);
            this.Controls.Add(this.tbxIPAdress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRingAmbulans);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBokaTid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxLäkarTid);
            this.Controls.Add(this.btnVisaLäkartid);
            this.Name = "Patient";
            this.Text = "Patient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVisaLäkartid;
        private System.Windows.Forms.TextBox tbxLäkarTid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBokaTid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRingAmbulans;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxIPAdress;
    }
}