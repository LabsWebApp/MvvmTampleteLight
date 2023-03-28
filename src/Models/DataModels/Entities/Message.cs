using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataModels.Entities;

[PrimaryKey(nameof(Id))]
public class Message
{
    public long Id { get; init; }

    public int UserId { get; init; } = User.Guest.Id;
    public User? User { get; init; }

    public DateTime PublishTime { get; set; } = DateTime.Now;

    [MinLength(4), MaxLength(500)] public string? Title { get; set; }
    
    [MinLength(4), MaxLength(500)] public string Content { get; set; } = null!;
}