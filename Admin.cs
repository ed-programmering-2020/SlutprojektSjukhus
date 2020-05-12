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
        string connectionString = "SERVER=5.178.75.122;DATABASE=sjukhusdb;UID=linus;PASSWORD=LinusT;";


        TcpListener lyssnare;
        int port = 12345;

        public Admin()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
            StartaServer();
            HämtaPatienter();
            HämtaLäkare();
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
        private void HämtaPatienter()
        {
            HämtaTabell("patienter", patienter);
            for (int i = 0; i < patienter.Count; i++)
            {
                listBox1.Items.Add(patienter[i]);
            }
        }

        private void HämtaLäkare()
        {
            HämtaTabell("läkare", läkare);
            for(int i = 0; i < läkare.Count; i++)
            {
                listBox2.Items.Add(läkare[i]);
            }
        }

        private void HämtaTabell(string t, List<string> l)
        {
            connection.Open();

            MySqlDataReader dataReader;
            string sqlsats = "";

            if (t == "patienter")
                sqlsats = "SELECT ID, Namn, Efternamn, Symptomer FROM " + t;
            else
                sqlsats = "SELECT ID, Namn, Efternamn, Specialisering FROM " + t;

            MySqlCommand cmd = new MySqlCommand(sqlsats, connection);
            dataReader = cmd.ExecuteReader();

            l.Clear();
            while (dataReader.Read())
            {
                if (t == "patienter")
                    l.Add(dataReader.GetString("Namn") + " " + dataReader.GetString("Efternamn") + " - Symptom: " + dataReader.GetString("Symptomer"));
                else
                    l.Add(dataReader.GetString("Namn") + " " + dataReader.GetString("Efternamn") + " - Specialisering: " + dataReader.GetString("Specialisering"));
            }

            connection.Close();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != null)
            {
                
            }
        }
    }
}
