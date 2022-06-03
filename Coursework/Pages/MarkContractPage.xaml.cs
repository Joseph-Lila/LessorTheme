using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Coursework.BLL.DtoModels;
using Coursework.BLL.Services;
using Coursework.Domain;

namespace Coursework.Pages;

public partial class MarkContractPage : Page
{
    private ComplexPlace? _lastPlace = null;
    public ObservableCollection<ComplexPlace> Places { get; set; }
    public MarkContractPage()
    {
        InitializeComponent();
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        Places = window.manager.GetFreeComplexPlaces();
        ComplexList.ItemsSource = Places;
    }

    private void ComplexList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _lastPlace = (ComplexPlace)ComplexList.SelectedItem;
        ChangeTotalCost();
    }

    private void ChangeTotalCost()
    {
        if (StartDay.SelectedDate != null && FinishDay.SelectedDate != null && _lastPlace != null)
        {
            TakeAPlace.IsEnabled = true;
            int days = (DateTime.Parse(FinishDay.Text) - DateTime.Parse(StartDay.Text)).Days;
            days = Math.Abs(days);
            TotalCost.Text = (days * _lastPlace!.PricePerDay).ToString();
        }
    }
    private void TakeAPlace_OnClick(object sender, RoutedEventArgs e)
    {
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        Contract contract = new Contract
        {
            TenantId = Identity.TenantId,
            Debt = Convert.ToDouble(TotalCost.Text),
            Finish = Convert.ToDateTime(FinishDay.Text),
            PlaceId = _lastPlace!.PlaceId,
            Start = Convert.ToDateTime(StartDay.Text),
            TotalCost = Convert.ToDouble(TotalCost.Text)
        };
        window.manager.ContractManager.Create(contract);
        window.manager.PlaceManager.MakeNotFree(window.manager.PlaceManager.GetCollection()
            .Find(x => x.Id == _lastPlace.PlaceId)!);
        Places = window.manager.GetFreeComplexPlaces();
        ComplexList.ItemsSource = Places;
        TakeAPlace.IsEnabled = false;
        _lastPlace = null;
    }

    private void FinishDay_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
    {
        ChangeTotalCost();
    }

    private void StartDay_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
    {
        ChangeTotalCost();
    }
}