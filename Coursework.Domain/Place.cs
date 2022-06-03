using Coursework.Domain.Interfaces;

namespace Coursework.Domain;

public class Place : IHaveId
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int PlaceNumber { get; set; }
    public double PricePerDay { get; set; }
    public bool IsFree { get; set; }
    public int LessorId { get; set; }
}