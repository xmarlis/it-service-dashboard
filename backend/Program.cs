using ItServiceDashboard.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Datenbank (SQLite)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controller aktivieren und JSON so konfigurieren,
// dass Zyklen in Navigation Properties ignoriert werden (Client -> Tickets -> Client ...)
builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// CORS: Frontend unter http://localhost:4200 erlauben
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware-Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Wenn du möchtest, dass http://localhost:5023/ automatisch zu Swagger weiterleitet:
app.MapGet("/", () => Results.Redirect("/swagger"));

// HTTPS-Redirect im Dev deaktiviert, um keinen Stress mit Ports/Zertifikaten zu haben
// app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.MapControllers();

// Datenbank beim Start erstellen
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.Run();
