using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Project.Logic.Tournaments;
using Project.Logic.Registrations;

namespace Project.Interface
{
    public partial class JudgePage : Page
    {
        private RegistrationPage _reg;
        private Tournament tournament;
        public JudgePage(RegistrationPage reg)
        {
            InitializeComponent();
            _reg = reg;
        }
        public void loadTournament(Tournament tournament)
        {
            this.tournament = tournament;
            refreshJudges();
        }
        public void refreshJudges()
        {
            string names = "";
            string[] judges = tournament.getJudges();
            for(int i = 0; i < judges.Length; i++)
            {
                names+=judges[i]+"\n";
            }
            judgeName.Text = names;
        }

        private void GoBack_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_reg);
        }

        private void addJudgeButton(object sender, RoutedEventArgs e)
        {
            if (addJudgeName.Text == "" || addJudgeSurname.Text == "") return;
            tournament.addJudge(new Judge(addJudgeName.Text, addJudgeSurname.Text));
            addJudgeName.Text = "";
            addJudgeSurname.Text = "";
            refreshJudges();
        }

        private void removeJudgeButton(object sender, RoutedEventArgs e)
        {
            tournament.removeJudge(new Judge(addJudgeName.Text, addJudgeSurname.Text));
            removeJudgeName.Text = "";
            removeJudgeSurname.Text = "";
            refreshJudges();
        }
    }
}
