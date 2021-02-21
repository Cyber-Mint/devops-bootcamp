# Database migrations Cheatsheet
This a quick introduction to database migrations in some of the common frameworks, including .net core entity framework and flyway database migrations that you are most likely to need on a day-to-day basis.

Relational databases usually model (describe) our persisted data structures. These structures change as the application is developed and if we do not use a tool to manage these changes they can quickly get out of hand. Database migration tools allow us to follow a structured approach to handling data modelling changes. Typically a migration script that models a database change falls into one of three categories:
1. Unique version. This script should only be run once against the target database.
2. Repeatable migration. This script can be run multiple times against the target database without any adverse affects. (Think idempotent changes.)
3. Data initialization. Theses scripts provide initialization data for a database (such as postal codes for addresses, or titles for people). 

When we request that a database migration is applied to a target database we are requesting that the schema of the target is updated to match the schema that is needed for our application. Each change in our schema is generally referred to as a version. We are also able to check that the database has the correct version of our database schema applied. We can also rollback a migration to an earlier version if an error occurred.

Most modern languages make use of [Object-relational mapping (ORM)](https://en.wikipedia.org/wiki/Object%E2%80%93relational_mapping) to accelerate application development with databases. Java has [Hibernate](https://hibernate.org/orm/documentation/5.4/), Python has [Django Migrations](https://docs.djangoproject.com/en/3.1/topics/migrations/), .net core has [Entity Framework Core Migrations](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli), and so on. Keep in mind that ORM's give a quickstart to a new database based project, but frequently struggle under a production load. 

There are some database migration frameworks that are not tightly coupled to the language being used, for example [Redgate Flyway](https://flywaydb.org/documentation/) and [Liquibase](https://docs.liquibase.com/home.html) are both popular. These migration technologies do not necessitate an ORM (they do not dictate a specific programming language) and allow for hand-coded database interactions that can maximize performance (when needed).

With application frameworks, like EF Core and Django, it is possible to create database migrations from code and this is known as _code first_. Most ORM frameworks also allow for working from an existing database and this is referred to as _database first_.

This guide focuses on .net EF core and Flyway SQL-based migrations to give an introduction to database migrations. 

## Flyway 
The first thing to check is whether the database you plan to use is supported by Flyway. For this document we assume [MS SQL Server](https://flywaydb.org/documentation/database/sqlserver). [Check the docs here](https://flywaydb.org/documentation/).

We also focus on the [Flyway command line tool](https://flywaydb.org/documentation/usage/commandline/) rather than embedded tools such as Maven. Rather than install the tool locally, we prefer to use [the docker image](https://hub.docker.com/r/flyway/flyway). If you do want to run flyway against a docker hosted database, remember that it must be on the same docker network.



### Useful commands
Flyway CLI only has seven commands:
| Command | Description | Usage Docs |
| ------- | ------- | --- |
| `flyway [options] migrate` | [Apply idempotent database migration(s)](https://flywaydb.org/documentation/command/migrate) | [migrate usage docs](https://flywaydb.org/documentation/usage/commandline/migrate) |
| `flyway [options] clean` | [Drops all objects in the configured schemas]https://flywaydb.org/documentation/command/clean) | [clean usage docs](https://flywaydb.org/documentation/usage/commandline/clean) |
| `flyway [options] info` | [Prints the details and status information about all the migrations.](https://flywaydb.org/documentation/command/info) | [info usage docs](https://flywaydb.org/documentation/usage/commandline/info) |
| `flyway [options] validate` | [Validate applied migrations against those available]https://flywaydb.org/documentation/command/validate) | [validate usage docs](https://flywaydb.org/documentation/usage/commandline/validate) |
| `flyway [options] undo` | [Revert the most recent versioned migration](https://flywaydb.org/documentation/command/undo) | [undo usage docs](https://flywaydb.org/documentation/usage/commandline/undo) |
| `flyway [options] baseline` | [Baseline an existing database.](https://flywaydb.org/documentation/command/baseline) | [baseline usage docs](https://flywaydb.org/documentation/usage/commandline/baseline) |
| `flyway [options] repair` | [Repairs the schema history table](https://flywaydb.org/documentation/command/repair) | [repair usage docs](https://flywaydb.org/documentation/usage/commandline/repair) |

[See configuration for parameters](https://flywaydb.org/documentation/configuration/parameters/)

## .net EF core 

If you are starting with an existing database (or following a database first paradigm) then [this is a useful guide](https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx)


### asp.net core healthcheck
In order for docker to confirm that a service is up and running it can call a well defined [Healthcheck](https://docs.docker.com/engine/reference/builder/#healthcheck).

If you are running asp.net core the the following is a useful command to add to your Dockerfile:
```
HEALTHCHECK CMD curl --fail http://localhost:80/ready || exit 1
```
Make sure that the port used matches the port that you are using to expose your service.


## MS SQL Reference
[Quickstart](https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&preserve-view=true&pivots=cs1-bash)

If using 2019 version, you must run as `root` to access volumes.

[sqlcmd help](https://docs.microsoft.com/en-us/sql/tools/sqlcmd-utility?view=sql-server-ver15)

Once running, try the following:
```
docker exec -it s01e03_db_1 /bin/bash
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Your_secret123!"
SELECT @@VERSION;
```
Simplify this:
```
docker exec -it s01e03_db_1 /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Your_secret123!"
SELECT @@VERSION;
```
Simplify this:
```
docker exec -it s01e03_db_1 /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Your_secret123!" -Q "SELECT @@VERSION;"
```

### Create a database using an init script
```
cd samples/s01e03
sudo cp scripts/db-init.sql mssql/sql/
docker exec -it s01e03_db_1 ls -lt /tmp/sql/
```
Initialize the database
```
docker exec -it s01e03_db_1 /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Your_secret123!" -i "/tmp/sql/db-init.sql"
```
Did it work? Can you see `teamfu` database?
```
docker exec -it s01e03_db_1 /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Your_secret123!" -Q "SELECT name, database_id, create_date FROM sys.databases;"
```

### References
[Flyway database migrations with Java](https://www.baeldung.com/database-migrations-with-flyway)

------
[Readme](../README.md) | [Session 3](s01e03.md)

---
[MIT Licensed](LICENSE) and prepared for Varsity College by [Cyber-Mint (Pty) Ltd](https://www.cyber-mint.com)<br>
TeamFu &trade; is trademark of Cyber-Mint (Pty) Ltd.<br>
&copy; Copyright 2020, Cyber-Mint (Pty) Ltd.  
