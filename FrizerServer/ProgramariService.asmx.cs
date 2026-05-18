
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Data.SqlClient;

namespace FrizerServer
{
    [WebService(Namespace = "http://tempuri.org/")]
    public class ProgramariService : System.Web.Services.WebService
    {
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FrizerieDataBase.mdf;Integrated Security=True";

        [WebMethod]
        public string AdaugaInDB(string client, DateTime data, string tip)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string sqlVerificare = "SELECT COUNT(*) FROM ProgramariTable WHERE Data = @d";
                SqlCommand cmdVerificare = new SqlCommand(sqlVerificare, conn);
                cmdVerificare.Parameters.AddWithValue("@d", data);

                int existaDeja = (int)cmdVerificare.ExecuteScalar();

                if (existaDeja > 0)
                {
                    return "Această dată nu mai este disponibilă! Te rugăm să alegi alta.";
                }

                string sql = "INSERT INTO ProgramariTable (Client, Data, TipTuns) VALUES (@c, @d, @t)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@c", client);
                cmd.Parameters.AddWithValue("@d", data);
                cmd.Parameters.AddWithValue("@t", tip);
                cmd.ExecuteNonQuery();
                return "Programare salvată!";
            }
        }
        [WebMethod]
        public string ModificaProgramare(int id, string client, DateTime data, string tip)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string sqlVerificare = "SELECT COUNT(*) FROM ProgramariTable WHERE Data = @d AND Id <> @id";
                SqlCommand cmdVerificare = new SqlCommand(sqlVerificare, conn);
                cmdVerificare.Parameters.AddWithValue("@d", data);
                cmdVerificare.Parameters.AddWithValue("@id", id);

                int existaDeja = (int)cmdVerificare.ExecuteScalar();

                if (existaDeja > 0)
                {
                    return "Eroare: Această dată nu mai este disponibilă! Te rugăm să alegi alta.";
                }

                string sql = "UPDATE ProgramariTable SET Client=@c, Data=@d, TipTuns=@t WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@c", client);
                cmd.Parameters.AddWithValue("@d", data);
                cmd.Parameters.AddWithValue("@t", tip);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return "Programare modificată cu succes!";
            }
        }

        [WebMethod]
        public string StergeProgramare(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "DELETE FROM ProgramariTable WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Programarea a fost ștearsă!";
            }
        }

        [WebMethod]
        public List<ModelProgramare> GetToateProgramarile()
        {
            List<ModelProgramare> lista = new List<ModelProgramare>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ProgramariTable ORDER BY Data ASC", conn);
                conn.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    lista.Add(new ModelProgramare
                    {
                        Id = (int)r["Id"],
                        Client = r["Client"].ToString(),
                        Data = (DateTime)r["Data"],
                        TipTuns = r["TipTuns"].ToString()
                    });
                }
            }
            return lista;
        }

    }
}

