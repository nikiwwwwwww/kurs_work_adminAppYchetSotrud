using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private Employe _currentEmploye = new Employe();

        Hash hash = new Hash();

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string soli = hash.CreateSalt(4);
            _currentEmploye.Name = TB_Name.Text;
            _currentEmploye.Last_name = TB_LastName.Text;
            _currentEmploye.Middle_name = TB_MiddleName.Text;
            _currentEmploye.Date_of_employment = DateTime.Now;
            _currentEmploye.Login = TB_Login.Text;
            _currentEmploye.Password = hash.GenerateHash(TB_Password.Text, soli);
            _currentEmploye.Phone_number = TB_PhoneNumber.Text;
            _currentEmploye.SOLI = soli;


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
           

            // Валидация имени
            if (!Regex.IsMatch(_currentEmploye.Name, "^[А-Яа-я]{0,50}$"))
                errors.AppendLine("Некорректное имя");

            // Валидация фамилии
            if (!Regex.IsMatch(_currentEmploye.Last_name, "^[А-Яа-я]{0,50}$"))
                errors.AppendLine("Некорректная фамилия");

            // Валидация отчества
            if (!Regex.IsMatch(_currentEmploye.Middle_name, "^[А-Яа-я]{0,50}$"))
                errors.AppendLine("Некорректное отчество");


            // Валидация номера телефона
            if (!Regex.IsMatch(_currentEmploye.Phone_number, @"^\+7\(\d{3}\)\d{3}-\d{2}-\d{2}$"))
                errors.AppendLine("Некорректный номер телефона. Формат: +7(XXX)XXX-XX-XX");

            // Валидация логина
            if (!Regex.IsMatch(_currentEmploye.Login, "^[A-Za-z0-9]{5,255}$"))
                errors.AppendLine("Некорректный логин. Логин должен состоять из латинских букв и иметь длину от 5 до 255 символов");

            //// валидация пароля
            //if (!regex.ismatch(_currentemploye.password, "^[а-яа-яa-za-z0-9]{5,255}$"))
            //    errors.appendline("некорректный пароль. пароль должен состоять из букв и цифр и иметь длину от 5 до 255 символов");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return;
            }

            try
            {
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe.Add(_currentEmploye);

                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();

                Post post = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post.FirstOrDefault(x => x.Name_post == "Пользователь");

                Employe employeee = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe.FirstOrDefault(x => x.Login == TB_Login.Text);


                Post_Employe post_employe = new Post_Employe();
                post_employe.Post_ID = post.ID_Post;
                post_employe.Employe_ID = employeee.ID_Employe;

                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post_Employe.Add(post_employe);

                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();

                MainWindow main = new MainWindow(null);

                MessageBox.Show("Вы заристрированы!");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка");
            }
        }
    }
}
