using Microsoft.EntityFrameworkCore;
using MusicStore.Domain.Models;

namespace MusicStore.Infrastructure;

public class MusicStoreContext(DbContextOptions<MusicStoreContext> options) : DbContext(options)
{
    public DbSet<Album> Albums { get; set; }
    public DbSet<Artist> Artists { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>()
            .HasMany(a => a.Artists)
            .WithOne(a => a.Album)
            .HasForeignKey(a => a.AlbumId);

        modelBuilder.Seed();

        base.OnModelCreating(modelBuilder);
    }
}