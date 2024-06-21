# Utilizza l'immagine SDK per compilare il codice
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia csproj e ripristina le dipendenze
COPY Src/MyApp/MyApp.csproj ./Src/MyApp/
COPY Tests/MyAppTests/MyAppTests.csproj ./Tests/MyAppTests/
RUN dotnet restore ./Src/MyApp/MyApp.csproj
RUN dotnet restore ./Tests/MyAppTests/MyAppTests.csproj

# Copia i file e costruisci
COPY . ./
RUN dotnet build ./Src/MyApp/MyApp.csproj -c Release

# Pubblica l'applicazione
WORKDIR /app/Src/MyApp
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/Src/MyApp/out .
ENTRYPOINT ["dotnet", "MyApp.dll"]
