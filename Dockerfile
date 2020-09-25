FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

#renombrado los paths para saber queestan haciendo en cada momento


# trabajamos sobre la carpeta /appDev
WORKDIR /appDev

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
# indicamos el mismo work dir
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /appProd
COPY --from=build-env /appDev/out .
ENTRYPOINT ["dotnet", "pipelines-dotnet-core.dll"]