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
    /// Логика взаимодействия для AddEditPost_Employe.xaml
    /// </summary>
    public partial class AddEditPost_Employe : Window
    {
        private Post_Employe _currentPostEmploye = new Post_Employe();

        public AddEditPost_Employe()
        {
            InitializeComponent();

            DataContext = _currentPostEmploye;
            LoadComboBoxData();
        }
        public AddEditPost_Employe(dynamic selectedPostEmploye)
        {
            InitializeComponent();

            if (selectedPostEmploye != null)
            {
                _currentPostEmploye = selectedPostEmploye;
                cb_Employe.SelectedItem = _currentPostEmploye.Employe.Login;
                cb_Post.SelectedItem = _currentPostEmploye.Post.Name_post;
            }
            DataContext = _currentPostEmploye;
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            var context = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext();

            // Загрузка данных в ComboBox
            cb_Employe.ItemsSource = context.Employe.Select(e => e.Login).ToList();
            cb_Post.ItemsSource = context.Post.Select(p => p.Name_post).ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получение выбранных значений из ComboBox
            string selectedEmploye = cb_Employe.SelectedItem?.ToString();
            string selectedPost = cb_Post.SelectedItem?.ToString();

            // Поиск соответствующих записей в базе данных
            var selectedEmployeObj = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe.FirstOrDefault(x => x.Login == selectedEmploye);
            var selectedPostObj = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post.FirstOrDefault(x => x.Name_post == selectedPost);

            // Заполнение ID в текущем объекте Post_Employe
            if (selectedEmployeObj != null)
                _currentPostEmploye.Employe_ID = selectedEmployeObj.ID_Employe;

            if (selectedPostObj != null)
                _currentPostEmploye.Post_ID = selectedPostObj.ID_Post;

           
            // Проверка обязательных полей
            StringBuilder errors = new StringBuilder();

            if (_currentPostEmploye.Employe_ID == null)
                errors.AppendLine("Укажите сотрудника");

            if (_currentPostEmploye.Post_ID == null)
                errors.AppendLine("Укажите должность");

          
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return;
            }

            // Сохранение данных
            if (_currentPostEmploye.ID_Post_employe == 0)
            {
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post_Employe.Add(_currentPostEmploye);
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


