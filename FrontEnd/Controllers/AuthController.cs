using Microsoft.AspNetCore.Mvc;
using FrontEnd.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using System.Net.Http.Headers;

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
            var backendUrl = _configuration.GetValue<string>("BackEnd:Url");

            var response = await _httpClient.PostAsJsonAsync($"{backendUrl}/api/Auth/Login", model);

            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = await response.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<TokenResponseViewModel>(tokenResponse);

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

                if (!HttpContext.Request.Path.StartsWithSegments("/_blazor"))
                {
                    // Guarda el token en el localStorage utilizando JavaScript
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "token", token.Token);
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error de inicio de sesión. Por favor, inténtalo de nuevo.");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(ClienteViewModel model)
        {
            var backendUrl = _configuration.GetValue<string>("BackEnd:Url");

            var response = await _httpClient.PostAsJsonAsync($"{backendUrl}/api/Auth/Registrar", model);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Si hubo un error, mostrar un mensaje de error
                ModelState.AddModelError(string.Empty, "Error de registro. Por favor, inténtalo de nuevo.");
                return View(model);
            }
        }
    }
}
