FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Backend/Presetatiton/HotellBooking.WebApi/HotellBooking.WebApi.csproj", "Backend/Presetatiton/HotellBooking.WebApi/"]
COPY ["Backend/Core/HotellBooking.Application/HotellBooking.Application.csproj", "Backend/Core/HotellBooking.Application/"]
COPY ["Backend/Core/HotellBooking.Domain/HotellBooking.Domain.csproj", "Backend/Core/HotellBooking.Domain/"]
COPY ["Backend/Persistence/HotellBooking.Persitence/HotellBooking.Persitence.csproj", "Backend/Persistence/HotellBooking.Persitence/"]
RUN dotnet restore "Backend/Presetatiton/HotellBooking.WebApi/HotellBooking.WebApi.csproj"
COPY . .
WORKDIR "/src/Backend/Presetatiton/HotellBooking.WebApi"
RUN dotnet build "HotellBooking.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "HotellBooking.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotellBooking.WebApi.dll"]
