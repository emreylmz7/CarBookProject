# Car Book Projesi

Bu proje, Araç Kiralama sistemi üzerine kurulu olan ve Onion Mimarisini kullanarak geliştirilmiş bir ASP.NET Core Web API projesidir. Projenin amacı, kullanıcıların araçları kiralamasına olanak sağlayan bir platform sunmaktır.

## Kullanılan Tasarım Desenleri ve Teknolojiler

Proje geliştirilirken aşağıdaki tasarım desenleri ve teknolojiler kullanılmıştır:

- **Onion Mimarisi**: Projenin temeli olarak kullanılan bir mimari yaklaşımıdır. Katmanlı bir yapı oluşturarak iş mantığını, veri erişimini ve sunum katmanını ayırır.
- **CQRS (Command Query Responsibility Segregation)**: Komut ve sorgu sorumluluğunun ayrılmasını sağlayan bir tasarım desenidir. Bu sayede yazma (write) ve okuma (read) işlemleri farklı yollarla işlenebilir.
- **Mediator Tasarım Deseni**: İşlemler arasında iletişimi kolaylaştıran bir desendir. İstemciden gelen isteklerin işlenmesini sağlar.
- **Repository Pattern**: Veritabanı işlemlerini soyutlar ve genelleştirir. Veri erişim katmanının bir parçasıdır.
- **JWT (Json Web Token)**: Kimlik doğrulama ve yetkilendirme için kullanılan bir standarttır. Kullanıcıların güvenli bir şekilde yetkilendirilmesini sağlar.
- **SignalR**: Gerçek zamanlı web uygulamaları için kullanılan bir kütüphanedir. Sunucu ile istemci arasında iletişim kurulmasını sağlar.
- **Pivot Table**: Veri analizi için kullanılan bir tekniktir. Verilerin özetlenmesini ve analiz edilmesini sağlar.
- **DTO (Data Transfer Object)**: Veri aktarımı için kullanılan nesnelerdir. Veri tabanı işlemleri sırasında verilerin taşınmasını sağlar.
- **Fluent Validation**: Giriş verilerinin doğrulanması için kullanılan bir kütüphanedir. Veri doğrulama kurallarını tanımlamayı kolaylaştırır.

## Kullanım

Projeyi çalıştırmak için aşağıdaki adımları izleyin:

1. Projenin klonunu alın: `git clone https://github.com/kullaniciadi/car-book.git`
2. Proje dizinine gidin: `cd car-book`
3. Gerekli bağımlılıkları yükleyin: `dotnet restore`
4. Proje çalıştırın: `dotnet run`

## Katkıda Bulunma

Katkıda bulunmak isterseniz, lütfen yeni bir dal oluşturun ve değişikliklerinizi yapın. Daha sonra bir çekme isteği (pull request) gönderin.

## Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına bakın.
