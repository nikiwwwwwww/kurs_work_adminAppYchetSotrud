using LiveCharts.Wpf;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для GraghWindow.xaml
    /// </summary>
    public partial class GraghWindow : Window
    {

        public List<ISeries<int>> Series { get; set; } = new List<ISeries<int>>();

        public GraghWindow()
        {
            InitializeComponent();

            var employeeWithPostCount = IS_YchetSotrudnikovYpravleniePersonalomEntities
            .GetContext()
            .Employe
            .Join(
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post_Employe,
                employee => employee.ID_Employe,
                postEmployee => postEmployee.Employe_ID,
                (employee, postEmployee) => new { employee, postEmployee }
            )
            .Join(
                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post,
                joined => joined.postEmployee.Post_ID,
                post => post.ID_Post,
                (joined, post) => new { joined.employee, post.Name_post }
            )
            .GroupBy(joined => joined.Name_post)
            .Select(group => new
            {
                PostName = group.Key,
                EmployeeCount = group.Count()
            })
            .ToList();

            foreach (var item in employeeWithPostCount)
            {
                var ser = new PieSeries<int> { Values = new int[] { item.EmployeeCount }, Name = item.PostName };
                Series.Add(ser);
            }

            Pie.Series = Series;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }
    }
}
