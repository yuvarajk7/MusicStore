using Microsoft.EntityFrameworkCore;
using MusicStore.Domain.Models;
using MusicStore.Domain.Repositories;

namespace MusicStore.Infrastructure.Repositories;

public class ArtistRepository : IArtistRepository
{
    private readonly MusicStoreContext _context;

    public ArtistRepository(MusicStoreContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Artist>> GetAllAsync() => await _context.Artists.ToListAsync();

    public async Task<Artist> GetByIdAsync(int id) => await _context.Artists.FindAsync(id);

    public async Task AddAsync(Artist artist)
    {
        _context.Artists.Add(artist);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Artist artist)
    {
        _context.Artists.Update(artist);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var artist = await _context.Artists.FindAsync(id);
        if (artist != null)
        {
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
        }
    }
}