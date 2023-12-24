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
    /// Логика взаимодействия для AddEditEmploye_Tasks.xaml
    /// </summary>
    public partial class AddEditEmploye_Tasks : Window
    {
        private Employe_Tasks _currentEmployeTasks = new Employe_Tasks();

        public AddEditEmploye_Tasks()
        {
            InitializeComponent();

            DataContext = _currentEmployeTasks;

            LoadComboBoxData();
        }

        public AddEditEmploye_Tasks(dynamic selectedEmployeTasks)
        {
            InitializeComponent();

            if (selectedEmployeTasks != null)
                _currentEmployeTasks = selectedEmployeTasks;

            DataContext = _currentEmployeTasks;

            LoadComboBoxData();
            // Выбираем предыдущие данные для выбранной записи
            var selectedTasks = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Tasks.FirstOrDefault(t => t.ID_Tasks == _currentEmployeTasks.Tasks_ID);
            var selectedEmploye = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe.FirstOrDefault(e => e.ID_Employe == _currentEmployeTasks.Employe_ID);

            // Заполняем ComboBox предыдущими данными
            if (selectedTasks != null)
                cb_Tasks.SelectedItem = selectedTasks.Topic;

            if (selectedEmploye != null)
                cb_Employe.SelectedItem = selectedEmploye.Login;

        }

        private void LoadComboBoxData()
        {
            cb_Tasks.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Tasks.Select(t => t.Topic).ToList();
            cb_Employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe.Select(e => e.Login).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveEmployeTasks();
        }

        private void SaveEmployeTasks()
        {
            string selectedTask = cb_Tasks.SelectedItem?.ToString();
            string selectedEmploye = cb_Employe.SelectedItem?.ToString();

            var selectedTaskObj = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Tasks.FirstOrDefault(x => x.Topic == selectedTask);
            var selectedEmployeObj = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe.FirstOrDefault(x => x.Login == selectedEmploye);

            if (selectedTaskObj != null)
                _currentEmployeTasks.Tasks_ID = selectedTaskObj.ID_Tasks;

            if (selectedEmployeObj != null)
                _currentEmployeTasks.Employe_ID = selectedEmployeObj.ID_Employe;

            StringBuilder errors = new StringBuilder();

            if (_currentEmployeTasks.Tasks_ID == null)
                errors.AppendLine("Выберите задачу");

            if (_currentEmployeTasks.Employe_ID == null)
                errors.AppendLine("Выберите сотрудника");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return;
            }

            if (_currentEmployeTasks.ID_Employe_tasks == 0)
            {
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe_Tasks.Add(_currentEmployeTasks);
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
