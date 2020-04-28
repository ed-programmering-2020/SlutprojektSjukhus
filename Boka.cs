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
    public partial class Boka : Form
    {
        MySqlConnection connection;
        string connectionString = "SERVER=localhost;DATABASE=sjukhus;" + "UID=user_sjukhus;PASSWORD=password;";

        public Boka()
        {
            InitializeComponent();
        }

        private void btnBoka_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("En ny kund kommer att skapas!", "Ny kund", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                string symptomer = "";
                connection = new MySqlConnection(connectionString);
                connection.Open();

                string sqlsats = string.Format("INSERT INTO kunder (ID, Name, Efternamn, Personnummer, Adress, Telefonnummer, Symptomer, RegistreringsTid) VALUES ({0}, \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", {7})", "Null", tbxNamn.Text, tbxEfternamn.Text, tbxPersonnummer.Text, tbxAdress.Text, tbxTelefon.Text, symptomer, "now()");

                MySqlCommand cmd = new MySqlCommand(sqlsats, connection);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    Console.WriteLine(error);
                    MessageBox.Show("Du måste fylla i alla rutor för att registrerar dig", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    return;
                }

                connection.Close();

                this.Close();
            }
        }

        private void btnAvbryt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
