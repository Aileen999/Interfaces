using Blazor.Cooperativa.Ahorro.Shared.Modelo;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Cooperativa.Ahorro.Repositorio
{

        public class TUsuarioRepository : ITUsuarioRepository
        {
            private readonly IDbConnection _bdConnection;
            public TUsuarioRepository(IDbConnection dbConnection)
            {
                _bdConnection = dbConnection;
            }

            public async Task<bool> Delete(int IdUsuario)
            {
                var sql = @"
                DELETE FROM TUsuario WHERE IdUsuario = @IdUsuario;
                ";
                var result = await _bdConnection.ExecuteAsync(sql, new
                {
                    IdUsuario = IdUsuario

                });
                return result > 0;


            }

            public async Task<IEnumerable<TUsuario>> GetAll()
            {
                var sql = @"
                 SELECT 
                    IdUsuario
                    ,CorreoElectronico
                    ,Nombre
                    ,Apellidos
                    ,Cedula
                    ,Contrasenia
                    ,TipoUsuario
                    ,Estado
                 FROM TUsuario
                ";
                return await _bdConnection.QueryAsync<TUsuario>(sql, new { });
            }

            public async Task<IEnumerable<TUsuario>> GetById(int IdUsuario)
            {
                var sql = @"
                SELECT 
                    IdUsuario
                    ,CorreoElectronico
                    ,Nombre
                    ,Apellidos
                    ,Cedula
                    ,Contrasenia
                    ,TipoUsuario
                    ,Estado
                 FROM TUsuario
                 WHERE IdUsuario = @IdUsuario
                ";
                return await _bdConnection.QueryAsync<TUsuario>(sql, new { IdUsuario = IdUsuario });
            }

            public async Task<bool> Insert(TUsuario Usuario)
            {
                var sql = @"
               INSERT INTO TUsuario(
                      CorreoElectronico,Nombre, Apellidos,Cedula,Contrasenia,
                      TipoUsuario,Estado)
               VALUES (
                      @CorreoElectronico,@Nombre,@Apellidos,@Cedula,
                      @Contrasenia,@TipoUsuario,@Estado)
            ";

                var result = await _bdConnection.ExecuteAsync(sql, new
                {
                    CorreoElectronico = Usuario.CorreoElectronico,
                    Nombre = Usuario.Nombre,
                    Apellidos = Usuario.Apellidos,
                    Cedula = Usuario.Cedula,
                    Contrasenia = Usuario.Contrasenia,
                    TipoUsuario = Usuario.TipoUsuario,
                    Estado = Usuario.Estado

                });
                return result > 0;


            }

            public async Task<bool> Update(TUsuario Usuario)
            {
                var sql = @"
               UPDATE TUsuario
                      SET
                        CorreoElectronico = @CorreoElectronico,Nombre = @Nombre, Apellidos = @Apellidos,
                        Cedula = @Cedula,Contrasenia = @Contrasenia,TipoUsuario = @TipoUsuario,Estado = @Estado
                       WHERE IdUsuario = @IdUsuario            
                      
                ";

                var result = await _bdConnection.ExecuteAsync(sql, new
                {
                    IdUsuario = Usuario.IdUsuario,
                    CorreoElectronico = Usuario.CorreoElectronico,
                    Nombre = Usuario.Nombre,
                    Apellidos = Usuario.Apellidos,
                    Cedula = Usuario.Cedula,
                    Contrasenia = Usuario.Contrasenia,
                    TipoUsuario = Usuario.TipoUsuario,
                    Estado = Usuario.Estado

                });
                return result > 0;
            }
        }
    
}
