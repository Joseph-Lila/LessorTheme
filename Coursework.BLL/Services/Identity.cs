using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Coursework.BLL.Services;

public static class Identity
{
    public static string Login { get; set; } = "";
    public static string Email { get; set; } = "";
    public static string PhoneNumber { get; set; } = "";
    public static bool IsAuthorized { get; set; } = false;
    public static int LessorId { get; set; }
    public static int UserId { get; set; }
    public static int TenantId { get; set; }
    public static string CurrentRole { get; set; } = "Guest";
    public static ObservableCollection<string> Roles { get; set; } = new ObservableCollection<string> { "Guest" };
}