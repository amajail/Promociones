#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Promociones.API/Promociones.API.csproj", "Promociones.API/"]
COPY ["Promociones.Domain/Promociones.Domain.csproj", "Promociones.Domain/"]
COPY ["Promociones.Infra.IoC/Promociones.Infra.IoC.csproj", "Promociones.Infra.IoC/"]
COPY ["Promociones.Application/Promociones.Application.csproj", "Promociones.Application/"]
COPY ["Promociones.Infra.Data/Promociones.Infra.Data.csproj", "Promociones.Infra.Data/"]
RUN dotnet restore "Promociones.API/Promociones.API.csproj"
COPY . .
WORKDIR "/src/Promociones.API"
RUN dotnet build "Promociones.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Promociones.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Promociones.API.dll"]
