# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files
COPY CodeApp.sln ./
COPY src/Core/CodeApp.Application/CodeApp.Application.csproj src/Core/CodeApp.Application/
COPY src/Core/CodeApp.Domain/CodeApp.Domain.csproj src/Core/CodeApp.Domain/
COPY src/Infrastructure/CodeApp.Infrastructure/CodeApp.Infrastructure.csproj src/Infrastructure/CodeApp.Infrastructure/
COPY src/Infrastructure/CodeApp.Persistence/CodeApp.Persistence.csproj src/Infrastructure/CodeApp.Persistence/
COPY src/WebAPI/CodeApp.WebAPI/CodeApp.WebAPI.csproj src/WebAPI/CodeApp.WebAPI/

# Restore only the deployable project (avoids test-project path issues in container)
RUN dotnet restore src/WebAPI/CodeApp.WebAPI/CodeApp.WebAPI.csproj

# Copy everything else
COPY . .

# Build the application
WORKDIR /src/src/WebAPI/CodeApp.WebAPI
RUN dotnet build -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy published files
COPY --from=publish /app/publish .

ENV ASPNETCORE_ENVIRONMENT=Production

# Railway sets PORT env variable, use shell to expand it
ENTRYPOINT ["sh", "-c", "dotnet CodeApp.WebAPI.dll --urls http://+:${PORT:-8080}"]
