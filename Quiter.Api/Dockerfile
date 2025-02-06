#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Quiter.Api/Quiter.Api.csproj", "Quiter.Api/"]
COPY ["Ciuter.Shared/Ciuter.Shared.csproj", "Ciuter.Shared/"]
COPY ["Quiter.Scheduling.Infrastructure/Quiter.Scheduling.Infrastructure.csproj", "Quiter.Scheduling.Infrastructure/"]
COPY ["Quiter.Scheduling/Quiter.Scheduling.csproj", "Quiter.Scheduling/"]
RUN dotnet restore "./Quiter.Api/Quiter.Api.csproj"
COPY . .
WORKDIR "/src/Quiter.Api"
RUN dotnet build "./Quiter.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Quiter.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quiter.Api.dll"]