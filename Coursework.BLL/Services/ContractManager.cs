using System;
using System.Collections.Generic;
using Coursework.DAL.Interfaces;
using Coursework.DAL.Repository.SQLite.Repositories;
using Coursework.Domain;

namespace Coursework.BLL.Services;

public class ContractManager
{
    private IRepository<Contract> _contractRep;

    public ContractManager(string connectionString)
    {
        _contractRep = new ContractRepository(connectionString);
    }

    public List<Contract> GetCollection()
    {
        return _contractRep.GetCollection();
    }

    public int Create(Contract contract)
    {
        _contractRep.Create(contract);
        List<Contract> contracts = _contractRep.GetCollection();
        return contracts.Find(
            x => Math.Abs(x.Debt - contract.Debt) < 0.0001 &&
                 x.Finish == contract.Finish &&
                 x.Start == contract.Start &&
                 x.PlaceId == contract.PlaceId &&
                 x.TenantId == contract.TenantId &&
                 Math.Abs(x.TotalCost - contract.TotalCost) < 0.0001)!.Id;
    }

    public void RepayDebt(Contract contract, double amount)
    {
        Contract newOne = new Contract
        {
            Debt = contract.Debt - amount,
            Finish = contract.Finish,
            Id = contract.Id,
            PlaceId = contract.PlaceId,
            Start = contract.Start,
            TenantId = contract.TenantId,
            TotalCost = contract.TotalCost
        };
        _contractRep.Update(contract, newOne);
    }
}