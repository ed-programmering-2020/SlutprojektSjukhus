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

                #region checkBoxes
                if (cbAndningsproblem.Checked)
                {
                    if(symptomer == "")
                    {
                        symptomer = cbAndningsproblem.Text;
                    }
                    else
                    {
                        MessageBox.Show("Du kan inte registrera fler än en symptom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (cbDiabetes.Checked)
                {
                    if (symptomer == "")
                    {
                        symptomer = cbDiabetes.Text;
                    }
                    else
                    {
                        MessageBox.Show("Du kan inte registrera fler än en symptom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (cbHudsjukdom.Checked)
                {
                    if (symptomer == "")
                    {
                        symptomer = cbHudsjukdom.Text;
                    }
                    else
                    {
                        MessageBox.Show("Du kan inte registrera fler än en symptom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (cbHuvudvärkMigrän.Checked)
                {
                    if (symptomer == "")
                    {
                        symptomer = cbHuvudvärkMigrän.Text;
                    }
                    else
                    {
                        MessageBox.Show("Du kan inte registrera fler än en symptom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (cbHögtBlodtryck.Checked)
                {
                    if (symptomer == "")
                    {
                        symptomer = cbHögtBlodtryck.Text;
                    }
                    else
                    {
                        MessageBox.Show("Du kan inte registrera fler än en symptom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (cbKolesterolproblem.Checked)
                {
                    if (symptomer == "")
                    {
                        symptomer = cbKolesterolproblem.Text;
                    }
                    else
                    {
                        MessageBox.Show("Du kan inte registrera fler än en symptom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (cbLedvärk.Checked)
                {
                    if (symptomer == "")
                    {
                        symptomer = cbLedvärk.Text;
                    }
                    else
                    {
                        MessageBox.Show("Du kan inte registrera fler än en symptom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (cbNeurologiskaStörningar.Checked)
                {
                    if (symptomer == "")
                    {
                        symptomer = cbNeurologiskaStörningar.Text;
                    }
                    else
                    {
                        MessageBox.Show("Du kan inte registrera fler än en symptom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (cbRyggproblem.Checked)
                {
                    if (symptomer == "")
                    {
                        symptomer = cbRyggproblem.Text;
                    }
                    else
                    {
                        MessageBox.Show("Du kan inte registrera fler än en symptom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (cbÅngestDepression.Checked)
                {
                    if (symptomer == "")
                    {
                        symptomer = cbÅngestDepression.Text;
                    }
                    else
                    {
                        MessageBox.Show("Du kan inte registrera fler än en symptom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                #endregion

                connection = new MySqlConnection(connectionString);
                connection.Open();

                string sqlsats = string.Format("INSERT INTO patienter (Namn, Efternamn, Personnummer, Adress, Telefonnummer, Symptomer, RegistreringsTid) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", tbxNamn.Text, tbxEfternamn.Text, tbxPersonnummer.Text, tbxAdress.Text, tbxTelefon.Text, symptomer, DateTime.Now.ToString() );
                //string sqlsats = string.Format("INSERT INTO pasienter (NameV VALUES ('{0}''", tbxNamn.Text, tbxEfternamn.Text, tbxPersonnummer.Text, tbxAdress.Text, tbxTelefon.Text, symptomer, DateTime.Now.ToString());
                MySqlCommand cmd = new MySqlCommand(sqlsats, connection);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    Console.WriteLine(error);
                    MessageBox.Show("Du måste fylla i alla rutor för att registrera dig", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
