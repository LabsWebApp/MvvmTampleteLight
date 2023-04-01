using System.ComponentModel.DataAnnotations;
using DataModels.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataModels.Entities;

[PrimaryKey(nameof(Id))]
public class User 
{
    public int Id { get; init; }

    [Required] public RoleEnum Role { get; set; }

    [MinLength(3), MaxLength(500)]
    [Required]
    public string FullName { get; set; } = null!;

    public string? PasswordHash { get; set; }

    [EmailAddress, Required] public string Email { get; set; } = string.Empty;
    
    [Required] public string PhoneNumber { get; set; } = string.Empty;

    public SexEnum? Sex { get; set; }

    public DateOnly? Birthday { get; set; }

    public int? PlaceId { get; set; }

    public Place? Place { get; set; }

    public virtual IList<Message> Messages { get; set; } = new List<Message>();

    public virtual IList<Event> ParticipantEvents { get; set; } = new List<Event>();
    public virtual IList<Event> ModeratorEvents { get; set; } = new List<Event>();
    public virtual IList<Event> OrganizerEvents { get; set; } = new List<Event>();

    public static User Guest => new()
    {
        Id = -1,
        Role = RoleEnum.Guest, 
        FullName = "Гость",
        Email = "guest@guest.guest",
        PhoneNumber = "0"
    };

    public static User Admin => new()
    {
        Id = 1,
        Role = RoleEnum.Admin,
        FullName = "admin",
        PasswordHash = Helpers.GetHashString("admin"),
        Email = "MustChange@Must.Change",
        PhoneNumber = "MustChange"
    };
}