# Set the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy the remaining source code
COPY . .

# Build the application
RUN dotnet build -c Release --no-restore

# Publish the application
RUN dotnet publish -c Release -o out --no-restore

# Set the final base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/out .

# Expose the desired port
EXPOSE 80

# Set the entry point for the application
ENTRYPOINT ["dotnet", "JornadaMilhas.dll"]