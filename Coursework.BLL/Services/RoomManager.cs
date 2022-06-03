using System.Collections.Generic;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.DAL.Repository.SQLite.Repositories;
using Coursework.Domain;

namespace Coursework.BLL.Services;

public class RoomManager
{
    private IRepository<Room> _repository;

    public RoomManager(string connectionString)
    {
        _repository = new RoomRepository(connectionString);
    }

    public Room GetById(int id)
    {
        return _repository.GetItem(id);
    }
    public bool CheckExistsRoom(Room room)
    {
        List<Room> rooms = _repository.GetCollection();
        Room? checkBuilding = rooms.FirstOrDefault(x => x.RoomNumber == room.RoomNumber && x.BuildingId == room.BuildingId);
        if (checkBuilding != null)
            return true;
        return false;
    }

    public int? Create(Room room)
    {
        _repository.Create(room);
        Room it = GetByItem(room);
        return it.Id;
    }

    public Room GetByItem(Room room)
    {
        return _repository.GetCollection().Find(x => x.RoomNumber == room.RoomNumber && x.BuildingId == room.BuildingId)!;
    }
}