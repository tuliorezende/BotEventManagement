FROM  mcr.microsoft.com/dotnet/core/aspnet:2.2-2-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine AS build
WORKDIR /src
COPY BotEventTemplate.Api/BotEventManagement.Api.csproj BotEventTemplate.Api/
COPY BotEventManagement.Services/BotEventManagement.Services.csproj BotEventManagement.Services/
COPY BotEventManagement.Models/BotEventManagement.Models.csproj BotEventManagement.Models/
RUN dotnet restore BotEventTemplate.Api/BotEventManagement.Api.csproj
COPY . .
WORKDIR /src/BotEventTemplate.Api
RUN dotnet build BotEventManagement.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish BotEventManagement.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BotEventManagement.Api.dll"]
