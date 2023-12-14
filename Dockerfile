#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY /Deploy/ /deploy/
RUN /deploy/Scripts/Bash/Startup.sh

#commands
#Download sql server
FROM mcr.microsoft.com/mssql/server:2017-latest
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=abcDEF123
ENV MSSQL_PID=Developer
ENV MSSQL_TCP_PORT=1433 
WORKDIR /src 
COPY filldata.sql ./filldata.sql 
RUN (/opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" &&  /opt/mssql-tools/bin/sqlcmd -S127.0.0.1 -Usa -PabcDEF123 -i filldata.sql



FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TrinityAPI.csproj", "."]
RUN dotnet restore "./TrinityAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TrinityAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TrinityAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrinityAPI.dll"]