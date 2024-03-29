#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Mc2.CrudTest.Presentation/Server/Mc2.CrudTest.Presentation.Server.csproj", "Mc2.CrudTest.Presentation/Server/"]
COPY ["Mc2.CrudTest.Domain/Mc2.CrudTest.Domain.csproj", "Mc2.CrudTest.Domain/"]
COPY ["Mc2.CrudTest.Infrastructure/Mc2.CrudTest.Infrastructure.csproj", "Mc2.CrudTest.Infrastructure/"]
COPY ["Mc2.CrudTest.Services/Mc2.CrudTest.Services.csproj", "Mc2.CrudTest.Services/"]
COPY ["Mc2.CrudTest.Presentation/Client/Mc2.CrudTest.Presentation.Client.csproj", "Mc2.CrudTest.Presentation/Client/"]
COPY ["Mc2.CrudTest.Presentation/Shared/Mc2.CrudTest.Presentation.Shared.csproj", "Mc2.CrudTest.Presentation/Shared/"]
RUN dotnet restore "./Mc2.CrudTest.Presentation/Server/./Mc2.CrudTest.Presentation.Server.csproj"
COPY . .
WORKDIR "/src/Mc2.CrudTest.Presentation/Server"
RUN dotnet build "./Mc2.CrudTest.Presentation.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Mc2.CrudTest.Presentation.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mc2.CrudTest.Presentation.Server.dll"]