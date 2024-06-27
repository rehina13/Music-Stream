using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MusicPlaylistDL
{
    public class User
    {
        public string Artist { get; set; }
    }

    public class SqlData
    {
        static string connectionString = "Data Source=DESKTOP-JNQ2TIM;Initial Catalog=MusicPlaylistDL;Integrated Security=True;";

        public static void Connect()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlConnection.Close();
            }
        }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string selectStatement = "SELECT Artist, Songs and Album FROM users";
                SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

                sqlConnection.Open();

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Artist = reader["Artist"].ToString(),
                        });
                    }
                }

                sqlConnection.Close();
            }

            return users;
        }

        public static int AddUser(string artist, string album)
        {
            int success;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string insertStatement = "INSERT INTO users (Artist, Songs and Album) VALUES (@artist, @songs and album)";
                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

                insertCommand.Parameters.AddWithValue("@artist", artist);

                sqlConnection.Open();
                success = insertCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

            return success;
        }

        public static int UpdateUser(string artist)
        {
            int success;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string updateStatement = "UPDATE users SET Songs and Album = @songs and calbum WHERE Artist = @artist";
                SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

                updateCommand.Parameters.AddWithValue("@artist", artist);

                sqlConnection.Open();
                success = updateCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

            return success;
        }

        public static int DeleteUser(string artist)
        {
            int success;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string deleteStatement = "DELETE FROM users WHERE Artist = @artist";
                SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

                deleteCommand.Parameters.AddWithValue("@artist", artist);

                sqlConnection.Open();
                success = deleteCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

            return success;
        }
    }
}
