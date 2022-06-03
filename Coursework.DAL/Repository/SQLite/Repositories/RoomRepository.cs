using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.Domain;

namespace Coursework.DAL.Repository.SQLite.Repositories;

public class RoomRepository : IRepository<Room>
{
    private readonly string _connectionString;

    public RoomRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Room> GetCollection()
    {
        List<Room> rooms = new List<Room>();
        string sqlExpression = "SELECT * FROM Room";
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var buildingId = reader.GetInt32(1);
                        var roomNumber = reader.GetInt32(2);
                        rooms.Add(new Room
                            { Id = id, BuildingId = buildingId, RoomNumber = roomNumber});
                    }
                }
            }
        }

        return rooms;
    }

    public Room? GetItem(int id)
    {
        return GetCollection().FirstOrDefault(item => item.Id == id);
    }

    public void Create(Room item)
    {
        string sqlExpression = "INSERT INTO Room (BuildingId, RoomNumber) VALUES (@buildingId, @roomNumber)";
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            SQLiteParameter buildingIdParam = new SQLiteParameter("@buildingId", item.BuildingId);
            SQLiteParameter roomNumberParam = new SQLiteParameter("@roomNumber", item.RoomNumber);
            command.Parameters.Add(buildingIdParam);
            command.Parameters.Add(roomNumberParam);
            command.ExecuteNonQuery();
        }
    }

    public void Update(Room old, Room @new)
    {
        string sqlExpression = 
            $"UPDATE Room SET BuildingId={@new.BuildingId}, RoomNumber={@new.RoomNumber} WHERE BuildingId={old.BuildingId}, RoomNumber={old.RoomNumber}";
 
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        string sqlExpression = $"DELETE FROM Room WHERE Id={id}";
 
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }
}