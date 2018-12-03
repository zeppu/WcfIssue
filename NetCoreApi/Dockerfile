FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["NetCoreApi/NetCoreApi.csproj", "NetCoreApi/"]
RUN dotnet restore "NetCoreApi/NetCoreApi.csproj"
COPY . .
WORKDIR "/src/NetCoreApi"
RUN dotnet build "NetCoreApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NetCoreApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NetCoreApi.dll"]