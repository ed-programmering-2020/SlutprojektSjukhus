using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Sjukhus
{
    public partial class Admin : Form
    {
        List<läkare> AllaLäkare = new List<läkare>();
        List<patienter> AllaPatienter = new List<patienter>();

        string connectionString = "SERVER=5.178.75.122;DATABASE=sjukhusdb;UID=linus;PASSWORD=LinusT;";


        TcpListener lyssnare;
        int port = 12345;

        public Admin()
        {
            InitializeComponent();
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
            label4.Text = "Inväntande...";
            label4.ForeColor = Color.FromArgb(0, 255, 255);
            btnSkickaAmbulans.Enabled = true;
        }

        private void btnSkickaAmbulans_Click(object sender, EventArgs e)
        {
            label4.Text = "Skickad!";
            label4.ForeColor = Color.FromArgb(0, 255, 0);
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

            foreach (DataRow row in dt.Rows)
            {
                AllaPatienter.Add(new patienter(row));
            }

            connection.Close();

            listBox1.DataSource = AllaPatienter; 
        }

        private void HämtaLäkare()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand cmd = läkare.getAll();  //statisk metod
            MySqlDataAdapter datAdapt = new MySqlDataAdapter();
            datAdapt.SelectCommand = cmd;
            cmd.Connection = connection;
            DataTable dt = new DataTable();
            datAdapt.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                AllaLäkare.Add(new läkare(row));
            }

            connection.Close();

            listBox2.DataSource = AllaLäkare;
        }

        private void HämtaTabell()
        {
           

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand cmd = patienter.getAll();  //statisk metod
            MySqlDataAdapter datAdapt = new MySqlDataAdapter();
            datAdapt.SelectCommand = cmd;
            cmd.Connection = connection;
            DataTable dt = new DataTable();
            datAdapt.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                AllaPatienter.Add(new patienter(row));
            }

            connection.Close();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
                MessageBox.Show(listBox1.SelectedItem.ToString());

                AdminTilldelaPatient adminTilldelaPatient = new AdminTilldelaPatient(AllaPatienter[listBox1.SelectedIndex]);
                adminTilldelaPatient.Show();
        }
    }
}
