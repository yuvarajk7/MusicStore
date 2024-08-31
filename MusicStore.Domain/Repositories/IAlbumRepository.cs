using MusicStore.Domain.Models;

namespace MusicStore.Domain.Repositories;

public interface IAlbumRepository
{
    Task<IEnumerable<Album>> GetAllAsync();
    Task<Album> GetByIdAsync(int id);
    Task AddAsync(Album album);
    Task UpdateAsync(Album album);
    Task DeleteAsync(int id);
}