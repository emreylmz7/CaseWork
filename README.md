# Kurumsal İş Başvuru Platformu

Bu proje, kurumsal bir firmanın iş başvurularını online olarak almak için geliştirilmiş bir platformu içermektedir.

## Özellikler

### Backend (C# .NET 7.0, Web API, Entity Framework, MSSQL, Swagger):

- **Veritabanı Modeli:** İş başvurusu modeli (Başvuru sahibinin adı, soyadı, iletişim bilgileri, özgeçmişi, pozisyon tercihi, vb. bilgiler içerir). MSSQL veritabanı kullanılarak başvurular saklanır.

- **Web API:** İş başvurularını almak, kaydetmek, güncellemek ve silmek için API endpoint'leri sunar. Başvuru verilerini doğrulama ve işleme için gerekli validasyonları içerir.

- **Swagger Dökümantasyonu:** API dökümantasyonunu oluşturmak için Swagger kullanılır. Kullanıcıların API'yi daha iyi anlamalarını sağlar.

### Frontend (MVC):

- **Kullanıcı Arayüzü:** İş başvuru formu, başvurucunun kişisel bilgilerini ve özgeçmişini içerir. Kullanıcılar pozisyon tercihini seçebilir.

- **Başvuru Listesi:** Kullanıcıların yaptığı başvuruları listeleyen bir sayfa. Her başvuruya tarih bilgisi eklenir.

- **İş Başvurusu Gönderme:** Kullanıcıların başvurularını göndermesine olanak tanır.

- **Ekstralar:** Kullanıcıların başvurularını düzenlemesine veya silmesine izin verir. İş başvurularının durumunu takip etmek için bir sistem içerir (bekleme, inceleme, kabul, reddedildi, vb.).

## Başlarken

Projenin yerel olarak çalıştırılması veya geliştirilmesi için aşağıdaki adımları izleyebilirsiniz:

1. Proje deposunu bilgisayarınıza klonlayın.

2. `Backend` klasöründe, gerekli bağımlılıkları yüklemek için `dotnet restore` komutunu çalıştırın.

3. `Backend` klasöründe `appsettings.json` dosyasını düzenleyerek MSSQL veritabanı bağlantı ayarlarını yapın.

4. Veritabanını oluşturmak ve veritabanı tablolarını oluşturmak için Entity Framework Migration kullanın (`dotnet ef migrations add InitialCreate` ve `dotnet ef database update`).

5. Web API'yi başlatmak için `dotnet run` komutunu çalıştırın.

6. `Frontend` klasöründe, gerekli bağımlılıkları yüklemek için `npm install` veya `yarn install` komutunu çalıştırın.

7. Kullanıcı arayüzünü başlatmak için `npm start` veya `yarn start` komutunu çalıştırın.

8. Tarayıcınızda projenin çalıştığını görmek için `http://localhost:3000` adresini ziyaret edin.

## Katkıda Bulunma

Projeyle ilgili katkılarda bulunmak isterseniz, lütfen bir çekme isteği (pull request) gönderin. Katkılarınızı memnuniyetle karşılarız.


