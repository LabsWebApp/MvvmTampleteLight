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

    public int PlaceId { get; set; }
    public Place? Place { get; set; }

    public virtual IList<User> Participants { get; set; } = new List<User>();
    public virtual IList<User> Moderators { get; set; } = new List<User>();
    public virtual IList<User> Organizers { get; set; } = new List<User>();
    public virtual IList<User> MustBeChangedUsers { get; set; } = new List<User>();

    //public static readonly IList<Event> ExampleEvents = new List<Event>
    //{
    //    new()
    //    {
    //        Name = "Example1",
    //        StartedAt = new DateTime(2024, 5, 5),
    //        PlaceId = 1
    //    },
    //    new()
    //    {
    //        Name = "Example2",
    //        StartedAt = new DateTime(2024, 10, 5),
    //        PlaceId = 2
    //    },
    //    new()
    //    {
    //        Name = "Example3",
    //        StartedAt = new DateTime(2022, 11, 5),
    //        PlaceId = 3
    //    },
    //};
}