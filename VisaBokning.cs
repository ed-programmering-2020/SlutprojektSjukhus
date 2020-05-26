using MySql.Data.MySqlClient;
using Renci.SshNet.Messages.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Sjukhus
{
    public partial class VisaBokning : Form
    {
        string connectionString = "SERVER=5.178.75.122;DATABASE=sjukhusdb;UID=linus;PASSWORD=LinusT;";

        List<bokningar> AllaBokningar = new List<bokningar>();
        int personnummer;
        int patientId;
        public VisaBokning(int personnummer)
        {
            InitializeComponent();
            this.personnummer = personnummer;
            HämtaPatient();
            HämtaBokningar();
        }

        public void HämtaPatient()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlDataReader dataReader = null;
            string sqlsats = "Select * from patienter where Personnummer= \"" + personnummer + "\"";

            MySqlCommand cmd = new MySqlCommand(sqlsats, connection);

            dataReader = cmd.ExecuteReader();

            while(dataReader.Read())
            {
                patientId = Int32.Parse(dataReader.GetValue(0).ToString());
                tbxNamn.Text = dataReader.GetValue(1).ToString();
                tbxEfternamn.Text = dataReader.GetValue(2).ToString();
                tbxPersonnummer.Text = dataReader.GetValue(3).ToString();
                tbxAdress.Text = dataReader.GetValue(4).ToString();
                tbxTelefon.Text = dataReader.GetValue(5).ToString();
            }
            connection.Close();
        }

        private void HämtaBokningar()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM bokningar WHERE PatientID= " + patientId;
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

            BokadeTider.Items.Clear();
            for (int i = 0; i < AllaBokningar.Count; i++)
            {
                BokadeTider.Items.Add(AllaBokningar[i]);
            }
            // BokadeTider.DataSource = AllaBokningar;
        }

        private void btnSpara_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Dina förädningar kommer att sparas!", "Spara", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                string sqlsats = string.Format("UPDATE patienter SET Namn = \"{0}\", Efternamn = \"{1}\", Adress = \"{2}\", Telefonnummer = \"{3}\" WHERE Personnummer = \"{4}\"", tbxNamn.Text, tbxEfternamn.Text, tbxAdress.Text, tbxTelefon.Text, personnummer);

                MySqlCommand cmd = new MySqlCommand(sqlsats, connection);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, Text);
                    connection.Close();
                    return;
                }

                connection.Close();
                this.Close();
            }
        }

        private void btnRaderaTid_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Den markerade läkartiden kommer att raderas, du kommer inte få någon ny läkartid! Ta kontakt med din läkare för ny tid.", "Radera läkartid", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                int bokningId = AllaBokningar[BokadeTider.SelectedIndex].ID;

                string sqlsats = string.Format("DELETE FROM bokningar WHERE ID = \"{0}\"", bokningId);

                MySqlCommand cmd = new MySqlCommand(sqlsats, connection);
                cmd.ExecuteNonQuery();

                connection.Close();

                HämtaBokningar();
            }
        }

        private void btnAvbryt_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Dina förädningar kommer inte att sparas!", "Avbryt", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnRadera_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Dina registrering kommer att raderas!", "Radera registrering", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                string sqlsats = string.Format("DELETE FROM patienter WHERE Personnummer = \"{0}\"", personnummer);

                MySqlCommand cmd = new MySqlCommand(sqlsats, connection);
                cmd.ExecuteNonQuery();

                connection.Close();
                this.Close();
            }
        }
    }
}
