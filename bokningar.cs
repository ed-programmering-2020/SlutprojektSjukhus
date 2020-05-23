using MySql.Data.MySqlClient;
using System.Data;
using System;
namespace Sjukhus
{

    public class bokningar
    {



        public bokningar() { }  // tom standardkonstruktör

        // Variabelista 
        int id;  //Primary key
        int patientid;
        int läkareid;
        DateTime datum;


        public static MySqlCommand getAll()
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = " Select * from bokningar";
            return command;
        }


        // Datarad till objekt via Konstruktör 
        public bokningar(DataRow dr)
        {
            ID = dr["ID"] == DBNull.Value ? ID = 0 : (int)dr["ID"];
            PatientID = dr["PatientID"] == DBNull.Value ? PatientID = 0 : (int)dr["PatientID"];
            LäkareID = dr["LäkareID"] == DBNull.Value ? LäkareID = 0 : (int)dr["LäkareID"];
            Datum = dr["Datum"] == DBNull.Value ? Datum = Convert.ToDateTime("01/01/1900") : (DateTime)dr["Datum"];
        }

        // todo: rätt ToString för att fylla listboxar mm)
        public override string ToString()
        {
            return patienter.GetNameLastname(PatientID) + " : " + läkare.GetNameLastname(LäkareID) + " (" + Datum.ToString("dddd, dd MMMM yyyy") + ")"; 
        }

        // metod för radera detta objekt
        public MySqlCommand GetDeleteCommand()
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "DELETE from bokningar WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", ID);
            return command;
        }

        // metod för updatera detta objekt
        public MySqlCommand GetUpdateCommand()
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = " UPDATE bokningar SET ID = @ID, PatientID = @PatientID, LäkareID = @LäkareID, Datum = @Datum WHERE ID = @ID"; command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@PatientID", PatientID);
            command.Parameters.AddWithValue("@LäkareID", LäkareID);
            command.Parameters.AddWithValue("@Datum", Datum);
            return command;
        }

        // metod för insert detta objekt i DB
        public MySqlCommand GetInsertCommand()
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO bokningar (ID, PatientID, LäkareID, Datum ) Values (@ID, @PatientID, @LäkareID, @Datum)"; command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@PatientID", PatientID);
            command.Parameters.AddWithValue("@LäkareID", LäkareID);
            command.Parameters.AddWithValue("@Datum", Datum);
            return command;
        }


        // Getter och Setter
        public int ID { get { return id; } set { id = value; } }
        public int PatientID { get { return patientid; } set { patientid = value; } }
        public int LäkareID { get { return läkareid; } set { läkareid = value; } }
        public DateTime Datum { get { return datum; } set { datum = value; } }
    }
}