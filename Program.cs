using AulaApp1.Components;
using Microsoft.EntityFrameworkCore;
using AulaApp1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Fábrica de contextos: cada operação cria um Contexto novo e o descarta no fim.
var conexao = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContextFactory<Contexto>(options =>
    options.UseMySql(conexao, ServerVersion.AutoDetect(conexao)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found");
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
