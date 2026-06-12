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



        #endregion

    }
}
