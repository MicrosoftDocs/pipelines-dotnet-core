# First stage of multi-stage build
FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# copy the contents of agent working directory on host to workdir in container
COPY . ./

# dotnet commands to build, test, and publish
RUN dotnet restore
RUN dotnet build -c Release
RUN dotnet test dotnetcore-tests/dotnetcore-tests.csproj -c Release --logger "trx;LogFileName=testresults.trx"
RUN dotnet publish -c Release -o out

# Second stage - Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/dotnetcore-sample/out .
ENTRYPOINT ["dotnet", "dotnetcore-sample.dll"]