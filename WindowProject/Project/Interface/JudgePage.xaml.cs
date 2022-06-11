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
using Project.Exceptions;

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
            addJudgeName.Text = "";
            addJudgeSurname.Text = "";
            removeJudgeName.Text = "";
            removeJudgeSurname.Text = "";
            string names = "";
            string[] judges = tournament.getJudgeString();
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
            try
            {
                if (addJudgeName.Text == "" || addJudgeSurname.Text == "") throw new EmptyStringException("Podaj dane sędziego");
                tournament.addJudge(new Judge(addJudgeName.Text, addJudgeSurname.Text));
            }
            catch(EmptyStringException ex)
            {
                MessageBoxResult error = MessageBox.Show(ex.Message, "UWAGA", MessageBoxButton.OK, MessageBoxImage.Error);
                refreshJudges();
                return;
            }
            catch(JudgeExistsException ex)
            {
                MessageBoxResult error = MessageBox.Show($"Sędzia {ex.getName()} {ex.getSurname()} już istnieje", "UWAGA", MessageBoxButton.OK, MessageBoxImage.Error);
                refreshJudges();
                return;
            }
            refreshJudges();
        }

        private void removeJudgeButton(object sender, RoutedEventArgs e)
        {
            try
            {
                if (removeJudgeName.Text == "" || removeJudgeSurname.Text == "") throw new EmptyStringException("Podaj dane sędziego");
                tournament.removeJudge(new Judge(removeJudgeName.Text, removeJudgeSurname.Text));
            }
            catch(EmptyStringException ex)
            {
                MessageBoxResult error = MessageBox.Show(ex.Message, "UWAGA", MessageBoxButton.OK, MessageBoxImage.Error);
                refreshJudges();
                return;
            }
            catch(JudgeNotExistsException ex)
            {
                MessageBoxResult error = MessageBox.Show($"Sędzia {ex.getName()} {ex.getSurname()} nie istnieje", "UWAGA", MessageBoxButton.OK, MessageBoxImage.Error);
                refreshJudges();
                return;
            }
            refreshJudges();
        }
    }
}
