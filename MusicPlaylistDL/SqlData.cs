using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MusicPlaylistDL
{
    public class User
    {
        public string Artist { get; set; }
        public string SongsAndAlbum { get; set; }
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

        public static List<User> GetMusicInfo()
        {
            List<User> users = new List<User>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string selectStatement = "SELECT Artist, SongsAndAlbum FROM users";
                SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

                sqlConnection.Open();

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Artist = reader["Artist"].ToString(),
                            SongsAndAlbum = reader["SongsAndAlbum"].ToString()
                        });
                    }
                }

                sqlConnection.Close();
            }

            return users;
        }

        public static int AddMusicInfo(string artist, string songsAndAlbum)
        {
            int success;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string insertStatement = "INSERT INTO musicinfo (Artist, SongsAndAlbum) VALUES (@artist, @songsAndAlbum)";
                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

                insertCommand.Parameters.AddWithValue("@artist", artist);
                insertCommand.Parameters.AddWithValue("@songsAndAlbum", songsAndAlbum);

                sqlConnection.Open();
                success = insertCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

            return success;
        }

        public static int UpdateMusicInfo(string artist, string songsAndAlbum)
        {
            int success;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string updateStatement = "UPDATE musicinfo SET SongsAndAlbum = @songsAndAlbum WHERE Artist = @artist";
                SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

                updateCommand.Parameters.AddWithValue("@artist", artist);
                updateCommand.Parameters.AddWithValue("@songsAndAlbum", songsAndAlbum);

                sqlConnection.Open();
                success = updateCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

            return success;
        }

        public static int DeleteMusicInfo(string artist)
        {
            int success;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string deleteStatement = "DELETE FROM musicinfo WHERE Artist = @artist";
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
