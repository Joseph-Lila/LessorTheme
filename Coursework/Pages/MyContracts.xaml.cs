using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Coursework.BLL.Services;
using Coursework.Domain;

namespace Coursework.Pages;

public partial class MyContracts : Page
{
    private Contract? _lastChosen = null;
    public ObservableCollection<Contract> Contracts { get; set; }

    public MyContracts()
    {
        InitializeComponent();
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        Contracts = window.manager.GetMyContracts();
        ContractsList.ItemsSource = Contracts;
    }
    
    private void CheckIsNumeric(TextCompositionEventArgs e)
    {
        int result;

        if(!(int.TryParse(e.Text, out result) || e.Text == ","))
        {
            e.Handled = true;
        }
    }

    private void MoneyForDebt_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        CheckIsNumeric(e);
    }

    private void RepayDebt_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            double amount = Convert.ToDouble(MoneyForDebt.Text);
            if (amount <= _lastChosen!.Debt && amount > 0)
            {
                MainWindow window = (Application.Current.MainWindow as MainWindow)!;
                window.manager.ContractManager.RepayDebt(_lastChosen, amount);
                Contracts = window.manager.GetMyContracts();
                ContractsList.ItemsSource = Contracts;
                foreach (var item in Contracts)
                {
                    if (item.Debt == 0)
                    {
                        window.manager.PlaceManager.MakeFree(item.PlaceId);
                    }
                }
            }
        }
        catch
        {
            MessageBox.Show("Сумма не должна превышать долг!");
        }

    }

    private void ContractsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _lastChosen = (Contract)ContractsList.SelectedItem;
        RepayDebt.IsEnabled = true;
    }
}