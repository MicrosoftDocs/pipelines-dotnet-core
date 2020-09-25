# Modificaciones

Sobre el proyecto original vamos a Dockerizarlo utilizando este tutorial <https://docs.docker.com/engine/examples/dotnetcore/>

/usr/share/dotnet/sdk/3.1.402/Sdks/Microsoft.NET.Sdk/targets/Microsoft.NET.TargetFrameworkInference.targets(127,5): error NETSDK1045: The current .NET SDK does not support targeting .NET Core 5.0.  Either target .NET Core 3.1 or lower, or use a version of the .NET SDK that supports .NET Core 5.0. [/app/pipelines-dotnet-core.csproj]
The command '/bin/sh -c dotnet restore' returned a non-zero code: 1

Hemos modificado de

```yaml
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
```

por

```yaml
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
```

y 

```yaml
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
```

a

``` yaml
FROM mcr.microsoft.com/dotnet/aspnet:5.0
```

Despues de pelearme un poco porque el contanier se crea pero no funciona he visto que el comando entry point que lanza la web tiene que referenciar al assembly que toca

```yaml
ENTRYPOINT ["dotnet", "pipelines-dotnet-core.dll"]
```
