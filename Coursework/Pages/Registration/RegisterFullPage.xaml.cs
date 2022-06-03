using System;
using System.Windows;
using System.Windows.Controls;
using Coursework.Domain;

namespace Coursework.Pages.Registration;

public partial class RegisterFullPage : Page
{
    public RegisterFullPage()
    {
        InitializeComponent();
    }
    
    private bool CheckTheFields()
    {
        return !(String.IsNullOrWhiteSpace(TxtBoxName.Text) ||
                         String.IsNullOrWhiteSpace(TxtBoxSurname.Text) ||
                         String.IsNullOrWhiteSpace(TxtBoxLastname.Text) ||
                         String.IsNullOrWhiteSpace(TxtBoxNickName.Text) ||
                         String.IsNullOrWhiteSpace(TxtBoxPassport.Text) ||
                         String.IsNullOrWhiteSpace(TxtBoxEmail.Text) ||
                         String.IsNullOrWhiteSpace(TxtBoxPhone.Text) ||
                         String.IsNullOrWhiteSpace(TxtBoxPassword.Password) ||
                         String.IsNullOrWhiteSpace(TxtBoxLogin.Text));
    }
    private void Button_Register(object sender, RoutedEventArgs e)
    {
        bool correct = CheckTheFields();
        if (correct)
        {
            MainWindow window = (Application.Current.MainWindow as MainWindow)!;
            User user = new User { Email = TxtBoxEmail.Text, Login = TxtBoxLogin.Text, 
                Password = TxtBoxPassword.Password, PhoneNumber = TxtBoxPhone.Text };
            int? userId;
            if (!window.manager.UserManager.CheckExistsUser(user))
            {
                userId = window.manager.UserManager.Create(user);
            }
            else
            {
                MessageBox.Show("Пользователь с таким логином уже существует!");
                return;
            }
            Lessor lessor = new Lessor
            {
                UserId = (int)userId,
                Lastname = TxtBoxLastname.Text,
                Name = TxtBoxName.Text,
                NickName = TxtBoxNickName.Text,
                PassportData = TxtBoxPassport.Text,
                Rating = 0,
                Surname = TxtBoxSurname.Text
            };
            window.manager.LessorManager.Create(lessor);
            Tenant tenant = new Tenant
            {
                UserId = (int)userId,
                Lastname = TxtBoxLastname.Text,
                Name = TxtBoxName.Text,
                PassportData = TxtBoxPassport.Text,
                Surname = TxtBoxSurname.Text
            };
            window.manager.TenantManager.Create(tenant);
            window.MainFrame.Source = window.pages["HelloPage"];
        }
        else
        {
            MessageBox.Show("Заполните все поля!");
        }
    }
}