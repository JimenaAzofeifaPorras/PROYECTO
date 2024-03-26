using Microsoft.AspNetCore.Mvc;
using FrontEnd.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FrontEnd.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IJSRuntime _jsRuntime;

        public AuthController(HttpClient httpClient, IConfiguration configuration, IJSRuntime jSRuntime)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _jsRuntime = jSRuntime;
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
                var backendUrl = _configuration.GetValue<string>("BackEnd:Url");

                var response = await _httpClient.PostAsJsonAsync($"{backendUrl}/api/Auth/Login", model);

                if (response.IsSuccessStatusCode)
                {
                    var tokenResponse = await response.Content.ReadAsStringAsync();
                    var token = JsonConvert.DeserializeObject<TokenResponseViewModel>(tokenResponse);

                    Response.Cookies.Append("jwt", token.Token, new CookieOptions
                    {
                        HttpOnly = true, // Marca la cookie como httpOnly
                        Secure = false, // Establece la cookie como segura (requiere HTTPS)
                        SameSite = SameSiteMode.Strict // Establece SameSite a Strict para mitigar ataques CSRF
                    });

                    return RedirectToAction("Index", "Home");
                }
            } 
                ModelState.AddModelError(string.Empty, "Error de inicio de sesión. Por favor, inténtalo de nuevo.");
                return View(model);
            
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(ClienteViewModel model)
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
