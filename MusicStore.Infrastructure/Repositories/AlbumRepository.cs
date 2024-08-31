using Microsoft.EntityFrameworkCore;
using MusicStore.Domain.Models;
using MusicStore.Domain.Repositories;

namespace MusicStore.Infrastructure.Repositories;

public class AlbumRepository : IAlbumRepository
{
    private readonly MusicStoreContext _context;

    public AlbumRepository(MusicStoreContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Album>> GetAllAsync() => 
        await _context
            .Albums
            .Include(a => a.Artists)
            .ToListAsync();

    public async Task<Album> GetByIdAsync(int id) => 
        await _context
            .Albums
            .Include(a => a.Artists)
            .FirstOrDefaultAsync(a => a.Id == id);

    public async Task AddAsync(Album album)
    {
        _context.Albums.Add(album);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Album album)
    {
        _context.Albums.Update(album);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var album = await _context.Albums.FindAsync(id);
        if (album != null)
        {
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
        }
    }
}