FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
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