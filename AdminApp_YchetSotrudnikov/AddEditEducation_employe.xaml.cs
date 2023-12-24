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
using System.Windows.Shapes;

namespace AdminApp_YchetSotrudnikov
{
    /// <summary>
    /// Логика взаимодействия для AddEditEducation_employe.xaml
    /// </summary>
    public partial class AddEditEducation_employe : Window
    {
        private Education_employe _currentEducationEmploye = new Education_employe();

        public AddEditEducation_employe()
        {
            InitializeComponent();
            DataContext = _currentEducationEmploye;

            LoadComboBoxData();
        }

        public AddEditEducation_employe(dynamic selectedEducationEmploye)
        {
            InitializeComponent();

            if (selectedEducationEmploye != null)
                _currentEducationEmploye = selectedEducationEmploye;

            DataContext = _currentEducationEmploye;
            cb_Education.SelectedItem = _currentEducationEmploye.Education.Specialization;
            cb_Employe.SelectedItem = _currentEducationEmploye.Employe.Login; // Поменяйте на подходящий свойство с именем сотрудника

            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            cb_Education.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Education.Select(e => e.Specialization).ToList();
            cb_Employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe.Select(emp => emp.Login).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveEducationEmploye();
        }

        private void SaveEducationEmploye()
        {
            string selectedEducationType = cb_Education.SelectedItem.ToString();
            var selectedEducation = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Education.FirstOrDefault(ed => ed.Specialization == selectedEducationType);

            if (selectedEducation != null)
            {
                _currentEducationEmploye.Education_ID = selectedEducation.ID_Education;
            }

            string selectedEmployeName = cb_Employe.SelectedItem.ToString();
            var selectedEmploye = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe.FirstOrDefault(emp => emp.Login == selectedEmployeName);

            if (selectedEmploye != null)
            {
                _currentEducationEmploye.Employe_ID = selectedEmploye.ID_Employe;
            }

            StringBuilder errors = new StringBuilder();

            if (_currentEducationEmploye.Education_ID == null)
                errors.AppendLine("Укажите образование");

            if (_currentEducationEmploye.Employe_ID == null)
                errors.AppendLine("Укажите сотрудника");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return;
            }

            if (_currentEducationEmploye.ID_Education_employe == 0)
            {
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Education_employe.Add(_currentEducationEmploye);
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
