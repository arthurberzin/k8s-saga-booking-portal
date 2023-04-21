#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Supportal/Portal/Supportal.csproj", "src/Supportal/Portal/"]
COPY ["src/Supportal/SupportalApplication/Supportal.Application.csproj", "src/Supportal/SupportalApplication/"]
COPY ["src/Core/Models/Core.Models.csproj", "src/Core/Models/"]
COPY ["src/Supportal/SupportalModels/Supportal.Models.csproj", "src/Supportal/SupportalModels/"]
RUN dotnet restore "src/Supportal/Portal/Supportal.csproj"
COPY . .
WORKDIR "/src/src/Supportal/Portal"
RUN dotnet build "Supportal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Supportal.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Supportal.dll"]