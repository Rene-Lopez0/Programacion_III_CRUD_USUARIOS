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
        private const string sp_spRegistrarUsuarios = "spRegistrarUsuarios";
        private const string sp_spObtenerUsuarios = "spObtenerUsuarios";

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

        public Respuesta<UsuarioDTO> RegistrarUsuarios(UsuarioDTO ObjUsuario)
        {

            Respuesta<UsuarioDTO> respuesta = new Respuesta<UsuarioDTO>();
            try
            {

                var ConexionBD = _Config.GetConnectionString("Conexion");

                using (SqlConnection connection = new SqlConnection(ConexionBD))
                {

                    connection.Open();


                    using (SqlCommand command = new SqlCommand(sp_spRegistrarUsuarios, connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@pCorreo", SqlDbType.NVarChar, 80) { Value = ObjUsuario.Correo });
                        command.Parameters.Add(new SqlParameter("@pContrasena", SqlDbType.NVarChar, 50) { Value = ObjUsuario.Contrasena });
                        command.Parameters.Add(new SqlParameter("@pIdRol", SqlDbType.Int) { Value = ObjUsuario.IdRol });
                        command.Parameters.Add(new SqlParameter("@pNombre", SqlDbType.NVarChar, 50) { Value = ObjUsuario.Nombre });
                        command.Parameters.Add(new SqlParameter("@pApellido1", SqlDbType.NVarChar, 50) { Value = ObjUsuario.Apellido1 });
                        command.Parameters.Add(new SqlParameter("@pApellido2", SqlDbType.NVarChar, 50) { Value = ObjUsuario.Apellido2 });
                        command.Parameters.Add(new SqlParameter("@pFechaNac", SqlDbType.Date) { Value = ObjUsuario.FechaNacimiento });
                        command.Parameters.Add(new SqlParameter("@pGenero", SqlDbType.NVarChar, 50) { Value = ObjUsuario.Genero });
                        command.Parameters.Add(new SqlParameter("@pTelefono", SqlDbType.NVarChar, 50) { Value = ObjUsuario.Telefono });
                        command.Parameters.Add(new SqlParameter("@pDireccion", SqlDbType.NVarChar, 400) { Value = ObjUsuario.Direccion });

                        int FilasAfectadas = command.ExecuteNonQuery();

                        if (FilasAfectadas > 0)
                        {

                            respuesta.Ok = true;
                            respuesta.Mensaje = "El usuario ha sido registrado de manera exitosa.";
                            respuesta.ValorRetorno = null;

                        }
                        else
                        {
                            respuesta.Ok = false;
                            respuesta.Mensaje = "Ha ocurrido un error al intentar registrar el usuario.";
                            respuesta.ValorRetorno = null;

                        }
                    }

                }


            }
            catch (Exception ex)
            {

                respuesta.Ok = false;
                respuesta.Mensaje = $"Ha ocurrido un error en la función RegistrarUsuarios de la capa DAPPER {ex.Message}";
                respuesta.ValorRetorno = null;
            }

            return respuesta;

        }


        public Respuesta<List<UsuarioDTO>> ObtenerUsuarios()
        {

            Respuesta<List<UsuarioDTO>> respuesta = new Respuesta<List<UsuarioDTO>>();
            List<UsuarioDTO> ListaUsuarios = new List<UsuarioDTO>();
            try
            {

                var ConexionBD = _Config.GetConnectionString("Conexion");

                using (SqlConnection connection = new SqlConnection(ConexionBD))
                {

                    connection.Open();


                    using (SqlCommand command = new SqlCommand(sp_spObtenerUsuarios, connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        //command.Parameters.Add(new SqlParameter("@pCorreo", SqlDbType.NVarChar, 80) { Value = ObjUsuario.Correo });
                        //command.Parameters.Add(new SqlParameter("@pContrasena", SqlDbType.NVarChar, 50) { Value = ObjUsuario.Contrasena });


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                UsuarioDTO Usuario = new UsuarioDTO
                                {
                                    Correo = (string)reader["Correo"],
                                    NombreRol = (string)reader["NombreRol"],
                                    NombreCompleto = (string)reader["NombreCompleto"],
                                    Telefono = (string)reader["Telefono"],
                                    IdUsuario = (int)reader["IdUsuario"],

                                };

                                ListaUsuarios.Add(Usuario);




                            }

                            respuesta.Ok = true;
                            respuesta.Mensaje = "Se han obtenido los usuarios de manera exitosa.";
                            respuesta.ValorRetorno = ListaUsuarios;


                        }


                    }

                }


            }
            catch (Exception ex)
            {

                respuesta.Ok = false;
                respuesta.Mensaje = $"Ha ocurrido un error en la función ObtenerUsuarios de la capa DAPPER {ex.Message}";
                respuesta.ValorRetorno = null;
            }

            return respuesta;

        }


        #endregion



    }
}
