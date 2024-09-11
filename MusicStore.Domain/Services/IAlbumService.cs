using MusicStore.Domain.DTOs;

namespace MusicStore.Domain.Services;

public interface IAlbumService
{
    Task<IEnumerable<AlbumDto>> GetAllAsync(int pageNumber, int pageSize, string sortBy, bool ascending);
    Task<AlbumDto> GetByIdAsync(int id);
    Task AddAsync(AlbumDto albumDto);
    Task UpdateAsync(AlbumDto albumDto);
    Task DeleteAsync(int id);
}