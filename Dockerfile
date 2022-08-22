FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy sln and csproj files
COPY ./*.sln ./

# Project
COPY TestProject.WebAPI/TestProject.WebAPI.csproj TestProject.WebAPI/TestProject.WebAPI.csproj

# Restore as distinct layers
RUN dotnet restore TestProject.WebAPI/TestProject.WebAPI.csproj

# Copy everything else
COPY ./src ./src

# Build
WORKDIR /app/TestProject.WebAPI
RUN dotnet publish -c Release -o out -r linux-x64 -f net6.0

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/TestProject.WebAPI/out .

ENV ASPNETCORE_URLS http://*:80
EXPOSE 80
ENTRYPOINT ["dotnet", "TestProject.WebAPI.dll"]