namespace Coursework.BLL.DtoModels;

public class StatisticDto
{
    public int PlaceId { get; set; }
    public int QuantityTenants { get; set; }
    public string Country { get; set; } = "";
    public string City { get; set; } = "";
    public string Street { get; set; } = "";
    public int BuildingNumber { get; set; }
    public int RoomNumber { get; set; }
    public int PlaceNumber { get; set; }
}