using LiveChartsCore.Geo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using static AdminApp_YchetSotrudnikov.MainWindow;

namespace AdminApp_YchetSotrudnikov
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        //admin admin
        //kadrovik kadrovik
        //nachalnik nachalnik
        //buchgalter buchgalter


        Employe employe;
        Hash hash = new Hash();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                employe = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe.FirstOrDefault(x => x.Login == TB_login.Text);

                if (employe != null && hash.AreEqual(TB_password.Text, employe.Password, employe.SOLI))
                {
                    Post_Employe post_employe = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post_Employe.FirstOrDefault(x => x.Employe_ID == employe.ID_Employe);

                    Post post = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post.FirstOrDefault(x => x.ID_Post == post_employe.Post_ID);

                    switch (post.Name_post.ToLower().ToString())
                    {
                        case "администратор":
                            MainWindow windowForAdmin = new MainWindow("администратор");
                            windowForAdmin.Show();
                            this.Close();
                            break;
                        case "кадровик":
                            MainWindow windowForKadrovik = new MainWindow("кадровик");
                            windowForKadrovik.Show();
                            this.Close();
                            break;
                        case "бухгалтер":
                            MainWindow windowForBuhgalter = new MainWindow("бухгалтер");
                            windowForBuhgalter.Show();
                            this.Close();
                            break;
                        case "начальник":
                            MainWindow windowForNachalnik = new MainWindow("руководитель");
                            windowForNachalnik.Show();
                            this.Close();
                            break;
                        default:
                            MainWindow windowForUser = new MainWindow("user");
                            windowForUser.Show();
                            this.Close();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Вы не зарегистрированы в системе!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow regWindow = new RegistrationWindow();
            regWindow.Show();
        }
    
    }
}
