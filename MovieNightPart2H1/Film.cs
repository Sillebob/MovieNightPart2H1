using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNightPart2H1
{
    public class Film
    {
        // Properties: setting private and defining set & get.
        #region Properties.

        private int filmId;
        private string title;
        private int year;
        private string descript;

        public int FilmId
        {
            get
            { return filmId; }
            set
            { filmId = value; }
        }
        public string Title
        {
            get
            { return title; }
            set
            { title = value; }
        }
        public int Year
        {
            get
            { return year; }
            set
            { year = value; }
        }

        public string Descript
        {
            get
            { return descript; }
            set
            { descript = value; }
        }
        #endregion Properties.


        // Making the constructor.
        #region Constructors.
        // Making one without Id to get the autoincrementet id from the SQL server
        public Film(string title, int year, string descript)
        {
            this.title = title;
            this.year = year;
            this.descript = descript;
        }
        public Film(int filmId, string title, int year, string descript) : this(title,year,descript)
        {
            this.filmId = filmId;
        }
        #endregion Constructors
    }
}

