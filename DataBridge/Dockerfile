FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 8080
EXPOSE 8081

COPY DataBridge/DataBridge.csproj DataBridge/DataBridge.csproj
COPY UnitTests/UnitTests.csproj UnitTests/UnitTests.csproj
COPY IntegrationTests/IntegrationTests.csproj IntegrationTests/
#COPY UnitTests/UnitTests.csproj UnitTests/

RUN dotnet restore DataBridge/DataBridge.csproj
RUN dotnet restore UnitTests/UnitTests.csproj
RUN dotnet restore IntegrationTests/IntegrationTests.csproj
#RUN dotnet restore UnitTests/UnitTests.csproj

# Copy the app folders over
COPY . .
WORKDIR /app/DataBridge
RUN dotnet publish -c Release -o /app/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "DataBridge.dll" ]

#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER $APP_UID
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["DataBridge/DataBridge.csproj", "DataBridge/"]
#RUN dotnet restore "DataBridge/DataBridge.csproj"
#COPY . .
#WORKDIR "/src/DataBridge"
#RUN dotnet build "DataBridge.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "DataBridge.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "DataBridge.dll"]
