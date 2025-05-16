using System.Net;
using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.Dto;
using MagicVilla_API.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersionNeutral]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private APIResponse _response;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _response = new();
        }

        [HttpPost("login")] //Ruta: /api/Usuario/login
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO modelo)
        {
            var loginResponse = await _usuarioRepositorio.Login(modelo);
            if (loginResponse.Usuario == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.statusCode = HttpStatusCode.BadRequest;
                _response.IsExitoso = false;
                _response.ErrorMessages.Add("UserName o Password incorrectos");
                return BadRequest(_response);
            }
            _response.IsExitoso = true;
            _response.statusCode = HttpStatusCode.OK;
            _response.Resultado = loginResponse;
            return Ok(_response);
        }

        [HttpPost("registrar")] //Ruta: /api/Usuario/registrar
        public async Task<IActionResult> Registrar([FromBody] RegistroRequestDTO modelo)
        {
            bool isUsuarioUnico = _usuarioRepositorio.IsUsuarioUnico(modelo.UserName);
            if (!isUsuarioUnico)
            {
                _response.statusCode = HttpStatusCode.BadRequest;
                _response.IsExitoso = false;
                _response.ErrorMessages.Add("Usuario ya existe!");
                return BadRequest(_response);
            }
            var usuario = await _usuarioRepositorio.Registrar(modelo);
            if (usuario == null)
            {
                _response.statusCode = HttpStatusCode.BadRequest;
                _response.IsExitoso = false;
                _response.ErrorMessages.Add("Error al registrar el usuario!");
                return BadRequest(_response);
            }
            _response.statusCode = HttpStatusCode.OK;
            _response.IsExitoso = true;
            return Ok(_response);
        }

    }
}
