using MusicStore.Domain.Models;

namespace MusicStore.Domain.Repositories;

public interface IAlbumRepository
{
    Task<IEnumerable<Album>> GetAllAsync(int pageNumber, int pageSize, string sortBy, bool ascending);
    Task<Album> GetByIdAsync(int id);
    Task AddAsync(Album album);
    Task UpdateAsync(Album album);
    Task DeleteAsync(int id);
}