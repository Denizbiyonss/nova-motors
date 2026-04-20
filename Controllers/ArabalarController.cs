using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovaMotors.Models;

namespace NovaMotors.Controllers;

// arabaları gösterdiğimiz controller
public class ArabalarController : Controller
{
    private readonly Veritabani _db;

    public ArabalarController(Veritabani db)
    {
        _db = db;
    }

    public async Task<IActionResult> Marka(int id)
    {
        // seçilen markanın arabalarını bul
        var secilenMarka = await _db.Markalar
            .Include(m => m.Arabalar)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (secilenMarka == null)
        {
            return NotFound(); // bulunamadı hatası
        }

        return View(secilenMarka);
    }

    public async Task<IActionResult> Detay(int id)
    {
        var araba = await _db.Arabalar
            .Include(a => a.Marka)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (araba == null)
        {
            return NotFound();
        }

        return View(araba);
    }
}
