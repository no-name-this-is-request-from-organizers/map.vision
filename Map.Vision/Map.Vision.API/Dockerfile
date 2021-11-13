#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Map.Vision.API/Map.Vision.API.API/Map.Vision.API.API.csproj", "Map.Vision.API/Map.Vision.API.API/"]
COPY ["Map.Vision.API/Map.Vision.API.BI/Map.Vision.API.BI.csproj", "Map.Vision.API/Map.Vision.API.BI/"]
COPY ["Map.Vision.API/Map.Vision.API.Data/Map.Vision.API.Data.csproj", "Map.Vision.API/Map.Vision.API.Data/"]
COPY ["Map.Vision.API/Map.Vision.API.General/Map.Vision.API.General.csproj", "Map.Vision.API/Map.Vision.API.General/"]
RUN dotnet restore "Map.Vision.API/Map.Vision.API.API/Map.Vision.API.API.csproj"
COPY . .
WORKDIR "/src/Map.Vision.API/Map.Vision.API.API"
RUN dotnet build "Map.Vision.API.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Map.Vision.API.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Map.Vision.API.API.dll"]