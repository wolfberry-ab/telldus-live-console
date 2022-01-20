#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Wolfberry.TelldusLive.Console/Wolfberry.TelldusLive.Console.csproj", "Wolfberry.TelldusLive.Console/"]
RUN dotnet restore "Wolfberry.TelldusLive.Console/Wolfberry.TelldusLive.Console.csproj"
COPY . .
WORKDIR "/src/Wolfberry.TelldusLive.Console"
RUN dotnet build "Wolfberry.TelldusLive.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Wolfberry.TelldusLive.Console.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tdlive.dll"]
