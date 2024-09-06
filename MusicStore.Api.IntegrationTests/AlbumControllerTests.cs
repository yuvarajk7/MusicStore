using System.Diagnostics;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using MusicStore.Domain.DTOs;
using MusicStore.Infrastructure;

namespace MusicStore.Api.IntegrationTests;

public class AlbumControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    
    public AlbumControllerTests(WebApplicationFactory<Program> factory)
    {
        WebApplicationFactory<Program> factory1 = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                // Replace the real database with an in-memory database for tests
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<MusicStoreContext>));
                Debug.Assert(descriptor != null, nameof(descriptor) + " != null");
                services.Remove(descriptor);
                services.AddDbContext<MusicStoreContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });
            });
        });

        _client = factory1.CreateClient();
    }
    
    [Fact]
    public async Task GetAllAlbums_ShouldReturnEmptyList_WhenNoAlbumsExist()
    {
        // Act
        var response = await _client.GetAsync("/api/albums");

        // Assert
        response.EnsureSuccessStatusCode();
        var albums = await response.Content.ReadFromJsonAsync<IEnumerable<AlbumDto>>();
        albums.Should().BeEmpty();
    }
    
    [Fact]
    public async Task AddAlbum_ShouldCreateNewAlbum()
    {
        // Arrange
        var newAlbum = new AlbumDto
        {
            Name = "Test Album",
            Genre = "Male",
            Rating = 4.5,
            TotalSold = 100,
            ReleaseDate = new DateTime(2021, 1, 1),
            Artists =
            [
                new ArtistDto
                {
                    FirstName = "Test",
                    LastName = "LN",
                    Gender = "Male",
                    Country = "USA"
                }
            ]
        };

        // Act
        var postResponse = await _client.PostAsJsonAsync("/api/albums", newAlbum);

        // Assert
        postResponse.EnsureSuccessStatusCode();

        var getResponse = await _client.GetAsync("/api/albums");
        var albums = await getResponse.Content.ReadFromJsonAsync<IEnumerable<AlbumDto>>();
        albums.Should().ContainSingle(album => album.Name == "Test Album");
    }
    
    [Fact]
    public async Task UpdateAlbum_ShouldModifyExistingAlbum()
    {
        // Arrange
        var album = new AlbumDto
        {
            Id = 1,
            Name = "Album1",
            Genre = "Male",
            Rating = 4.5,
            TotalSold = 100,
            ReleaseDate = new DateTime(2021, 1, 1),
            Artists =
            [
                new ArtistDto
                {
                    Id = 1,
                    AlbumId = 1,
                    FirstName = "Test",
                    LastName = "LN",
                    Gender = "Male",
                    Country = "USA"
                }
            ]
        };

        await _client.PostAsJsonAsync("/api/albums", album);

        var albums = await _client.GetFromJsonAsync<IEnumerable<AlbumDto>>("/api/albums");
        var albumToUpdate = albums!.First();
        albumToUpdate.Name = "Updated Album";

        // Act
        var updateResponse = await _client.PutAsJsonAsync($"/api/albums/{albumToUpdate.Id}", albumToUpdate);

        // Assert
        updateResponse.EnsureSuccessStatusCode();

        var updatedAlbums = await _client.GetFromJsonAsync<IEnumerable<AlbumDto>>("/api/albums");
        updatedAlbums.Should().ContainSingle(a => a.Name == "Updated Album");
    }

    [Fact]
    public async Task DeleteAlbum_ShouldRemoveAlbum()
    {
        // Arrange
        var album = new AlbumDto
        {
            Id = 1,
            Name = "Album1",
            Genre = "Male",
            Rating = 4.5,
            TotalSold = 100,
            ReleaseDate = new DateTime(2021, 1, 1),
            Artists =
            [
                new ArtistDto
                {
                    Id = 1,
                    AlbumId = 1,
                    FirstName = "Test",
                    LastName = "LN",
                    Gender = "Male",
                    Country = "USA"
                }
            ]
        };

        await _client.PostAsJsonAsync("/api/albums", album);
        var albums = await _client.GetFromJsonAsync<IEnumerable<AlbumDto>>("/api/albums");
        var albumToDelete = albums!.First();

        // Act
        var deleteResponse = await _client.DeleteAsync($"/api/albums/{albumToDelete.Id}");

        // Assert
        deleteResponse.EnsureSuccessStatusCode();

        var remainingAlbums = await _client.GetFromJsonAsync<IEnumerable<AlbumDto>>("/api/albums");
        remainingAlbums.Should().BeEmpty();
    }
}