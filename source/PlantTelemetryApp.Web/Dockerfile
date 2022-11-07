FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["source/PlantTelemetryApp.Web/PlantTelemetryApp.Web.csproj", "PlantTelemetryApp.Web/"]
RUN dotnet restore "PlantTelemetryApp.Web/PlantTelemetryApp.Web.csproj"

COPY ["/source", "."]
WORKDIR "/src/PlantTelemetryApp.Web"

RUN dotnet build "PlantTelemetryApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlantTelemetryApp.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlantTelemetryApp.Web.dll"]
