using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Coursework.BLL.DtoModels;

namespace Coursework.Pages;

public partial class MyDebtors : Page
{
    public ObservableCollection<DebtorsDto> DebtorsDtos { get; set; }
    public MyDebtors()
    {
        InitializeComponent();
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        DebtorsDtos = window.manager.GetDebtors();
        DebtorsList.ItemsSource = DebtorsDtos;
    }
}