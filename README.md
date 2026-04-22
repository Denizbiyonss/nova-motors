# Nova Motors 🚗

> **ASP.NET Core MVC** tabanlı bir otomotiv e-ticaret uygulaması. Volkswagen Group araçlarını (VW, Audi, SEAT, CUPRA, Škoda, Porsche) listeler; kullanıcıların sepete araç ekleyip simüle edilmiş bir ödeme süreci tamamlamasına olanak tanır.

---

## ⚠️ Önemli Not

> **[!IMPORTANT]**
> Bu proje yalnızca **eğitim ve portföy amaçlı** geliştirilmiştir. Gerçek bir ödeme altyapısı **içermemektedir**. Ödeme adımı simülasyon amaçlıdır; herhangi bir finansal işlem gerçekleşmez.

---

## ⚠️ Eski .NET Sürümleri Hakkında Önemli Not

> **[!CAUTION]**
> Eski veya eksik .NET SDK kurulumları uygulamanın çalışmasına engel olmaktadır. Bilgisayarınızda uyumsuz bir sürüm bulunuyorsa lütfen tamamen kaldırın ve **.NET 10.0** sürümünü yükleyin. Bunu yapmadığınız takdirde Nova-Motors çok yüksek ihtimalle çalışmayacaktır.

---

## 📋 Özet

**Nova Motors**, Volkswagen Group bın araçlarını listeleyen, kullanıcıların sepete ürün ekleyip simüle edilmiş ödeme akışını tamamlayabildiği bir ASP.NET Core MVC web uygulamasıdır. Bu uygulama kesinlikle **gerçek bir satış platformu değildir** ve kreünyesindeki markalardi kartı işlemlerinde/gerçek hayatta herhangi bir ücrete sebep **olmayacaktır**.

Proje şu konuları kapsar:
- MVC mimarisi (Model - View - Controller)
- Entity Framework Core ile SQLite veritabanı entegrasyonu
- Session tabanlı sepet yönetimi
- Razor Views ile dinamik sayfa oluşturma

> **[!NOTE]**
> Windows, macOS veya Linux işletim sistemlerinde geliştirici ortamında çalıştırmanız mecburidir.

---

## 🔒 Virüs & Veri Sızıntısı & Ödeme İşlemleri

