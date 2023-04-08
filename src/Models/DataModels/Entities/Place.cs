using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataModels.Entities;

[PrimaryKey(nameof(Id))]
public class Place
{
    public int Id { get; init; }

    [Required]
    [MinLength(1), MaxLength(500)]
    public string Name { get; set; } = null!;

    public string? Image { get; set; }

    public virtual IList<User> Users { get; set; } = new List<User>();
    public virtual IList<Event> Events { get; set; } = new List<Event>();

    public override string ToString() => $"№{Id} - {Name}";

    public static readonly IList<Place> Places = new List<Place>
    {
        new() { Id = 1, Name = "РФ" },
        new() { Id = 2, Name = "КЗ" },
        new() { Id = 3, Name = "UK" }
    };
}