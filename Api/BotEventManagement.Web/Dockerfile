FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["BotEventManagement.Web/BotEventManagement.Web.csproj", "BotEventManagement.Web/"]
COPY ["BotEventManagement.Services/BotEventManagement.Services.csproj", "BotEventManagement.Services/"]
COPY ["BotEventManagement.Models/BotEventManagement.Models.csproj", "BotEventManagement.Models/"]
RUN dotnet restore "BotEventManagement.Web/BotEventManagement.Web.csproj"
COPY . .
WORKDIR "/src/BotEventManagement.Web"
RUN dotnet build "BotEventManagement.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BotEventManagement.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BotEventManagement.Web.dll"]