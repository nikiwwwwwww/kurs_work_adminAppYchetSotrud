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
    /// Логика взаимодействия для AddEditPost.xaml
    /// </summary>
    public partial class AddEditPost : Window
    {
        private Post _currentPost = new Post();

        public AddEditPost()
        {
            InitializeComponent();

            DataContext = _currentPost;

            LoadComboBoxData();
        }

        public AddEditPost(dynamic selectedPost)
        {
            InitializeComponent();

            if (selectedPost != null)
            {
                _currentPost = selectedPost;
                cb_Department.SelectedItem = _currentPost.Department.Name_departament;
                TB_name_post.Text = _currentPost.Name_post;
            }
            DataContext = _currentPost;
            LoadComboBoxData();
        }


        private void LoadComboBoxData()
        {
            var context = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext();

            // Загрузка данных в ComboBox
            cb_Department.ItemsSource = context.Department.Select(d => d.Name_departament).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SavePost();
        }

        private void SavePost()
        {
            // Получение выбранных значений из ComboBox
            string selectedDepartment = cb_Department.SelectedItem?.ToString();

            // Поиск соответствующей записи в базе данных
            var selectedDepartmentObj = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Department.FirstOrDefault(x => x.Name_departament == selectedDepartment);

            // Заполнение ID в текущем объекте Post
            if (selectedDepartmentObj != null)
                _currentPost.Department_ID = selectedDepartmentObj.ID_Department;



            // Проверка обязательных полей
            StringBuilder errors = new StringBuilder();

            if (_currentPost.Department_ID == null)
                errors.AppendLine("Укажите отдел");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return;
            }

            // Сохранение данных
            if (_currentPost.ID_Post == 0)
            {
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post.Add(_currentPost);
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
