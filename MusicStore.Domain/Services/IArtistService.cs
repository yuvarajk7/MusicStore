using MusicStore.Domain.DTOs;

namespace MusicStore.Domain.Services;

public interface IArtistService
{
    Task<IEnumerable<ArtistDto>> GetAllAsync();
    Task<ArtistDto> GetByIdAsync(int id);
    Task AddAsync(ArtistDto artistDto);
    Task UpdateAsync(ArtistDto artistDto);
    Task DeleteAsync(int id);
}