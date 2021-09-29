using Blazor.Cooperativa.Ahorro.Shared.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Cooperativa.Ahorro.Repositorio
{
    public interface ITUsuarioRepository
    {
        Task<IEnumerable<TUsuario>> GetAll();
        Task<IEnumerable<TUsuario>> GetById(int IdUsuario);
        Task<bool> Insert(TUsuario Usuario);
        Task<bool> Delete(int IdUsuario);
        Task<bool> Update(TUsuario Usuario);
    }
}
