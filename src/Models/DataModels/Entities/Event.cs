using System.ComponentModel.DataAnnotations;
using DataModels.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataModels.Entities;

[PrimaryKey(nameof(Id))]
public class Event 
{
    public int Id { get; set; }

    public DateTime StartedAt { get; set; }
    public DateTime? EndedAt { get; set; }

    [MinLength(4), MaxLength(256)]
    public string Name { get; set; } = null!;

    public EventType? Type { get; set; }

    [MinLength(4), MaxLength(4096)]
    public string? Description { get; set; } = "Хорошая пьянка!";

    public Guid PlaceId { get; set; }
    public Place? Place { get; set; }

    public virtual IList<User> Participants { get; set; } = new List<User>();
    public virtual IList<User> Moderators { get; set; } = new List<User>();
    public virtual IList<User> Organizers { get; set; } = new List<User>();
}