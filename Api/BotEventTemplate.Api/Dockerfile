FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY BotEventTemplate.Api/BotEventManagement.Api.csproj BotEventTemplate.Api/
COPY BotEventManagement.Services/BotEventManagement.Services.csproj BotEventManagement.Services/
COPY BotEventManagement.Services/BotEventManagement.Models.csproj BotEventManagement.Models/
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
