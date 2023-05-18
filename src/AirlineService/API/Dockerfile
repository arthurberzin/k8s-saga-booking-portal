#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/AirlineService/API/Airline.API.csproj", "src/AirlineService/API/"]
COPY ["src/AirlineService/AirlineApplication/Airline.Application.csproj", "src/AirlineService/AirlineApplication/"]
COPY ["src/AirlineService/Infrastructure/Airline.Infrastructure.csproj", "src/AirlineService/Infrastructure/"]
COPY ["src/AirlineService/AirlineModels/Airline.Models.csproj", "src/AirlineService/AirlineModels/"]
RUN dotnet restore "src/AirlineService/API/Airline.API.csproj"
COPY . .
WORKDIR "/src/src/AirlineService/API"
RUN dotnet build "Airline.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Airline.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Airline.API.dll"]