using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Text;
using System.Linq;

namespace Sjukhus
{
    public partial class Admin : Form
    {
        List<bokningar> AllaBokningar = new List<bokningar>();
        List<patienter> AllaPatienter = new List<patienter>();

        string connectionString = "SERVER=5.178.75.122;DATABASE=sjukhusdb;UID=linus;PASSWORD=LinusT;";
        TcpClient client = new TcpClient();

        TcpListener lyssnare;
        int port = 12345;

        public Admin()
        {
            InitializeComponent();
            StartaServer();
            UpdateLists();
        }

        private void StartaServer()
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

            StartaMottagning();
        }

        public async void StartaMottagning()
        {
            TcpClient klient;

            try
            {
                klient = await lyssnare.AcceptTcpClientAsync();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, Text);
                return;
            }

            AmbulansInväntan(klient);
            StartaMottagning();
        }

        private async void AmbulansInväntan(TcpClient k)
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

            if (Encoding.Unicode.GetString(buffert, 0, n) == "Ambulans")
            {

                Debug.WriteLine(k.ToString());
                label4.Text = "Inväntande...";
                label4.ForeColor = Color.FromArgb(0, 255, 255);
                btnSkickaAmbulans.Enabled = true;
                k.Close();
            }
            else
            {
                Debug.WriteLine(k.ToString());
                label4.Text = "Ogiltlig anslutning!";
                label4.ForeColor = Color.FromArgb(255, 0, 0);
                lyssnare.Stop();
                k.Close();
            }
        }

        private async void StartaSändning()
        {
            string ambulans = comboBox1.Text;
            byte[] utData = new byte[1024];
            utData = Encoding.Unicode.GetBytes(ambulans);

            try
            {
                await client.GetStream().WriteAsync(utData, 0, utData.Length);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, Text);
                client.Close();
                return;
            }
        }

        private void btnSkickaAmbulans_Click(object sender, EventArgs e)
        {
            StartaSändning();

            label4.Text = "Skickad!";
            label4.ForeColor = Color.FromArgb(0, 255, 0);
            StartaMottagning();
        }
        private void HämtaPatienter()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand cmd = patienter.getAll();  //statisk metod
            MySqlDataAdapter datAdapt = new MySqlDataAdapter();
            datAdapt.SelectCommand = cmd;
            cmd.Connection = connection;
            DataTable dt = new DataTable();
            datAdapt.Fill(dt);

            AllaPatienter.Clear();
            foreach (DataRow row in dt.Rows)
            {
                AllaPatienter.Add(new patienter(row));
            }

            connection.Close();

            listBox1.Items.Clear();
            for (int i = 0; i < AllaPatienter.Count; i++)
            {
                listBox1.Items.Add(AllaPatienter[i]);
            }
            // listBox1.DataSource = AllaPatienter;

        }

        private void HämtaBokningar()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand cmd = bokningar.getAll();  //statisk metod
            MySqlDataAdapter datAdapt = new MySqlDataAdapter();
            datAdapt.SelectCommand = cmd;
            cmd.Connection = connection;
            DataTable dt = new DataTable();
            datAdapt.Fill(dt);

            AllaBokningar.Clear();
            foreach (DataRow row in dt.Rows)
            {
                AllaBokningar.Add(new bokningar(row));
            }

            connection.Close();

            listBox2.Items.Clear();
            for (int i = 0; i < AllaBokningar.Count; i++)
            {
                listBox2.Items.Add(AllaBokningar[i]);
            }
            // listBox2.DataSource = AllaBokningar;
        }

        public void UpdateLists()
        {
            // Updatera Datasource för båda listorna
            HämtaPatienter();
            HämtaBokningar();
            
            
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            // MessageBox.Show(listBox1.SelectedItem.ToString());

            AdminTilldelaPatient adminTilldelaPatient = new AdminTilldelaPatient(AllaPatienter[listBox1.SelectedIndex]);
            adminTilldelaPatient.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateLists();
        }
    }
}
