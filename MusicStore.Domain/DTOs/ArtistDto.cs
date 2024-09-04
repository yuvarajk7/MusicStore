namespace MusicStore.Domain.DTOs;

public class ArtistDto
{
    public int  Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Country { get; set; }
    public int AlbumId { get; set; }
}