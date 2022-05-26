using System;

namespace Project.Exceptions
{
    public class TournamentException : Exception
    {
        private string name, category;
        public TournamentException(string name, string category) : base()
        {
            this.name = name;
            this.category = category;
        }

        public string getName()
        {
            return name;
        }
        public string getCategory()
        {
            return category;
        }
    }
}
