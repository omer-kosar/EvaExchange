This project aims to help users while they are using evaexchange application.

Technologies:
.NET Core 6 API
AutoMapper
Entity Framework Core 6
Swagger for API documentation
PostgreSQL as database

How to run:
git clone https://github.com/omer-kosar/EvaExchange.git

dotnet build

There should be database user with username is "postgres" and password is "1"
//this command will create database and run migrations configuration and then add bulk records
In Terminal run dotnet ef database update 
or
In Package Manager Console run update-database

The postman collections for buy and sell trades is in folder that is called PostmanTestCollections