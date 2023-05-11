#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/BillingService/API/Billing.API.csproj", "src/BillingService/API/"]
COPY ["src/BillingService/BillingApplication/Billing.Application.csproj", "src/BillingService/BillingApplication/"]
COPY ["src/Core/Models/Core.Models.csproj", "src/Core/Models/"]
COPY ["src/BillingService/BillingModels/Billing.Models.csproj", "src/BillingService/BillingModels/"]
RUN dotnet restore "src/BillingService/API/Billing.API.csproj"
COPY . .
WORKDIR "/src/src/BillingService/API"
RUN dotnet build "Billing.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Billing.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Billing.API.dll"]