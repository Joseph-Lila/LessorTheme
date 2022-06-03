using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows;
using Coursework.DAL.Interfaces;
using Coursework.Domain;

namespace Coursework.DAL.Repository.SQLite.Repositories;

public class PlaceRepository : IRepository<Place>
{
    private readonly string _connectionString;

    public PlaceRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Place> GetCollection()
    {
        List<Place> places = new List<Place>();
        string sqlExpression = "SELECT * FROM Place";
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
                        var lessorId = reader.GetInt32(1);
                        var roomId = reader.GetInt32(2);
                        var placeNumber = reader.GetInt32(3);
                        var pricePerDay = reader.GetDouble(4);
                        var isFreeInt = reader.GetInt32(5);
                        bool isFree;
                        if (isFreeInt == 1)
                            isFree = true;
                        else isFree = false;
                        places.Add(new Place
                            { Id = id, LessorId = lessorId, RoomId = roomId, PlaceNumber = placeNumber, PricePerDay = pricePerDay, IsFree = isFree});
                    }
                }
            }
        }

        return places;
    }

    public Place? GetItem(int id)
    {
        return GetCollection().FirstOrDefault(item => item.Id == id);
    }

    public void Create(Place item)
    {
        string sqlExpression = "INSERT INTO Place (LessorId, RoomId, PlaceNumber, PricePerDay, IsFree) VALUES (@lessorId, @roomId, @placeNumber, @pricePerDay, @isFree)";
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            SQLiteParameter roomIdParam = new SQLiteParameter("@roomId", item.RoomId);
            SQLiteParameter lessorIdParam = new SQLiteParameter("@lessorId", item.LessorId);
            SQLiteParameter placeNumberParam = new SQLiteParameter("@placeNumber", item.PlaceNumber);
            SQLiteParameter pricePerDayParam = new SQLiteParameter("@pricePerDay", item.PricePerDay);
            int isFree;
            if (item.IsFree)
                isFree = 1;
            else
                isFree = 0;
            SQLiteParameter isFreeParam = new SQLiteParameter("@isFree", isFree);
            command.Parameters.Add(roomIdParam);
            command.Parameters.Add(lessorIdParam);
            command.Parameters.Add(placeNumberParam);
            command.Parameters.Add(pricePerDayParam);
            command.Parameters.Add(isFreeParam);
            command.ExecuteNonQuery();
        }
    }

    public void Update(Place old, Place @new)
    {
        int oldFree = 0, newFree = 0;
        if (old.IsFree)
            oldFree = 1;
        if (@new.IsFree)
            newFree = 1;
        string sqlExpression = 
            $"UPDATE Place SET RoomId={@new.RoomId}, PlaceNumber={@new.PlaceNumber}, PricePerDay={@new.PricePerDay.ToString().Replace(',', '.')}, IsFree={newFree} WHERE RoomId={old.RoomId} and PlaceNumber={old.PlaceNumber} and PricePerDay={old.PricePerDay.ToString().Replace(',', '.')} and IsFree={oldFree}";
 
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        string sqlExpression = $"DELETE FROM Place WHERE Id={id}";
 
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }
}