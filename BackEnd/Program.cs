using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");
var secretKey = builder.Configuration.GetSection("settings").GetSection("secretKey").ToString();
var keyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

})
     .AddCookie(options =>
     {
         options.Cookie.Name = "jwt"; // Nombre de la cookie que contiene el token JWT
         options.Cookie.SameSite = SameSiteMode.Strict; // Establece SameSite a Strict para mitigar ataques CSRF
         options.Cookie.HttpOnly = true; // Marca la cookie como httpOnly
         options.Cookie.SecurePolicy = CookieSecurePolicy.None; // Establece la política de seguridad de la cookie (ajusta según tus necesidades)
     })
.AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });

builder.Services.AddAuthorization();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.Cookie.HttpOnly = true; // Marca la cookie como httpOnly
//        options.Cookie.SecurePolicy = CookieSecurePolicy.None; // Establece la política de seguridad de la cookie como 'Always' (requiere HTTPS)
//        options.Cookie.SameSite = SameSiteMode.Strict; // Establece SameSite a Strict para mitigar ataques CSRF
//        options.LoginPath = "/Auth/Login"; // Especifica la ruta de inicio de sesión
//        options.LogoutPath = "/Auth/Logout"; // Especifica la ruta de cierre de sesión
//    });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProyectoContext>();

#region DI
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
builder.Services.AddScoped<IClienteDAL, ClienteDALImpl>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IEmpleadoDAL, EmpleadoDALImpl>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IProductoDAL, ProductoDALImpl>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IServicioDAL, ServicioDALImpl>();
builder.Services.AddScoped<IServicioService, ServicioService>();
builder.Services.AddScoped<IPiscinaDAL, PiscinaDAL>();
builder.Services.AddScoped<IPiscinaService, PiscinaService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    Secure = CookieSecurePolicy.None // Permitir cookies en conexiones no seguras
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();