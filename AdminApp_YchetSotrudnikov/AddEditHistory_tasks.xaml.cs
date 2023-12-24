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
    /// Логика взаимодействия для AddEditHistory_tasks.xaml
    /// </summary>
    public partial class AddEditHistory_tasks : Window
    {
        private History_tasks _currentHistoryTask = new History_tasks();

        public AddEditHistory_tasks()
        {
            InitializeComponent();
            DataContext = _currentHistoryTask;
            LoadComboBoxData();

        }
        public AddEditHistory_tasks(dynamic selectedHistoryTask)
        {
            InitializeComponent();

            if (selectedHistoryTask != null)
                _currentHistoryTask = selectedHistoryTask;

            DataContext = _currentHistoryTask;
            LoadPreviousData();
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            cb_Tasks.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Tasks.Select(t => t.Topic).ToList();
        }

        private void LoadPreviousData()
        {
            CheckBox_Completed.IsChecked = _currentHistoryTask.Сompleted;
            CheckBox_OnTime.IsChecked = _currentHistoryTask.On_time;
            cb_Tasks.SelectedItem = _currentHistoryTask.Tasks.Topic;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            SaveHistoryTask();
        }

        private void SaveHistoryTask()
        {
            string selectedTaskTopic = cb_Tasks.SelectedItem?.ToString();
            var selectedTask = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Tasks.FirstOrDefault(t => t.Topic == selectedTaskTopic);

            if (selectedTask != null)
            {
                _currentHistoryTask.Tasks_ID = selectedTask.ID_Tasks;
            }

            _currentHistoryTask.Сompleted = CheckBox_Completed.IsChecked ?? false;
            _currentHistoryTask.On_time = CheckBox_OnTime.IsChecked ?? false;

            StringBuilder errors = new StringBuilder();

            if (_currentHistoryTask.Tasks_ID == 0)
                errors.AppendLine("Укажите задачу");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return;
            }

            if (_currentHistoryTask.ID_History_tasks == 0)
            {
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().History_tasks.Add(_currentHistoryTask);
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
