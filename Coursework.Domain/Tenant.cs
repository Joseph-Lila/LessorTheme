using Coursework.Domain.Interfaces;

namespace Coursework.Domain;

public class Tenant : IHaveId
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public string Lastname { get; set; } = "";
    public string PassportData { get; set; } = "";
}