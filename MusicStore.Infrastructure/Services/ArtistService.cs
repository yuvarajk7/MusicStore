using AutoMapper;
using MusicStore.Domain.DTOs;
using MusicStore.Domain.Models;
using MusicStore.Domain.Repositories;
using MusicStore.Domain.Services;

namespace MusicStore.Infrastructure.Services;

public class ArtistService : IArtistService
{
    private readonly IArtistRepository _artistRepository;
    private readonly IMapper _mapper;

    public ArtistService(IArtistRepository artistRepository, IMapper mapper)
    {
        _artistRepository = artistRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ArtistDto>> GetAllAsync()
    {
        var artists = await _artistRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ArtistDto>>(artists);
    }

    public async Task<ArtistDto> GetByIdAsync(int id)
    {
        var artist = await _artistRepository.GetByIdAsync(id);
        return _mapper.Map<ArtistDto>(artist);
    }

    public async Task AddAsync(ArtistDto artistDto)
    {
        var artist = _mapper.Map<Artist>(artistDto);
        await _artistRepository.AddAsync(artist);
    }

    public async Task UpdateAsync(ArtistDto artistDto)
    {
        var artist = _mapper.Map<Artist>(artistDto);
        await _artistRepository.UpdateAsync(artist);
    }

    public async Task DeleteAsync(int id) => await _artistRepository.DeleteAsync(id);
}