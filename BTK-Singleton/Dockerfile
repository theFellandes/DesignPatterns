FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BTK-Singleton/BTK-Singleton.csproj", "BTK-Singleton/"]
RUN dotnet restore "BTK-Singleton/BTK-Singleton.csproj"
COPY . .
WORKDIR "/src/BTK-Singleton"
RUN dotnet build "BTK-Singleton.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BTK-Singleton.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BTK-Singleton.dll"]
