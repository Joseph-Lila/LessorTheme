using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.Domain;

namespace Coursework.DAL.Repository.SQLite.Repositories;

public class LessorRepository  : IRepository<Lessor>
{
    private readonly string _connectionString;

    public LessorRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Lessor> GetCollection()
    {
        List<Lessor> lessors = new List<Lessor>();
        string sqlExpression = "SELECT * FROM Lessor";
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
                        var nickName = reader.GetString(5);
                        var passportData = reader.GetString(6);
                        var rating = reader.GetInt32(7);
                        lessors.Add(new Lessor
                            { Id = id, UserId = userId, Name = name, Surname = surname, Lastname = lastname, NickName = nickName, PassportData = passportData, Rating = rating});
                    }
                }
            }
        }

        return lessors;
    }

    public Lessor? GetItem(int id)
    {
        return GetCollection().FirstOrDefault(item => item.Id == id);
    }

    public void Create(Lessor item)
    {
        string sqlExpression = "INSERT INTO Lessor (UserId, Name, Surname, Lastname, NickName, PassportData, Rating) VALUES (@userId, @name, @surname, @lastname, @nickName, @passportData, @rating)";
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            SQLiteParameter userIdParam = new SQLiteParameter("@userId", item.UserId);
            SQLiteParameter nameParam = new SQLiteParameter("@name", item.Name);
            SQLiteParameter surnameParam = new SQLiteParameter("@surname", item.Surname);
            SQLiteParameter lastnameParam = new SQLiteParameter("@lastname", item.Lastname);
            SQLiteParameter nickNameParam = new SQLiteParameter("@nickName", item.NickName);
            SQLiteParameter passportDataParam = new SQLiteParameter("@passportData", item.PassportData);
            SQLiteParameter ratingParam = new SQLiteParameter("@rating", item.Rating);
            command.Parameters.Add(userIdParam);
            command.Parameters.Add(nameParam);
            command.Parameters.Add(surnameParam);
            command.Parameters.Add(lastnameParam);
            command.Parameters.Add(nickNameParam);
            command.Parameters.Add(passportDataParam);
            command.Parameters.Add(ratingParam);
            command.ExecuteNonQuery();
        }
    }

    public void Update(Lessor old, Lessor @new)
    {
        string sqlExpression = 
            $"UPDATE Lessor SET UserId={@new.UserId}, Name='{@new.Name}', Surname='{@new.Surname}', Lastname='{@new.Lastname}', NickName='{@new.NickName}', PassportData='{@new.PassportData}', Rating={@new.Rating} WHERE UserId={old.UserId}, Name='{old.Name}', Surname='{old.Surname}', Lastname='{old.Lastname}', NickName='{old.NickName}', PassportData='{old.PassportData}', Rating={old.Rating}";
 
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        string sqlExpression = $"DELETE FROM Lessor WHERE Id={id}";
 
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }
}