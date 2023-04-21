#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/AggregatorService/API/Aggregator.API.csproj", "src/AggregatorService/API/"]
COPY ["src/AggregatorService/AggregatorApplication/Aggregator.Application.csproj", "src/AggregatorService/AggregatorApplication/"]
COPY ["src/Core/Models/Core.Models.csproj", "src/Core/Models/"]
COPY ["src/AggregatorService/AggregatorModels/Aggregator.Models.csproj", "src/AggregatorService/AggregatorModels/"]
RUN dotnet restore "src/AggregatorService/API/Aggregator.API.csproj"
COPY . .
WORKDIR "/src/src/AggregatorService/API"
RUN dotnet build "Aggregator.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aggregator.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aggregator.API.dll"]