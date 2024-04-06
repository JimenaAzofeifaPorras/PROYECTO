using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using System.Net;
using BackEnd.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Entities.Entities;
using System.Security.Cryptography;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string _secretKey;
        private readonly ProyectoContext _proyectoContext;

        public AuthController(IConfiguration config, ProyectoContext proyectoContext)
        {
            _secretKey = config.GetValue<string>("JWT:Key");
            _proyectoContext = proyectoContext;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] IniciarSesionModel request)
        {
            var cliente = _proyectoContext.Clientes.FirstOrDefault(c => c.Correo == request.Correo);

            if (cliente != null && VerifyPassword(request.Contrasena, cliente.Contrasena))
            {
                var token = GenerateJwtToken(request.Correo);
                var tokenResponse = new TokenResponse { Token = token };

                return Ok(tokenResponse);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { error = "Credenciales incorrectas" });
            }
        }

        [HttpPost]
        [Route("Registrar")]
        public IActionResult Registrar([FromBody] ClienteModel model)
        {
            if (ModelState.IsValid)
            {

                string HashedPassword = HashPassword(model.Contrasena);

                var cliente = new Cliente
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    SegundoApellido = model.SegundoApellido,
                    Correo = model.Correo,
                    NumeroTelefonico = model.NumeroTelefonico,
                    Contrasena = HashedPassword,
                };

                _proyectoContext.Add(cliente);
                       _proyectoContext.SaveChanges();

                // Luego, puedes generar un token JWT para el cliente registrado
                var token = GenerateJwtToken(model.Correo);

                return Ok(new { token });
            }
            else
            {
                // Si el modelo no es válido, devolver un error de validación
                var errors = new List<string>();
                foreach (var state in ModelState.Values)
                {
                    foreach (var error in state.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                return BadRequest(new { errors });
            }
        }

        private string GenerateJwtToken(string correo)
        {
            var keyBytes = Encoding.ASCII.GetBytes(_secretKey);
            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim(ClaimTypes.Email, correo));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(tokenConfig);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            string hashedInputPassword = HashPassword(password);
            return hashedInputPassword == hashedPassword;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}