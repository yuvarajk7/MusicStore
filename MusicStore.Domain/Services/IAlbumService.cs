using MusicStore.Domain.DTOs;

namespace MusicStore.Domain.Services;

public interface IAlbumService
{
    Task<IEnumerable<AlbumDto>> GetAllAsync();
    Task<AlbumDto> GetByIdAsync(int id);
    Task AddAsync(AlbumDto albumDto);
    Task UpdateAsync(AlbumDto albumDto);
    Task DeleteAsync(int id);
}