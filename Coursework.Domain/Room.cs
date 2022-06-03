using Coursework.Domain.Interfaces;

namespace Coursework.Domain;

public class Room : IHaveId
{
    public int Id { get; set; }
    public int BuildingId { get; set; }
    public int RoomNumber { get; set; }
}