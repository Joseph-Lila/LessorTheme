namespace Coursework.BLL.DtoModels;

public class ComplexPlace
{
    public int BuildingId { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int BuildingNumber { get; set; }
    public int RoomId { get; set; }
    public int RoomNumber { get; set; }
    public int PlaceNumber { get; set; }
    public double PricePerDay { get; set; }
    public bool IsFree { get; set; }
    public int PlaceId { get; set; }
    public int LessorId { get; set; }
    public int Rating { get; set; }
    public string NickName { get; set; }
}