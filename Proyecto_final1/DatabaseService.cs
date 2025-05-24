using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Proyecto_final1
{

    public class DatabaseService
    {
        private readonly string _connString = "Server=ALE_GARCIA\\SQLEXPRESS;Database=Registro_Ai;Integrated Security=True; TrustServerCertificate=True; ";

        public async Task GuardarAsync(Registro record)
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    await conn.OpenAsync();
                    var cmd = new SqlCommand(
                        "INSERT INTO Registros (Prompt, Respuesta, Fecha) VALUES (@p, @r, @f)", conn);

                    cmd.Parameters.AddWithValue("@p", record.Prompt);
                    cmd.Parameters.AddWithValue("@r", record.Respuesta);
                    cmd.Parameters.AddWithValue("@f", record.Fecha);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception($"Error SQL ({sqlEx.Number}): {sqlEx.Message}", sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error general al guardar: {ex.Message}", ex);
            }
        }
    }
}

