using System;
using Project.Exceptions;

namespace Project.Registrations
{
    public class TeamManager
    {
        public void addTeam(MenuPage _menu, string teamName, int teamCategory)
        {
            if (teamName.Length == 0) throw new EmptyNameException("Podaj nazwę drużyny");
            Team tmpTeam = new Team(teamName);
            switch (teamCategory)
            {
                case 0:
                    if (_menu.volleyball.getTeams().Contains(tmpTeam)) throw new AddExistentTeamException(teamName, "Siatkówka");
                    _menu.volleyball.addTeam(tmpTeam);
                    break;
                case 1:
                    if (_menu.tugOfWar.getTeams().Contains(tmpTeam)) throw new AddExistentTeamException(teamName, "Przeciąganie liny");
                    _menu.tugOfWar.addTeam(tmpTeam);
                    break;
                case 2:
                    if (_menu.dodgeball.getTeams().Contains(tmpTeam)) throw new AddExistentTeamException(teamName, "Dwa ognie");
                    _menu.dodgeball.addTeam(tmpTeam);
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
