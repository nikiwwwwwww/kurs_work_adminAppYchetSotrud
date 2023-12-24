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
    /// Логика взаимодействия для AddEditDepartment.xaml
    /// </summary>
    public partial class AddEditDepartment : Window
    {
        private Department _currentDepartment = new Department();

        public AddEditDepartment()
        {
            InitializeComponent();
            DataContext = _currentDepartment;

        }
        public AddEditDepartment(dynamic selectedDepartment)
        {
            InitializeComponent();

            if (selectedDepartment != null)
            {
                _currentDepartment = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Department.Find(selectedDepartment.ID_Department);
            }

            DataContext = _currentDepartment;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveDepartment();
        }

        private void SaveDepartment()
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_currentDepartment.Name_departament))
                errors.AppendLine("Укажите название отдела");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return;
            }

            if (_currentDepartment.ID_Department == 0)
            {
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Department.Add(_currentDepartment);
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
