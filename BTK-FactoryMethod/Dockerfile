FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BTK-FactoryMethod/BTK-FactoryMethod.csproj", "BTK-FactoryMethod/"]
RUN dotnet restore "BTK-FactoryMethod/BTK-FactoryMethod.csproj"
COPY . .
WORKDIR "/src/BTK-FactoryMethod"
RUN dotnet build "BTK-FactoryMethod.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BTK-FactoryMethod.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BTK-FactoryMethod.dll"]
