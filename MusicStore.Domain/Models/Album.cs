namespace MusicStore.Domain.Models;

public class Album
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int TotalSold { get; set; }
    public double Rating { get; set; }
    public ICollection<Artist> Artists { get; set; } 
}       