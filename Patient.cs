using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Sjukhus
{
    public partial class Patient : Form
    {
        TcpClient klient = new TcpClient();
        int port = 12345;

        private int personnummer;
        public Patient()
        {
            InitializeComponent();
            StartaAnslutning();
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

        private async void StartaAnslutning()
        {
            try
            {
                IPAddress adress = IPAddress.Parse(tbxIPAdress.Text);
                await klient.ConnectAsync(adress, port);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, Text);
                return;
            }
        }

        private void btnRingAmbulans_Click(object sender, EventArgs e)
        {

        }
    }
}
