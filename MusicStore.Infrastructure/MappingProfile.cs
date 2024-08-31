using AutoMapper;
using MusicStore.Domain.DTOs;
using MusicStore.Domain.Models;

namespace MusicStore.Infrastructure;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Album, AlbumDto>().ReverseMap();
        CreateMap<Artist, ArtistDto>().ReverseMap();
    }
}