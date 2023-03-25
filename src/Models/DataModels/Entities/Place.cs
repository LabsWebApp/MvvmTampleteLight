using Microsoft.EntityFrameworkCore;

namespace DataModels.Entities;

[PrimaryKey(nameof(Id))]
public class Place
{
    public int Id { get; init; }

    public string Name { get; set; } = null!;

    public byte[]? Image { get; set; }

    public virtual IList<User> Users { get; set; } = new List<User>();
}