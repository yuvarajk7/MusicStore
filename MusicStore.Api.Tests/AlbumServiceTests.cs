namespace MusicStore.Api.Tests;

public class AlbumServiceTests
{
    private readonly IFixture _fixture;
    private readonly Mock<IAlbumRepository> _albumRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly AlbumService _albumService;

    public AlbumServiceTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        _albumRepositoryMock = _fixture.Freeze<Mock<IAlbumRepository>>();
        _mapperMock = _fixture.Freeze<Mock<IMapper>>();
        _albumService = new AlbumService(_albumRepositoryMock.Object, _mapperMock.Object);
    }
    
    [Fact]
    public async Task GetAllAlbums_ShouldReturnAlbums()
    {
        //Arrange
        var albums = _fixture.Build<Album>().OmitAutoProperties().CreateMany<Album>();
        var albumDtos = _fixture.Build<AlbumDto>().OmitAutoProperties().CreateMany<AlbumDto>();
        _albumRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(albums);
        _mapperMock.Setup(m => m.Map<IEnumerable<AlbumDto>>(albums)).Returns(albumDtos);
        
        // Act
        var result = await _albumService.GetAllAsync();
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(albumDtos, result);
        _albumRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        _mapperMock.Verify(m => m.Map<IEnumerable<AlbumDto>>(albums), Times.Once);
    }
    
    [Fact]
    public async Task GetByIdAsync_ShouldReturnMappedAlbum_WhenAlbumExists()
    {
        // Arrange
        var album = _fixture.Build<Album>().OmitAutoProperties().Create<Album>();
        var albumDto = _fixture.Build<AlbumDto>().OmitAutoProperties().Create<AlbumDto>();
        var albumId = album.Id;  // Assuming Album has an Id property
        _albumRepositoryMock.Setup(repo => repo.GetByIdAsync(albumId)).ReturnsAsync(album);
        _mapperMock.Setup(m => m.Map<AlbumDto>(album)).Returns(albumDto);

        // Act
        var result = await _albumService.GetByIdAsync(albumId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(albumDto, result);
        _albumRepositoryMock.Verify(repo => repo.GetByIdAsync(albumId), Times.Once);
        _mapperMock.Verify(m => m.Map<AlbumDto>(album), Times.Once);
    }
    
    [Fact]
    public async Task AddAsync_ShouldCallRepositoryWithMappedAlbum()
    {
        // Arrange
        var albumDto = _fixture.Build<AlbumDto>().OmitAutoProperties().Create<AlbumDto>();
        var album = _fixture.Build<Album>().OmitAutoProperties().Create<Album>();
        _mapperMock.Setup(m => m.Map<Album>(albumDto)).Returns(album);

        // Act
        await _albumService.AddAsync(albumDto);

        // Assert
        _albumRepositoryMock.Verify(repo => repo.AddAsync(album), Times.Once);
        _mapperMock.Verify(m => m.Map<Album>(albumDto), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallRepositoryWithMappedAlbum()
    {
        // Arrange
        var albumDto = _fixture.Build<AlbumDto>().OmitAutoProperties().Create<AlbumDto>();
        var album = _fixture.Build<Album>().OmitAutoProperties().Create<Album>();
        _mapperMock.Setup(m => m.Map<Album>(albumDto)).Returns(album);

        // Act
        await _albumService.UpdateAsync(albumDto);

        // Assert
        _albumRepositoryMock.Verify(repo => repo.UpdateAsync(album), Times.Once);
        _mapperMock.Verify(m => m.Map<Album>(albumDto), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallRepositoryWithCorrectId()
    {
        // Arrange
        var albumId = _fixture.Create<int>();

        // Act
        await _albumService.DeleteAsync(albumId);

        // Assert
        _albumRepositoryMock.Verify(repo => repo.DeleteAsync(albumId), Times.Once);
    }
}