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
    /// Логика взаимодействия для AddEditEducation.xaml
    /// </summary>
    public partial class AddEditEducation : Window
    {
        private Education _currentEducation = new Education();

        public AddEditEducation()
        {
            InitializeComponent();
            DataContext = _currentEducation;
        }

        public AddEditEducation(dynamic selectedEducation)
        {
            InitializeComponent();

            if (selectedEducation != null)
            {
                _currentEducation = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Education.Find(selectedEducation.ID_Education);

            }

            DataContext = _currentEducation;
        }

        

            private void Button_Save_Click(object sender, RoutedEventArgs e)
            {
                SaveEducation();
            }

            private void SaveEducation()
            {
                StringBuilder errors = new StringBuilder();

                if (string.IsNullOrWhiteSpace(_currentEducation.Type_of_education))
                    errors.AppendLine("Укажите тип образования");

                if (string.IsNullOrWhiteSpace(_currentEducation.Specialization))
                    errors.AppendLine("Укажите специализацию");

                if (string.IsNullOrWhiteSpace(_currentEducation.Institution))
                    errors.AppendLine("Укажите учебное заведение");

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Ошибка");
                    return;
                }

                if (_currentEducation.ID_Education == 0)
                {
                    IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Education.Add(_currentEducation);
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

