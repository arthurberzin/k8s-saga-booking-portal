#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/WebPortal/Portal/WebPortal.csproj", "src/WebPortal/Portal/"]
COPY ["src/WebPortal/WebPortalApplication/WebPortal.Application.csproj", "src/WebPortal/WebPortalApplication/"]
COPY ["src/Core/Models/Core.Models.csproj", "src/Core/Models/"]
COPY ["src/WebPortal/WebPortalModels/WebPortal.Models.csproj", "src/WebPortal/WebPortalModels/"]
RUN dotnet restore "src/WebPortal/Portal/WebPortal.csproj"
COPY . .
WORKDIR "/src/src/WebPortal/Portal"
RUN dotnet build "WebPortal.csproj" -c Release -o /app/build

RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev gnupg libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get update && apt-get install -y nodejs

FROM build AS publish
RUN dotnet publish "WebPortal.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebPortal.dll"]