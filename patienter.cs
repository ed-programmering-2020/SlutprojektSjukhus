using MySql.Data.MySqlClient;
using System.Data;
using System;
namespace Sjukhus
{

    public class patienter
    {



        public patienter() { }  // tom standardkonstruktör

        // Variabelista 
        int id;  //Primary key
        string namn;
        string efternamn;
        int personnummer;
        string adress;
        int telefonnummer;
        string symptomer;
        DateTime registreringstid;


        public static MySqlCommand getAll()
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = " Select * from patienter";
            return command;
        }


        // Datarad till objekt via Konstruktör 
        public patienter(DataRow dr)
        {
            ID = dr["ID"] == DBNull.Value ? ID = 0 : (int)dr["ID"];
            Namn = dr["Namn"] == DBNull.Value ? Namn = "" : (string)dr["Namn"];
            Efternamn = dr["Efternamn"] == DBNull.Value ? Efternamn = "" : (string)dr["Efternamn"];
            Personnummer = dr["Personnummer"] == DBNull.Value ? Personnummer = 0 : (int)dr["Personnummer"];
            Adress = dr["Adress"] == DBNull.Value ? Adress = "" : (string)dr["Adress"];
            Telefonnummer = dr["Telefonnummer"] == DBNull.Value ? Telefonnummer = 0 : (int)dr["Telefonnummer"];
            Symptomer = dr["Symptomer"] == DBNull.Value ? Symptomer = "" : (string)dr["Symptomer"];
            RegistreringsTid = dr["RegistreringsTid"] == DBNull.Value ? RegistreringsTid = Convert.ToDateTime("01/01/1900") : (DateTime)dr["RegistreringsTid"];
        }

        // todo: rätt ToString för att fylla listboxar mm)
        public override string ToString() 
        { 
            return Namn + " " + Efternamn + " : " + Symptomer;
        }

        public static string GetNameLastname(int ID)
        {
            string connectionString = "SERVER=5.178.75.122;DATABASE=sjukhusdb;UID=linus;PASSWORD=LinusT;";
            string returnValue = "";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlDataReader dataReader = null;
            string sqlsats = "Select Namn, Efternamn from patienter where ID =" + ID;
            MySqlCommand cmd = new MySqlCommand(sqlsats, connection);

            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                returnValue = dataReader.GetValue(0).ToString() + " " + dataReader.GetValue(1).ToString();
            }

            return returnValue;
        }


        // metod för radera detta objekt
        public MySqlCommand GetDeleteCommand()
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "DELETE from patienter WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", ID);
            return command;
        }

        // metod för updatera detta objekt
        public MySqlCommand GetUpdateCommand()
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = " UPDATE patienter SET ID = @ID, Namn = @Namn, Efternamn = @Efternamn, Personnummer = @Personnummer, Adress = @Adress, Telefonnummer = @Telefonnummer, Symptomer = @Symptomer, RegistreringsTid = @RegistreringsTid WHERE ID = @ID"; command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Namn", Namn);
            command.Parameters.AddWithValue("@Efternamn", Efternamn);
            command.Parameters.AddWithValue("@Personnummer", Personnummer);
            command.Parameters.AddWithValue("@Adress", Adress);
            command.Parameters.AddWithValue("@Telefonnummer", Telefonnummer);
            command.Parameters.AddWithValue("@Symptomer", Symptomer);
            command.Parameters.AddWithValue("@RegistreringsTid", RegistreringsTid);
            return command;
        }

        // metod för insert detta objekt i DB
        public MySqlCommand GetInsertCommand()
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO patienter (ID, Namn, Efternamn, Personnummer, Adress, Telefonnummer, Symptomer, RegistreringsTid ) Values (@ID, @Namn, @Efternamn, @Personnummer, @Adress, @Telefonnummer, @Symptomer, @RegistreringsTid)"; command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Namn", Namn);
            command.Parameters.AddWithValue("@Efternamn", Efternamn);
            command.Parameters.AddWithValue("@Personnummer", Personnummer);
            command.Parameters.AddWithValue("@Adress", Adress);
            command.Parameters.AddWithValue("@Telefonnummer", Telefonnummer);
            command.Parameters.AddWithValue("@Symptomer", Symptomer);
            command.Parameters.AddWithValue("@RegistreringsTid", RegistreringsTid);
            return command;
        }


        // Getter och Setter
        public int ID { get { return id; } set { id = value; } }
        public string Namn { get { return namn; } set { namn = value; } }
        public string Efternamn { get { return efternamn; } set { efternamn = value; } }
        public int Personnummer { get { return personnummer; } set { personnummer = value; } }
        public string Adress { get { return adress; } set { adress = value; } }
        public int Telefonnummer { get { return telefonnummer; } set { telefonnummer = value; } }
        public string Symptomer { get { return symptomer; } set { symptomer = value; } }
        public DateTime RegistreringsTid { get { return registreringstid; } set { registreringstid = value; } }
    }
}
