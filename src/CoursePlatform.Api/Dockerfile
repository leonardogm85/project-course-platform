FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/
COPY ../ ./
RUN dotnet restore "./CoursePlatform.Api/CoursePlatform.Api.csproj"
RUN dotnet build "./CoursePlatform.Api/CoursePlatform.Api.csproj" \
  -c $BUILD_CONFIGURATION \
  -o /app/build
RUN dotnet publish "./CoursePlatform.Api/CoursePlatform.Api.csproj" \
  -c $BUILD_CONFIGURATION \
  -o /app/publish \
  /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app/
COPY --from=publish /app/publish ./
USER app
EXPOSE 8080
ENTRYPOINT ["dotnet", "./CoursePlatform.Api.dll"]
