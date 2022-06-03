using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Coursework.BLL.DtoModels;
using Coursework.Domain;

namespace Coursework.BLL.Services;

public class Manager
{
    public UserManager UserManager;
    public LessorManager LessorManager;
    public TenantManager TenantManager;
    public ContractManager ContractManager;
    public BuildingManager BuildingManager;
    public RoomManager RoomManager;
    public PlaceManager PlaceManager;

    public Manager(string connectionString)
    {
        UserManager = new UserManager(connectionString);
        LessorManager = new LessorManager(connectionString);
        TenantManager = new TenantManager(connectionString);
        ContractManager = new ContractManager(connectionString);
        BuildingManager = new BuildingManager(connectionString);
        RoomManager = new RoomManager(connectionString);
        PlaceManager = new PlaceManager(connectionString);
    }

    public ObservableCollection<Contract> GetMyContracts()
    {
        ObservableCollection<Contract> collection = new ObservableCollection<Contract>();
        List<Contract> myContracts = ContractManager.GetCollection().FindAll(x => x.TenantId == Identity.TenantId && (x.Finish > DateTime.Now || x.Debt > 0));
        foreach (var item in myContracts)
        {
            collection.Add(item);
        }

        return collection;
    }

    public ObservableCollection<DebtorsDto> GetDebtors()
    {
        ObservableCollection<DebtorsDto> collection = new ObservableCollection<DebtorsDto>();
        List<Tenant> tenants = TenantManager.GetCollection();
        foreach (var tenant in tenants)
        {
            double totalDebt = 0;
            List<Contract> contracts = ContractManager.GetCollection().FindAll(x => x.TenantId == tenant.Id);
            foreach (var contract in contracts)
            {
                totalDebt += contract.Debt;
            }
            if (totalDebt > 0)
            {
                collection.Add(new DebtorsDto
                {
                    TenantsLastname = tenant.Lastname,
                    TenantsName = tenant.Name,
                    TenantsSurname = tenant.Surname,
                    TotalDebt = totalDebt
                });   
            }
        }

        return collection;
    }
    public ObservableCollection<StatisticDto> GetStatistics()
    {
        ObservableCollection<StatisticDto> collection = new ObservableCollection<StatisticDto>();
        List<Place> myPlaces = PlaceManager.GetCollection().FindAll(x => x.LessorId == Identity.LessorId);
        foreach (var place in myPlaces)
        {
            Room room = RoomManager.GetById(place.RoomId);
            Building building = BuildingManager.GetById(room.BuildingId);
            List<Contract> contracts = ContractManager.GetCollection().FindAll(x => x.PlaceId == place.Id);
            collection.Add(new StatisticDto
            {
                PlaceNumber = place.PlaceNumber,
                PlaceId = place.Id,
                BuildingNumber = building.BuildingNumber,
                City = building.City,
                Country = building.Country,
                RoomNumber = room.RoomNumber,
                Street = building.Street,
                QuantityTenants = contracts.Count
            });
        }

        return collection;
    }
    public ObservableCollection<ComplexPlace> GetFreeComplexPlaces()
    {
        ObservableCollection<ComplexPlace> collection = new ObservableCollection<ComplexPlace>();
        List<Place> freePlaces = PlaceManager.GetCollection().FindAll(x => x.IsFree);
        foreach (var place in freePlaces)
        {
            Room room = RoomManager.GetById(place.RoomId);
            Building building = BuildingManager.GetById(room.BuildingId);
            Lessor lessor = LessorManager.GetById(place.LessorId);
            collection.Add(new ComplexPlace
            {
                BuildingId = building.Id, Country = building.Country,
                City = building.City, Street = building.Street,
                BuildingNumber = building.BuildingNumber, RoomId = room.Id,
                RoomNumber = room.RoomNumber, PlaceNumber = place.PlaceNumber,
                PricePerDay = place.PricePerDay, IsFree = true,
                PlaceId = place.Id, LessorId = lessor.Id,
                Rating = lessor.Rating, NickName = lessor.NickName
            });
        }
        return collection;
    }
}