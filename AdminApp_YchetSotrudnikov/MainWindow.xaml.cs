using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AdminApp_YchetSotrudnikov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string? role)
        {
            InitializeComponent();

            if (Role == "")
            {
                Role = role;
            }

            switch (Role)
            {
                case "администратор":

                    break;

                case "кадровик":

                    menuInMenu.Visibility = Visibility.Hidden;

                    Btn_departament.Visibility = Visibility.Visible;
                    Btn_education.Visibility = Visibility.Visible;
                    Btn_educationEmploye.Visibility = Visibility.Visible;
                    Btn_emloye.Visibility = Visibility.Visible;
                    Btn_graghrabotEmploye.Visibility = Visibility.Visible;
                    Btn_post.Visibility = Visibility.Visible;
                    Btn_postEmploye.Visibility = Visibility.Visible;
                    Btn_sallary.Visibility = Visibility.Visible;

                    Btn_gragh_rabot.Visibility = Visibility.Hidden;
                    Btn_historytask.Visibility = Visibility.Hidden;
                    Btn_LogTable.Visibility = Visibility.Hidden;
                    Btn_sick.Visibility = Visibility.Hidden;
                    Btn_stavka.Visibility = Visibility.Hidden;
                    Btn_tip_dny.Visibility = Visibility.Hidden;
                    Btn_zadania.Visibility = Visibility.Hidden;
                    Btn_zadanieEmploye.Visibility = Visibility.Hidden;
                    break;
                case "бухгалтер":
                    menuInMenu.Visibility = Visibility.Hidden;

                    Btn_departament.Visibility = Visibility.Hidden;
                    Btn_education.Visibility = Visibility.Hidden;
                    Btn_educationEmploye.Visibility = Visibility.Hidden;
                    Btn_post.Visibility = Visibility.Hidden;
                    Btn_historytask.Visibility = Visibility.Hidden;
                    Btn_LogTable.Visibility = Visibility.Hidden;
                    Btn_zadania.Visibility = Visibility.Hidden;
                    Btn_zadanieEmploye.Visibility = Visibility.Hidden;

                    Btn_gragh_rabot.Visibility = Visibility.Visible;
                    Btn_tip_dny.Visibility = Visibility.Visible;
                    Btn_emloye.Visibility = Visibility.Visible;
                    Btn_postEmploye.Visibility = Visibility.Visible;
                    Btn_graghrabotEmploye.Visibility = Visibility.Visible;
                    Btn_sallary.Visibility = Visibility.Visible;
                    Btn_sick.Visibility = Visibility.Visible;
                    Btn_stavka.Visibility = Visibility.Visible;
                    break;
                case "руководитель":
                    menuInMenu.Visibility = Visibility.Hidden;

                    Btn_departament.Visibility = Visibility.Hidden;
                    Btn_education.Visibility = Visibility.Hidden;
                    Btn_educationEmploye.Visibility = Visibility.Hidden;
                    Btn_emloye.Visibility = Visibility.Hidden;
                    Btn_post.Visibility = Visibility.Hidden;
                    Btn_gragh_rabot.Visibility = Visibility.Hidden;
                    Btn_LogTable.Visibility = Visibility.Hidden;
                    Btn_tip_dny.Visibility = Visibility.Hidden;
                    Btn_sallary.Visibility = Visibility.Hidden;
                    Btn_sick.Visibility = Visibility.Hidden;
                    Btn_stavka.Visibility = Visibility.Hidden;

                    Btn_zadania.Visibility = Visibility.Visible;
                    Btn_postEmploye.Visibility = Visibility.Visible;
                    Btn_graghrabotEmploye.Visibility = Visibility.Visible;
                    Btn_zadanieEmploye.Visibility = Visibility.Visible;
                    Btn_historytask.Visibility = Visibility.Visible;
                    break;
                default:
                    menuInMenu.Visibility = Visibility.Hidden;

                    Btn_departament.Visibility = Visibility.Hidden;
                    Btn_education.Visibility = Visibility.Hidden;
                    Btn_educationEmploye.Visibility = Visibility.Hidden;
                    Btn_emloye.Visibility = Visibility.Hidden;
                    Btn_post.Visibility = Visibility.Hidden;
                    Btn_gragh_rabot.Visibility = Visibility.Hidden;
                    Btn_LogTable.Visibility = Visibility.Hidden;
                    Btn_tip_dny.Visibility = Visibility.Hidden;
                    Btn_sallary.Visibility = Visibility.Hidden;
                    Btn_sick.Visibility = Visibility.Hidden;
                    Btn_stavka.Visibility = Visibility.Hidden;
                    Btn_zadania.Visibility = Visibility.Hidden;
                    Btn_postEmploye.Visibility = Visibility.Hidden;
                    Btn_historytask.Visibility = Visibility.Hidden;
                    Btn_graghrabotEmploye.Visibility = Visibility.Visible;
                    Btn_zadanieEmploye.Visibility = Visibility.Visible;
                    break;
            }
        }

        public string NameTable = String.Empty;

        public string Role = "";

        public string GetRole()
        {
            return Role;
        }

        public void SetRole(string role)
        {
            Role = role;
        }

        private void Button_Stake_Click(object sender, RoutedEventArgs e)
        {
            int size = Dg_Stake.Columns.Count;

            switch (Role)
            {
                case "администратор":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Stake.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "кадровик":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Stake.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "бухгалтер":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Stake.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "руководитель":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Stake.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                default:
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Stake.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
            }
            VisibleDataGrid("Stake");
            GetVisibleTable("Stake");
            Dg_Stake.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Stake.ToList();

            CB_Seach.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Stake.Select(pe => pe.Payment_per_day).ToList();
        }

        private void Button_Zarplata_Click(object sender, RoutedEventArgs e)
        {
            int size = Dg_Sallary.Columns.Count;

            switch (Role)
            {
                case "администратор":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Sallary.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "кадровик":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Sallary.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "бухгалтер":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Sallary.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "руководитель":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Sallary.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                default:
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Sallary.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
            }
            VisibleDataGrid("Sallary");
            GetVisibleTable("Sallary");

            Dg_Sallary.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Sallary.ToList();

            CB_Seach.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Sallary.Select(pe => pe.Stake.Payment_per_day).ToList();
        }

        private void Button_Bolnichni_Click(object sender, RoutedEventArgs e)
        {
            int size = Dg_Sick.Columns.Count;

            switch (Role)
            {
                case "администратор":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Sick.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "кадровик":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Sick.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "бухгалтер":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Sick.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "руководитель":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Sick.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                default:
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Sick.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
            }
            VisibleDataGrid("Sick");
            GetVisibleTable("Sick");

            Dg_Sick.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Sick.ToList();

            CB_Seach.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Sick.Select(pe => pe.Ill).ToList();
        }

        private void Button_Otdel_Click(object sender, RoutedEventArgs e)
        {
            int size = Dg_Department.Columns.Count;

            switch (Role)
            {
                case "администратор":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Department.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "кадровик":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Department.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "бухгалтер":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Department.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "руководитель":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Department.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                default:
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Department.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
            }
            VisibleDataGrid("Department");
            GetVisibleTable("Department");

            Dg_Department.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Department.ToList();

            CB_Seach.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Department.Select(pe => pe.Name_departament).ToList();
        }

        private void Button_Doljn_Click(object sender, RoutedEventArgs e)
        {
            int size = Dg_Post.Columns.Count;

            switch (Role)
            {
                case "администратор":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Post.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "кадровик":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Post.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "бухгалтер":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Post.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "руководитель":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Post.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                default:
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Post.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
            }
            VisibleDataGrid("Post");
            GetVisibleTable("Post");

            Dg_Post.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post.ToList();

            CB_Seach.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post.Select(pe => pe.Name_post).ToList();
        }

        private void Button_DoljnSotrud_Click(object sender, RoutedEventArgs e)
        {

            int size = Dg_Post_Employe.Columns.Count;

            switch (Role)
            {
                case "администратор":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Post_Employe.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "кадровик":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Post_Employe.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "бухгалтер":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Post_Employe.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "руководитель":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Post_Employe.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                default:
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Post_Employe.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
            }
            VisibleDataGrid("Post_Employe");
            GetVisibleTable("Post_Employe");

            Dg_Post_Employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post_Employe.ToList();

            CB_Seach.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post_Employe.Select(pe => pe.Post.Name_post).ToList();
        }

        private void Button_Sotrud_Click(object sender, RoutedEventArgs e)
        {
            int size = Dg_Employe.Columns.Count;

            switch (Role)
            {
                case "администратор":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Employe.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "кадровик":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Employe.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "бухгалтер":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Employe.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "руководитель":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Employe.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                default:
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Employe.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
            }
            VisibleDataGrid("Employe");
            GetVisibleTable("Employe");

            Dg_Employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe.ToList();

            CB_Seach.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe.Select(pe => pe.Date_of_employment).ToList();
        }

        private void Button_ObrazovSotrud_Click(object sender, RoutedEventArgs e)
        {
            int size = Dg_Education_employe.Columns.Count;

            switch (Role)
            {
                case "администратор":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Education_employe.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "кадровик":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Education_employe.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "бухгалтер":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Education_employe.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "руководитель":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Education_employe.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                default:
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Education_employe.Columns[size].Visibility = Visibility.Hidden;
                    break;
            }
            VisibleDataGrid("Education_employe");
            GetVisibleTable("Education_employe");

            Dg_Education_employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Education_employe.ToList();

            CB_Seach.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Education_employe.Select(pe => pe.Education.Specialization).ToList();
        }

        private void Button_Obraz_Click(object sender, RoutedEventArgs e)
        {
            int size = Dg_Education_employe.Columns.Count;

            switch (Role)
            {
                case "администратор":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Education.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "кадровик":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Education.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "бухгалтер":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Education.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "руководитель":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Education.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                default:
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Education.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
            }
            VisibleDataGrid("Education");
            GetVisibleTable("Education");

            Dg_Education.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Education.ToList();

            CB_Seach.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Education.Select(pe => pe.Specialization).ToList();
        }

        private void Button_GraphSotrud_Click(object sender, RoutedEventArgs e)
        {
            int size = Dg_Work_schedule_Employe.Columns.Count;

            switch (Role)
            {
                case "администратор":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Work_schedule_Employe.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "кадровик":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Work_schedule_Employe.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "бухгалтер":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Work_schedule_Employe.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "руководитель":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Work_schedule_Employe.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                default:
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Work_schedule_Employe.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
            }
            VisibleDataGrid("Work_schedule_Employe");
            GetVisibleTable("Work_schedule_Employe");

            Dg_Work_schedule_Employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Work_schedule_Employe.ToList();

            CB_Seach.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Work_schedule_Employe.Select(pe => pe.Work_schedule.Time_start_working_day).ToList();
        }

        private void Button_Graph_Click(object sender, RoutedEventArgs e)
        {
            int size = Dg_Work_schedule.Columns.Count;

            switch (Role)
            {
                case "администратор":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Work_schedule.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "кадровик":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Work_schedule.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "бухгалтер":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Work_schedule.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "руководитель":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Work_schedule.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                default:
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Work_schedule.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
            }
            VisibleDataGrid("Work_schedule");
            GetVisibleTable("Work_schedule");

            Dg_Work_schedule.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Work_schedule.ToList();

            CB_Seach.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Work_schedule.Select(pe => pe.Time_start_working_day).ToList();
        }

        private void Button_TipDny_Click(object sender, RoutedEventArgs e)
        {
            int size = Dg_Type_day.Columns.Count;

            switch (Role)
            {
                case "администратор":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Type_day.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "кадровик":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Type_day.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "бухгалтер":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Type_day.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "руководитель":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Type_day.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                default:
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Type_day.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
            }
            VisibleDataGrid("Type_day");
            GetVisibleTable("Type_day");

            Dg_Type_day.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Type_day.ToList();

            CB_Seach.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Type_day.Select(pe => pe.Type_of_day).ToList();
        }

        private void Button_ZadaniaSotrud_Click(object sender, RoutedEventArgs e)
        {
            int size = Dg_Employe_Tasks.Columns.Count;

            switch (Role)
            {
                case "администратор":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Employe_Tasks.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "кадровик":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Employe_Tasks.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "бухгалтер":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Employe_Tasks.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "руководитель":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Employe_Tasks.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                default:
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Employe_Tasks.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
            }
            VisibleDataGrid("Employe_Tasks");
            GetVisibleTable("Employe_Tasks");

            Dg_Employe_Tasks.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe_Tasks.ToList();

            CB_Seach.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe_Tasks.Select(pe => pe.Tasks.Date_of_end).ToList();
        }

        private void Button_Zadania_Click(object sender, RoutedEventArgs e)
        {
            int size = Dg_Tasks.Columns.Count;

            switch (Role)
            {
                case "администратор":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Tasks.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "кадровик":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Tasks.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "бухгалтер":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Tasks.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "руководитель":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_Tasks.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                default:
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_Tasks.Columns[size].Visibility = Visibility.Hidden;
                    break;
            }
            VisibleDataGrid("Tasks");
            GetVisibleTable("Tasks");

            Dg_Tasks.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Tasks.ToList();

            CB_Seach.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Tasks.Select(pe => pe.Complexity).ToList();
        }

        private void Button_IstoriaZadania_Click(object sender, RoutedEventArgs e)
        {
            int size = Dg_History_tasks.Columns.Count;

            switch (Role)
            {
                case "администратор":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_History_tasks.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "кадровик":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_History_tasks.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "бухгалтер":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_History_tasks.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "руководитель":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_History_tasks.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                default:
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_History_tasks.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
            }
            VisibleDataGrid("History_tasks");
            GetVisibleTable("History_tasks");

            Dg_History_tasks.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().History_tasks.ToList();

            CB_Seach.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().History_tasks.Select(pe => pe.On_time).ToList();
        }

        private void Button_LogTable_Click(object sender, RoutedEventArgs e)
        {
            int size = Dg_History_tasks.Columns.Count;

            switch (Role)
            {
                case "администратор":
                    Btn_Add.Visibility = Visibility.Visible;
                    Btn_Del.Visibility = Visibility.Visible;
                    Dg_History_tasks.Columns[size - 1].Visibility = Visibility.Visible;
                    break;
                case "кадровик":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_History_tasks.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "бухгалтер":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_History_tasks.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                case "руководитель":
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_History_tasks.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
                default:
                    Btn_Add.Visibility = Visibility.Hidden;
                    Btn_Del.Visibility = Visibility.Hidden;
                    Dg_History_tasks.Columns[size - 1].Visibility = Visibility.Hidden;
                    break;
            }
            VisibleDataGrid("LogTable");
            GetVisibleTable("LogTable");

            Dg_LogTable.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().LogTable.ToList();

            CB_Seach.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().LogTable.Select(pe => pe.LogMessage).ToList();
        }

        private void SearchTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            var allDataGrids = G_glav.Children.OfType<DataGrid>();
            foreach (var dataGrid in allDataGrids)
            {
                if (dataGrid.Visibility == Visibility.Visible)
                {
                    if (Equals(dataGrid.Name, "Dg_Tasks"))
                    {
                        Dg_Tasks.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Tasks
                        .ToList()
                        .Where(x => x.Topic.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Complexity.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Date_of_issue)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Employe"))
                    {

                        if(CB_Seach.SelectedValue == null)
                        {
                            Dg_Employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                            .GetContext()
                            .Employe
                            .ToList()
                            .Where(x => x.Login.Contains(TB_Seach.Text))
                            .ToList();
                        }
                        else
                        {
                            Dg_Employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                               .GetContext()
                               .Employe
                               .ToList()
                               .Where(x => x.Login.Contains(TB_Seach.Text))
                               .ToList()
                               .Where(x => x.Date_of_employment.Equals(CB_Seach.SelectedValue))
                               .ToList()
                               .OrderBy(x => x.Last_name)
                               .ToList();
                        }
                       
                    }
                    if (Equals(dataGrid.Name, "Dg_Stake"))
                    {

                        Dg_Stake.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                       .GetContext()
                       .Stake
                       .ToList()
                       .Where(x => Convert.ToString(x.Payment_per_day).Contains(TB_Seach.Text))
                       .ToList()
                       .Where(x => x.Payment_per_day.Equals(CB_Seach.SelectedValue))
                       .ToList()
                       .OrderBy(x => x.Date_of_salary)
                       .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Sallary"))
                    {
                        Dg_Sallary.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Sallary
                        .Where(s => s.Post_Employe.Employe.Login.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(s => s.Stake.Payment_per_day.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(s => s.Post_Employe.Employe.Login)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Sick"))
                    {
                        Dg_Sick.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Sick
                        .Where(x => x.Ill.ToString().Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Ill.ToString().Equals(CB_Seach.SelectedValue.ToString()))
                        .ToList()
                        .OrderBy(x => x.Sick_for_days)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Department"))
                    {
                        Dg_Department.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                       .GetContext()
                       .Department
                       .ToList()
                       .Where(x => x.Name_departament.Contains(TB_Seach.Text))
                       .ToList()
                       .Where(x => x.Name_departament.Equals(CB_Seach.SelectedValue))
                       .ToList()
                       .OrderBy(x => x.Name_departament)
                       .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Post"))
                    {
                        Dg_Post.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Post
                        .ToList()
                        .Where(x => x.Name_post.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Name_post.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Name_post)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Post_Employe"))
                    {
                        Dg_Post_Employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Post_Employe
                        .ToList()
                        .Where(x => x.Employe.Login.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Post.Name_post.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Employe.Login)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Education_employe"))
                    {
                        Dg_Education_employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Education_employe
                        .ToList()
                        .Where(x => x.Employe.Login.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Education.Specialization.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Employe.Login)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Education"))
                    {
                        Dg_Education.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Education
                        .ToList()
                        .Where(x => x.Specialization.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Specialization.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Institution).ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Work_schedule_Employe"))
                    {
                        Dg_Work_schedule_Employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Work_schedule_Employe
                        .ToList()
                        .Where(x => x.Employe.Login.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Work_schedule.Time_start_working_day.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Employe.Login)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Work_schedule"))
                    {
                        Dg_Work_schedule.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Work_schedule
                        .ToList()
                        .Where(x => x.Day.ToString().Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Time_start_working_day.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Available_places)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Type_day"))
                    {
                        Dg_Type_day.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Type_day
                        .ToList()
                        .Where(x => x.Type_of_day.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Type_of_day.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Type_of_day)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Employe_Tasks"))
                    {
                        Dg_Employe_Tasks.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Employe_Tasks
                        .ToList()
                        .Where(x => x.Employe.Login.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Tasks.Date_of_end.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Employe.Login)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_History_tasks"))
                    {
                        Dg_History_tasks.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .History_tasks
                        .ToList()
                        .Where(x => x.Tasks.Topic.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.On_time.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Tasks.Topic)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_LogTable"))
                    {
                        Dg_LogTable.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .LogTable
                        .ToList()
                        .Where(x => x.LogMessage.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.LogMessage.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.LogDateTime)
                        .ToList();
                    }

                }
            }
        }

        private void Filtr_Click(object sender, RoutedEventArgs e)
        {
            var allDataGrids = G_glav.Children.OfType<DataGrid>();
            foreach (var dataGrid in allDataGrids)
            {
                if (dataGrid.Visibility == Visibility.Visible)
                {
                    if (Equals(dataGrid.Name, "Dg_Tasks"))
                    {
                        Dg_Tasks.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Tasks
                        .ToList()
                        .Where(x => x.Topic.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Complexity.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Date_of_issue)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Employe"))
                    {
                        Dg_Employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Employe
                        .ToList()
                        .Where(x => x.Login.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Date_of_employment.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Last_name)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Stake"))
                    {

                        Dg_Stake.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                       .GetContext()
                       .Stake
                       .ToList()
                       .Where(x => Convert.ToString(x.Payment_per_day).Contains(TB_Seach.Text))
                       .ToList()
                       .Where(x => x.Payment_per_day.Equals(CB_Seach.SelectedValue))
                       .ToList()
                       .OrderBy(x => x.Date_of_salary)
                       .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Sallary"))
                    {
                        Dg_Sallary.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Sallary
                        .Where(s => s.Post_Employe.Employe.Login.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(s => s.Stake.Payment_per_day.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(s => s.Post_Employe.Employe.Login)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Sick"))
                    {
                        Dg_Sick.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Sick
                        .Where(x => x.Ill.ToString().Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Ill.ToString().Equals(CB_Seach.SelectedValue.ToString()))
                        .ToList()
                        .OrderBy(x => x.Sick_for_days)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Department"))
                    {
                        Dg_Department.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                       .GetContext()
                       .Department
                       .ToList()
                       .Where(x => x.Name_departament.Contains(TB_Seach.Text))
                       .ToList()
                       .Where(x => x.Name_departament.Equals(CB_Seach.SelectedValue))
                       .ToList()
                       .OrderBy(x => x.Name_departament)
                       .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Post"))
                    {
                        Dg_Post.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Post
                        .ToList()
                        .Where(x => x.Name_post.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Name_post.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Name_post)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Post_Employe"))
                    {
                        Dg_Post_Employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Post_Employe
                        .ToList()
                        .Where(x => x.Employe.Login.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Post.Name_post.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Employe.Login)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Education_employe"))
                    {
                        Dg_Education_employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Education_employe
                        .ToList()
                        .Where(x => x.Employe.Login.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Education.Specialization.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Employe.Login)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Education"))
                    {
                        Dg_Education.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Education
                        .ToList()
                        .Where(x => x.Specialization.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Specialization.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Institution).ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Work_schedule_Employe"))
                    {
                        Dg_Work_schedule_Employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Work_schedule_Employe
                        .ToList()
                        .Where(x => x.Employe.Login.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Work_schedule.Time_start_working_day.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Employe.Login)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Work_schedule"))
                    {
                        Dg_Work_schedule.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Work_schedule
                        .ToList()
                        .Where(x => x.Day.ToString().Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Time_start_working_day.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Available_places)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Type_day"))
                    {
                        Dg_Type_day.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Type_day
                        .ToList()
                        .Where(x => x.Type_of_day.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Type_of_day.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Type_of_day)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_Employe_Tasks"))
                    {
                        Dg_Employe_Tasks.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .Employe_Tasks
                        .ToList()
                        .Where(x => x.Employe.Login.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.Tasks.Date_of_end.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Employe.Login)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_History_tasks"))
                    {
                        Dg_History_tasks.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .History_tasks
                        .ToList()
                        .Where(x => x.Tasks.Topic.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.On_time.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.Tasks.Topic)
                        .ToList();
                    }
                    if (Equals(dataGrid.Name, "Dg_LogTable"))
                    {
                        Dg_LogTable.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities
                        .GetContext()
                        .LogTable
                        .ToList()
                        .Where(x => x.LogMessage.Contains(TB_Seach.Text))
                        .ToList()
                        .Where(x => x.LogMessage.Equals(CB_Seach.SelectedValue))
                        .ToList()
                        .OrderBy(x => x.LogDateTime)
                        .ToList();
                    }

                }
            }
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {

            MenuItem menuItem = (MenuItem)sender;
            MessageBox.Show(menuItem.Header.ToString());
        }

        private void BackUp_Click(object sender, RoutedEventArgs e)
        {
            CreateBackup();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                Title = "Save CSV File"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                ExportTableToCSV(NameTable, filePath);
            }
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {

                Filter = "CSV files (*.csv)|*.csv",
                Title = "Open CSV File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                //ImportCSVData(filePath, NameTable);
            }
        }

        private void Gragh_Click(object sender, RoutedEventArgs e)
        {
            GraghWindow graghWindow = new GraghWindow();
            graghWindow.Show();
        }

        private string GetVisibleTable(string NameDataGrid)
        {
            var allDataGrids = G_glav.Children.OfType<DataGrid>();

            foreach (var dataGrid in allDataGrids)
            {
                if (dataGrid.Visibility == Visibility.Visible)
                {
                    return NameTable = dataGrid.Name.Substring(3);
                }
            }
            return "";
        }

        static void ExportTableToCSV(string tableName, string exportFilePath)
        {

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.Commercial;

                using (var package = new ExcelPackage())
                {
                    ExcelPackage.LicenseContext = LicenseContext.Commercial;

                    var worksheet = package.Workbook.Worksheets.Add(tableName);

                    using (SqlConnection connection = new SqlConnection(GetServerName()))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand($"SELECT * FROM {tableName}", connection);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int col = 1;
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                worksheet.Cells[1, col++].Value = reader.GetName(i);
                            }

                            int row = 2;
                            while (reader.Read())
                            {
                                col = 1;
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    worksheet.Cells[row, col++].Value = reader[i];
                                }
                                row++;
                            }
                        }
                    }

                    package.SaveAs(new FileInfo(exportFilePath));
                }

                MessageBox.Show("Экспорт успешно завершен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        public static void CreateBackup()
        {
            try
            {
                string backupFilePath = @"C:\Program Files\Microsoft SQL Server\MSSQL14.MYSERVER\MSSQL\Backup\IS_YchetSotrudnikovYpravleniePersonalom.bak";
                string databaseName = "IS_YchetSotrudnikovYpravleniePersonalom";

                string backupQuery = $"BACKUP DATABASE [{databaseName}] TO DISK = '{backupFilePath}'";

                string connectionString = GetServerName();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(backupQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Резервная копия базы данных {databaseName} создана успешно в файле {backupFilePath}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании резервной копии: {ex.Message}");
            }
        }

        static string GetServerName()
        {
            return "Server=DESKTOP-6LE7OLB\\MYSERVER;Database=IS_YchetSotrudnikovYpravleniePersonalom;User Id=sa;Password=1234;";
        }

        private void Btn_edit_zarplata_click(object sender, RoutedEventArgs e)
        {
            var allDataGrids = G_glav.Children.OfType<DataGrid>();

            foreach (var dataGrid in allDataGrids)
            {
                if (dataGrid.Visibility == Visibility.Visible)
                {
                    string dataGridNameWithoutPrefix = dataGrid.Name.StartsWith("Dg_")
                                ? dataGrid.Name.Substring(3)
                                : dataGrid.Name;


                    string windowClassName = "AddEdit" + dataGridNameWithoutPrefix;

                    Type windowType = Type.GetType("AdminApp_YchetSotrudnikov." + windowClassName);

                    if (windowType != null)
                    {
                        var window = Activator.CreateInstance(windowType, (sender as Button).DataContext) as Window;
                        window.Show();
                    }
                    else
                    {

                    }
                }
            }
        }

        public void VisibleDataGrid(string NameDataGrid)
        {
            var allDataGrids = G_glav.Children.OfType<DataGrid>();

            foreach (var dataGrid in allDataGrids)
            {
                dataGrid.Visibility = dataGrid.Name == "Dg_" + NameDataGrid ? Visibility.Visible : Visibility.Hidden;
            }
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            var allDataGrids = G_glav.Children.OfType<DataGrid>();

            foreach (var dataGrid in allDataGrids)
            {
                if (dataGrid.Visibility == Visibility.Visible)
                {
                    string dataGridNameWithoutPrefix = dataGrid.Name.StartsWith("Dg_")
                                ? dataGrid.Name.Substring(3)
                                : dataGrid.Name;


                    string windowClassName = "AddEdit" + dataGridNameWithoutPrefix;

                    Type windowType = Type.GetType("AdminApp_YchetSotrudnikov." + windowClassName);

                    if (windowType != null)
                    {

                        var window = Activator.CreateInstance(windowType) as Window;
                        window.Show();

                    }
                    else
                    {

                    }
                }
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            var allDataGrids = G_glav.Children.OfType<DataGrid>();

            foreach (var dataGrid in allDataGrids)
            {
                if (dataGrid.Visibility == Visibility.Visible)
                {
                    //dataGrid.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Stake.ToList();

                }
            }

        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            var allDataGrids = G_glav.Children.OfType<DataGrid>();

            foreach (var dataGrid in allDataGrids)
            {
                if (dataGrid.Visibility == Visibility.Visible)
                {
                    if (dataGrid == Dg_Stake)
                    {
                        var StakeForRemoving = Dg_Stake.SelectedItems.Cast<Stake>().ToList();

                        if (MessageBox.Show($"Вы точно хотите удалить слудующие {StakeForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Stake.RemoveRange(StakeForRemoving);
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные удалены");

                                Dg_Stake.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Stake.ToList();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    if (dataGrid == Dg_Sick)
                    {
                        var StakeForRemoving = Dg_Sick.SelectedItems.Cast<Sick>().ToList();

                        if (MessageBox.Show($"Вы точно хотите удалить слудующие {StakeForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Sick.RemoveRange(StakeForRemoving);
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные удалены");

                                Dg_Sick.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Sick.ToList();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    if (dataGrid == Dg_Post)
                    {
                        var StakeForRemoving = Dg_Post.SelectedItems.Cast<Post>().ToList();

                        if (MessageBox.Show($"Вы точно хотите удалить слудующие {StakeForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post.RemoveRange(StakeForRemoving);
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные удалены");

                                Dg_Post.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post.ToList();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    if (dataGrid == Dg_Post_Employe)
                    {
                        var StakeForRemoving = Dg_Post_Employe.SelectedItems.Cast<Post_Employe>().ToList();

                        if (MessageBox.Show($"Вы точно хотите удалить слудующие {StakeForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post_Employe.RemoveRange(StakeForRemoving);
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные удалены");

                                Dg_Post_Employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Post_Employe.ToList();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    if (dataGrid == Dg_Work_schedule)
                    {
                        var StakeForRemoving = Dg_Work_schedule.SelectedItems.Cast<Work_schedule>().ToList();

                        if (MessageBox.Show($"Вы точно хотите удалить слудующие {StakeForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Work_schedule.RemoveRange(StakeForRemoving);
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные удалены");

                                Dg_Work_schedule.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Work_schedule.ToList();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    if (dataGrid == Dg_Work_schedule_Employe)
                    {
                        var StakeForRemoving = Dg_Work_schedule_Employe.SelectedItems.Cast<Work_schedule_Employe>().ToList();

                        if (MessageBox.Show($"Вы точно хотите удалить слудующие {StakeForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Work_schedule_Employe.RemoveRange(StakeForRemoving);
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные удалены");

                                Dg_Work_schedule_Employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Work_schedule_Employe.ToList();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    if (dataGrid == Dg_History_tasks)
                    {
                        var StakeForRemoving = Dg_History_tasks.SelectedItems.Cast<History_tasks>().ToList();

                        if (MessageBox.Show($"Вы точно хотите удалить слудующие {StakeForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().History_tasks.RemoveRange(StakeForRemoving);
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные удалены");

                                Dg_History_tasks.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().History_tasks.ToList();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    if (dataGrid == Dg_LogTable)
                    {
                        var StakeForRemoving = Dg_LogTable.SelectedItems.Cast<LogTable>().ToList();

                        if (MessageBox.Show($"Вы точно хотите удалить слудующие {StakeForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().LogTable.RemoveRange(StakeForRemoving);
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные удалены");

                                Dg_LogTable.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().LogTable.ToList();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    if (dataGrid == Dg_Education)
                    {
                        var StakeForRemoving = Dg_Education.SelectedItems.Cast<Education>().ToList();

                        if (MessageBox.Show($"Вы точно хотите удалить слудующие {StakeForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Education.RemoveRange(StakeForRemoving);
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные удалены");

                                Dg_Education.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Education.ToList();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    if (dataGrid == Dg_Education_employe)
                    {
                        var StakeForRemoving = Dg_Education_employe.SelectedItems.Cast<Education_employe>().ToList();

                        if (MessageBox.Show($"Вы точно хотите удалить слудующие {StakeForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Education_employe.RemoveRange(StakeForRemoving);
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные удалены");

                                Dg_Education_employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Education_employe.ToList();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    if (dataGrid == Dg_Department)
                    {
                        var StakeForRemoving = Dg_Department.SelectedItems.Cast<Department>().ToList();

                        if (MessageBox.Show($"Вы точно хотите удалить слудующие {StakeForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Department.RemoveRange(StakeForRemoving);
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные удалены");

                                Dg_Department.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Department.ToList();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    if (dataGrid == Dg_Employe)
                    {
                        var StakeForRemoving = Dg_Employe.SelectedItems.Cast<Employe>().ToList();

                        if (MessageBox.Show($"Вы точно хотите удалить слудующие {StakeForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe.RemoveRange(StakeForRemoving);
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные удалены");
                                Dg_Employe.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe.ToList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    if (dataGrid == Dg_Type_day)
                    {
                        var StakeForRemoving = Dg_Type_day.SelectedItems.Cast<Type_day>().ToList();

                        if (MessageBox.Show($"Вы точно хотите удалить слудующие {StakeForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Type_day.RemoveRange(StakeForRemoving);
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные удалены");
                                Dg_Type_day.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Type_day.ToList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    if (dataGrid == Dg_Tasks)
                    {
                        var StakeForRemoving = Dg_Tasks.SelectedItems.Cast<Tasks>().ToList();

                        if (MessageBox.Show($"Вы точно хотите удалить слудующие {StakeForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Tasks.RemoveRange(StakeForRemoving);
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные удалены");
                                Dg_Tasks.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Tasks.ToList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    if (dataGrid == Dg_Sallary)
                    {
                        var StakeForRemoving = Dg_Sallary.SelectedItems.Cast<Sallary>().ToList();

                        if (MessageBox.Show($"Вы точно хотите удалить слудующие {StakeForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Sallary.RemoveRange(StakeForRemoving);
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные удалены");
                                Dg_Sallary.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Sallary.ToList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    if (dataGrid == Dg_Employe_Tasks)
                    {
                        var StakeForRemoving = Dg_Employe_Tasks.SelectedItems.Cast<Employe_Tasks>().ToList();

                        if (MessageBox.Show($"Вы точно хотите удалить слудующие {StakeForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe_Tasks.RemoveRange(StakeForRemoving);
                                IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные удалены");

                                Dg_Employe_Tasks.ItemsSource = IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext().Employe_Tasks.ToList();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }

                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void Exit_Acc(object sender, RoutedEventArgs e)
        {
            NameTable = String.Empty;
            Role = "";

            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();

            this.Close();
        }

        private void Exit_App(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
