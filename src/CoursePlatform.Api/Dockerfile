FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CoursePlatform.Api/CoursePlatform.Api.csproj", "src/CoursePlatform.Api/"]
RUN dotnet restore "./src/CoursePlatform.Api/CoursePlatform.Api.csproj"
COPY . .
WORKDIR "/src/src/CoursePlatform.Api"
RUN dotnet build "./CoursePlatform.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CoursePlatform.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoursePlatform.Api.dll"]
