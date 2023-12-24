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
    /// Логика взаимодействия для Work_schedule_Employe.xaml
    /// </summary>
    public partial class AddEditWork_schedule_Employe : Window
    {
        private Work_schedule_Employe _currentWork_schedule = new Work_schedule_Employe();

        public AddEditWork_schedule_Employe()
        {
            InitializeComponent();


            DataContext = _currentWork_schedule;
            LoadComboBoxData();
        }
        public AddEditWork_schedule_Employe(dynamic selectedPostEmploye)
        {
            InitializeComponent();

            if (selectedPostEmploye != null)
            {
                _currentWork_schedule = selectedPostEmploye;
                cb_Employe.SelectedItem = _currentWork_schedule.Employe.Login;
                cb_WorkSchedule.SelectedItem = _currentWork_schedule.Work_schedule.Day;
            }
            DataContext = _currentWork_schedule;
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            var context = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext();

            // Загрузка данных в ComboBox
            cb_Employe.ItemsSource = context.Employe.Select(e => e.Login).ToList();
            cb_WorkSchedule.ItemsSource = context.Work_schedule.Select(p => p.Day).ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получение выбранных значений из ComboBox
            string selectedEmploye = cb_Employe.SelectedItem?.ToString();
            var selectedWork_schedule_day = cb_WorkSchedule.SelectedItem as DateTime?;

            // Поиск соответствующих записей в базе данных
            var selectedEmployeObj = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe.FirstOrDefault(x => x.Login == selectedEmploye);
            var selecteddWork_schedule_dayObj = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Work_schedule.FirstOrDefault(x => x.Day == selectedWork_schedule_day);

            // Заполнение ID в текущем объекте Post_Employe
            if (selectedEmployeObj != null)
                _currentWork_schedule.Employe_ID = selectedEmployeObj.ID_Employe;

            if (selecteddWork_schedule_dayObj != null)
                _currentWork_schedule.Work_schedule_ID = selecteddWork_schedule_dayObj.ID_Work_schedule;


            // Проверка обязательных полей
            StringBuilder errors = new StringBuilder();

            if (_currentWork_schedule.Employe_ID == null)
                errors.AppendLine("Укажите сотрудника");

            if (_currentWork_schedule.Work_schedule_ID == null)
                errors.AppendLine("Укажите должность");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return;
            }

            // Сохранение данных
            if (_currentWork_schedule.ID_Work_schedule_employe == 0)
            {
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Work_schedule_Employe.Add(_currentWork_schedule);
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
