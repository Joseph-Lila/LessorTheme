using System.Collections.Generic;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.DAL.Repository.SQLite.Repositories;
using Coursework.Domain;

namespace Coursework.BLL.Services;

public class BuildingManager
{
    private IRepository<Building> _repository;

    public BuildingManager(string connectionString)
    {
        _repository = new BuildingRepository(connectionString);
    }

    public bool CheckExistsBuilding(Building building)
    {
        List<Building> buildings = _repository.GetCollection();
        Building? checkBuilding = buildings.FirstOrDefault(
            x => x.Country == building.Country && x.City == building.City &&
                 x.Street == building.Street && x.BuildingNumber == building.BuildingNumber);
        if (checkBuilding != null)
            return true;
        return false;
    }

    public int? Create(Building building)
    {
        _repository.Create(building);
        Building it = GetByItem(building);
        return it.Id;
    }

    public Building GetById(int id)
    {
        return _repository.GetItem(id);
    }
    public Building GetByItem(Building building)
    {
        return _repository.GetCollection().Find(
            x => x.Country == building.Country && x.City == building.City &&
                 x.Street == building.Street && x.BuildingNumber == building.BuildingNumber)!;
    }
}