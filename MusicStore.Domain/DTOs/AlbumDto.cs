namespace MusicStore.Domain.DTOs;

public class AlbumDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int TotalSold { get; set; }
    public double Rating { get; set; }
    public List<ArtistDto> Artists { get; set; } = new();
}