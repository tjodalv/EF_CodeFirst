using EF_CodeFirst;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Uèitavanje connection stringa iz konfiguracije
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Konfiguriranje DbContext-a
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Primjena migracija i seedanje podataka prilikom pokretanja aplikacije
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}


app.MapGet("/", async (ApplicationDbContext db) =>
{
    var students = await db.Studenti.ToListAsync();
    return Results.Ok(students);
});

app.Run();
