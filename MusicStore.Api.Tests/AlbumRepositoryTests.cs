using Microsoft.EntityFrameworkCore;
using MusicStore.Infrastructure;
using MusicStore.Infrastructure.Repositories;

namespace MusicStore.Api.Tests;

public class AlbumRepositoryTests
{
    private readonly DbContextOptions<MusicStoreContext> _dbContextOptions;
    
    public AlbumRepositoryTests()
    {
        // Set up the in-memory database options
        _dbContextOptions = new DbContextOptionsBuilder<MusicStoreContext>()
            .UseInMemoryDatabase(databaseName: "TestMusicStoreDb")
            .Options;
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllAlbums()
    {
        // Arrange
        await using (var context = new MusicStoreContext(_dbContextOptions))
        {
            context.Albums.AddRange(new List<Album>
            {
                new Album { Id = 1, Name = "Album 1", Genre = "Pop", 
                            Rating = 4.5, TotalSold = 150, ReleaseDate = DateTime.Today,
                            Artists = new List<Artist>()
                            {
                                new Artist() { AlbumId = 1, Country = "USA", FirstName = "FN", 
                                                LastName = "LN", Gender = "Male"},
                                new Artist() { AlbumId = 1, Country = "USA", FirstName = "FN2", 
                                                LastName = "LN2", Gender = "Female"},
                            }
                },
                new Album { Id = 2, Name = "Album 2", Genre = "Rock", 
                    Rating = 2.5, TotalSold = 50, ReleaseDate = DateTime.Today,
                    Artists = new List<Artist>()
                    {
                        new Artist() { AlbumId = 2, Country = "UK", FirstName = "FN", 
                            LastName = "LN", Gender = "Female"}
                    }
                },
            });
            await context.SaveChangesAsync();

            var repository = new AlbumRepository(context);

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }
    }
    
    [Fact]
    public async Task GetByIdAsync_ShouldReturnAlbum_WhenAlbumExists()
    {
        // Arrange
        using (var context = new MusicStoreContext(_dbContextOptions))
        {
            var album = new Album
            {
                Id = 3, Name = "Album 3", Genre = "Rock",
                Rating = 2.5, TotalSold = 50, ReleaseDate = DateTime.Today,
                Artists = new List<Artist>()
                {
                    new Artist()
                    {
                        AlbumId = 3, Country = "UK", FirstName = "FN",
                        LastName = "LN", Gender = "Female"
                    }
                }
            };
            context.Albums.Add(album);
            await context.SaveChangesAsync();

            var repository = new AlbumRepository(context);

            // Act
            var result = await repository.GetByIdAsync(album.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(album.Id, result.Id);
            Assert.Equal(album.Name, result.Name);
        }
    }
    
    [Fact]
    public async Task AddAsync_ShouldAddAlbumToDatabase()
    {
        // Arrange
        using (var context = new MusicStoreContext(_dbContextOptions))
        {
            var repository = new AlbumRepository(context);
            var album = new Album
            {
                Id = 4, Name = "Album 4", Genre = "Rock",
                Rating = 2.5, TotalSold = 50, ReleaseDate = DateTime.Today,
                Artists = new List<Artist>()
                {
                    new Artist()
                    {
                        AlbumId = 4, Country = "UK", FirstName = "FN",
                        LastName = "LN", Gender = "Female"
                    }
                }
            };

            // Act
            await repository.AddAsync(album);

            // Assert
            var addedAlbum = await context.Albums.FindAsync(4);
            Assert.NotNull(addedAlbum);
            Assert.Equal(album.Name, addedAlbum.Name);
        }
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateAlbumInDatabase()
    {
        // Arrange
        using (var context = new MusicStoreContext(_dbContextOptions))
        {
            var album = new Album
            {
                Id = 2, Name = "Album new", Genre = "Rock",
                Rating = 2.5, TotalSold = 50, ReleaseDate = DateTime.Today,
                Artists = new List<Artist>()
                {
                    new Artist()
                    {
                        AlbumId = 2, Country = "UK", FirstName = "FN",
                        LastName = "LN", Gender = "Female"
                    }
                }
            };
            context.Albums.Add(album);
            await context.SaveChangesAsync();

            var repository = new AlbumRepository(context);
            album.Name = "Updated Album";

            // Act
            await repository.UpdateAsync(album);

            // Assert
            var updatedAlbum = await context.Albums.FindAsync(album.Id);
            Assert.NotNull(updatedAlbum);
            Assert.Equal("Updated Album", updatedAlbum.Name);
        }
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveAlbumFromDatabase()
    {
        // Arrange
        using (var context = new MusicStoreContext(_dbContextOptions))
        {
            var album = new Album
            {
                Id = 5, Name = "Album new", Genre = "Rock",
                Rating = 2.5, TotalSold = 50, ReleaseDate = DateTime.Today,
                Artists = new List<Artist>()
                {
                    new Artist()
                    {
                        AlbumId = 5, Country = "UK", FirstName = "FN",
                        LastName = "LN", Gender = "Female"
                    }
                }
            };
            context.Albums.Add(album);
            await context.SaveChangesAsync();

            var repository = new AlbumRepository(context);

            // Act
            await repository.DeleteAsync(album.Id);

            // Assert
            var deletedAlbum = await context.Albums.FindAsync(album.Id);
            Assert.Null(deletedAlbum);
        }
    }

    [Fact]
    public async Task DeleteAsync_ShouldDoNothing_WhenAlbumDoesNotExist()
    {
        // Arrange
        using (var context = new MusicStoreContext(_dbContextOptions))
        {
            var repository = new AlbumRepository(context);

            // Act
            await repository.DeleteAsync(999);  // Non-existing album

            // Assert
            // No exception should be thrown, and nothing should happen.
            Assert.Equal(0, context.Albums.Count());
        }
    }
}