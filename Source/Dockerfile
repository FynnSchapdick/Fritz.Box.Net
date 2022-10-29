FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Source/FritzBoxPrometheusExporter/", "Source/FritzBoxPrometheusExporter/"]
COPY ["Source/RS.Fritz.Manager.API/", "Source/RS.Fritz.Manager.API/"]
WORKDIR "/src/Source/FritzBoxPrometheusExporter"
RUN dotnet build "FritzBoxPrometheusExporter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FritzBoxPrometheusExporter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FritzBoxPrometheusExporter.dll"]