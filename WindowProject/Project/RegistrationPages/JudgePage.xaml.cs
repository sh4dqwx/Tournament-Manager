using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.Generic;
using Project.Registrations;
using Project.Exceptions;

namespace Project.RegistrationPages
{
    public partial class JudgePage : Page
    {
        private MenuPage _menu;
        private JudgeManager judgeManager;
        public JudgePage(MenuPage menu)
        {
            InitializeComponent();
            _menu = menu;
            judgeManager = new JudgeManager();
        }
        public void refreshJudges()
        {
            string names = "";
            string category = "";
            List<Judge> judges = _menu.volleyball.getJudges();
            judges.ForEach(judge => { names += judge.getName() + " " + judge.getSurname() + "\n"; category += "Siatkówka\n"; });
            judges = _menu.tugOfWar.getJudges();
            judges.ForEach(judge => { names += judge.getName() + " " + judge.getSurname() + "\n"; category += "Przeciąganie liny\n"; ; });
            judges = _menu.dodgeball.getJudges();
            judges.ForEach(judge => { names += judge.getName() + " " + judge.getSurname() + "\n"; category += "Dwa ognie\n"; ; });
            judgeName.Text = names;
            judgeCategory.Text = category;
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
            removeJudgeName.Text = "";
            removeJudgeSurname.Text = "";
            removeCategoryName.SelectedIndex = 0;
            _menu.refreshTables();
        }
    }
}
