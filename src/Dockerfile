FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["bash", "-c", "dotnet ef database update && dotnet BackendApi.dll"]
#WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BackendApi/BackendApi.csproj", "BackendApi/"]
COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
RUN dotnet restore "BackendApi/BackendApi.csproj"
COPY . .
WORKDIR "/src/BackendApi"
RUN dotnet build "BackendApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackendApi.csproj" -c Release -o /app/publish /p:UserAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackendApi.dll"]