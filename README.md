# MusicStore

### Create solution and project using dotnet cli
```sh
dotnet new sln -n MusicStore

dotnet new web -n MusicStore.Api
dotnet new classlib -n MusicStore.Domain
dotnet new classlib -n MusicStore.Infrastructure

dotnet sln add MusicStore.Api/MusicStore.Api.csproj
dotnet sln add MusicStore.Domain/MusicStore.Domain.csproj
dotnet sln add MusicStore.Infrastructure/MusicStore.Infrastructure.csproj

dotnet add MusicStore.Api/MusicStore.Api.csproj reference MusicStore.Domain/MusicStore.Domain.csproj
dotnet add MusicStore.Api/MusicStore.Api.csproj reference MusicStore.Infrastructure/MusicStore.Infrastructure.csproj  
dotnet add MusicStore.Infrastructure/MusicStore.Infrastructure.csproj reference MusicStore.Domain/MusicStore.Domain.csproj
```

### Create MusicStore.Api.Tests Projects
```sh
dotnet new xunit -n MusicStore.Api.Tests
dotnet sln add MusicStore.Api.Tests/MusicStore.Api.Tests.csproj

dotnet add MusicStore.Api.Tests package Moq
dotnet add MusicStore.Api.Tests package AutoFixture
dotnet add MusicStore.Api.Tests package AutoFixture.AutoMoq
dotnet add MusicStore.Api.Tests package Microsoft.AspNetCore.Mvc.Testing
dotnet add MusicStore.Api.Tests package Microsoft.EntityFrameworkCore.InMemory

```