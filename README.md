# Digital Menu API

Projenin içinde farklı ek yazılımlar (RabbitMQ, Redis, PostgreSQL) kullanıldığı için bu yazılımların yüklü olması gerekmektedir. Eğer bu yazılımları kurmak istemiyorsanız projeyi **Docker** ortamında ayağa kaldırabilirsiniz. Docker ile ve Docker olmadan kurulum adımlarına aşağıdan ulaşabilirsiniz. Herhangi bir mail servisinin entegrasyonunu yapmadığım için mail gönderim işlemleri çalışmayacaktır. Mail gönderimi yalnızca **parola sıfırlama** ve **aboneliğin bitmesine 3 gün kala kullanıcıyı uyarma** amacıyla kullanılmaktadır. Projenin genel işleyişine engel değildir.

## Docker ile Kurulum

---

Gereksinimler

- Docker
- Docker Compose (Linux işletim sistemlerinde ayrıca yüklenmesi gerekir.)

`docker-compose.yaml` dosyasındaki açıklamalara göre ilgili alanları doldurduktan sonra

```
docker-compose up -d
```

komutu ile projeyi çalıştırabilirsiniz. Projelerin güncel halleri `Docker Hub`'da tutulmaktadır.

## Manuel Kurulum

---

Gereksinimler

- .NET 5.0
- NodeJS
- PostgreSQL
- Redis
- RabbitMQ

Backend için [AppSettings.json](/src/DigitalMenu.Api/appsettings.json) dosyasındaki `PostgreSqlProvider`, `RabbitMQConfig`, `RedisConfig` bağlantı değerlerine kendi ayarlarınızı girdikten sonra, terminalden [DigitalMenu.Api.csproj](/src/DigitalMenu.Api/DigitalMenu.Api.csproj) konumundayken

```
dotnet run
```

komutu ile .NET 5.0 Backend projesini ayağa kaldırabilirsiniz. Veri tabanını oluşturmak için herhangi bir migration geçmenize gerek yoktur, connection string değerini doğru girdiyseniz veri tabanı otomatik olarak oluşacaktır.

Vue ile yazılmış client uygulamasını ayağa kaldırmak için ise, öncelikle ilgili [Repoyu](https://github.com/ErenKaya1/digital-menu-client) bilgisayarınıza klonladıktan sonra

```
npm run serve
```

komutu ile projeyi çalıştırabilirsiniz.
Client projesinin root dizininindeki `.env` dosyasının içindeki **VUE_APP_BACKEND_URL** ortam değişkeni backend projesinin çalıştığı url ile aynı olmak zorundadır. Http requestleri bu adrese gönderilmektedir.
