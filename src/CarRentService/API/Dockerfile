#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/CarRentService/API/CarRent.API.csproj", "src/CarRentService/API/"]
COPY ["src/Core/Common/Core.Common.csproj", "src/Core/Common/"]
COPY ["src/Core/Models/Core.Models.csproj", "src/Core/Models/"]
COPY ["src/CarRentService/CarRentApplication/CarRent.Application.csproj", "src/CarRentService/CarRentApplication/"]
COPY ["src/CarRentService/CarRentModels/CarRent.Models.csproj", "src/CarRentService/CarRentModels/"]
COPY ["src/CarRentService/Infrastructure/CarRent.Infrastructure.csproj", "src/CarRentService/Infrastructure/"]
RUN dotnet restore "src/CarRentService/API/CarRent.API.csproj"
COPY . .
WORKDIR "/src/src/CarRentService/API"
RUN dotnet build "CarRent.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarRent.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarRent.API.dll"]