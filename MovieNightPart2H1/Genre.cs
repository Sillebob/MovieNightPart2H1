using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNightPart2H1
{
    public class Genre
    {
        // Properties: setting private and defining set & get.
        #region Properties.

        private int genreId;
        private string genreType;

        public int GenreId
        {
            get
            { return genreId; }
            set
            { genreId = value; }
        }
        public string GenreType
        {
            get
            { return genreType; }
            set
            { genreType = value; }
        }
        #endregion Properties.

        // Making the constructor.
        #region Constructors.
        // Making one without Id to get the autoincrementet id from the SQL server
        public Genre(string genreType)
        {
           this.genreType = genreType;
        }

        public Genre(int genreId, string genreType) : this(genreType)
        {
            this.genreId = genreId;
        }
        #endregion Constructors.
    }
}
