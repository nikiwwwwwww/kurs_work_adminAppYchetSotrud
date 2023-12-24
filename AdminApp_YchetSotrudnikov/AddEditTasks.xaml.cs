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
    /// Логика взаимодействия для AddEditTasks.xaml
    /// </summary>
    public partial class AddEditTasks : Window
    {
        private Tasks _currentTask = new Tasks();

        public AddEditTasks()
        {
            InitializeComponent();

            DataContext = _currentTask;

        }
        public AddEditTasks(dynamic selectedTask)
        {
            InitializeComponent();

            if (selectedTask != null)
                _currentTask = selectedTask;

            DataContext = _currentTask;
            LoadPreviousData();
        }

        private void LoadPreviousData()
        {
            TB_Topic.Text = _currentTask.Topic;
            TB_Description.Text = _currentTask.Description;
            TB_Complexity.Text = _currentTask.Complexity;
            DatePicker_Start.SelectedDate = _currentTask.Date_of_issue;
            DatePicker_End.SelectedDate = _currentTask.Date_of_end;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            SaveTask();
        }

        private void SaveTask()
        {
            _currentTask.Topic = TB_Topic.Text;
            _currentTask.Description = TB_Description.Text;
            _currentTask.Complexity = TB_Complexity.Text;
            _currentTask.Date_of_issue = DatePicker_Start.SelectedDate ?? DateTime.Now;
            _currentTask.Date_of_end = DatePicker_End.SelectedDate ?? DateTime.Now;

            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentTask.Topic))
                errors.AppendLine("Укажите тему задачи");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return;
            }

            if (_currentTask.ID_Tasks == 0)
            {
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Tasks.Add(_currentTask);
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
