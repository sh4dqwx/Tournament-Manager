using System;

namespace Projekt
{
    public class Team
    {
        private String name;
        private int score;

        public String getName()
        {
            return name;
        }

        public int getScore()
        {
            return score;
        }

        public Team()
        {
            name = "[Brak nazwy]";
            score = 0;
        }

        public Team(String name)
        {
            this.name = name;
            this.score = 0;
        }
    }
}
