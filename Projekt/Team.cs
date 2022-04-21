using System;

namespace Projekt
{
    public class Team
    {
        private string name;
        private int score;

        public Team()
        {
            name = "[Brak nazwy]";
            score = 0;
        }

        public Team(string name)
        {
            this.name = name;
            this.score = 0;
        }

        public string getName()
        {
            return name;
        }

        public int getScore()
        {
            return score;
        }
    }
}
