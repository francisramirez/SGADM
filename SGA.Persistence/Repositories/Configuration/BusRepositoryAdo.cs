
using Microsoft.Data.SqlClient;
using SGA.Domain.Entitines;
using SGA.Domain.Base;
using SGA.Domain.Entitines.Configuration;
using SGA.Application.Repositories.Confguration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using SGA.Persistence.Models.Configuration.Bus;
namespace SGA.Persistence.Repositories.Configuration
{
    public class BusRepositoryAdo : IBusRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<BusRepositoryAdo> _logger;
        public BusRepositoryAdo(IConfiguration configuration,
                                ILogger<BusRepositoryAdo> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public Task<bool> Exists(Expression<Func<Bus, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> GetAll()
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration["SgaConnString"]))
                {
                    using (SqlCommand command = new SqlCommand("usp_Bus_ObtenerBuses", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        await connection.OpenAsync();

                        using (SqlDataReader da = await command.ExecuteReaderAsync())
                        {


                            if (!da.HasRows)
                            {
                                operationResult.Success = true;
                                operationResult.Message = "No se encontraron buses.";
                                return operationResult;
                            }

                            List<BusGetModel> buses = new List<BusGetModel>();

                            while (await da.ReadAsync())
                            {
                                BusGetModel busGetModel = new BusGetModel()
                                {
                                    IdBus = da.GetInt32(da.GetOrdinal("IdBus")),
                                    NumeroPlaca = da.GetString(da.GetOrdinal("NumeroPlaca")),
                                    Nombre = da.GetString(da.GetOrdinal("Nombre")),
                                    CapacidadPiso1 = da.GetInt32(da.GetOrdinal("CapacidadPiso1")),
                                    CapacidadPiso2 = da.GetInt32(da.GetOrdinal("CapacidadPiso2")),
                                    CapacidadTotal = da.GetInt32(da.GetOrdinal("CapacidadTotal")),
                                    Disponible = da.GetBoolean(da.GetOrdinal("Disponible")),
                                    FechaCreacion = da.GetDateTime(da.GetOrdinal("FechaCreacion"))
                                };

                                buses.Add(busGetModel);
                            }

                            operationResult.Success = true;
                            operationResult.Data = buses;
                            operationResult.Message = "Buses obtenidos correctamente.";
                            return operationResult;

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al obtener los buses.");
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error al obtener los buses.";
                return operationResult;
            }

            return operationResult;
        }

        public Task<OperationResult> GetAll(Expression<Func<Bus, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> GetEntityBy(int Id)
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration["SgaConnString"]))
                {
                    using (SqlCommand command = new SqlCommand("usp_Bus_ObtenerBusById", connection))
                    {
                        command.Parameters.AddWithValue("@IdBus", Id);

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdBus", Id);

                        await connection.OpenAsync();

                        using (SqlDataReader da = await command.ExecuteReaderAsync())
                        {

                            if (!da.HasRows)
                            {
                                operationResult.Success = false;
                                operationResult.Message = "No se encontraron buses.";
                                return operationResult;
                            }

                            List<BusGetModel> buses = new List<BusGetModel>();

                            while (await da.ReadAsync())
                            {
                                BusGetModel busGetModel = new BusGetModel()
                                {
                                    IdBus = da.GetInt32(da.GetOrdinal("IdBus")),
                                    NumeroPlaca = da.GetString(da.GetOrdinal("NumeroPlaca")),
                                    Nombre = da.GetString(da.GetOrdinal("Nombre")),
                                    CapacidadPiso1 = da.GetInt32(da.GetOrdinal("CapacidadPiso1")),
                                    CapacidadPiso2 = da.GetInt32(da.GetOrdinal("CapacidadPiso2")),
                                    CapacidadTotal = da.GetInt32(da.GetOrdinal("CapacidadTotal")),
                                    Disponible = da.GetBoolean(da.GetOrdinal("Disponible")),
                                    FechaCreacion = da.GetDateTime(da.GetOrdinal("FechaCreacion"))
                                };

                                buses.Add(busGetModel);
                            }

                            operationResult.Success = true;
                            operationResult.Data = buses;
                            operationResult.Message = "Buses obtenidos correctamente.";
                            return operationResult;

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al obtener los buses.");
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error al obtener los buses.";
                return operationResult;
            }

            return operationResult;
        }

        public Task<OperationResult> Remove(Bus entity)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> Save(Bus entity)
        {
            OperationResult operationResult = new OperationResult();

            // validaciones de datos

            if (entity == null)
            {
                operationResult.Success = false;
                operationResult.Message = "El objeto bus no puede ser nulo.";
                return operationResult;
            }
            if (string.IsNullOrWhiteSpace(entity.NumeroPlaca))
            {
                operationResult.Success = false;
                operationResult.Message = "El número de placa no puede ser nulo o vacío.";
                return operationResult;
            }
            if (entity.NumeroPlaca.Length > 50)
            {
                operationResult.Success = false;
                operationResult.Message = "El número de placa no puede ser nulo o vacío.";
                return operationResult;
            }
            if (string.IsNullOrWhiteSpace(entity.Nombre))
            {
                operationResult.Success = false;
                operationResult.Message = "El nombre del bus no puede ser nulo o vacío.";
                return operationResult;
            }
            if (entity.Nombre.Length > 50)
            {
                operationResult.Success = false;
                operationResult.Message = "El nombre del bus no puede tener más de 50 caracteres.";
                return operationResult;
            }

            try
            {
                // Implementación ADO.NET para guardar el bus en la base de datos

                using (SqlConnection connection = new SqlConnection(_configuration["SgaConnString"]))
                {

                    using (SqlCommand command = new SqlCommand("usp_Bus_Guardar", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NumeroPlaca", entity.NumeroPlaca);
                        command.Parameters.AddWithValue("@Nombre", entity.Nombre);
                        command.Parameters.AddWithValue("@CapacidadPiso1", entity.CapacidadPiso1);
                        command.Parameters.AddWithValue("@CapacidadPiso2", entity.CapacidadPiso2);
                        command.Parameters.AddWithValue("@Disponible", entity.Disponible);
                        command.Parameters.AddWithValue("@UsuarioModificacion", entity.UsuarioModificacion);
                        command.Parameters.AddWithValue("@FechaCreacion", entity.FechaCreacion);
                      

                        SqlParameter p_result = new SqlParameter("@Presult", System.Data.SqlDbType.VarChar)
                        {
                            Size = 1000,
                            Direction = System.Data.ParameterDirection.Output
                        };

                        command.Parameters.Add(p_result);

                        await connection.OpenAsync();

                        var commandResult = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al guardar el bus.");
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error al guardar el bus.";
                return operationResult;
            }
            return operationResult;
        }

        public async Task<OperationResult> Update(Bus entity)
        {
            OperationResult operationResult = new OperationResult();

            // validaciones de datos

            if (entity == null)
            {
                operationResult.Success = false;
                operationResult.Message = "El objeto bus no puede ser nulo.";
                return operationResult;
            }
            if (string.IsNullOrWhiteSpace(entity.NumeroPlaca))
            {
                operationResult.Success = false;
                operationResult.Message = "El número de placa no puede ser nulo o vacío.";
                return operationResult;
            }
            if (entity.NumeroPlaca.Length > 50)
            {
                operationResult.Success = false;
                operationResult.Message = "El número de placa no puede ser nulo o vacío.";
                return operationResult;
            }
            if (string.IsNullOrWhiteSpace(entity.Nombre))
            {
                operationResult.Success = false;
                operationResult.Message = "El nombre del bus no puede ser nulo o vacío.";
                return operationResult;
            }
            if (entity.Nombre.Length > 50)
            {
                operationResult.Success = false;
                operationResult.Message = "El nombre del bus no puede tener más de 50 caracteres.";
                return operationResult;
            }

            try
            {
                // Implementación ADO.NET para guardar el bus en la base de datos


                using (SqlConnection connection = new SqlConnection(_configuration["SgaConnString"]))
                {
                    using (SqlCommand command = new SqlCommand("usp_Bus_Actualizar", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NumeroPlaca", entity.IdBus);
                        command.Parameters.AddWithValue("@NumeroPlaca", entity.NumeroPlaca);
                        command.Parameters.AddWithValue("@Nombre", entity.Nombre);
                        command.Parameters.AddWithValue("@CapacidadPiso1", entity.CapacidadPiso1);
                        command.Parameters.AddWithValue("@CapacidadPiso2", entity.CapacidadPiso2);
                        command.Parameters.AddWithValue("@Disponible", entity.Disponible);
                        command.Parameters.AddWithValue("@UsuarioModificacion", entity.UsuarioModificacion);
                        command.Parameters.AddWithValue("@FechaCreacion", entity.FechaCreacion);
                        command.Parameters.AddWithValue("@FechaModificacion", entity.FechaModificacion);
                        command.Parameters.AddWithValue("@Estatus", entity.Estatus);


                        SqlParameter p_result = new SqlParameter("@Presult", System.Data.SqlDbType.VarChar)
                        {
                            Size = 1000,
                            Direction = System.Data.ParameterDirection.Output
                        };

                        command.Parameters.Add(p_result);

                        await connection.OpenAsync();

                        var commandResult = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al actualizar el bus.");
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error al actualizar el bus.";
                return operationResult;
            }
            return operationResult;
        }
    }
}
