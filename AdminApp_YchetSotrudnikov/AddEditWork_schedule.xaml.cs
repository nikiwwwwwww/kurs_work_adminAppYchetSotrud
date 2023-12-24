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
    /// Логика взаимодействия для AddEditWork_schedule.xaml
    /// </summary>
    public partial class AddEditWork_schedule : Window
    {
        private Work_schedule _currentWorkSchedule = new Work_schedule();

        public AddEditWork_schedule()
        {
            InitializeComponent();
            DataContext = _currentWorkSchedule;

        }
        public AddEditWork_schedule(dynamic selectedWorkSchedule)
        {
            InitializeComponent();

            if (selectedWorkSchedule != null)
                _currentWorkSchedule = selectedWorkSchedule;

            DataContext = _currentWorkSchedule;

            // Заполнение элементов управления значениями из объекта
            DatePicker_Day.SelectedDate = _currentWorkSchedule.Day;
            TimePicker_Start.Value = DateTime.Today.Add(_currentWorkSchedule.Time_start_working_day);
            TimePicker_End.Value = DateTime.Today.Add(_currentWorkSchedule.Time_end_working_day);
            CheckBox_FullTime.IsChecked = _currentWorkSchedule.Full_time;
            TextBox_AvailablePlaces.Text = _currentWorkSchedule.Available_places.ToString();
            TextBox_Break.Text = _currentWorkSchedule.@break.ToString();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            SaveWorkSchedule();
        }

        private void SaveWorkSchedule()
        {
            // Заполнение значений в объекте Work_schedule
            _currentWorkSchedule.Day = DatePicker_Day.SelectedDate ?? DateTime.MinValue;
            _currentWorkSchedule.Time_start_working_day = TimePicker_Start.Value?.TimeOfDay ?? new TimeSpan();
            _currentWorkSchedule.Time_end_working_day = TimePicker_End.Value?.TimeOfDay ?? new TimeSpan();
            _currentWorkSchedule.Full_time = CheckBox_FullTime.IsChecked ?? false;

            if (int.TryParse(TextBox_AvailablePlaces.Text, out int availablePlaces))
                _currentWorkSchedule.Available_places = availablePlaces;

            if (int.TryParse(TextBox_Break.Text, out int breakTime))
                _currentWorkSchedule.@break = breakTime;

            StringBuilder errors = new StringBuilder();

            // Проверка наличия ошибок перед сохранением
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return;
            }

            // Добавление нового объекта или сохранение изменений
            if (_currentWorkSchedule.ID_Work_schedule == 0)
            {
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Work_schedule.Add(_currentWorkSchedule);
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
