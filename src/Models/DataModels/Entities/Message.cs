using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataModels.Entities;

[PrimaryKey(nameof(Id))]
public class Message
{
    public int Id { get; init; }

    public int UserId { get; init; } = User.Guest.Id;
    public User User { get; init; } = User.Guest;

    public DateTime PublishTime { get; set; } = DateTime.Now;

    public string? Title { get; set; }
    
    [MinLength(4), MaxLength(500)] public string Content { get; set; } = null!;
}