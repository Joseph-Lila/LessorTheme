using System.Windows;
using System.Windows.Controls;

namespace Coursework.Pages;

public partial class LessorMenuPage : Page
{
    public LessorMenuPage()
    {
        InitializeComponent();
    }

    private void Button_AddPlace(object sender, RoutedEventArgs e)
    {
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        window.MainFrame.Source = window.pages["AddPlacePage"];
    }

    private void Button_ShowStatistic(object sender, RoutedEventArgs e)
    {
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        window.MainFrame.Source = window.pages["ShowStatisticPage"];
    }

    private void DebtorsList_OnClick(object sender, RoutedEventArgs e)
    {
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        window.MainFrame.Source = window.pages["MyDebtorsPage"];
    }
}