FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Udemy-Proxy/Udemy-Proxy.csproj", "Udemy-Proxy/"]
RUN dotnet restore "Udemy-Proxy/Udemy-Proxy.csproj"
COPY . .
WORKDIR "/src/Udemy-Proxy"
RUN dotnet build "Udemy-Proxy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Udemy-Proxy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Udemy-Proxy.dll"]
