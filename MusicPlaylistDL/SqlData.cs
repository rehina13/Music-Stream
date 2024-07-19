using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;
namespace MusicPlaylistDL
{

    public class SqlData
    {
        static string connectionString = "Data Source=DESKTOP-JNQ2TIM;Initial Catalog=MusicPlaylistDL;Integrated Security=True;";

        public static List<User> GetMusicInfo()
        {
            List<User> users = new List<User>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string selectStatement = "SELECT username ,Artist, SongsAndAlbum FROM MusicPlaylistDL";
                SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

                sqlConnection.Open();

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            username = reader["Username"].ToString(),
                            Artist = reader["Artist"].ToString(),
                            SongsAndAlbum = reader["SongsAndAlbum"].ToString()
                        });
                    }
                }

                sqlConnection.Close();
            }

            return users;
        }

        public void AddMusicInfo(string username, string Artist, string SongsAndAlbum)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string insertStatement = "INSERT INTO MusicInfo (username, Artist, SongsAndAlbum) VALUES (@username, @Artist, @songsAndAlbum)";
                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

                insertCommand.Parameters.AddWithValue("@username", username);
                insertCommand.Parameters.AddWithValue("@Artist", Artist);
                insertCommand.Parameters.AddWithValue("@SongsAndAlbum", SongsAndAlbum);

                sqlConnection.Open();
                insertCommand.ExecuteNonQuery();
            }
        }

        public void DeleteMusicInfo(string username ,string Artist, string SongsAndAlbum)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string deleteStatement = "DELETE FROM MusicInfo WHERE Artist = @artist";
                SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

                deleteCommand.Parameters.AddWithValue("@username", username);
                deleteCommand.Parameters.AddWithValue("@artist", Artist);
                deleteCommand.Parameters.AddWithValue("@SongsAndAlbum", SongsAndAlbum);

                sqlConnection.Open();
                deleteCommand.ExecuteNonQuery();
            }
        }

        public void UpdateMusicInfo(User oldUser, string newUser)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string updateStatement = "UPDATE MusicInfo  SET Artist = @newArtist, SongsAndAlbum = @newSongsAndAlbum WHERE Artist = @oldArtist AND SongsAndAlbum = @oldSongsAndAlbum";
                SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

                updateCommand.Parameters.AddWithValue("@newArtist", newUser.Artist);
                updateCommand.Parameters.AddWithValue("@newSongsAndAlbum", newUser.SongsAndAlbum);
                updateCommand.Parameters.AddWithValue("@oldArtist", oldUser.Artist);
                updateCommand.Parameters.AddWithValue("@oldongsAndAlbum", oldUser.SongsAndAlbum);


                sqlConnection.Open();
                updateCommand.ExecuteNonQuery();
            }
        }
    }
}
