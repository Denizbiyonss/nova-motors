using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovaMotors.Models;

namespace NovaMotors.Controllers;

// anasayfayı kontrol eden yer
public class AnaSayfaController : Controller
{
    private readonly Veritabani _db;

    public AnaSayfaController(Veritabani db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        // markaları çekiyoruz veritabanından
        var markalar = await _db.Markalar.ToListAsync();
        return View(markalar);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
