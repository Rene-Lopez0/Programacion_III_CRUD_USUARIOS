using CRUD.DATA.DAPPER;
using CRUD.ENTIDADES;
using System.Runtime.CompilerServices;

namespace CRUD.LOGICA.NEGOCIO
{
    public class IniciarSesionBLL
    {

        //Instancias

        private readonly InicioSesionDAPPER _AccesoInicioSesionDAPPER;

        //Contructor
        public IniciarSesionBLL(InicioSesionDAPPER inicioSesionDAPPER)
        {
            _AccesoInicioSesionDAPPER = inicioSesionDAPPER;

        }


        public Respuesta<UsuarioDTO> IniciarSesion(UsuarioDTO ObjUsuario)
        {

            Respuesta<UsuarioDTO> respuesta = new Respuesta<UsuarioDTO>();

            try
            {

                var resDAL = _AccesoInicioSesionDAPPER.IniciarSesion(ObjUsuario);

                if (resDAL != null)
                {
                    respuesta = resDAL;

                }


            }
            catch (Exception ex)
            {

                respuesta.Ok = false;
                respuesta.Mensaje = $"Ha ocurrido un error en la función IniciarSesion de la capa IniciarSesionBLL {ex.Message}";
                respuesta.ValorRetorno = null;
            }

            return respuesta;

        }



    }
}
