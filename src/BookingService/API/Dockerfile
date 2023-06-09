#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/BookingService/API/Booking.API.csproj", "src/BookingService/API/"]
COPY ["src/Core/Common/Core.Common.csproj", "src/Core/Common/"]
COPY ["src/Core/Models/Core.Models.csproj", "src/Core/Models/"]
COPY ["src/BookingService/BookingApplication/Booking.Application.csproj", "src/BookingService/BookingApplication/"]
COPY ["src/BookingService/BookingModels/Booking.Models.csproj", "src/BookingService/BookingModels/"]
COPY ["src/BookingService/BookingInfrastructure/Booking.Infrastructure.csproj", "src/BookingService/BookingInfrastructure/"]
RUN dotnet restore "src/BookingService/API/Booking.API.csproj"
COPY . .
WORKDIR "/src/src/BookingService/API"
RUN dotnet build "Booking.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Booking.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Booking.API.dll"]