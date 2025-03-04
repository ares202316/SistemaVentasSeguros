using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BackendSeguros.Data;
using BackendSeguros.Models;
using BackendSeguros.Models.Dtos.UsuarioDTO;
using BackendSeguros.Repositorio.IRepositorio;
using Microsoft.IdentityModel.Tokens;
using XAct;
using XSystem.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackendSeguros.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly ApplicationDbContext _bd;
        private string claveSecreta;


        public UsuarioRepository(ApplicationDbContext bd, IConfiguration config)
        {
            _bd = bd;
            claveSecreta = config.GetValue<string>("ApiSettings:Secreta");
        }


        public Usuario GetUsuario(int usuarioId)
        {
            return _bd.Usuario.FirstOrDefault(u => u.id == usuarioId);
        }

        public ICollection<Usuario> GetUsuarios()
        {
            return _bd.Usuario.OrderBy(u => u.usuario).ToList();
        }

        public bool IsUniqueUser(string nusuario)
        {
            var usuariobd = _bd.Usuario.FirstOrDefault(u => u.usuario == nusuario);

            if (usuariobd == null)
            {
                return true;
            }

            return false;
        }

        public async Task<UsuarioLoginRespuestaDto> Login(UsuarioLoginDto usuarioLoginDto)
        {
            var passwordEncriptado = obtenermd5(usuarioLoginDto.password);

            var usuario = _bd.Usuario.FirstOrDefault(
                u => u.usuario.ToLower() == usuarioLoginDto.usuario.ToLower()
                && u.password == passwordEncriptado
                );

            //Validamos si el usuario no existe con la combinación de usuario y contraseña correcta
            if (usuario == null)
            {
                return new UsuarioLoginRespuestaDto()
                {
                    Token = "",
                    Usuario = null
                };
            }

            //Aquí existe el usuario entonces podemos procesar el login
            var manejadoToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(claveSecreta);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.usuario.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Rol.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = manejadoToken.CreateToken(tokenDescriptor);

            UsuarioLoginRespuestaDto usuarioLoginRespuestaDto = new UsuarioLoginRespuestaDto()
            {
                Token = manejadoToken.WriteToken(token),
                Usuario = usuario
            };

            return usuarioLoginRespuestaDto;
        }

        public async Task<Usuario> Registro(CreaRUsuarioDto usuarioRegistroDto)
        {
            var passwordEncriptado = obtenermd5(usuarioRegistroDto.password);

            Usuario usuario = new Usuario()
            {
                usuario = usuarioRegistroDto.usuario,
                password = passwordEncriptado,
                Nombre = usuarioRegistroDto.Nombre,
                Rol = (Usuario.TipoRol)usuarioRegistroDto.Rol
            };

            usuario.FecRegistro = DateTime.Now;
            _bd.Usuario.Add(usuario);
            await _bd.SaveChangesAsync();
            usuario.password = passwordEncriptado;
            return usuario;
        }

        //Método para encriptar contraseña con MD5 se usa tanto en el Acceso como en el Registro
        public static string obtenermd5(string valor)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(valor);
            data = x.ComputeHash(data);
            string resp = "";
            for (int i = 0; i < data.Length; i++)
                resp += data[i].ToString("x2").ToLower();
            return resp;
        }

       
        public ICollection<Usuario> Buscarusuario(string Nombre)
        {
            IQueryable<Usuario> query = _bd.Usuario;
            if (!string.IsNullOrEmpty(Nombre))
            {
                query = query.Where(e => e.usuario.Contains(Nombre));
            }

            return query.ToList();
        }

        public bool BorrarRamo(Usuario usuario)
        {
            _bd.Usuario.Remove(usuario);
            return Guardar();
        }

        public bool Guardar()
        {
            try
            {
                return _bd.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error al guardar: {ex.Message}");
                return false;
            }
        }

        public bool Existeusuario(int usuarioid)
        {
            bool valor = _bd.Usuario.Any(c => c.id == usuarioid);
            return valor;
        }
    }
}
