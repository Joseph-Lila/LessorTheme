using System;
using System.Windows;
using System.Windows.Controls;


namespace Coursework.Pages;

public partial class SignUpPage : Page
{
    public SignUpPage()
    {
        InitializeComponent();
    }
    
    private void Button_GoToRegisterAsLessor(object sender, RoutedEventArgs e)
    {
        if (Application.Current.MainWindow.GetType() == typeof(MainWindow))
        {
            (Application.Current.MainWindow as MainWindow).MainFrame.Source = (Application.Current.MainWindow as MainWindow).pages["RegisterAsLessorPage"];
        }
    }  
    
    private void Button_GoToRegisterAsTenant(object sender, RoutedEventArgs e)
    {
        if (Application.Current.MainWindow.GetType() == typeof(MainWindow))
        {
            (Application.Current.MainWindow as MainWindow).MainFrame.Source = (Application.Current.MainWindow as MainWindow).pages["RegisterAsTenantPage"];
        }
    }
    
    private void Button_GoToRegisterFull(object sender, RoutedEventArgs e)
    {
        if (Application.Current.MainWindow.GetType() == typeof(MainWindow))
        {
            (Application.Current.MainWindow as MainWindow).MainFrame.Source = (Application.Current.MainWindow as MainWindow).pages["RegisterFullPage"];
        }
    }
}