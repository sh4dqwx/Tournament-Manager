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
            string surnames = "";
            List<Judge> judges = _menu.volleyball.getJudges();
            judges.ForEach(judge => { names += judge.getName() + "\n"; surnames += judge.getSurname() + "\n"; });
            judges = _menu.tugOfWar.getJudges();
            judges.ForEach(judge => { names += judge.getName() + "\n"; surnames += judge.getSurname() + "\n"; });
            JudgeName.Text = names;
            JudgeSurname.Text = surnames;
        }

        private void GoBack_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_menu);
        }

        private void addJudgeButton(object sender, RoutedEventArgs e)
        {
            if (addJudgeName.Text.Length == 0 || addJudgeSurname.Text.Length == 0) return;
            //Wywołanie dodania sędzięgo
            addJudgeName.Text = "";
            addJudgeSurname.Text = "";
            refreshJudges();
        }

        private void removeJudgeButton(object sender, RoutedEventArgs e)
        {
            if (addJudgeName.Text.Length == 0 || addJudgeSurname.Text.Length == 0) return;
            //Wywołanie usunięcia sędziego
            addJudgeName.Text = "";
            addJudgeSurname.Text = "";
            refreshJudges();
        }
    }
}
