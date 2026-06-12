using CRUD.DATA.DAPPER;
using CRUD.LOGICA.NEGOCIO;
using CRUD.UI.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{

    options.Filters.Add<ValidarSesionAttribute>();

});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;


});

builder.Services.AddScoped<IniciarSesionBLL>();
builder.Services.AddScoped<InicioSesionDAPPER>();
builder.Services.AddScoped<MantUsuariosBLL>();
builder.Services.AddScoped<MantUsuariosDAPPER>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=Iniciosesion}/{id?}")
    .WithStaticAssets();


app.Run();
