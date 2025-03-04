using AutoMapper;
using BackendSeguros.Models.Dtos.UsuarioDTO;
using BackendSeguros.Repositorio.IRepositorio;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendSeguros.Models;
using Microsoft.AspNetCore.Authorization;

namespace BackendSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usRepo;
        protected RespuestaAPI _respuestaApi;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioRepository usRepo, IMapper mapper)
        {
            _usRepo = usRepo;
            _mapper = mapper;
            this._respuestaApi = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUsuarios()
        {
            var listaUsuarios = _usRepo.GetUsuarios();

            var listaUsuariosDto = new List<UsuarioDto>();

            foreach (var lista in listaUsuarios)
            {
                listaUsuariosDto.Add(_mapper.Map<UsuarioDto>(lista));
            }
            return Ok(listaUsuariosDto);
        }

        [HttpGet("{usuarioId:int}", Name = "GetUsuario")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUsuario(int usuarioId)
        {
            var itemUsuario = _usRepo.GetUsuario(usuarioId);

            if (itemUsuario == null)
            {
                return NotFound();
            }

            var itemUsuarioDto = _mapper.Map<UsuarioDto>(itemUsuario);

            return Ok(itemUsuarioDto);
        }


        [HttpGet("Buscar")]
        public IActionResult Buscar(string nombre)
        {
            try
            {
                var resultado = _usRepo.Buscarusuario(nombre.Trim());
                if (resultado.Any())
                {
                    return Ok(resultado);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error recuperando datos");
            }
        }


        [HttpPost("registro")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Registro([FromBody] CreaRUsuarioDto CreaRUsuarioDto)
        {
            bool validarNombreUsuarioUnico = _usRepo.IsUniqueUser(CreaRUsuarioDto.usuario);
            if (!validarNombreUsuarioUnico)
            {
                _respuestaApi.StatusCode = HttpStatusCode.BadRequest;
                _respuestaApi.IsSuccess = false;
                _respuestaApi.ErrorMessages.Add("El nombre de usuario ya existe");
                return BadRequest(_respuestaApi);
            }

            var usuario = await _usRepo.Registro(CreaRUsuarioDto);
            if (usuario == null)
            {
                _respuestaApi.StatusCode = HttpStatusCode.BadRequest;
                _respuestaApi.IsSuccess = false;
                _respuestaApi.ErrorMessages.Add("Error en el registro");
                return BadRequest(_respuestaApi);
            }

            _respuestaApi.StatusCode = HttpStatusCode.OK;
            _respuestaApi.IsSuccess = true;
            return Ok(_respuestaApi);

        }

        [HttpDelete("{usuarioid:int}", Name = "BorrarUsuario")]
        public IActionResult BorrarUsuario(int usuarioid)
        {
            if (!_usRepo.Existeusuario(usuarioid))
            {
                return NotFound();
            }
            var usuario = _usRepo.GetUsuario(usuarioid);

            if (!_usRepo.BorrarRamo(usuario))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro{usuario.usuario}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }



        [HttpPost("login")]
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDto usuarioLoginDto)
        {

            var respuestaLogin = await _usRepo.Login(usuarioLoginDto);

            if (respuestaLogin.Usuario == null || string.IsNullOrEmpty(respuestaLogin.Token))
            {
                _respuestaApi.StatusCode = HttpStatusCode.BadRequest;
                _respuestaApi.IsSuccess = false;
                _respuestaApi.ErrorMessages.Add("El nombre de usuario o password son incorrectos");
                return BadRequest(_respuestaApi);
            }

            _respuestaApi.StatusCode = HttpStatusCode.OK;
            _respuestaApi.IsSuccess = true;
            _respuestaApi.Result = respuestaLogin;
            return Ok(_respuestaApi);
        }

    }
}
