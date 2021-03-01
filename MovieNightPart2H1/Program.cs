using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MovieNightPart2H1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Insert. 
            #region Insert Actor, Film, Genre.
            // Could be made into user input and do Console.ReadLine.

            #region Insert Actor.
            // Calling the method from the FilmManager.
            FilmManager.InsertActor(new Actor("Marlon", "Brando"));
            // Calling the printing method to check if it was insertet correctly.
            PrintActor();
            #endregion Insert Actor

            #region Insert Film.
            // Calling the method from the FilmManager.
            FilmManager.InsertFilm(new Film("The godfather", 1972, "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son"));
            // Calling the printing method to check if it was insertet correctly.
            PrintFilm();
            #endregion Insert Film

            #region Insert Genre.
            // Calling the method from the FilmManager.
            FilmManager.InsertGenre(new Genre("Crime"));
            // Calling the printing method to check if it was insertet correctly.
            PrintGenre();
            #endregion Insert Genre.

            #endregion Insert Actor, Film, Genre.

            // Update.
            #region Update Actor, Film, Genre.
            // Could be made into user input and do Console.ReadLine.

            #region Update Actor.
            // Printing to get the Id numbers.
            PrintActor();

            // Calling the method from FilmManager which calls the method from DalManager to update firstname.
            // Update an actors firstname, needs the id of the actor and the new name
            // in this example the actor with the id 1 gets newFirstName as the first name
            FilmManager.UpdateActor(1, "newFirstNAme");

            // Printing to check if it was a success.
            PrintActor();
            #endregion Update Actor.

            #region Update Film.

            // Same comments as for Update Actor.
            PrintFilm();
            FilmManager.UpdateFilm(1, "newTitle");
            PrintFilm();
            #endregion Update Film

            #region Update Genre.
            // Same comments as for Update Actor.

            PrintGenre();
            FilmManager.UpdateGenre(1, "newGenre");
            PrintGenre();
            #endregion Update Genre.

            #endregion Update Actor, Film Genre.

            //Delete
            #region Delete Actor, Film, Genre.
            // Could be made into user input and do Console.ReadLine

            #region Delete Actor.
            // Printing to get the Id numbers.
            PrintActor();

            // Calling the method from FilmManager which calls the method from DalManager to delete.
            // Deletes an actors, needs the id of the actor.
            // in this example the actor with the id 1 gets deleted.
            FilmManager.DeleteActor(1);

            // Printing to check if it was a success.
            PrintActor();
            #endregion Delete Actor.

            #region Delete Film.
            // Same comments as for Delete Actor.
            PrintFilm();
            FilmManager.DeleteFilm(1);
            PrintFilm();
            #endregion Delete Film.

            #region Delete Genre.
            // Same comments as for Delete Actor.
            PrintGenre();
            FilmManager.DeleteGenre(1);
            PrintGenre();
            #endregion Delete Genre.

            #endregion Delete Actor, Film, Genre.

            Console.ReadKey();
        }
        // Methods.

        // Creating methods to print film, actor and genre to display their id's 
        // To know which id number to send with the methods for update and delete.
        #region Method PrintFilm.
        public static void PrintFilm()
        {
            // Calling the Filmmanager to get a list of all the movietitles.
            List<Film> film = FilmManager.ReturnFilms();

            foreach (Film item in film)
            {
                Console.WriteLine(item.FilmId + " " + item.Title + " " + item.Year);
            }

        }
        #endregion PrintFilm.

        #region PrintActor.
        public static void PrintActor()
        {
            // Calling the Filmmanager to get a list of all the actors.
            List<Actor> actor = FilmManager.ReturnActors();
            foreach (Actor item in actor)
            {
                Console.WriteLine(item.ActorId + " " + item.FirstName + " " + item.LastName);
            }

        }
        #endregion PrintActor.

        #region PrintGenre.
        public static void PrintGenre()
        {
            // Calling the Filmmanager to get a list of all the genres.
            List<Genre> genres = FilmManager.ReturnGenre();
            foreach (Genre item in genres)
            {
                Console.WriteLine(item.GenreId + " " + item.GenreType);
            }

        }
        #endregion PrintGenre

    }
}
