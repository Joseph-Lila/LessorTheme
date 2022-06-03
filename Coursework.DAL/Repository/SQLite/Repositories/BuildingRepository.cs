using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.Domain;

namespace Coursework.DAL.Repository.SQLite.Repositories;

public class BuildingRepository : IRepository<Building>
{
    private readonly string _connectionString;

    public BuildingRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Building> GetCollection()
    {
        List<Building> buildings = new List<Building>();
        string sqlExpression = "SELECT * FROM Building";
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
                        var country = reader.GetString(1);
                        var city = reader.GetString(2);
                        var street = reader.GetString(3);
                        var buildingNumber = reader.GetInt32(4);
                        buildings.Add(new Building
                            { Id = id, Country = country, City = city, Street = street, BuildingNumber = buildingNumber});
                    }
                }
            }
        }

        return buildings;
    }

    public Building? GetItem(int id)
    {
        return GetCollection().FirstOrDefault(item => item.Id == id);
    }

    public void Create(Building item)
    {
        string sqlExpression = "INSERT INTO Building (Country, City, Street, BuildingNumber) VALUES (@country, @city, @street, @buildingNumber)";
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            SQLiteParameter countryParam = new SQLiteParameter("@country", item.Country);
            SQLiteParameter cityParam = new SQLiteParameter("@city", item.City);
            SQLiteParameter streetParam = new SQLiteParameter("@street", item.Street);
            SQLiteParameter buildingNumberParam = new SQLiteParameter("@buildingNumber", item.BuildingNumber);
            command.Parameters.Add(countryParam);
            command.Parameters.Add(cityParam);
            command.Parameters.Add(streetParam);
            command.Parameters.Add(buildingNumberParam);
            command.ExecuteNonQuery();
        }
    }

    public void Update(Building old, Building @new)
    {
        string sqlExpression = 
            $"UPDATE Building SET Country='{@new.Country}', City='{@new.City}', Street='{@new.Street}', BuildingNumber={@new.BuildingNumber} WHERE Country='{old.Country}', City='{old.City}', Street='{old.Street}', BuildingNumber={old.BuildingNumber}";
 
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        string sqlExpression = $"DELETE FROM Building WHERE Id={id}";
 
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }
}