using System.Collections.Generic;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.DAL.Repository.SQLite.Repositories;
using Coursework.Domain;

namespace Coursework.BLL.Services;

public class TenantManager
{
    private IRepository<Tenant> _tenantManager;

    public TenantManager(string connectionString)
    {
        _tenantManager = new TenantRepository(connectionString);
    }

    public List<Tenant> GetCollection()
    {
        return _tenantManager.GetCollection();
    } 
    
    public void Create(Tenant tenant)
    {
        _tenantManager.Create(tenant);
    }

    public bool IsTenant(int userId)
    {
        Tenant? tenant = _tenantManager.GetCollection().FirstOrDefault(x => x.UserId == userId);
        if (tenant != null) return true;
        return false;
    }
    
    public Tenant? GetByUserId(int userId)
    {
        return _tenantManager.GetCollection().FirstOrDefault(x => x.UserId == userId);
    }
}