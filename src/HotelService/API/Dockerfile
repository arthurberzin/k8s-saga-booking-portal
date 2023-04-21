#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/HotelService/API/Hotel.API.csproj", "src/HotelService/API/"]
COPY ["src/HotelService/HotelApplication/Hotel.Application.csproj", "src/HotelService/HotelApplication/"]
COPY ["src/Core/Models/Core.Models.csproj", "src/Core/Models/"]
COPY ["src/HotelService/HotelModels/Hotel.Models.csproj", "src/HotelService/HotelModels/"]
RUN dotnet restore "src/HotelService/API/Hotel.API.csproj"
COPY . .
WORKDIR "/src/src/HotelService/API"
RUN dotnet build "Hotel.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hotel.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hotel.API.dll"]