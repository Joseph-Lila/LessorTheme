using Coursework.Domain.Interfaces;

namespace Coursework.Domain;

public class User : IHaveId
{
    public int Id { get; set; }
    public string Login { get; set; } = "";
    public string Password { get; set; } = "";
    public string Email { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
}