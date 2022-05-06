using System;
using Project.Exceptions;

namespace Project.Registrations
{
    public class TeamManager
    {
        public void addTeam(MenuPage _menu, string teamName, int teamCategory)
        {
            if (teamName.Length == 0) throw new EmptyNameException("Podaj nazwę drużyny");
            switch (teamCategory)
            {
                case 0:
                    _menu.volleyball.addTeam(new Team(teamName));
                    break;
                case 1:
                    _menu.tugOfWar.addTeam(new Team(teamName));
                    break;
                case 2:
                    _menu.dodgeball.addTeam(new Team(teamName));
                    break;
                default:
                    break;
            }
        }
        public void removeTeam(MenuPage _menu, string teamName, int teamCategory)
        {
            if (teamName.Length == 0) throw new EmptyNameException("Podaj nazwę drużyny");
            switch (teamCategory)
            {
                case 0:
                    _menu.volleyball.removeTeam(new Team(teamName));
                    break;
                case 1:
                    _menu.tugOfWar.removeTeam(new Team(teamName));
                    break;
                case 2:
                    _menu.dodgeball.removeTeam(new Team(teamName));
                    break;
                default:
                    break;
            }
        }
    }
}
