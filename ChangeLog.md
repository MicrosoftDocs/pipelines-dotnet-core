# Modificaciones

## Agregar soporte para contenedores

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

## Modificaciomos el pipeline de azure para dar soporte a los contenedores

Intentamos seguir este [tutorial](https://docs.microsoft.com/es-es/azure/devops/pipelines/ecosystems/containers/build-image?view=azure-devops)

### Paso previo

Tambien es verdad que al actualizar el proyecto anterior y utilizar la version 5.0 la pipeline que ya teniamos no funciona ya que el fichero _azure-pipelines.yml_ no esta bien

Por lo visto las maquinas virtuales que compilan el codigo no tendran (en el momento de la compilacion) el sdk 5.0 instalado. Depues de pelearme un rato, buscando si hay algun post o alguien que lo explique, lo que he realizado es instalar un agente en mi pc local y configurar el yaml para que le indique a Azure que utilice el Agent Pool instalado en mi maquina ( es un poco estupido, pero por lo menos me permite seguir con mis pruebas)
En un entorno profesional tendriamos dos opciones en cuanto esto se solvente:

* Si hay infraestructura podriamos tener agentes locales
* Seguir utilizando Azure

Los pasos que he realizado son:

* Instalarme y configurar un agente de compilacion en mi maquina de desarrollo
* Configurar la pipeline para que utilice el agente en lugar de la imagen

```yaml
pool:
  vmImage: 'ubuntu-latest'
```

por

```yaml
pool:
  name: 'SelfHostedPcAlberto'
```

### Continuar

