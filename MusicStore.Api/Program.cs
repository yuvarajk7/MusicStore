using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicStore.Domain.DTOs;
using MusicStore.Domain.Repositories;
using MusicStore.Domain.Services;
using MusicStore.Infrastructure;
using MusicStore.Infrastructure.Repositories;
using MusicStore.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MusicStoreContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IArtistService, ArtistService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

app.MapGet("/api/albums", async (IAlbumService albumService) 
    => await albumService.GetAllAsync());
app.MapGet("/api/albums/{id}", async (int id, IAlbumService albumService) 
    => await albumService.GetByIdAsync(id));
app.MapPost("/api/albums", async (AlbumDto albumDto, IAlbumService albumService) 
    => await albumService.AddAsync(albumDto));
app.MapPut("/api/albums/{id}", async (int id, AlbumDto albumDto, IAlbumService albumService) 
    => await albumService.UpdateAsync(albumDto));
app.MapDelete("/api/albums/{id}", async (int id, IAlbumService albumService) 
    => await albumService.DeleteAsync(id));

app.MapGet("/api/artists", async (IArtistService artistService) 
    => await artistService.GetAllAsync());
app.MapGet("/api/artists/{id}", async (int id, IArtistService artistService) 
    => await artistService.GetByIdAsync(id));
app.MapPost("/api/artists", async (ArtistDto artistDto, IArtistService artistService) 
    => await artistService.AddAsync(artistDto));
app.MapPut("/api/artists/{id}", async (int id, ArtistDto artistDto, IArtistService artistService) 
    => await artistService.UpdateAsync(artistDto));
app.MapDelete("/api/artists/{id}", async (int id, IArtistService artistService) 
    => await artistService.DeleteAsync(id));

app.Run();
