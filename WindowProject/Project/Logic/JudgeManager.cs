using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Exceptions;
using Project.Logic;
namespace Project.Registrations
{
    public class JudgeManager
    {
        public void addJudge(MenuPage _menu, string judgeName, string judgeSurname, int judgeCategory)
        {
            if (judgeName.Length == 0 || judgeSurname.Length == 0) throw new EmptyNameException("Podaj imię i nazwisko sędziego");
            Judge tmpJudge = new Judge(judgeName, judgeSurname);
            switch (judgeCategory)
            {
                case 0:
                    if(_menu.volleyball.getJudges().Contains(tmpJudge)) throw new AddExistentJudgeException(judgeName, judgeSurname, "Siatkówka");
                    _menu.volleyball.addJudge(tmpJudge);
                    break;
                case 1:
                    if (_menu.tugOfWar.getJudges().Contains(tmpJudge)) throw new AddExistentJudgeException(judgeName, judgeSurname, "Przeciąganie liny");
                    _menu.tugOfWar.addJudge(tmpJudge);
                    break;
                case 2:
                    if (_menu.dodgeball.getJudges().Contains(tmpJudge)) throw new AddExistentJudgeException(judgeName, judgeSurname, "Dwa ognie");
                    _menu.dodgeball.addJudge(tmpJudge);
                    break;
                default:
                    break;
            }
        }
        public void removeJudge(MenuPage _menu, string judgeName, string judgeSurname, int judgeCategory)
        {
            if (judgeName.Length == 0 || judgeSurname.Length == 0) throw new EmptyNameException("Podaj imię i nazwisko sędziego");
            Judge tmpJudge = new Judge(judgeName, judgeSurname);
            switch (judgeCategory)
            {
                case 0:
                    if (!_menu.volleyball.getJudges().Contains(tmpJudge)) throw new RemoveNonExistentJudgeException(judgeName, judgeSurname, "Siatkówka");
                    _menu.volleyball.removeJudge(tmpJudge);
                    break;
                case 1:
                    if (!_menu.tugOfWar.getJudges().Contains(tmpJudge)) throw new RemoveNonExistentJudgeException(judgeName, judgeSurname, "Przeciąganie liny");
                    _menu.tugOfWar.removeJudge(tmpJudge);
                    break;
                case 2:
                    if (!_menu.dodgeball.getJudges().Contains(tmpJudge)) throw new RemoveNonExistentJudgeException(judgeName, judgeSurname, "Dwa ognie");
                    _menu.dodgeball.removeJudge(tmpJudge);
                    break;
                default:
                    break;
            }
        }
    }
}
