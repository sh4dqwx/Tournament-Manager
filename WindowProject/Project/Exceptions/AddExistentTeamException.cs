using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Exceptions
{
    public class AddExistentTeamException : Exception
    {
        private string teamName, teamCategory;

        public AddExistentTeamException(string teamName, string teamCategory) : base()
        {
            this.teamName = teamName;
            this.teamCategory = teamCategory;
        }

        public string getTeamName()
        {
            return teamName;
        }
        public string getTeamCategory()
        {
            return teamCategory;
        }
    }
}
