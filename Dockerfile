FROM mcr.microsoft.com/dotnet/sdk:5.0 AS builder
WORKDIR /source
COPY . .
WORKDIR /source/src/DigitalMenu.Api
RUN dotnet restore
RUN dotnet publish -c Release -o /app/

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=builder /app .
EXPOSE 80
CMD [ "dotnet", "DigitalMenu.Api.dll" ]