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

    public byte[]? Image { get; set; }

    public virtual IList<User> Users { get; set; } = new List<User>();
    public virtual IList<Event> Events { get; set; } = new List<Event>();
}