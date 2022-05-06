using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Exceptions;

namespace Project.Registrations
{
    public class JudgeManager
    {
        public void addJudge(MenuPage _menu, string judgeName, string judgeSurname, int judgeCategory)
        {
            if (judgeName.Length == 0 || judgeSurname.Length == 0) throw new EmptyNameException("Podaj imię i nazwisko sędziego");
            switch (judgeCategory)
            {
                case 0:
                    _menu.volleyball.addJudge(new Judge(judgeName, judgeSurname));
                    break;
                case 1:
                    _menu.tugOfWar.addJudge(new Judge(judgeName, judgeSurname));
                    break;
                case 2:
                    _menu.dodgeball.addJudge(new Judge(judgeName, judgeSurname));
                    break;
                default:
                    break;
            }
        }
        public void removeJudge(MenuPage _menu, string judgeName, string judgeSurname, int judgeCategory)
        {
            if (judgeName.Length == 0 || judgeSurname.Length == 0) throw new EmptyNameException("Podaj imię i nazwisko sędziego");
            switch (judgeCategory)
            {
                case 0:
                    _menu.volleyball.removeJudge(new Judge(judgeName, judgeSurname));
                    break;
                case 1:
                    _menu.tugOfWar.removeJudge(new Judge(judgeName, judgeSurname));
                    break;
                case 2:
                    _menu.dodgeball.removeJudge(new Judge(judgeName, judgeSurname));
                    break;
                default:
                    break;
            }
        }
    }
}