Program açık kaynak kodlu (HTML, CSS, C#) olduğundan **tüm kodu görüp inceleyebilirsiniz**. Bazı kullanıcılar ödeme sayfasında gerçek veri istenip istenmediğini sorabilir; ancak bu `.cshtml` dosyalarının yapısından dolayı yanlış bir izlenim verebilmektedir — bimüu formlar yalnızca slasyonu etkiler. İstemeyen ve güvenmeyen kullanıcılar kullanmak zorunda değildir, herkesin kendi seçimidir.

> **[!NOTE]**
> Uygulama içerisinde toplanan sepet verileri ve araç listeleri **yalnızca yerel veritabanında** (`novamotors.db`) tutulmaktadır. Herhangi bir veri ihlali veya güvenlik açığı bulunmamaktadır.

> **[!IMPORTANT]**
> Kyi incelerken karşılaşacodların içinde ya da projeağınız sepet tutarları veya ödeme adımları sizi korkutmasın. Bu, tamamen ASP.NET Core MVC yapısını ve e-ticaret iş akışını göstermek amacıyla tasarlanmış bir projedir. Geliştirici olan Deniz, bu projeyi tamamen ücretsiz ve açık kaynak kodlu şekilde [GitHub - Nova-Motors](https://github.com/Denizbiyonss/nova-motors) repository'sinde paylaşmaktadır. Bu projeden hiçbir ticari gelir elde edilmemektedir.

---

## 🚀 Nova-Motors'u Kullanmak

Nova-Motors'u kullanmak için **iki yöntem** bulunmaktadır.

- **Visual Studio (IDE) ile kullanma:** Yalnızca bir kez proje Express veya Kestrelyi derleyip ardından IIS üzerinden otomatik olarak çalışır.
- **Terminal (CLI) ile kullanma:** Terminal üzerinden her defasında `dotnet run` komutu ile başlatmanız gerekir (terminal penceresi kapatıldığında sunucu durur).

> **[!NOTE]**
> İndirdiğiniz proje klasörünü çıkardığınız konumdan **taşımayın**. Yapı `appsettings.json` ayarlarını ve proje yolunu kullanacağından dosyaları taşırsanız yerel veritabanı bağlantısı bozulabilir. (Tavsiyem sizi rahatsız etmeyecek bir konuma çıkarmanız. Örneğin, `C:\NovaMotors\`.)

---

### 🖥️ Visual Studio ile Kullanma *(Hızlı Başlatma — Otomatik çalışır)*

1. Repoyu bilgisayarınıza indirin.
2. ZIP dosyasını herhangi bir dizine çıkarın.
3. `NovaMotors.csproj` dosyasına çift tıklayarak **Visual Studio** ile açın.
4. Üst menüden **▶ Start** butonuna basın.
5. Tarayıcı, proje derlendiğinde otomatik olarak açılacak ve uygulama başlayacaktır.

> **[!NOTE]**
> Bu işlem projeyi derleyip tarayıcıda otomatik açacaktır. Uygulamayı durdurmak için Visual Studio'daki **■ Stop** butonuna basmanız yeterlidir.

---

### 💻 Terminal (CLI) ile Kullanma *(Tek seferlik — pencere kapatıldığında sona erer)*

Bir komut penceresi açılır ve uygulama çalışmaya başlar; pencere kapatıldığında sunucu durur.

1. Repoyu klonlayın:
   ```bash
   git clone https://github.com/Denizbiyonss/nova-motors.git
   cd nova-motors
   ```

2. Bağımlılıkları yükleyin:
   ```bash
   dotnet restore
   ```

3. Uygulamayı başlatın:
   ```bash
   dotnet run
   ```

4. Tarayıcınızda açın:
   ```
   http://localhost:5000
   ```

> **[!NOTE]**
> `dotnet run` komutu ile çalıştırıldığında hem bilgisayarınız yeniden başlatıldığında uygulamayı elle açmanız gerekecek, hem de terminal penceresi kapatıldığında uygulama devre dışı kalacaktır.

---

## ⚙️ Veritabanı ve Bağlantıları Düzenleme

Bu projede varsayılan olarak **SQLite** (`novamotors.db`) kullanılmaktadır. Farklı bir veritabanına geçmek için `appsettings.json` ve `appsettings.Development.json` dosyalarını herhangi bir metin düzenleyici ile düzenleyerek `DefaultConnection` bilgilerini değiştirebilirsiniz. (Tavsiye edilen: SQLite — kurulum gerektirmez, sıfır konfigürasyonla çalışır.)

---

## 📁 Proje Yapısı

```
nova-motors/
├── Controllers/        → MVC Controller'ları (araç listesi, sepet, ödeme)
├── Models/             → Veri modelleri (Car, CartItem, Order vb.)
├── Views/              → Razor şablonları (.cshtml sayfaları)
│   ├── Home/
│   ├── Cart/
│   └── Shared/
├── wwwroot/            → Statik dosyalar (CSS, JS, resimler)
├── Program.cs          → Uygulama giriş noktası ve servis konfigürasyonu
├── NovaMotors.csproj   → Proje dosyası
└── novamotors.db       → SQLite veritabanı
```

---

## 🏎️ Desteklenen Markalar

Uygulama aşağıdaki **Volkswagen Group** markalarının araçlarını listeler:

- 🔵 **Volkswagen (VW)**
- 🔴 **Audi**
- 🟠 **SEAT**
- 🟣 **CUPRA**
- 🟢 **Škoda**
- ⚫ **Porsche**

---

## 🛒 Özellikler

- Marka ve modele göre araç listeleme
- Araç detay sayfası
- Sepete araç ekleme / çıkarma
- Session tabanlı sepet yönetimi *(giriş gerektirmez)*
- Simüle edilmiş ödeme / sipariş tamamlama ekranı

---

## 🔧 Sık Karşılaşılan Sorunlar

**`dotnet` komutu tanınmıyor / SDK bulunamadı hatası:**
Bilgisayarınızda uygun .NET SDK yüklü değil. [Buradan](https://dotnet.microsoft.com/download) .NET 10 SDK'yı indirip kurabilirsiniz.

**Port zaten kullanımda hatası:**
`Program.cs` dosyasından port numarasını değiştirebilir ya da çakışan uygulamayı kapatabilirsiniz.

**Veritabanı tablosu bulunamadı (Entity Framework hataları):**
Konsol veya Paket Yöneticisi üzerinden aşağıdaki komutu çalıştırın:
```bash
dotnet ef database update
```
Bu komutu çalıştırmadan önce EF Core Tools'un kurulu olduğundan emin olun:
```bash
dotnet tool install --global dotnet-ef
```

**"Dosya yolu bulunamadı" hatası:**
Bu hata proje klasörünü farklı bir konuma taşımanız halinde ortaya çıkar. Projeyi orijinal konumuna geri taşıyın veya sıfırdan klonlayıp tekrar çalıştırın.

---

## ⭐ Bağış ve Destek

Bu projeyi kullanmak tamamen **ücretsizdir**. Kullanımından herhangi bir ticari gelir elde edilmemektedir. Eğer projeye destek olmak isterseniz GitHub üzerinden **⭐ yıldız** verebilirsiniz — bu en büyük motivasyon kaynağıdır.

---

## ⚖️ Yasal Uyarı

> **[!IMPORTANT]**
> Bu uygulamanın kullanımından doğan her türlü yasal sorumluluk kullanan kişiye aittir. Uygulama yalnızca **eğitim ve araştırma amaçları** ile yazılmış ve düzenlenmiş olup; bu uygulamayı bu şartlar altında kullanmak ya da kullanmamak kullanıcının kendi seçimidir. Bu proje, bilgi paylaşımı ve kodlama eğitimi amaçlarıyla açık kaynak olarak paylaşılmıştır.

---

<div align="center">
  <sub>Built with ❤️ using ASP.NET Core MVC · <a href="https://github.com/Denizbiyonss">Denizbiyonss</a></sub>
</div>
