using System.Collections.Generic;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.DAL.Repository.SQLite.Repositories;
using Coursework.Domain;

namespace Coursework.BLL.Services;

public class PlaceManager
{
    private IRepository<Place> _repository;

    public PlaceManager(string connectionString)
    {
        _repository = new PlaceRepository(connectionString);
    }

    public List<Place> GetCollection()
    {
        return _repository.GetCollection();
    }
    public bool CheckExistsUser(Place place)
    {
        List<Place> users = _repository.GetCollection();
        Place? checkPlace = users.FirstOrDefault(
            x => x.RoomId == place.RoomId && x.PlaceNumber == place.PlaceNumber);
        if (checkPlace != null)
        {
            return true;
        }
        return false;
    }

    public int? Create(Place place)
    {
        _repository.Create(place);
        Place it = _repository.GetCollection().Find(x => x.RoomId == place.RoomId && x.PlaceNumber == place.PlaceNumber);
        return it?.Id;
    }

    public void MakeFree(int placeId)
    {
        Place place = _repository.GetCollection().Find(x => x.Id == placeId)!;
        Place @new = new Place
        {
            Id = place.Id,
            IsFree = true,
            LessorId = place.LessorId,
            PlaceNumber = place.PlaceNumber,
            PricePerDay = place.PricePerDay,
            RoomId = place.RoomId
        };
        Update(place, @new);
    }
    public void MakeNotFree(Place place)
    {
        Place @new = new Place
        {
            Id = place.Id,
            IsFree = false,
            LessorId = place.LessorId,
            PlaceNumber = place.PlaceNumber,
            PricePerDay = place.PricePerDay,
            RoomId = place.RoomId
        };
        Update(place, @new);
    }
    
    public void Update(Place old, Place @new)
    {
        _repository.Update(old, @new);
    }
}