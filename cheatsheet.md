# Pasos creación proyecto

## Crear solución:
```
andres@penguin:~/REST.NET$ dotnet new sln -o UserTasks
The template "Solution File" was created successfully.
```

## Crear librería dentro:
```
andres@penguin:~/REST.NET/UserTasks$ dotnet new classlib -o UserTasks.Contracts
The template "Class Library" was created successfully.
```

## Crear api dentro:
```
andres@penguin:~/REST.NET/UserTasks$ dotnet new webapi -o UserTasks
The template "ASP.NET Core Web API" was created successfully.
```

## Añadir ambos a la solución:
```
andres@penguin:~/REST.NET/UserTasks$ dotnet new webapi -o UserTasks
The template "ASP.NET Core Web API" was created successfully.
```
## Instalar paquetes
```
andres@penguin:~$ dotnet add ./UserTasks package ErrorOr

```


Program.cs -> activar controles
Proyecto.csproj -> enlazar.contract


Controller:
1. recibes request -> transformar en model, mirar errores? -> conseguir value
2. Value a service -> error?  o ok()
3. error? -> apicontroller devuelve el problema estructurado -> devuelve controllermodel