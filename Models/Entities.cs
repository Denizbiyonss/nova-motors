using System.ComponentModel.DataAnnotations;

namespace NovaMotors.Models
{
    // arabaların markaları burda tutulacak hocanın istediği gibi
    public class Marka
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string LogoResmi { get; set; } // resim linki buraya gelsin
        
        public List<Araba> Arabalar { get; set; } = new List<Araba>();
    }

    // bu araba classı
    public class Araba
    {
        public int Id { get; set; }
        public int MarkaId { get; set; }
        public Marka Marka { get; set; } // foreign key
        
        public string ModelAdi { get; set; }
        public int UretimYili { get; set; }
        public decimal Fiyat { get; set; }
        public string ArabaResmi { get; set; }
        public string Aciklama { get; set; }
    }

    // sepete atılan ürünler için
    public class SepetUrunu
    {
        public int Id { get; set; }
        public int ArabaId { get; set; }
        public Araba Araba { get; set; }
        public int Adet { get; set; }
        public string SessionId { get; set; } // kullanıcının sepeti karışmasın diye id
    }
}
