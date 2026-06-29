using Microsoft.EntityFrameworkCore;
using MiWeb.Data;
using MiWeb.Models;
using System.Security.Cryptography;
using System.Text;
// using WebEssentials.AspNetCore.PWA;  // Comentado temporalmente - verifica la instalación de la package

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// ⭐ ACTIVAR PWA
builder.Services.AddProgressiveWebApp();

// Configuración de sesión
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ⭐ USAR SQLITE
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=LOGIN.db"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ==========================================
// ⭐ CREAR USUARIOS DE PRUEBA
// ==========================================
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();

    if (!context.Usuarios.Any())
    {
        var usuario = new Usuario
        {
            Nombre = "Brayan",
            Email = "brayan@gmail.com",
            ContrasenaHash = HashContrasena("123456"),
            FechaRegistro = DateTime.Now
        };

        var admin = new Usuario
        {
            Nombre = "Administrador",
            Email = "admin@gmail.com",
            ContrasenaHash = HashContrasena("admin123"),
            FechaRegistro = DateTime.Now
        };

        context.Usuarios.AddRange(usuario, admin);
        context.SaveChanges();

        Console.WriteLine("✅ Usuarios de prueba creados:");
        Console.WriteLine("   Email: brayan@gmail.com | Contraseña: 123456");
        Console.WriteLine("   Email: admin@gmail.com | Contraseña: admin123");
    }

    // ⭐ CREAR PRODUCTOS DE PRUEBA
    if (!context.Productos.Any())
    {
        var productos = new List<Producto>
        {
            new Producto { Nombre = "ASUS ROG Strix G18", Descripcion = "Laptop gamer de alto rendimiento", Precio = 22000, Cantidad = 10 },
            new Producto { Nombre = "ROG Phone 8", Descripcion = "Smartphone gamer definitivo", Precio = 15500, Cantidad = 15 },
            new Producto { Nombre = "ROG Swift OLED", Descripcion = "Monitor 4K 240Hz", Precio = 12800, Cantidad = 8 },
            new Producto { Nombre = "ROG Azoth", Descripcion = "Teclado mecánico inalámbrico", Precio = 3200, Cantidad = 20 }
        };
        context.Productos.AddRange(productos);
        context.SaveChanges();
        Console.WriteLine("✅ Productos de prueba creados: 4 productos");
    }
}

app.Run();

static string HashContrasena(string contrasena)
{
    using (var sha256 = SHA256.Create())
    {
        var bytes = Encoding.UTF8.GetBytes(contrasena);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}