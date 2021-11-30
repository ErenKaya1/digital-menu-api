# Digital Menu API

## Installation with Docker

---

Requirements

- Docker
- Docker Compose (for Linux based systems need to be installed separately.)

Edit the contents of the `docker-compose.yaml` file according to your own settings.

Then you can run project with

```
docker-compose up -d
```

## Manuel Installation

---

Requirements

- .NET 5.0
- NodeJS
- PostgreSQL
- Redis
- RabbitMQ

Edit the content of the [AppSettings.json](/src/DigitalMenu.Api/appsettings.json) file according to your own settings.

Then you can run project with

```
dotnet run
```

No need to migration for creating the database. If you typed the connection string correctly, it will be created automatically.

For the client app writen with Vue, clone the [repo](https://github.com/ErenKaya1/digital-menu-client) first. Then, 
```
npm run serve
```
Don't forget to write the URL where your backend application is runnig in the `.env` file.
