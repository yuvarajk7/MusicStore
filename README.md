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

