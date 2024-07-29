using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace MusicPlaylistDL
{
    public class SqlData
    {
        static string connectionString
        //= "Data Source=DESKTOP-JNQ2TIM;Initial Catalog=MusicPlaylistDL;Integrated Security=True;";
         = "Server=tcp:20.189.112.141,1433; Database=MusicPlaylistDL; User Id=sa; Password=BSIT2-1";



        static SqlConnection sqlConnection = new SqlConnection(connectionString);

        static public void Connect()
        {
            sqlConnection.Open();
        }
        public static List<User> GetMusicInfo()
        {
            List<User> users = new List<User>();


                string selectStatement = "SELECT username, Artist, SongsAndAlbum FROM MusicInfo";
                SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();


            SqlDataReader reader = selectCommand.ExecuteReader();
          

            while (reader.Read())
                     {
                        users.Add(new User
                        {
                            username = reader["Username"].ToString(),
                            Artist = reader["Artist"].ToString(),
                            SongsAndAlbum = reader["SongsAndAlbum"].ToString()
                        });
                    }
                
            
            sqlConnection.Close();

            return users;
        }

        public void AddMusicInfo(string username, string artist, string songsAndAlbum)
        {

                string insertStatement = "INSERT INTO MusicInfo (Username, Artist, SongsAndAlbum) VALUES (@username, @artist, @songsAndAlbum)";
                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

                insertCommand.Parameters.AddWithValue("@username", username);
                insertCommand.Parameters.AddWithValue("@artist", artist);
                insertCommand.Parameters.AddWithValue("@songsAndAlbum", songsAndAlbum);

                sqlConnection.Open();
                insertCommand.ExecuteNonQuery();


            
        }

        public void DeleteMusicInfo(string artist)
        {

                string deleteStatement = "DELETE FROM MusicInfo WHERE Artist = @artist";
                SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

                deleteCommand.Parameters.AddWithValue("@Artist", artist);


            
        }

        public void UpdateMusicInfo(User oldUser, User newUser)
        {

                string updateStatement = "UPDATE MusicInfo SET Artist = @newArtist, SongsAndAlbum = @newSongsAndAlbum WHERE Artist = @oldArtist AND SongsAndAlbum = @oldSongsAndAlbum";
                SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

                updateCommand.Parameters.AddWithValue("@newArtist", newUser.Artist);
                updateCommand.Parameters.AddWithValue("@newSongsAndAlbum", newUser.SongsAndAlbum);
                updateCommand.Parameters.AddWithValue("@oldArtist", oldUser.Artist);
                updateCommand.Parameters.AddWithValue("@oldSongsAndAlbum", oldUser.SongsAndAlbum);


            
        }
    }
}