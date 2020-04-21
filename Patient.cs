using System;
using System.Windows.Forms;

namespace Sjukhus
{
    public partial class Patient : Form
    {
        private int personnummer;
        public Patient()
        {
            InitializeComponent();
        }

        private void btnVisaLäkartid_Click(object sender, EventArgs e)
        {
            try
            {
                personnummer = Int32.Parse(tbxLäkarTid.Text);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                MessageBox.Show("Du skrev in ett ogiltligt personnummer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tbxLäkarTid.Text = "";
            VisaBokning visaBokning = new VisaBokning();
            visaBokning.ShowDialog();
        }

        private void btnBokaTid_Click(object sender, EventArgs e)
        {
            Boka boka = new Boka();
            boka.ShowDialog();
        }

        private void btnRingAmbulans_Click(object sender, EventArgs e)
        {

        }
    }
}
