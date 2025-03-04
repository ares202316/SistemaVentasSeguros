using BackendSeguros.Models;
using BackendSeguros.Models.Dtos.UsuarioDTO;

namespace BackendSeguros.Repositorio.IRepositorio
{
    public interface IUsuarioRepository
    {
        ICollection<Usuario> GetUsuarios();

        bool Existeusuario(int usuarioid);
        Usuario GetUsuario(int usuarioId);
        ICollection<Usuario> Buscarusuario(string Nombre);
        
        bool IsUniqueUser(string usuario);
        bool BorrarRamo(Usuario usuario);
        Task<UsuarioLoginRespuestaDto> Login(UsuarioLoginDto usuarioLoginDto);
        Task<Usuario> Registro(CreaRUsuarioDto usuarioRegistroDto);

        bool Guardar();
    }
}
