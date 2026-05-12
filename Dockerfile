# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
# USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MMOlogs_BackEnd/MMOlogs_BackEnd.csproj", "MMOlogs_BackEnd/"]
COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["Repository/Repository.csproj", "Repository/"]
RUN dotnet restore "MMOlogs_BackEnd/MMOlogs_BackEnd.csproj"
COPY . .
WORKDIR "/src/MMOlogs_BackEnd"
RUN dotnet build "MMOlogs_BackEnd.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MMOlogs_BackEnd.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY mmo.db /app/mmo.db
ENV RUNNING_IN_DOCKER=true
ENTRYPOINT ["dotnet", "MMOlogs_BackEnd.dll"]
