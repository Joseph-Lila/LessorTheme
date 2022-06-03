using System;
using System.Windows;
using System.Windows.Controls;
using Coursework.BLL.Services;
using Coursework.Domain;

namespace Coursework.Pages;

public partial class AddPlacePage : Page
{
    public AddPlacePage()
    {
        InitializeComponent();
    }

    private bool CheckTheFields()
    {
        return !(String.IsNullOrWhiteSpace(TxtBoxCountry.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxCity.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxStreet.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxBuildingNumber.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxRoomNumber.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxPlaceNumber.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxPricePerDay.Text));
    }
    private void ButtonAddPlace(object sender, RoutedEventArgs e)
    {
        bool correct = CheckTheFields();
        if (correct)
        {
            MainWindow window = (Application.Current.MainWindow as MainWindow)!;
            Building building = new Building { Country = TxtBoxCountry.Text,
                BuildingNumber = Convert.ToInt32(TxtBoxBuildingNumber.Text),
                City = TxtBoxCity.Text, Street = TxtBoxStreet.Text };
            int? buildingId;
            if (!window.manager.BuildingManager.CheckExistsBuilding(building))
                buildingId = window.manager.BuildingManager.Create(building);
            else
                buildingId = window.manager.BuildingManager.GetByItem(building).Id;
            Room room = new Room
            { BuildingId = (int)buildingId, RoomNumber = Convert.ToInt32(TxtBoxRoomNumber.Text) };
            int? roomId;
            if (!window.manager.RoomManager.CheckExistsRoom(room))
                roomId = window.manager.RoomManager.Create(room);
            else
                roomId = window.manager.RoomManager.GetByItem(room).Id;
            Place place = new Place { IsFree = true, PlaceNumber = Convert.ToInt32(TxtBoxPlaceNumber.Text),
                PricePerDay = Convert.ToDouble(TxtBoxPricePerDay.Text), RoomId = (int)roomId, LessorId = Identity.LessorId};
            if (!window.manager.PlaceManager.CheckExistsUser(place))
            {
                window.manager.PlaceManager.Create(place);
            }
            window.MainFrame.Source = window.pages["LessorMenuPage"];
        }
        else
        {
            MessageBox.Show("Заполните все поля!");
        }
    }
}