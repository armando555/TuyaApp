# HikersApp

this a technical interview for a semi senior position developer
In this case de frontend was made in Express using html, javascript(Ajax), and CSS [VANILA PROJECT] and the Web Api was built in Dotnet 7 using a DDD(Domain driven design) 

## Note:

 Don't forget change the API URL BASE, in my case is localhost:5299. You can do it in the next file [ApiFile](./frontend/engine/apiService.js)

If you need a SQL Server Database use the next docker command to create, this is the database that I used for the testing. Also

```sh
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=ZquV4qWj2xMJ5j5X"    -p 1433:1433 --name sql1 --hostname sql1    -d    mcr.microsoft.com/mssql/server:2022-latest
```

After this, create the database so you must login with the "sa" user and password that is in this case "ZquV4qWj2xMJ5j5X"

Run the next query inside the database for creating it 

```sh
CREATE DATABASE HikerElementDB;
```

Also, if you need to change the SQL String Connection you can do it [Here](./src/WebApi/appsettings.json)

# Migrations

## Notes: don't forget run this command from webApi project and create the database

Make migration to database

```sh
cd src/WebApi && dotnet ef migrations add --project ../Infrastructure/ adding_seed
```

Update database

```sh
cd src/WebApi && dotnet ef database update -p ../Infrastructure/
```

# Run the Backend

Build the project

```sh
cd src/WebApi && dotnet build
```

Run the project

```sh
cd src/WebApi && dotnet run
```

# Run the frontend

install dependencies of express

```sh
cd frontend && npm i
```

Run the project

```sh
cd frontend && npm start
```