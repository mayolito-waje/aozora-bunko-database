# build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
EXPOSE 80
EXPOSE 443

# copy csproj and restore distinct layers
COPY AozoraBunkoDatabase.sln .
COPY Server/Server.csproj ./app/
RUN dotnet restore ./app/Server.csproj

# publish stage
COPY Server/. ./app/
WORKDIR /src/app
RUN dotnet publish -c release -o /app/publish

# final stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT [ "dotnet", "Server.dll", "--environment=Development"]
