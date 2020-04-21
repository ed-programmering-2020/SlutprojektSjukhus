using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Sjukhus
{
    public partial class Admin : Form
    {
        List<string> läkare = new List<string>();
        List<string> patienter = new List<string>();

        MySqlConnection connection;
        string connectionString = "SERVER=localhost;DATABASE=sjukhus;" + "UID=user_sjukhus;PASSWORD=password;";


        TcpListener lyssnare;
        int port = 12345;

        public Admin()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
            StartaServer();
            HämtaLäkare();
            HämtaPatienter();
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

        private void AmbulansInväntan(TcpClient k)
        {
            Debug.WriteLine(k.ToString());
            btnSkickaAmbulans.Enabled = true;
        }

        private void btnSkickaAmbulans_Click(object sender, EventArgs e)
        {

        }

        private void HämtaLäkare()
        {
            HämtaTabell("läkare", läkare);
            for(int i = 0; i < läkare.Count; i++)
            {
                listBox1.Items.Add(läkare[i]);
            }
        }

        private void HämtaPatienter()
        {
            HämtaTabell("patienter", patienter);
            for (int i = 0; i < patienter.Count; i++)
            {
                listBox1.Items.Add(patienter[i]);
            }
        }

        private void HämtaTabell(string t, List<string> l)
        {
            connection.Open();

            MySqlDataReader dataReader;
            string sqlsats = "SELECT ID FROM " + t;

            MySqlCommand cmd = new MySqlCommand(sqlsats, connection);
            dataReader = cmd.ExecuteReader();

            l.Clear();
            while (dataReader.Read())
            {
                l.Add(dataReader.GetString("ID"));
            }

            connection.Close();
        }
    }
}
