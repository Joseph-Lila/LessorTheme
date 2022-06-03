using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.Domain;

namespace Coursework.DAL.Repository.SQLite.Repositories;

public class TenantRepository : IRepository<Tenant>
{
    private readonly string _connectionString;

    public TenantRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Tenant> GetCollection()
    {
        List<Tenant> tenants = new List<Tenant>();
        string sqlExpression = "SELECT * FROM Tenant";
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
                        var userId = reader.GetInt32(1);
                        var name = reader.GetString(2);
                        var surname = reader.GetString(3);
                        var lastname = reader.GetString(4);
                        var passportData = reader.GetString(5);
                        tenants.Add(new Tenant
                            { Id = id, UserId = userId, Name = name, Surname = surname, Lastname = lastname, PassportData = passportData});
                    }
                }
            }
        }

        return tenants;
    }

    public Tenant? GetItem(int id)
    {
        return GetCollection().FirstOrDefault(item => item.Id == id);
    }

    public void Create(Tenant item)
    {
        string sqlExpression =
            "INSERT INTO Tenant (UserId, Name, Surname, Lastname, PassportData) VALUES (@userId, @name, @surname, @lastname, @passportData)";
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            SQLiteParameter userIdParam = new SQLiteParameter("@userId", item.UserId);
            SQLiteParameter nameParam = new SQLiteParameter("@name", item.Name);
            SQLiteParameter surnameParam = new SQLiteParameter("@surname", item.Surname);
            SQLiteParameter lastnameParam = new SQLiteParameter("@lastname", item.Lastname);
            SQLiteParameter passportDataParam = new SQLiteParameter("@passportData", item.PassportData);
            command.Parameters.Add(userIdParam);
            command.Parameters.Add(nameParam);
            command.Parameters.Add(surnameParam);
            command.Parameters.Add(lastnameParam);
            command.Parameters.Add(passportDataParam);
            command.ExecuteNonQuery();
        }
    }

    public void Update(Tenant old, Tenant @new)
    {
        string sqlExpression = 
            $"UPDATE Tenant SET UserId={@new.UserId}, Name='{@new.Name}', Surname='{@new.Surname}', Lastname='{@new.Lastname}', PassportData='{@new.PassportData}' WHERE UserId={old.UserId}, Name='{old.Name}', Surname='{old.Surname}', Lastname='{old.Lastname}', PassportData='{old.PassportData}'";
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        string sqlExpression = $"DELETE FROM Tenant WHERE Id={id}";
 
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }
}