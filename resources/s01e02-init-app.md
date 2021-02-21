# Initialize Cheatsheet
This a quick introduction to initializing your app in some of the common frameworks, including .net core on Ubuntu 20.04 and the common commands that you are most likely to need on a day-to-day basis.

## .net core LTS
.net core is a cross platform version of Microsoft's popular .NET development environment. 
[Installing .net core on Ubuntu](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu)

### C# Web API Tutorial
[Useful tutorial for MS .net web api](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio-code)

![Architecture](images/msdotnet-architecture.png)

### Official Images
[Official SDK Images](https://hub.docker.com/_/microsoft-dotnet-sdk)

[Building .net docker images](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-5.0)

A useful sample dockerfile:
```
# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY aspnetapp/*.csproj ./aspnetapp/
RUN dotnet restore

# copy everything else and build app
COPY aspnetapp/. ./aspnetapp/
WORKDIR /source/aspnetapp
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "aspnetapp.dll"]
```

## Python
[Useful Django guide to building a ToDo app](https://dev.to/codesnail/django-todo-app-part-1-django-installation-and-setup-380c)

## Java
[Useful Java with Spring boot](https://github.com/jcsantosbr/todo-backend-springboot2-java12)

[More complete Java app](https://github.com/johanvogelzang/todo-backend)

## Databases
There are numerous docker images available for databases, below are some of the common options:

### Postgres
[Official postgres docker image](https://hub.docker.com/_/postgres)

### MS SQL Server
[Using the MS SQL Server docker image](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/database-server-container)

### MySQL
[Official mySQL docker image](https://hub.docker.com/_/mysql)

### References
[dotnet cli cheatsheet](https://cheatography.com/oba/cheat-sheets/dotnet-cli/)

[Useful samples in various languages](https://todobackend.com/)

------
[Readme](../README.md) | [Session 2](s01e02.md)

---
[MIT Licensed](LICENSE) and prepared for Varsity College by [Cyber-Mint (Pty) Ltd](https://www.cyber-mint.com)<br>
TeamFu &trade; is trademark of Cyber-Mint (Pty) Ltd.<br>
&copy; Copyright 2020, Cyber-Mint (Pty) Ltd.  
