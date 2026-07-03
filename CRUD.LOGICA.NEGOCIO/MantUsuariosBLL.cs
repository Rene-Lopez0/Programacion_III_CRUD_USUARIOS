using CRUD.DATA.DAPPER;
using CRUD.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CRUD.LOGICA.NEGOCIO
{
    public class MantUsuariosBLL
    {

        #region "Constructor"
        //Instancias
        private readonly MantUsuariosDAPPER _MantUsuarioDapper;

        //Constructor

        public MantUsuariosBLL(MantUsuariosDAPPER mantUsuariosDAPPER)
        {

            _MantUsuarioDapper = mantUsuariosDAPPER;
        }

        #endregion



        #region "Funciones"
        //Funciones o métodos

        public Respuesta<List<RolesDto>> ObtenerRoles()
        {

            Respuesta<List<RolesDto>> respuesta = new Respuesta<List<RolesDto>>();

            try
            {

                var ResDal = _MantUsuarioDapper.ObtenerRoles();

                if (ResDal != null)
                {
                    respuesta = ResDal;

                }

            }
            catch (Exception ex)
            {

                respuesta.Ok = false;
                respuesta.Mensaje = $"Ha ocurrido un error en la capa MantUsuarioBLL en el método ObtenerRoles {ex.Message}";
                respuesta.ValorRetorno = null;
            }

            return respuesta;


        }


        public Respuesta<UsuarioDTO> RegistrarUsuarios(UsuarioDTO ObjUsuario)
        {

            Respuesta<UsuarioDTO> respuesta = new Respuesta<UsuarioDTO>();

            try
            {

                var resDAL = _MantUsuarioDapper.RegistrarUsuarios(ObjUsuario);

                if (resDAL != null)
                {

                    respuesta = resDAL;

                }

            }
            catch (Exception ex)
            {

                respuesta.Ok = false;
                respuesta.Mensaje = $"Ha ocurrido un error en la función RegistrarUsuarios {ex.Message}";
                respuesta.ValorRetorno= null;
            }

            return respuesta;

        }

        public Respuesta<UsuarioDTO> ActualizarUsuarioPorId(UsuarioDTO ObjUsuario)
        {

            Respuesta<UsuarioDTO> respuesta = new Respuesta<UsuarioDTO>();

            try
            {

                var resDAL = _MantUsuarioDapper.ActualizarUsuarioPorId(ObjUsuario);

                if (resDAL != null)
                {

                    respuesta = resDAL;

                }

            }
            catch (Exception ex)
            {

                respuesta.Ok = false;
                respuesta.Mensaje = $"Ha ocurrido un error en la función ActualizarUsuarioPorId {ex.Message}";
                respuesta.ValorRetorno = null;
            }

            return respuesta;

        }

        public Respuesta<List<UsuarioDTO>> ObtenerUsuarios()
        {

            Respuesta<List<UsuarioDTO>> respuesta = new Respuesta<List<UsuarioDTO>>();

            try
            {

                var ResDal = _MantUsuarioDapper.ObtenerUsuarios();

                if (ResDal != null)
                {
                    respuesta = ResDal;

                }

            }
            catch (Exception ex)
            {

                respuesta.Ok = false;
                respuesta.Mensaje = $"Ha ocurrido un error en la capa MantUsuarioBLL en el método ObtenerUsuarios {ex.Message}";
                respuesta.ValorRetorno = null;
            }

            return respuesta;


        }

        public Respuesta<UsuarioDTO> ObtenerUsuarioPorId(UsuarioDTO ObjUsuario)
        {

            Respuesta<UsuarioDTO> respuesta = new Respuesta<UsuarioDTO>();

            try
            {

                var ResDal = _MantUsuarioDapper.ObtenerUsuarioPorId(ObjUsuario);

                if (ResDal != null)
                {
                    respuesta = ResDal;

                }

            }
            catch (Exception ex)
            {

                respuesta.Ok = false;
                respuesta.Mensaje = $"Ha ocurrido un error en la capa MantUsuarioBLL en el método ObtenerUsuarioPorId {ex.Message}";
                respuesta.ValorRetorno = null;
            }

            return respuesta;


        }



        #endregion

    }
}
