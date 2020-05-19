using MySql.Data.MySqlClient;
using System.Data;
using System;
namespace Sjukhus
{

    public class läkare
    {



        public läkare() { }  // tom standardkonstruktör

        // Variabelista 
        int id;  //Primary key
        string namn;
        string efternamn;
        string specialisering;


        public static MySqlCommand getAll()
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = " Select * from läkare";
            return command;
        }

        public static MySqlCommand getAll(string Specialisering)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = " Select * from läkare where Specialisering = '" + Specialisering + "'";
            return command;
        }


        // Datarad till objekt via Konstruktör 
        public läkare(DataRow dr)
        {
            ID = dr["ID"] == DBNull.Value ? ID = 0 : (int)dr["ID"];
            Namn = dr["Namn"] == DBNull.Value ? Namn = "" : (string)dr["Namn"];
            Efternamn = dr["Efternamn"] == DBNull.Value ? Efternamn = "" : (string)dr["Efternamn"];
            Specialisering = dr["Specialisering"] == DBNull.Value ? Specialisering = "" : (string)dr["Specialisering"];
        }

        // todo: rätt ToString för att fylla listboxar mm)
        public override string ToString() 
        {
            return Namn + " " + Efternamn + " : " + Specialisering; 
        }

        // metod för radera detta objekt
        public MySqlCommand GetDeleteCommand()
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "DELETE from läkare WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", ID);
            return command;
        }

        // metod för updatera detta objekt
        public MySqlCommand GetUpdateCommand()
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = " UPDATE läkare SET ID = @ID, Namn = @Namn, Efternamn = @Efternamn, Specialisering = @Specialisering WHERE ID = @ID"; command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Namn", Namn);
            command.Parameters.AddWithValue("@Efternamn", Efternamn);
            command.Parameters.AddWithValue("@Specialisering", Specialisering);
            return command;
        }

        // metod för insert detta objekt i DB
        public MySqlCommand GetInsertCommand()
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO läkare (ID, Namn, Efternamn, Specialisering ) Values (@ID, @Namn, @Efternamn, @Specialisering)"; command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Namn", Namn);
            command.Parameters.AddWithValue("@Efternamn", Efternamn);
            command.Parameters.AddWithValue("@Specialisering", Specialisering);
            return command;
        }


        // Getter och Setter
        public int ID { get { return id; } set { id = value; } }
        public string Namn { get { return namn; } set { namn = value; } }
        public string Efternamn { get { return efternamn; } set { efternamn = value; } }
        public string Specialisering { get { return specialisering; } set { specialisering = value; } }
    }
}