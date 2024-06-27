using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylistDL
{
    public class User
    {
        public string Username { get; set; }
    }

    public class SqlData
    {
        static string connectionString = "Data Source=DESKTOP-JNQ2TIM;Initial Catalog=MusicPlaylistDL;Integrated Security=True;";

        public static void Connect()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                
            }
        }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string selectStatement = "SELECT Artist, Album and songs FROM users";
                SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

                sqlConnection.Open();

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Username = reader["username"].ToString()
                        });
                    }
                }
            }

            return users;
        }
    }
}
