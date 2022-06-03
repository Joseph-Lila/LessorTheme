using System;
using System.Windows;
using System.Windows.Controls;
using Coursework.BLL.Services;
using Coursework.Domain;

namespace Coursework.Pages;

public partial class LoginPage : Page
{
    public LoginPage()
    {
        InitializeComponent();
    }
    
    private bool CheckTheFields()
    {
        return !(String.IsNullOrWhiteSpace(TxtBoxPassword.Password) || String.IsNullOrWhiteSpace(TxtBoxLogin.Text));
    }
    private void Button_LogIn(object sender, RoutedEventArgs e)
    {
        if (CheckTheFields())
        {
            MainWindow window = (Application.Current.MainWindow as MainWindow)!;
            User current = new User
            {
                Login = TxtBoxLogin.Text,
                Password = TxtBoxPassword.Password
            };
            if (window.manager.UserManager.CheckExistsUser(current))
            {
                current = window.manager.UserManager.GetByLogin(current.Login);
                Identity.UserId = current.Id;
                if (window.manager.LessorManager.IsLessor(current.Id))
                {
                    Identity.Roles.Add("Lessor");
                    Identity.LessorId = window.manager.LessorManager.GetByUserId(current.Id)!.Id;
                }

                if (window.manager.TenantManager.IsTenant(current.Id))
                {
                    Identity.Roles.Add("Tenant");
                    Identity.TenantId = window.manager.TenantManager.GetByUserId(current.Id)!.Id;
                }

                Identity.Email = current.Email;
                Identity.Login = current.Login;
                Identity.PhoneNumber = current.PhoneNumber;
                Identity.IsAuthorized = true;
                window.LoginButton.Content = "Log Out";
                window.MainFrame.NavigationService.Navigate(window.pages["HelloPage"]);
            }
        }
    }
}