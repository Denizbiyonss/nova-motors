using Microsoft.EntityFrameworkCore;
using NovaMotors.Models;

var builder = WebApplication.CreateBuilder(args);

// mvc kullanıyoruz
builder.Services.AddControllersWithViews();

// veritabanı ayarı
builder.Services.AddDbContext<Veritabani>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// sepet için session lazım
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/AnaSayfa/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// hocanın dediği sessionu açtık
app.UseSession();

// anasayfayı değiştirdim
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AnaSayfa}/{action=Index}/{id?}");

app.Run();
