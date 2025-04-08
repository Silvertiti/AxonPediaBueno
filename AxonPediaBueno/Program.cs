using AxonPediaBueno.Data;        // Assurez-vous que ApplicationDbContext est défini dans ce namespace
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Récupérer la chaîne de connexion depuis appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Enregistrer le DbContext avec SQL Server dans l'injection de dépendances
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Ajouter les services pour Razor Pages et Blazor Server
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Configuration du hub Blazor
app.MapBlazorHub();
// Configuration du fallback vers la page _Host (assurez-vous que Pages/_Host.cshtml existe)
app.MapFallbackToPage("/_Host");

app.Run();
