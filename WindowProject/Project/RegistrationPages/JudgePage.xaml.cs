using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.Generic;
using Project.Registrations;

namespace Project.RegistrationPages
{
    public partial class JudgePage : Page
    {
        private MenuPage _menu;
        public JudgePage(MenuPage menu)
        {
            InitializeComponent();
            _menu = menu;
        }
        public void refreshJudges()
        {
            string names = "";
            string category = "";
            List<Judge> judges = _menu.volleyball.getJudges();
            judges.ForEach(judge => { names += judge.getName() + " " + judge.getSurname() + "\n"; category += "Siatkówka\n"; });
            judges = _menu.tugOfWar.getJudges();
            judges.ForEach(judge => { names += judge.getName() + " " + judge.getSurname() + "\n"; category += "Przeciąganie liny\n"; ; });
            JudgeName.Text = names;
            JudgeCategory.Text = category;
        }

        private void GoBack_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_menu);
        }

        private void addJudgeButton(object sender, RoutedEventArgs e)
        {
            if (addJudgeName.Text.Length == 0 || addJudgeSurname.Text.Length == 0) return;
            switch (addCategoryName.SelectedIndex)
            {
                case 0:
                    _menu.volleyball.addJudge(new Judge(addJudgeName.Text, addJudgeSurname.Text));
                    break;
                case 1:
                    _menu.tugOfWar.addJudge(new Judge(addJudgeName.Text, addJudgeSurname.Text));
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            addJudgeName.Text = "";
            addJudgeSurname.Text = "";
            addCategoryName.SelectedIndex = 0;
            _menu.refreshTables();
        }

        private void removeJudgeButton(object sender, RoutedEventArgs e)
        {
            if (removeJudgeName.Text.Length == 0 || removeJudgeSurname.Text.Length == 0) return;
            switch (removeCategoryName.SelectedIndex)
            {
                case 0:
                    _menu.volleyball.removeJudge(new Judge(removeJudgeName.Text, removeJudgeSurname.Text));
                    break;
                case 1:
                    _menu.tugOfWar.removeJudge(new Judge(removeJudgeName.Text, removeJudgeSurname.Text));
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            removeJudgeName.Text = "";
            removeJudgeSurname.Text = "";
            removeCategoryName.SelectedIndex = 0;
            _menu.refreshTables();
        }
    }
}
