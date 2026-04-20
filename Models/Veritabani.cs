using Microsoft.EntityFrameworkCore;

namespace NovaMotors.Models
{
    // veritabanı bağlantısı hocanın kodundan kopyaladım
    public class Veritabani : DbContext
    {
        public Veritabani(DbContextOptions<Veritabani> options) : base(options)
        {
        }

        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Araba> Arabalar { get; set; }
        public DbSet<SepetUrunu> Sepettekiler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // hocaya göstermek için örnek markalar
            modelBuilder.Entity<Marka>().HasData(
                new Marka { Id = 1, Isim = "Volkswagen", LogoResmi = "https://www.car-logos.org/wp-content/uploads/2011/09/volkswagen_logo.png" },
                new Marka { Id = 2, Isim = "Audi", LogoResmi = "https://www.car-logos.org/wp-content/uploads/2011/09/audi.png" },
                new Marka { Id = 3, Isim = "Seat", LogoResmi = "https://www.car-logos.org/wp-content/uploads/2011/09/seat.png" },
                new Marka { Id = 4, Isim = "Cupra", LogoResmi = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cd/Cupra_logo.svg/1200px-Cupra_logo.svg.png" },
                new Marka { Id = 5, Isim = "Skoda", LogoResmi = "https://www.car-logos.org/wp-content/uploads/2011/09/skoda.png" },
                new Marka { Id = 6, Isim = "Porsche", LogoResmi = "https://www.car-logos.org/wp-content/uploads/2011/09/porsche.png" }
            );

            // örnek arabalar burdan başlıyor
            modelBuilder.Entity<Araba>().HasData(
                new Araba { Id = 1, MarkaId = 1, ModelAdi = "Golf", UretimYili = 2023, Fiyat = 1200000, ArabaResmi = "https://images.dealer.com/ddc/vehicles/2023/Volkswagen/Golf%20GTI/Hatchback/color/Deep%20Black%20Pearl-2T2T-8,8,8-640-en_US.jpg", Aciklama = "Çok iyi bir araba." },
                new Araba { Id = 2, MarkaId = 1, ModelAdi = "Passat", UretimYili = 2023, Fiyat = 1500000, ArabaResmi = "https://images.dealer.com/ddc/vehicles/2022/Volkswagen/Passat/Sedan/color/Tourmaline%20Blue%20Metallic-P2P2-11,28,49-640-en_US.jpg", Aciklama = "Makam aracı gibi valla." },
                new Araba { Id = 3, MarkaId = 2, ModelAdi = "A3", UretimYili = 2024, Fiyat = 1800000, ArabaResmi = "https://mediaservice.audi.com/media/fast/H4sIAAAAAAAAAFvzloG1tIiBOTrayfDpF1sMDIuYGBgYOBjygKIZTIxQGqScmVGSWqRgz2Lo7BTDwPAuT4GBl/EwkwP32Kk/H5ZJMTCoMvAyMOcWlRakmOQWlaTmlaQWAQWPszEw9H9gA4vN+7E/m6X8gBfD-2-41L2_vO2T8cE3XgZORgYGQQYmIOYBUQzSjIyMQmBBSB0oBsRnAQAAAP__t3D8eLAAAAA?req=MXwxMDI0fDU3Nnw0NTEyMTE=", Aciklama = "Zengin işi araba" },
                new Araba { Id = 4, MarkaId = 2, ModelAdi = "A4", UretimYili = 2024, Fiyat = 2500000, ArabaResmi = "https://mediaservice.audi.com/media/fast/H4sIAAAAAAAAAFvzloG1tIiBOTrayfDpF1sMDIyCjAwcDD5AwQwmBigNUc7MKEktUrBnMWRxcmJhYPgqpcDAy3iYyYF77NSfD8ukGBhUGXgZmHOLSgpSTHKLSlLzSlKLgILH2RgY-j-wgcXm_difzVJ-wIvh_Tdc6t5f3vbJ-OAbLwMnIwODIAMTEPOAKAaQ-sUMjIxgQUgdKAaMAwAAAP__f-LgS7AAAAA?req=MXwxMDI0fDU3Nnw0NTEyMTE=", Aciklama = "Bunu almak için çok çalışmak lazım." },
                new Araba { Id = 5, MarkaId = 3, ModelAdi = "Leon", UretimYili = 2023, Fiyat = 1100000, ArabaResmi = "https://www.seat.com.tr/media/Kwc_Basic_Image_Component/41349-83935-180862-image/dh-1024-5d5d67/9242d5e2/1682502693/seat-leon-hatchback-manyetik-tech-gri.png", Aciklama = "Genç işi araba." },
                new Araba { Id = 6, MarkaId = 4, ModelAdi = "Formentor", UretimYili = 2023, Fiyat = 1900000, ArabaResmi = "https://www.cupraofficial.com.tr/media/Kwc_Basic_Image_Component/41662-84950-185012-image/dh-1024-5d5d67/a9ed0d4a/1682672522/cupra-formentor-suv-manyetik-tech-gri.png", Aciklama = "Çok havalı duruyor." },
                new Araba { Id = 7, MarkaId = 5, ModelAdi = "Octavia", UretimYili = 2023, Fiyat = 1300000, ArabaResmi = "https://cdn.skoda-auto.com/imagedata/img/SKODA/models/octavia.png", Aciklama = "Geniş bagajlı aile arabası." },
                new Araba { Id = 8, MarkaId = 6, ModelAdi = "Macan", UretimYili = 2024, Fiyat = 5000000, ArabaResmi = "https://configurator.porsche.com/model-start/pictures/macan/exterior.png", Aciklama = "Rüya arabası." }
            );
        }
    }
}