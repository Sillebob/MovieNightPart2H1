using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace MovieNightPart2H1
{
    // Making the class public static ie there can be only 1 instance of this class DalManager.
    public static class DalManager
    {
        // Declaring and assigning an attribut to contain the connectionString.
        private static string cs = @"Data Source=ZBC-E-SKP2438\SQLH1;Initial Catalog=MovieNightH1; Integrated Security=SSPI";

        // Methods.
        // Methods for getting Lists.
        #region Method GetFilms.
        // Method to return a list of all the movies.
        public static List<Film> GetFilms()
        {
            // Making initialising the list to be returned containing the movies.
            List<Film> films = new List<Film>();

            // Making the database ready and connecting.
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                // Query to the database
                SqlCommand cmd = new SqlCommand("select film_id, title, released_year, descript from film", connection);

                // Catches the result of the SQL command
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    // Getting data from the reader and casting it to the correct datatype.
                    int filmId = (int)rdr["film_id"];
                    string title = (string)rdr["title"];
                    int year = (int)rdr["released_year"];
                    string descript = (string)rdr["descript"];

                    // New movie object.
                    Film f = new Film(filmId, title, year, descript);

                    // Adding movies to the list films.
                    films.Add(f);
                }
                return films;
            }
        }
        #endregion GetFilms.

        #region Method GetActors.
        // Method to return a list of all the actors.
        public static List<Actor> GetActors()
        {
            // Making initialising the list to be returned containing the actors.
            List<Actor> actors = new List<Actor>();

            // Making the database ready and connecting.
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                // Query to the database
                SqlCommand cmd = new SqlCommand("select actor_id, first_name, last_name from actor", connection);

                // Catches the result of the SQL command
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    // Getting data from the reader and casting it to the correct datatype.
                    int actorId = (int)rdr["actor_id"];
                    string firstName = (string)rdr["first_name"];
                    string lastName = (string)rdr["last_name"];

                    // New actor object.
                    Actor a = new Actor(actorId, firstName, lastName);

                    // Adding actors to the list films.
                    actors.Add(a);
                }
                return actors;
            }
        }
        #endregion GetActors.

        #region Method GetGenre.
        // Method to return a list of all the genres.
        public static List<Genre> GetGenre()
        {
            // Making initialising the list to be returned containing the movies.
            List<Genre> genres = new List<Genre>();

            // Making the database ready and connecting.
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                // Query to the database
                SqlCommand cmd = new SqlCommand("select genre_id, genre from genre", connection);

                // Catches the result of the SQL command
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    // Getting data from the reader and casting it to the correct datatype.
                    int genreId = (int)rdr["genre_id"];
                    string genreType = (string)rdr["genre"];
                    
                    // New genre object.
                    Genre g = new Genre(genreId, genreType);

                    // Adding genres to the list films.
                    genres.Add(g);
                }
                return genres;
            }
        }
        #endregion GetGenre.

        // Insert, Update, Delete
        #region Insert, Update, Delete.
        // Methods for inserting data.
        #region Insert.

        #region MethodInsertActor.
        public static Actor InsertActor(Actor a)
        {   // Making the database ready and connecting.
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                // Inserting data in the database getting the ID back (autoincremented).
                SqlCommand cmd = new SqlCommand("insert into actor(first_name,last_name) OUTPUT INSERTED.ACTOR_ID values(@fn,@ln)", connection);
                                
                // Adding parameters.
                cmd.Parameters.Add(new SqlParameter("@fn", a.FirstName));

                cmd.Parameters.Add(new SqlParameter("@ln", a.LastName));

                //If no result is getting returned ExecuteNonQuery is can be used instead of ExecuteScalar
                //cmd.ExecuteNonQuery();
                int newId = (Int32)cmd.ExecuteScalar();
                //Id sættes ind i a
                a.ActorId = newId;
            }
            return a;
        }
        #endregion Method InsertActor.

        // Method InsertFilm
        #region MethodInsertFilm.
        public static Film InsertFilm(Film f)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                // Inserting data in the database getting the ID back (autoincremented).
                SqlCommand cmd = new SqlCommand("insert into film(title, released_year, descript) OUTPUT INSERTED.Film_ID values(@title,@year,@descript)", connection);

                // Adding parameters.
                cmd.Parameters.Add(new SqlParameter("@title", f.Title));
                cmd.Parameters.Add(new SqlParameter("@year", f.Year));
                cmd.Parameters.Add(new SqlParameter("@descript", f.Descript));

                // Since no result is getting returned ExecuteNonQuery is used
                cmd.ExecuteNonQuery();

                // Getting the new id (from the autoincrement i SQL) and assigning it to a new variabel.
                int newId = (Int32)cmd.ExecuteScalar();

                // The property FilmId gets the value.
                f.FilmId = newId;                
            }
            return f;
        }
        #endregion Method InsertFilm.

        // Method InsertGenre
        #region MethodInsertGenre.
        public static Genre InsertGenre(Genre g)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();                                             

                // Inserting data in the database getting the ID back (autoincremented).
                SqlCommand cmd = new SqlCommand("insert into Genre(genre) OUTPUT INSERTED.genre_ID values(@genre)", connection);

                // Adding parameters.
                cmd.Parameters.Add(new SqlParameter("@genre", g.GenreType));

                // Since no result is getting returned ExecuteNonQuery is used
                cmd.ExecuteNonQuery();

                // Getting the new id (from the autoincrement i SQL) and assigning it to a new variabel.
                int newId = (Int32)cmd.ExecuteScalar();

                // The property FilmId gets the value.
                g.GenreId = newId;
            }
            return g;
        }
        #endregion Method InsertGenre.
        #endregion Insert.

        //Methods for updating data.
        #region Update.
       
        #region Method UpdateActor.
        public static void UpdateActor(int id, string newName)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                // Updating data in the database.
                SqlCommand cmd = new SqlCommand("update actor set first_name = @fn where Actor_id = @id", connection);

                // Adding parameters.
                cmd.Parameters.Add(new SqlParameter("@fn", newName));
                cmd.Parameters.Add(new SqlParameter("@id", id));

                // Since no result is getting returned ExecuteNonQuery is used
                cmd.ExecuteNonQuery();                
            }            
        }
        #endregion Method UpdateActor.

        #region Method UpdateFilm.
        public static void UpdateFilm(int id, string newTitle)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                // Updating data in the database.
                SqlCommand cmd = new SqlCommand("update film set title = @title  where film_id = @id", connection);

                // Adding parameters.
                cmd.Parameters.Add(new SqlParameter("@title", newTitle));
                cmd.Parameters.Add(new SqlParameter("@id", id));

                // Since no result is getting returned ExecuteNonQuery is used
                cmd.ExecuteNonQuery();               
            }                        
        }
        #endregion Method UpdateFilm.

        #region Method UpdateGenre.
        public static void UpdateGenre(int id, string newGenre)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                // Updating data in the database.
                SqlCommand cmd = new SqlCommand("update genre set genre = @genre where genre_id = @id", connection);

                // Adding parameters.
                cmd.Parameters.Add(new SqlParameter("@genre", newGenre));
                cmd.Parameters.Add(new SqlParameter("@id", id));

                // Since no result is getting returned ExecuteNonQuery is used
                cmd.ExecuteNonQuery();
            }   
        }
        #endregion Method UpdateGenre.
        #endregion Update.

        // Methods for deleting data.
        #region Delete.
        #region Method DeleteActor.
        public static void DeleteActor(int id)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                // Deleting data in the database.
                SqlCommand cmd = new SqlCommand("delete From actor where actor_id = @id", connection);

                // Adding parameters.
                cmd.Parameters.Add(new SqlParameter("@id", id));

                // Since no result is getting returned ExecuteNonQuery is used
                cmd.ExecuteNonQuery();                
            }   
        }
        #endregion Method DeleteActor.

        #region Method DeleteFilm.
        public static void DeleteFilm(int id)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                // Deleting data in the database.
                SqlCommand cmd = new SqlCommand("Delete from film where film_id = @id", connection);

                // Adding parameters.
                cmd.Parameters.Add(new SqlParameter("@id", id));
                
                // Since no result is getting returned ExecuteNonQuery is used
                cmd.ExecuteNonQuery();               
            }           
        }
        #endregion Method DeleteFilm.

        #region Method DeleteGenre.
        public static void DeleteGenre(int id)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                // Deleting data in the database.
                SqlCommand cmd = new SqlCommand("Delete from genre where genre_id = @id", connection);

                // Adding parameters.
                cmd.Parameters.Add(new SqlParameter("@id", id));

                // Since no result is getting returned ExecuteNonQuery is used
                cmd.ExecuteNonQuery();                
            }            
        }
        #endregion Method DeleteGenre
        #endregion Delete.
        #endregion Insert, Update, Delete.
    }
}
