using AutoMapper;
using MusicStore.Domain.DTOs;
using MusicStore.Domain.Models;
using MusicStore.Domain.Repositories;
using MusicStore.Domain.Services;

namespace MusicStore.Infrastructure.Services;

public class AlbumService : IAlbumService
{
    private readonly IAlbumRepository _albumRepository;
    private readonly IMapper _mapper;

    public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
    {
        _albumRepository = albumRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AlbumDto>> GetAllAsync(int pageNumber, int pageSize, string sortBy, bool ascending)
    {
        var albums = await _albumRepository.GetAllAsync( pageNumber, pageSize, sortBy, ascending);
        return _mapper.Map<IEnumerable<AlbumDto>>(albums);
    }

    public async Task<AlbumDto> GetByIdAsync(int id)
    {
        var album = await _albumRepository.GetByIdAsync(id);
        return _mapper.Map<AlbumDto>(album);
    }

    public async Task AddAsync(AlbumDto albumDto)
    {
        var album = _mapper.Map<Album>(albumDto);
        await _albumRepository.AddAsync(album);
    }

    public async Task UpdateAsync(AlbumDto albumDto)
    {
        var album = _mapper.Map<Album>(albumDto);
        await _albumRepository.UpdateAsync(album);
    }

    public async Task DeleteAsync(int id) 
        => await _albumRepository.DeleteAsync(id);
}