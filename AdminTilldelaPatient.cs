using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sjukhus
{
    public partial class AdminTilldelaPatient : Form
    {
        List<läkare> AllaLäkare = new List<läkare>();
        patienter patient;
        läkare läkare;

        string connectionString = "SERVER=5.178.75.122;DATABASE=sjukhusdb;UID=linus;PASSWORD=LinusT;";

        public AdminTilldelaPatient(patienter patient)
        {
            InitializeComponent();
            this.patient = patient;
            tbxNamn.Text = patient.Namn;
            tbxEfternamn.Text = patient.Efternamn;
            tbxPersonnummer.Text = patient.Personnummer.ToString();
            tbxAdress.Text = patient.Adress;
            tbxTelefonnummer.Text = patient.Telefonnummer.ToString();
            tbxSymptom.Text = patient.Symptomer;

            dateTimePicker1.Value = DateTime.Now;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand cmd = läkare.getAll(patient.Symptomer);
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
            listBox1.DataSource = AllaLäkare;
        }

        private void btnRegistrera_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Är du säker på att du vill registrera detta?", "Utföra?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if(dateTimePicker1.Value.Date <= DateTime.Now.Date)
                {
                    MessageBox.Show("Ändra på datumet!", "Varning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                läkare = AllaLäkare[listBox1.SelectedIndex];

                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                string sqlsats = string.Format("INSERT INTO bokningar (PatientID, LäkareID, Datum) VALUES ('{0}', '{1}', '{2}')", patient.ID, läkare.ID, dateTimePicker1.Value);
                MySqlCommand cmd = new MySqlCommand(sqlsats, connection);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    Console.WriteLine(error);
                    connection.Close();
                    MessageBox.Show("Någoting gick fel!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

                connection.Close();
                this.Close();
            }
        }
    }
}
