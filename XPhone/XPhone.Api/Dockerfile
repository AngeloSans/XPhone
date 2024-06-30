#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["XPhone.Api/XPhone.Api.csproj", "XPhone.Api/"]
COPY ["XPhone.Application/XPhone.Application.csproj", "XPhone.Application/"]
COPY ["XPhone.Domain/XPhone.Domain.csproj", "XPhone.Domain/"]
COPY ["XPhone.Infrastructure/XPhone.Infra.csproj", "XPhone.Infrastructure/"]
COPY ["XPhone.Tests/XPhone.Tests.csproj", "XPhone.Tests/"]
RUN dotnet restore "./XPhone.Api/./XPhone.Api.csproj"
COPY . .
WORKDIR "/src/XPhone.Api"
RUN dotnet build "./XPhone.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./XPhone.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "XPhone.Api.dll"]