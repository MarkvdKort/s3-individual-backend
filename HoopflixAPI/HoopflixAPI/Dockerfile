FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /source 
COPY . .
RUN dotnet restore ".\HoopflixAPI\HoopflixAPI\HoopflixAPI.csproj" --disable-parallel
RUN dotnet publish ".\HoopflixAPI\HoopflixAPI\HoopflixAPI.csproj" -c release -o /app --no-restore

WORKDIR /cert
RUN dotnet dev-certs https -ep certhttps.pfx -p PasswordAPI

FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY --from=build /cert ./app

WORKDIR /app
COPY --from=build /app ./

EXPOSE 4000
EXPOSE 80

ENTRYPOINT ["dotnet", "HoopflixAPI.dll"]


# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
# WORKDIR /app

# # Copy everything
# COPY . ./
# # Restore as distinct layers
# RUN dotnet restore
# # Build and publish a release
# RUN dotnet publish -c Release -o out

# # Build runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:6.0
# WORKDIR /app
# COPY --from=build-env /app ./
# ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]