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
    /// Логика взаимодействия для AddEditSick.xaml
    /// </summary>
    public partial class AddEditSick : Window
    {

        private Sick _currentSick = new Sick();

        public AddEditSick()
        {
            InitializeComponent();
            DataContext = _currentSick;
        }
        public AddEditSick(dynamic selectedSick)
        {
            InitializeComponent();

            if (selectedSick != null)
                _currentSick = selectedSick;
                
            if(_currentSick.Ill == true)
            {
                cb_IsSick.IsChecked = true;
            }
            DataContext = _currentSick;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(cb_IsSick.IsChecked == false)
            {
                _currentSick.Ill = false;
            }
            else _currentSick.Ill = true;


            StringBuilder errors = new StringBuilder();

            if (_currentSick.Sick_for_days <= 0)
                errors.AppendLine("Укажите количество дней болезни");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return;
            }


            if (_currentSick.ID_Sick == 0)
            {
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Sick.Add(_currentSick);
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
