using CRUD.ENTIDADES;
using CRUD.LOGICA.NEGOCIO;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace CRUD.UI.Controllers
{
    public class UsuarioController : Controller
    {
        #region "Constructor
        //Instancias

        private readonly MantUsuariosBLL _MantUsuarioBLL;

        //Constructor

        public UsuarioController(MantUsuariosBLL mantUsuariosBLL)
        {

            _MantUsuarioBLL = mantUsuariosBLL;

        }

        #endregion


        #region "Funciones"
        //Funciones

        public IActionResult MantUsuarios()
        {
            ObtenerRoles();
            return View();
        }


        public Respuesta<List<RolesDto>> ObtenerRoles()
        {

            Respuesta<List<RolesDto>> respuesta = new Respuesta<List<RolesDto>>();

            try
            {

                var ResBLL = _MantUsuarioBLL.ObtenerRoles();

                if (ResBLL != null)
                {
                    respuesta = ResBLL;

                    ViewBag.ListaRoles = respuesta.ValorRetorno;
                }


            }
            catch (Exception ex)
            {

                respuesta.Ok = false;
                respuesta.Mensaje = $"Ha ocurrido un error en la capa UsuarioController en el método ObtenerRoles {ex.Message}";
                respuesta.ValorRetorno = null;
            }

            return respuesta;


        }



        #endregion


    }
}
