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
    /// Логика взаимодействия для AddEditEmploye.xaml
    /// </summary>
    public partial class AddEditEmploye : Window
    {
        private Employe _currentEmploye = new Employe();

        public AddEditEmploye()
        {
            InitializeComponent();
            DataContext = _currentEmploye;

        }
        public AddEditEmploye(dynamic selectedEmploye)
        {
            InitializeComponent();

            if (selectedEmploye != null)
            {
                _currentEmploye = selectedEmploye;
                LoadPreviousData();
            }

            DataContext = _currentEmploye;
        }
        private void LoadPreviousData()
        {
            TB_Name.Text = _currentEmploye.Name;
            TB_LastName.Text = _currentEmploye.Last_name;
            TB_MiddleName.Text = _currentEmploye.Middle_name;
            DP_DateOfEmployment.SelectedDate = _currentEmploye.Date_of_employment;
            TB_Login.Text = _currentEmploye.Login;
            TB_Password.Text = _currentEmploye.Password;
            TB_PhoneNumber.Text = _currentEmploye.Phone_number;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveEmploye();
        }

        private void SaveEmploye()
        {
            _currentEmploye.Name = TB_Name.Text;
            _currentEmploye.Last_name = TB_LastName.Text;
            _currentEmploye.Middle_name = TB_MiddleName.Text;
            _currentEmploye.Date_of_employment = (DateTime)DP_DateOfEmployment.SelectedDate;
            _currentEmploye.Login = TB_Login.Text;
            _currentEmploye.Password = TB_Password.Text;
            _currentEmploye.Phone_number = TB_PhoneNumber.Text;
            _currentEmploye.SOLI = TB_Soli.Text;


            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_currentEmploye.Name))
                errors.AppendLine("Укажите имя");

            if (string.IsNullOrEmpty(_currentEmploye.Last_name))
                errors.AppendLine("Укажите фамилию");

            if (_currentEmploye.Date_of_employment == null)
                errors.AppendLine("Укажите дату приема на работу");

            if (string.IsNullOrEmpty(_currentEmploye.Login))
                errors.AppendLine("Укажите логин");

            if (string.IsNullOrEmpty(_currentEmploye.Password))
                errors.AppendLine("Укажите пароль");

            if (string.IsNullOrEmpty(_currentEmploye.Phone_number))
                errors.AppendLine("Укажите номер телефона");

            if (string.IsNullOrEmpty(_currentEmploye.SOLI))
                errors.AppendLine("Укажите соль");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return;

            }
            Hash hash = new Hash();
            _currentEmploye.Password = hash.GenerateHash(_currentEmploye.Password, _currentEmploye.SOLI);

            if (_currentEmploye.ID_Employe == 0)
            {
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe.Add(_currentEmploye);
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
