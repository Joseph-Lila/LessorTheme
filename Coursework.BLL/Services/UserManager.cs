using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Coursework.DAL.Interfaces;
using Coursework.DAL.Repository.SQLite.Repositories;
using Coursework.Domain;

namespace Coursework.BLL.Services;

public class UserManager
{
    private IRepository<User> _userRep;

    public UserManager(string connectionString)
    {
        _userRep = new UserRepository(connectionString);
    }

    public bool CheckExistsUser(User user)
    {
        List<User> users = _userRep.GetCollection();
        User? checkUser = users.FirstOrDefault(x => x.Login == user.Login);
        if (checkUser != null)
        {
            return true;
        }
        return false;
    }

    public int? Create(User user)
    {
        _userRep.Create(user);
        User it = _userRep.GetCollection().Find(x => x.Login == user.Login);
        return it?.Id;
    }

    public User GetByLogin(string login)
    {
        return _userRep.GetCollection().FirstOrDefault(x => x.Login == login)!;
    }
}