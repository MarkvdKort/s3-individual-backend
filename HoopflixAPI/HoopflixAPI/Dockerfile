FROM microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source 
COPY . .
RUN dotnet restore ".\HoopflixAPI\HoopflixAPI\HoopflixAPI.csproj" --disable-parallel
RUN dotnet publish ".\HoopflixAPI\HoopflixAPI\HoopflixAPI.csproj" -c release -o /app --no-restore

FROM microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY --from=build  /app ./
EXPOSE 4000
EXPOSE 80

ENTRYPOINT ["dotnet", "HoopflixAPI.dll"]