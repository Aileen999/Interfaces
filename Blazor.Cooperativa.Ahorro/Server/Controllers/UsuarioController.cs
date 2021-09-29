using Blazor.Cooperativa.Ahorro.Shared.Modelo;
using Cooperativa.Ahorro.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Inventario.Hogar.Ancianos.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly ITUsuarioRepository _tUsuarioRepository;

    public UsuarioController(ITUsuarioRepository tUsuarioRepository)
    {
        _tUsuarioRepository = tUsuarioRepository;
    }
    [HttpGet("GetUsers")]
    public async Task<IEnumerable<TUsuario>> GetAll()
    {
        return await _tUsuarioRepository.GetAll();
    }
    [HttpGet("GetById/{IdUsuario}")]
    public async Task<IEnumerable<TUsuario>> GetById(int IdUsuario)
    {
        return await _tUsuarioRepository.GetById(IdUsuario);
    }
   
    [HttpPost("InsertUser")]
    public async Task<bool> InsertUser([FromBody] TUsuario Usuario)
    {
        return await _tUsuarioRepository.Insert(Usuario);       

    }
    [HttpDelete("DeleteUser/{IdUsuario}")]
    public async Task<bool> DeleteUser(int IdUsuario)
    {
        return await _tUsuarioRepository.Delete(IdUsuario);
    }
    [HttpPut("UpdateUser")]
    public async Task<bool> UpdateUser([FromBody] TUsuario Usuario)
    {
        return await _tUsuarioRepository.Update(Usuario);
    }

    private bool ValidarDatos(TUsuario Usuario)
    { /*
        if (Usuario.NombreUsuario == null || Usuario.Nombre == null || Usuario.Apellidos == null ||
            Usuario.Apellidos == null || Usuario.Correo == null || Usuario.Contrasenna == null || Usuario.Tipo == null ||
            Usuario.Telefono == null)
            return true;
        else*/
        return false;
    }
}
