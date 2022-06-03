using Coursework.Domain.Interfaces;

namespace Coursework.Domain;

public class Building : IHaveId
{
    public int Id { get; set; }
    public string Country { get; set; } = "";
    public string City { get; set; } = "";
    public string Street { get; set; } = "";
    public int BuildingNumber { get; set; }
}