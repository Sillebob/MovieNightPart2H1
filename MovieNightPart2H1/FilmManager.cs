using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNightPart2H1
{
    // Making the class static as in DalManager.
    public static class FilmManager
    {
        // Method that returns the movies from the DalManager.
        #region Method ReturnFilms.
        public static List<Film> ReturnFilms()
        {
            // Calling the method from DalManager.
            return DalManager.GetFilms();
        }
        #endregion Method ReturnFilms.

        //Method that returns the actors from the DalManager.
        #region Method ReturnActors.
        public static List<Actor> ReturnActors()
        {
            // Calling the method from DalManager.
            return DalManager.GetActors();
        }
        #endregion Method ReturnActors.

        //Method that returns the genres from the DalManager.
        #region MethodReturnGenre.
        public static List<Genre> ReturnGenre()
        {
            // Calling the method from DalManager.
            return DalManager.GetGenre();
        }
        #endregion Method ReturnGenre.

        // Methods Part two.
        // Insert.
        #region Insert Actor, Film, Genre.
        #region Method InsertActor.
        public static Actor InsertActor(Actor a)
        {
            // Calling the method from DalManager.
             return DalManager.InsertActor(a);
        }
        #endregion Method InsertActor.

        // Method InsertFilm
        #region Method InsertFilm.
        public static Film InsertFilm(Film f)
        {
            // Calling the method from DalManager.
            return DalManager.InsertFilm(f);
        }
        #endregion Method InsertFilm.

        // Method InsertGenre
        #region Method InsertGenre.
        public static Genre InsertGenre(Genre g)
        {
            // Calling the method from DalManager.
          return DalManager.InsertGenre(g);
        }
        #endregion Method InsertGenre
        #endregion Insert Actor, Film, Genre.

        // Update
        #region Update Actor, Film, Genre.
        // Method UpdateActor
        #region Method UpdateActor.
        public static void UpdateActor(int id, string newName)
        {
            // Calling the method from DalManager.
            DalManager.UpdateActor(id, newName);
        }
        #endregion Method UpdateActor.

        // Method UpdateFilm
        #region Method UpdateFilm.
        public static void UpdateFilm(int id,string newTitle)
        {
            // Calling the method from DalManager.
             DalManager.UpdateFilm(id, newTitle);
        }
        #endregion Method UpdateFilm.

        // Method UpdateGenre
        #region Method UpdateGenre.
        public static void UpdateGenre(int id, string newGenre)
        {
            // Calling the method from DalManager.
            DalManager.UpdateGenre(id, newGenre);
        }
        #endregion Method UpdateGenre.
        #endregion Update Actor, Film, Genre.

        // Delete
        #region Delete Actor, Film, Genre.
        // Method DeleteActor
        #region Method DeleteActor.
        public static void DeleteActor(int id)
        {
            // Calling the method from DalManager.
            DalManager.DeleteActor(id);
        }
        #endregion Method DeleteActor

        // Method DeleteFilm
        #region Method DeleteFilm
        public static void DeleteFilm(int id)
        {
            // Calling the method from DalManager.
            DalManager.DeleteFilm(id);
        }
        #endregion

        // Method DeleteGenre
        #region Method DeleteGenre.
        public static void DeleteGenre(int id)
        {
            // Calling the method from DalManager.
            DalManager.DeleteGenre(id);
        }
        #endregion Method DeleteGenre.
        #endregion Delete Actor, Film, Genre.
    }
}
