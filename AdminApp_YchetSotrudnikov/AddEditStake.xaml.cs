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
    /// Логика взаимодействия для AddEditStavka.xaml
    /// </summary>
    public partial class AddEditStake : Window
    {

        private Stake _curentStake = new Stake();

        public AddEditStake()
        {
            InitializeComponent();

            DataContext = _curentStake;
        }

        public AddEditStake(dynamic selectedStake)
        {
            InitializeComponent();

            if (selectedStake != null)
                _curentStake = selectedStake;

            DataContext = _curentStake;
        }

        

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            double? paymentPerShift = _curentStake.Payment_per_shift;
            int? Count_days_worked = _curentStake.Count_days_worked;
            DateTime? Date_of_salary = _curentStake.Date_of_salary;
            double? Payment_per_day = _curentStake.Payment_per_shift;


            if (!paymentPerShift.HasValue || paymentPerShift.Value == 0.0 || paymentPerShift.Value < 0)
                errors.AppendLine("Укажите оплату за час");
            if (Count_days_worked < 0 || !Count_days_worked.HasValue)
                errors.AppendLine("Укажите количество отработанных дней");
            if (!Date_of_salary.HasValue)
                errors.AppendLine("Укажите дату выдачи зарплаты");
            if (!Payment_per_day.HasValue)
                errors.AppendLine("Укажите оплату за час");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_curentStake.ID_Stake == 0)
            {
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Stake.Add(_curentStake);
            }

            try
            {
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();

                MainWindow main = new MainWindow(null);

                MessageBox.Show("Информация сохранена коректно!");



                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }



        }
    }
}
