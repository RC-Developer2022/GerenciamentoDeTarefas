#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Tarefas.Api/Tarefas.Api.csproj", "Tarefas.Api/"]
COPY ["Tarefas.Application/Tarefas.Application.csproj", "Tarefas.Application/"]
COPY ["Tarefas.infrastructure/Tarefas.infrastructure.csproj", "Tarefas.infrastructure/"]
COPY ["Tarefas.Domain/Tarefas.Domain.csproj", "Tarefas.Domain/"]
RUN dotnet restore "./Tarefas.Api/./Tarefas.Api.csproj"
COPY . .
WORKDIR "/src/Tarefas.Api"
RUN dotnet build "./Tarefas.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Tarefas.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tarefas.Api.dll"]