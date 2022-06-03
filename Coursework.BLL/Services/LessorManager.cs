using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.DAL.Repository.SQLite.Repositories;
using Coursework.Domain;

namespace Coursework.BLL.Services;

public class LessorManager
{
    private IRepository<Lessor> _lessorManager;

    public LessorManager(string connectionString)
    {
        _lessorManager = new LessorRepository(connectionString);
    }
    
    public void Create(Lessor lessor)
    {
        _lessorManager.Create(lessor);
    }

    public bool IsLessor(int userId)
    {
        Lessor? lessor = _lessorManager.GetCollection().FirstOrDefault(x => x.UserId == userId);
        if (lessor != null) return true;
        return false;
    }

    public Lessor GetById(int id)
    {
        return _lessorManager.GetItem(id);
    }
    public Lessor? GetByUserId(int userId)
    {
        return _lessorManager.GetCollection().FirstOrDefault(x => x.UserId == userId);
    }
}