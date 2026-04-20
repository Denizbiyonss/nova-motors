using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovaMotors.Models;

namespace NovaMotors.Controllers;

// hocanın istediği sepet mantığı burada
public class SepetController : Controller
{
    private readonly Veritabani _db;

    public SepetController(Veritabani db)
    {
        _db = db;
    }

    // her kullanıcıya özel session oluşturuyoruz
    private string SessionGetir()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionId")))
        {
            HttpContext.Session.SetString("SessionId", Guid.NewGuid().ToString());
        }
        return HttpContext.Session.GetString("SessionId");
    }

    public async Task<IActionResult> Index()
    {
        var simdikiSession = SessionGetir();
        
        // sepeti listele
        var sepettekiUrunler = await _db.Sepettekiler
            .Include(s => s.Araba)
            .ThenInclude(a => a.Marka)
            .Where(s => s.SessionId == simdikiSession)
            .ToListAsync();

        return View(sepettekiUrunler);
    }

    [HttpPost]
    public async Task<IActionResult> SepeteEkle(int arabaId)
    {
        var simdikiSession = SessionGetir();
        
        var urun = await _db.Sepettekiler
            .FirstOrDefaultAsync(s => s.ArabaId == arabaId && s.SessionId == simdikiSession);

        if (urun == null)
        {
            // yeni eklendi
            urun = new SepetUrunu
            {
                ArabaId = arabaId,
                SessionId = simdikiSession,
                Adet = 1
            };
            _db.Sepettekiler.Add(urun);
        }
        else
        {
            urun.Adet++; // zaten varsa adeti arttır
        }

        await _db.SaveChangesAsync();

        return RedirectToAction("Index"); // sepete git
    }

    [HttpPost]
    public async Task<IActionResult> SepettenCikar(int id)
    {
        var simdikiSession = SessionGetir();
        var urun = await _db.Sepettekiler
            .FirstOrDefaultAsync(s => s.Id == id && s.SessionId == simdikiSession);

        if (urun != null)
        {
            _db.Sepettekiler.Remove(urun);
            await _db.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }

    public IActionResult Odeme()
    {
        var simdikiSession = SessionGetir();
        var urunler = _db.Sepettekiler
            .Include(s => s.Araba)
            .Where(s => s.SessionId == simdikiSession)
            .ToList();

        if (!urunler.Any())
        {
            return RedirectToAction("Index");
        }

        // toplam fiyat hesaplama
        ViewBag.Toplam = urunler.Sum(s => s.Araba.Fiyat * s.Adet);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> OdemeyiTamamla()
    {
        // ödeme başarılı olunca sepeti sil
        var simdikiSession = SessionGetir();
        var urunler = await _db.Sepettekiler
            .Where(s => s.SessionId == simdikiSession)
            .ToListAsync();

        _db.Sepettekiler.RemoveRange(urunler);
        await _db.SaveChangesAsync();

        return View("Basarili");
    }
}
