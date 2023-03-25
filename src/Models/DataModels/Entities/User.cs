using System.ComponentModel.DataAnnotations;
using DataModels.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataModels.Entities;

[PrimaryKey(nameof(Id))]
public class User 
{
    public int Id { get; init; }

    [Required] public RoleEnum RoleName { get; set; }

    [MinLength(3), MaxLength(500)]
    [Required]
    public string FullName { get; set; } = null!;

    [Required] public string? PasswordHash { get; set; }

    [EmailAddress, Required] public string Email { get; set; } = null!;
    [Required] public string PhoneNumber { get; set; } = null!;

    public SexEnum? Sex { get; set; } = SexEnum.Unknown;

    public DateOnly? Birthday { get; set; }

    public int? PlaceId { get; set; }

    public Place? Place { get; set; }

    public virtual IList<Message> Messages { get; set; } = new List<Message>();

    public static User Guest => new()
    {
        Id = -1,
        RoleName = RoleEnum.Guest, 
        FullName = "Гость",
        Email = "guest@mail.com",
        PhoneNumber = "0"
    };

    public static User Admin => new()
    {
        Id = 0,
        RoleName = RoleEnum.Admin,
        FullName = "admin",
        PasswordHash = Helpers.GetHashString("admin"),
        Email = "MustChange@Must.Change",
        PhoneNumber = "MustChange"
    };
}