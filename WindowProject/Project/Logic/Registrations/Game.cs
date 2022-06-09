using System;
using System.Collections.Generic;

namespace Project.Logic.Registrations
{
    public class Game
    {
        private Team firstTeam, secondTeam, winner, loser;
        private Judge mainJudge, secondaryJudge1, secondaryJudge2;
        private Random random;

        public Game(Team firstTeam, Team secondTeam, Random random)
        {
            this.firstTeam = firstTeam;
            this.secondTeam = secondTeam;
            this.random = random;
        }

        public Team getFirstTeam()
        {
            return firstTeam;
        }
        public Team getSecondTeam()
        {
            return secondTeam;
        }
        public Team getWinner()
        {
            return winner;
        }
        public Team getLoser()
        {
            return loser;
        }
        public void setJudges(Judge j)
        {
            mainJudge = j;
            secondaryJudge1 = null;
            secondaryJudge2 = null;
        }
        public void setJudges(Judge j1, Judge j2, Judge j3)
        {
            mainJudge = j1;
            secondaryJudge1 = j2;
            secondaryJudge2 = j3;
        }
        public Judge getMainJudge()
        {
            return mainJudge;
        }
        public Judge getSecondaryJudge1()
        {
            return secondaryJudge1;
        }
        public Judge getSecondaryJudge2()
        {
            return secondaryJudge2;
        }

        public void playManual(int chosen)
        {
            if (chosen == 1)
            {
                winner = firstTeam;
                loser = secondTeam;
                firstTeam.addScore(true);
                secondTeam.addScore(false);
            }
            else if (chosen == 2)
            {
                winner = secondTeam;
                loser = firstTeam;
                firstTeam.addScore(false);
                secondTeam.addScore(true);
            }
            else throw new Exception("Wrong number");
        }

        public void playRandom()
        {
            if (random.NextDouble() >= 0.5)
            {
                winner = firstTeam;
                loser = secondTeam;
                firstTeam.addScore(true);
                secondTeam.addScore(false);
            }
            else
            {
                winner = secondTeam;
                loser = firstTeam;
                firstTeam.addScore(false);
                secondTeam.addScore(true);
            }
        }
    }
}
