using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNightPart2H1
{
    public class Actor
    {
        // Properties: setting private and defining set & get.
        #region Properties.

        private int actorId;
        private string firstName;
        private string lastName;

        public int ActorId
        {
            get
            { return actorId; }
            set
            { actorId = value; }
        }
        public string FirstName
        {
            get
            { return firstName; }
            set
            { firstName = value; }
        }
        public string LastName
        {
            get
            { return lastName; }
            set
            { lastName = value; }
        }
        #endregion Properties.

        // Making the constructor.
        #region Constructors.
        // Making one without Id to get the autoincrementet id from the SQL server
        public Actor(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Actor(int actorId, string firstName, string lastName) : this(firstName, lastName)
        {
            this.actorId = actorId;
        }
        #endregion Constructors
    }

}
