namespace MusicStore.Api.Tests;

public class ArtistServiceTests
{
    private readonly IFixture _fixture;
    private readonly Mock<IArtistRepository> _artistRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly ArtistService _artistService;

    public ArtistServiceTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        _artistRepositoryMock = _fixture.Freeze<Mock<IArtistRepository>>();
        _mapperMock = _fixture.Freeze<Mock<IMapper>>();
        _artistService = new ArtistService(_artistRepositoryMock.Object, _mapperMock.Object);
    }       
    
    [Fact]
    public async Task GetAllAsync_ShouldReturnMappedArtists_WhenArtistsExist()
    {
        // Arrange
        var artists = _fixture.Build<Artist>().OmitAutoProperties().CreateMany<Artist>();
        var artistDtos = _fixture.Build<ArtistDto>().OmitAutoProperties().CreateMany<ArtistDto>();
        _artistRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(artists);
        _mapperMock.Setup(m => m.Map<IEnumerable<ArtistDto>>(artists)).Returns(artistDtos);

        // Act
        var result = await _artistService.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(artistDtos, result);
        _artistRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        _mapperMock.Verify(m => m.Map<IEnumerable<ArtistDto>>(artists), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnMappedArtist_WhenArtistExists()
    {
        // Arrange
        var artist = _fixture.Build<Artist>().OmitAutoProperties().Create<Artist>();
        var artistDto = _fixture.Build<ArtistDto>().OmitAutoProperties().Create<ArtistDto>();
        var artistId = artist.Id;  // Assuming Artist has an Id property
        _artistRepositoryMock.Setup(repo => repo.GetByIdAsync(artistId)).ReturnsAsync(artist);
        _mapperMock.Setup(m => m.Map<ArtistDto>(artist)).Returns(artistDto);

        // Act
        var result = await _artistService.GetByIdAsync(artistId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(artistDto, result);
        _artistRepositoryMock.Verify(repo => repo.GetByIdAsync(artistId), Times.Once);
        _mapperMock.Verify(m => m.Map<ArtistDto>(artist), Times.Once);
    }

    [Fact]
    public async Task AddAsync_ShouldCallRepositoryWithMappedArtist()
    {
        // Arrange
        var artist = _fixture.Build<Artist>().OmitAutoProperties().Create<Artist>();
        var artistDto = _fixture.Build<ArtistDto>().OmitAutoProperties().Create<ArtistDto>();
        _mapperMock.Setup(m => m.Map<Artist>(artistDto)).Returns(artist);

        // Act
        await _artistService.AddAsync(artistDto);

        // Assert
        _artistRepositoryMock.Verify(repo => repo.AddAsync(artist), Times.Once);
        _mapperMock.Verify(m => m.Map<Artist>(artistDto), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallRepositoryWithMappedArtist()
    {
        // Arrange
        var artist = _fixture.Build<Artist>().OmitAutoProperties().Create<Artist>();
        var artistDto = _fixture.Build<ArtistDto>().OmitAutoProperties().Create<ArtistDto>();
        _mapperMock.Setup(m => m.Map<Artist>(artistDto)).Returns(artist);

        // Act
        await _artistService.UpdateAsync(artistDto);

        // Assert
        _artistRepositoryMock.Verify(repo => repo.UpdateAsync(artist), Times.Once);
        _mapperMock.Verify(m => m.Map<Artist>(artistDto), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallRepositoryWithCorrectId()
    {
        // Arrange
        var artistId = _fixture.Create<int>();

        // Act
        await _artistService.DeleteAsync(artistId);

        // Assert
        _artistRepositoryMock.Verify(repo => repo.DeleteAsync(artistId), Times.Once);
    }
}