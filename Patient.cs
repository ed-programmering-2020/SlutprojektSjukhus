using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Sjukhus
{
    public partial class Patient : Form
    {
        TcpClient klient = new TcpClient();
        TcpListener lyssnare;
        int port = 12345;

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
                MessageBox.Show("Du skrev in ogiltlig PatientID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbxLäkarTid.Text = "";
                return;
            }
            tbxLäkarTid.Text = "";
            VisaBokning visaBokning = new VisaBokning(personnummer);
            visaBokning.ShowDialog();
        }

        private void btnBokaTid_Click(object sender, EventArgs e)
        {
            Boka boka = new Boka();
            boka.ShowDialog();
        }

        public async void StartaAnslutning()
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
            label4.Text = "Ansluten till sjukhuset!";
            label4.ForeColor = Color.FromArgb(0, 255, 255);
            btnRingAmbulans.Enabled = true;
        }

        public async void StartaSändning(string input)
        {
            byte[] utData = Encoding.Unicode.GetBytes(input);

            try
            {
                await klient.GetStream().WriteAsync(utData, 0, utData.Length);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, Text);
                return;
            }
            // klient.Close();
            label4.Text = "Ambulans föfrågan har skickats!";
            label4.ForeColor = Color.FromArgb(255, 255, 0);
            StartaServer(klient);
        }

        private void StartaServer(TcpClient k)
        {
            try
            {
                lyssnare = new TcpListener(IPAddress.Any, port);
                lyssnare.Start();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, Text);
                return;
            }

            StartaMottagning(k);
        }
        
        private async void StartaMottagning(TcpClient k)
        {
            byte[] buffert = new byte[1024];

            int n;
            try
            {
                n = await k.GetStream().ReadAsync(buffert, 0, buffert.Length);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, Text);
                return;
            }
            label4.Text = Encoding.Unicode.GetString(buffert, 0, n) + " har skickats!";
            label4.ForeColor = Color.FromArgb(0, 255, 0);
            k.Close();
            lyssnare.Stop();
        }

        private void btnRingAmbulans_Click(object sender, EventArgs e)
        {
            StartaSändning("Ambulans");
        }

        private void btnAnslut_Click(object sender, EventArgs e)
        {
            btnAnslut.Enabled = false;
            label4.Text = "Ansluter..";
            label4.ForeColor = Color.FromArgb(255, 255, 0);
            StartaAnslutning();
        }
    }
}
