using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.Domain;

namespace Coursework.DAL.Repository.SQLite.Repositories;

public class UserRepository : IRepository<User>
{
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<User> GetCollection()
    {
        List<User> users = new List<User>();
        string sqlExpression = "SELECT * FROM User";
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
                        var login = reader.GetString(1);
                        var password = reader.GetString(2);
                        var email = reader.GetString(3);
                        var phoneNumber = reader.GetString(4);
                        users.Add(new User
                            { Id = id, Login = login, Password = password, Email = email, PhoneNumber = password });
                    }
                }
            }
        }

        return users;
    }

    public User? GetItem(int id)
    {
        return GetCollection().FirstOrDefault(item => item.Id == id);
    }

    public void Create(User item)
    {
        string sqlExpression = "INSERT INTO User (Login, Password, Email, PhoneNumber) VALUES (@login, @password, @email, @phoneNumber)";
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            SQLiteParameter loginParam = new SQLiteParameter("@login", item.Login);
            SQLiteParameter passwordParam = new SQLiteParameter("@password", item.Password);
            SQLiteParameter emailParam = new SQLiteParameter("@email", item.Email);
            SQLiteParameter phoneNumberParam = new SQLiteParameter("@phoneNumber", item.PhoneNumber);
            command.Parameters.Add(loginParam);
            command.Parameters.Add(passwordParam);
            command.Parameters.Add(emailParam);
            command.Parameters.Add(phoneNumberParam);
            command.ExecuteNonQuery();
        }
    }

    public void Update(User old, User @new)
    {
        string sqlExpression = 
            $"UPDATE User SET Login='{@new.Login}', Password='{@new.Password}', Email='{@new.Email}', PhoneNumber='{@new.PhoneNumber}' WHERE Login='{old.Login}', Password='{old.Password}', Email='{old.Email}', PhoneNumber='{old.PhoneNumber}'";
 
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        string sqlExpression = $"DELETE FROM User WHERE Id={id}";
 
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }
}