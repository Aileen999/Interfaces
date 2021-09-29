using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Cooperativa.Ahorro.Shared.Modelo
{
    public class TUsuario
    {
        public int IdUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Contrasenia { get; set; }
        public string TipoUsuario { get; set; }
        public string Estado { get; set; }
    }
}
