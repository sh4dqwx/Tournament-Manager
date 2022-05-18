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
using Project.Logic;
using Project.Exceptions;
namespace Project
{
    public partial class JudgePage : Page
    {
        private MenuPage _menu;
        private Tournament tournament;
        public JudgePage(MenuPage menu)
        {
            InitializeComponent();
            _menu = menu;
        }
        public void loadTournament(Tournament tournament)
        {
            this.tournament = tournament;
        }
        public void refreshJudges()
        {
            string names = "";
            string category = "";
            string[] judges = tournament.getJudges();
            for(int i = 0; i < judges.Length; i++)
            {

            }
            judges.ForEach(judge => { names += judge.getName() + " " + judge.getSurname() + "\n"; category += "Siatkówka\n"; });
            judgeName.Text = names;
        }

        private void GoBack_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_menu);
        }

        private void addJudgeButton(object sender, RoutedEventArgs e)
        {
            try { judgeManager.addJudge(_menu, addJudgeName.Text, addJudgeSurname.Text, addCategoryName.SelectedIndex); }
            catch (EmptyNameException ex)
            {
                MessageBoxResult error = MessageBox.Show(ex.Message, "UWAGA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (AddExistentJudgeException ex)
            {
                MessageBoxResult error = MessageBox.Show(
                    $"Sędzia {ex.getJudgeName()} {ex.getJudgeSurname()} w kategorii {ex.getJudgeCategory()} już istnieje",
                    "UWAGA",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
            addJudgeName.Text = "";
            addJudgeSurname.Text = "";
            addCategoryName.SelectedIndex = 0;
            _menu.refreshTables();
        }

        private void removeJudgeButton(object sender, RoutedEventArgs e)
        {
            try { judgeManager.removeJudge(_menu, removeJudgeName.Text, removeJudgeSurname.Text, removeCategoryName.SelectedIndex); }
            catch (EmptyNameException ex)
            {
                MessageBoxResult error = MessageBox.Show(ex.Message, "UWAGA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (RemoveNonExistentJudgeException ex)
            {
                MessageBoxResult error = MessageBox.Show(
                    $"Sędzia {ex.getJudgeName()} {ex.getJudgeSurname()} w kategorii {ex.getJudgeCategory()} nie istnieje",
                    "UWAGA",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
            removeJudgeName.Text = "";
            removeJudgeSurname.Text = "";
            removeCategoryName.SelectedIndex = 0;
            _menu.refreshTables();
        }
    }
}
