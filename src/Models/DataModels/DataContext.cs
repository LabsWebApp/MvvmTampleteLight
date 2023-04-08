using DataModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataModels;

public sealed class DataContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;
    public DbSet<Place> Places { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;

    public DataContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=>
        optionsBuilder.UseSqlite("Data Source=C:\\Data\\data.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
            .HasMany(e => e.Participants)
            .WithMany(u => u.ParticipantEvents)
            .UsingEntity(j => j.ToTable("ParticipantEvent"));

        modelBuilder.Entity<Event>()
            .HasMany(e => e.Moderators)
            .WithMany(u => u.ModeratorEvents)
            .UsingEntity(j => j.ToTable("ModeratorEvent"));

        modelBuilder.Entity<Event>()
            .HasMany(e => e.Organizers)
            .WithMany(u => u.OrganizerEvents)
            .UsingEntity(j => j.ToTable("OrganizerEvent"));
        
        modelBuilder.Entity<Event>()
            .HasMany(e => e.MustBeChangedUsers)
            .WithMany(u => u.MustBeChangedEvents)
            .UsingEntity(j => j.ToTable("MustBeChangedEvent"));

        modelBuilder.Entity<User>().HasData(User.Admin);
        modelBuilder.Entity<User>().HasData(User.Guest);

        foreach (var item in Place.Places) modelBuilder.Entity<Place>().HasData(item);
    }
}