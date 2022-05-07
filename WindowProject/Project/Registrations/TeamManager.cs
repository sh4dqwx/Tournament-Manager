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
            Team tmpTeam = new Team(teamName);
            switch (teamCategory)
            {
                case 0:
                    if (!_menu.volleyball.getTeams().Contains(tmpTeam)) throw new RemoveNonExistentTeamException(teamName, "Siatkówka");
                    _menu.volleyball.removeTeam(tmpTeam);
                    break;
                case 1:
                    if (!_menu.tugOfWar.getTeams().Contains(tmpTeam)) throw new RemoveNonExistentTeamException(teamName, "Przeciąganie liny");
                    _menu.tugOfWar.removeTeam(tmpTeam);
                    break;
                case 2:
                    if (!_menu.dodgeball.getTeams().Contains(tmpTeam)) throw new RemoveNonExistentTeamException(teamName, "Dwa ognie");
                    _menu.dodgeball.removeTeam(tmpTeam);
                    break;
                default:
                    break;
            }
        }
    }
}
