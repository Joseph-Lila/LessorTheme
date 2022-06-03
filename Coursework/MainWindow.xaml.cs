using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Coursework.BLL.Services;
using Coursework.DAL.Repository.SQLite;
using Coursework.Domain;
using Microsoft.Win32;

namespace Coursework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _connectionString;
        public Dictionary<string, Uri> pages;
        public Manager manager;
        
        public MainWindow()
        {
            InitializeComponent();
            _connectionString = "Data Source=D:\\RiderProjects\\Coursework\\MyDb.sqlite";
            manager = new Manager(_connectionString);
            AddPages();
            MainFrame.NavigationService.Navigate(pages["HelloPage"]);
            MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            RolesBox.ItemsSource = Identity.Roles;
            RolesBox.SelectedValue = "Guest";
        }

        private void AddPages()
        {
            pages = new Dictionary<string, Uri>();
            pages["HelloPage"] = new Uri("Pages/HelloPage.xaml", UriKind.Relative);
            pages["SignUpPage"] = new Uri("Pages/SignUpPage.xaml", UriKind.Relative);
            pages["LoginPage"] = new Uri("Pages/LoginPage.xaml", UriKind.Relative);
            pages["RegisterAsLessorPage"] = new Uri("Pages/Registration/RegisterAsLessorPage.xaml", UriKind.Relative);
            pages["RegisterAsTenantPage"] = new Uri("Pages/Registration/RegisterAsTenantPage.xaml", UriKind.Relative);
            pages["RegisterFullPage"] = new Uri("Pages/Registration/RegisterFullPage.xaml", UriKind.Relative);
            pages["LessorMenuPage"] = new Uri("Pages/LessorMenuPage.xaml", UriKind.Relative);
            pages["TenantMenuPage"] = new Uri("Pages/TenantMenuPage.xaml", UriKind.Relative);
            pages["MyContractsPage"] = new Uri("Pages/MyContracts.xaml", UriKind.Relative);
            pages["AddPlacePage"] = new Uri("Pages/AddPlacePage.xaml", UriKind.Relative);
            pages["ShowStatisticPage"] = new Uri("Pages/ShowStatisticPage.xaml", UriKind.Relative);
            pages["MarkContractPage"] = new Uri("Pages/MarkContractPage.xaml", UriKind.Relative);
            pages["MyDebtorsPage"] = new Uri("Pages/MyDebtors.xaml", UriKind.Relative);
        }
        private void Button_GoToSignUp(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(pages["SignUpPage"]);
        }

        private void RolesBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Identity.CurrentRole = RolesBox.SelectedValue.ToString()!;
            if (Identity.CurrentRole == "Guest")
            {
                MainFrame.NavigationService.Navigate(pages["HelloPage"]);
            }
            if (Identity.CurrentRole == "Lessor")
            {
                MainFrame.NavigationService.Navigate(pages["LessorMenuPage"]);
            }
            if (Identity.CurrentRole == "Tenant")
            {
                MainFrame.NavigationService.Navigate(pages["TenantMenuPage"]);
            }
        }

        private void Button_LogIn(object sender, RoutedEventArgs e)
        {
            if ((string)LoginButton.Content == "Log In")
            {
                Identity.Email = "";
                Identity.Login = "";
                Identity.PhoneNumber = "";
                Identity.LessorId = 0;
                Identity.TenantId = 0;
                Identity.UserId = 0;
                Identity.IsAuthorized = false;
                MainFrame.NavigationService.Navigate(pages["LoginPage"]);
            }
            else
            {
                LoginButton.Content = "Log In";
                RolesBox.SelectedValue = "Guest";
                Identity.Roles.Remove("Lessor");
                Identity.Roles.Remove("Tenant");
                MainFrame.NavigationService.Navigate(pages["HelloPage"]);
            }
        }
    }
}
