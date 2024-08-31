using MusicStore.Domain.Models;

namespace MusicStore.Domain.Repositories;

public interface IArtistRepository
{
    Task<IEnumerable<Artist>> GetAllAsync();
    Task<Artist> GetByIdAsync(int id);
    Task AddAsync(Artist artist);
    Task UpdateAsync(Artist artist);
    Task DeleteAsync(int id);
}