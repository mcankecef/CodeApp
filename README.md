# Tech
- C#
- Net Core Web API
- EF Core
- Identity
- Onion Architecture
- MsSQL
- CQRS
- MediatR

# Railway + Monster MSSQL
Railway'de uygulama kalabilir, veritabani Monster ASP uzerindeki MSSQL'e baglanir.

Railway Variables tarafinda su degeri gir:

```text
ConnectionStrings__DefaultConnection=Server=SERVER_ADRESI;Database=DB_ADI;User Id=KULLANICI;Password=SIFRE;TrustServerCertificate=True;Encrypt=True;
```

Monster SQL Server TLS desteklemiyorsa `Encrypt=False;` kullan.

Hazir/verili bir veritabanina baglanirken migration otomatik kapali kalmali:

```text
Database__AutoMigrate=false
```

Yeni bos bir MSSQL veritabani olusturup migration calistirmak istersen once SQL Server migration'larini guncelle, sonra `Database__AutoMigrate=true` yap.

# Endpoints
<img src="https://user-images.githubusercontent.com/75936005/236691415-070961cf-001d-4bb1-aa19-b65374c587df.png" alt="endpoints-1">
<img src="https://user-images.githubusercontent.com/75936005/236691585-8bbdecce-8922-42da-a198-fe1ab74eee22.png" alt="endpoints-2">
