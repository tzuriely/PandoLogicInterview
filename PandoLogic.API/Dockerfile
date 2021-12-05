#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PandoLogic.API/PandoLogic.API.csproj", "PandoLogic.API/"]
COPY ["PandoLogic.Application/PandoLogic.Application.csproj", "PandoLogic.Application/"]
COPY ["PandoLogic.Domain/PandoLogic.Domain.csproj", "PandoLogic.Domain/"]
COPY ["PandoLogic.Infrastructure/PandoLogic.Infrastructure.csproj", "PandoLogic.Infrastructure/"]
RUN dotnet restore "PandoLogic.API/PandoLogic.API.csproj"
COPY . .
WORKDIR "/src/PandoLogic.API"
RUN dotnet build "PandoLogic.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PandoLogic.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PandoLogic.API.dll"]
