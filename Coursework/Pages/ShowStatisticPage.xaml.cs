using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Coursework.BLL.DtoModels;

namespace Coursework.Pages;

public partial class ShowStatisticPage : Page
{
    public ObservableCollection<StatisticDto> StatisticDtos { get; set; }
    public ShowStatisticPage()
    {
        InitializeComponent();
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        StatisticDtos = window.manager.GetStatistics();
        StatisticsList.ItemsSource = StatisticDtos;
    }
}