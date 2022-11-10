FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Talleres.API/Talleres.API.csproj", "Talleres.API/"]
COPY ["Talleres.Domain/Talleres.Domain.csproj", "Talleres.Domain/"]
COPY ["Talleres.Infrastructure/Talleres.Infrastructure.csproj", "Talleres.Infrastructure/"]
RUN dotnet restore "Talleres.API/Talleres.API.csproj"
COPY . .
WORKDIR "/src/Talleres.API"
RUN dotnet build "Talleres.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Talleres.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Talleres.API.dll"]