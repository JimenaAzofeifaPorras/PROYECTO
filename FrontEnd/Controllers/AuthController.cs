using Microsoft.AspNetCore.Mvc;
using FrontEnd.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Entities.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text;

namespace FrontEnd.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IJSRuntime _jsRuntime;
        private readonly ProyectoContext _proyectoContext;

        public AuthController(HttpClient httpClient, IConfiguration configuration, IJSRuntime jSRuntime)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _jsRuntime = jSRuntime;
            _proyectoContext = new ProyectoContext();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(IniciarSesionViewModel model)
        {

            if (ModelState.IsValid)
            {
                var cliente = _proyectoContext.Clientes.FirstOrDefault(c => c.Correo == model.Correo);

                if (cliente != null && VerifyPassword(model.Contrasena, cliente.Contrasena))
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, cliente.Nombre),
                    new Claim("Correo", cliente.Correo)
                };

                    if (!string.IsNullOrEmpty(cliente.Roles))
                    {
                        var roles = cliente.Roles.Split(',').ToList();
                        foreach (var rol in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, rol.Trim()));
                        }
                    }

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));


                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Error de inicio de sesión. Por favor, inténtalo de nuevo.");
            return View(model);

        }
        private bool VerifyPassword(string password, string hashedPassword)
        {
            string hashedInputPassword = HashPassword(password);
            return hashedInputPassword == hashedPassword;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistroClienteViewModel model)
        {

            if (ModelState.IsValid)
            {
                var backendUrl = _configuration.GetValue<string>("BackEnd:Url");

                var response = await _httpClient.PostAsJsonAsync($"{backendUrl}/api/Auth/Registrar", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            
                // Si hubo un error, mostrar un mensaje de error
                ModelState.AddModelError(string.Empty, "Error de registro. Por favor, inténtalo de nuevo.");
                return View(model);
            
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Aquí puedes realizar cualquier limpieza necesaria, como eliminar cookies o tokens de autenticación
            // Por ejemplo, si estás utilizando JWT, podrías invalidar el token actual

            // Luego, redirige al usuario a la página de inicio de sesión
            return RedirectToAction("Login", "Auth");
        }
    }
}
