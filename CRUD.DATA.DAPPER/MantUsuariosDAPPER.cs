using CRUD.ENTIDADES;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CRUD.DATA.DAPPER
{
    public class MantUsuariosDAPPER
    {

        #region "Procedimientos almacenados"
        //Procedimientos almacenados

        private const string sp_spObtenerRoles = "spObtenerRoles";

        #endregion



        #region "Constructor"
        //Instancias

        private readonly IConfiguration _Config;

        //Constructor

        public MantUsuariosDAPPER(IConfiguration configuration)
        {

            _Config = configuration;
        }

        #endregion




        #region "Funciones"

        public Respuesta<List<RolesDto>> ObtenerRoles()
        {

            Respuesta<List<RolesDto>> respuesta = new Respuesta<List<RolesDto>>();
            List<RolesDto> ListaRoles = new List<RolesDto>();
            try
            {

                var ConexionBD = _Config.GetConnectionString("Conexion");

                using (SqlConnection connection = new SqlConnection(ConexionBD))
                {

                    connection.Open();


                    using (SqlCommand command = new SqlCommand(sp_spObtenerRoles, connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        //command.Parameters.Add(new SqlParameter("@pCorreo", SqlDbType.NVarChar, 80) { Value = ObjUsuario.Correo });
                        //command.Parameters.Add(new SqlParameter("@pContrasena", SqlDbType.NVarChar, 50) { Value = ObjUsuario.Contrasena });


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                RolesDto Rol = new RolesDto
                                {
                                    IdRol = (int)reader["IdRol"],
                                    NombreRol = (string)reader["NombreRol"]

                                };

                                ListaRoles.Add(Rol);




                            }

                            respuesta.Ok = true;
                            respuesta.Mensaje = "Se han obtenido los roles de manera exitosa";
                            respuesta.ValorRetorno = ListaRoles;


                        }


                    }

                }


            }
            catch (Exception ex)
            {

                respuesta.Ok = false;
                respuesta.Mensaje = $"Ha ocurrido un error en la función ObtenerRoles de la capa DAPPER {ex.Message}";
                respuesta.ValorRetorno = null;
            }

            return respuesta;

        }



        #endregion



    }
}
