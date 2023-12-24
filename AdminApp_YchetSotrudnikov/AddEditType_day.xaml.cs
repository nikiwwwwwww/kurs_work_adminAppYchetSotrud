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
    /// Логика взаимодействия для AddEditType_day.xaml
    /// </summary>
    public partial class AddEditType_day : Window
    {
        private Type_day _currentTypeDay = new Type_day();

        public AddEditType_day()
        {
            InitializeComponent();
            DataContext = _currentTypeDay;

        }

        public AddEditType_day(dynamic selectedTypeDay)
        {
            InitializeComponent();

            if (selectedTypeDay != null)
                _currentTypeDay = selectedTypeDay;

            DataContext = _currentTypeDay;

            LoadTypeDayData();
        }
        private void LoadTypeDayData()
        {
            TB_TypeOfDay.Text = _currentTypeDay.Type_of_day;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveTypeDay();
        }

        private void SaveTypeDay()
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_currentTypeDay.Type_of_day))
                errors.AppendLine("Укажите тип дня");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return;
            }

            if (_currentTypeDay.ID_Type_day == 0)
            {
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Type_day.Add(_currentTypeDay);
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
