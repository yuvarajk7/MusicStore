namespace MusicStore.Domain.Models;

public class Artist
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Country { get; set; }
    public int  AlbumId { get; set; }
    public Album Album { get; set; }    
}       