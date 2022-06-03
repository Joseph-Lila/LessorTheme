using System.Windows;
using System.Windows.Controls;

namespace Coursework.Pages;

public partial class TenantMenuPage : Page
{
    public TenantMenuPage()
    {
        InitializeComponent();
    }

    private void Button_MyContracts(object sender, RoutedEventArgs e)
    {
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        window.MainFrame.Source = window.pages["MyContractsPage"];
    }

    private void Button_MarkContract(object sender, RoutedEventArgs e)
    {
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        window.MainFrame.Source = window.pages["MarkContractPage"];
    }
}