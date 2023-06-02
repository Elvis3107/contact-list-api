# ContactList API

This project is the back-end API for ContactList Frontend  
Developed in [Visual Studio Community 2022 for Mac] IDE using C# on the [.NET 6.0.9 (64-bit)] framework.

## Structure / Layout

* __Controllers__ - Defines the end-point methods
* __Services__ - Defines the services used by the Controllers
* __Repository__ - Defines the data access classes used by the services

## Start mysql:
* docker-compose up -d

## Stop mysql:
* docker-compose down

## Running

You can run the project by pressing F5 or the Start Button




# EDIT DB STRUCTURE

## Migration

### Create Migration

Run the following the root of the project, to create migration file based on the model

* dotnet ef migrations add <NAME OF THE MIGRATION> 

### Update DB After Migration

After making any changes and generating the migration, you can apply the change on the DB by running the following:

* dotnet ef database update

### Create DB SCRIPT

Generate the database script by running the following command

* dotnet ef migrations script