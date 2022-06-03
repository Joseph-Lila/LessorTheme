using System;
using Coursework.Domain.Interfaces;

namespace Coursework.Domain;

public class Contract : IHaveId
{
    public int Id { get; set; }
    public int TenantId { get; set; }
    public int PlaceId { get; set; }
    public double TotalCost { get; set; }
    public DateTime Start { get; set; }
    public DateTime Finish { get; set; }
    public double Debt { get; set; }
}