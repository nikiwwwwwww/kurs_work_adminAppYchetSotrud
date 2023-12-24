using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdminApp_YchetSotrudnikov
{
    /// <summary>
    /// Логика взаимодействия для AddEditSallary.xaml
    /// </summary>
    public partial class AddEditSallary : Window
    {
        private Sallary _currentSallary = new Sallary();

        public AddEditSallary()
        {
            InitializeComponent();
            DataContext = _currentSallary;

            LoadComboBoxData();
        }

        public AddEditSallary(dynamic selectedSallary)
        {
            InitializeComponent();

            if (selectedSallary != null)
                _currentSallary = selectedSallary;

            DataContext = _currentSallary;
            cb_Post_Emp.SelectedItem = _currentSallary.Post_Employe.Employe.Login;
            cb_Sick.SelectedItem = _currentSallary.Sick.Sick_for_days;
            cb_Stake.SelectedItem = _currentSallary.Stake.Payment_per_day;


            LoadComboBoxData();

        }

        private void LoadComboBoxData()
        {


            cb_Post_Emp.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post_Employe.Select(pe => pe.Employe.Login).ToList();
            cb_Sick.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Sick.Select(pe => pe.Sick_for_days).ToList();
            cb_Stake.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Stake.Select(pe => pe.Payment_per_day).ToList();

            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveSallary();
        }

        private void SaveSallary()
        {

            string selectedPost_employe = cb_Post_Emp.SelectedItem.ToString();

            var selectedEmploye = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post_Employe.FirstOrDefault(x => x.Employe.Login == selectedPost_employe) ;

            if (selectedEmploye != null)
            {
                _currentSallary.Post_Employe_ID = selectedEmploye.ID_Post_employe;
            }

            string selectedSickdays = cb_Sick.SelectedItem.ToString();
            if (selectedSickdays != null)
            {
                var selectedSickdaysInt = Int32.Parse(selectedSickdays);
                var selectedSick = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Sick.FirstOrDefault(x => x.Sick_for_days == selectedSickdaysInt);
                if (selectedSick != null)
                {
                    _currentSallary.Sick_ID = selectedSick.ID_Sick;
                }

            }

            string selectedStake_stake = cb_Sick.SelectedItem.ToString();
            if (selectedStake_stake != null)
            {
                var selectedStake_stakeInt = Int32.Parse(selectedStake_stake);

                var selectedStake = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Stake.FirstOrDefault(x => x.Payment_per_shift == selectedStake_stakeInt);

                if (selectedStake != null)
                {
                    _currentSallary.Stake_ID = selectedStake.ID_Stake;
                }
            }

            StringBuilder errors = new StringBuilder();

            if (_currentSallary.Post_Employe == null)
                errors.AppendLine("Укажите сотрудника");

            if (_currentSallary.Stake == null)
                errors.AppendLine("Укажите зарплату");

            if (_currentSallary.Sick == null)
                errors.AppendLine("Укажите больничные дни");



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return;
            }


            if (_currentSallary.ID_Sallary == 0)
            {
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Sallary.Add(_currentSallary);
            }

            try
            {
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();

                MainWindow main = new MainWindow(null);
         

                MessageBox.Show("Информация сохранена корректно!");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка");
            }
        }

    }
        
}

