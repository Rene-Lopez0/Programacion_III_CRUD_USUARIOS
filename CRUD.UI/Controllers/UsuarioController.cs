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
            ObtenerUsuarios();
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

        [HttpPost]
        public Respuesta<UsuarioDTO> RegistrarUsuarios([FromBody] UsuarioDTO ObjUsuario)
        {

            Respuesta<UsuarioDTO> respuesta = new Respuesta<UsuarioDTO>();

            try
            {

                var resBLL = _MantUsuarioBLL.RegistrarUsuarios(ObjUsuario);

                if (resBLL != null)
                {

                    respuesta = resBLL;

                }

            }
            catch (Exception ex) 
            {

                respuesta.Ok = false;
                respuesta.Mensaje = $"Ha ocurrido un error en el método RegistrarUsuarios en el controlador de Usuario {ex.Message}";
                respuesta.ValorRetorno = null;  
            }

            return respuesta;

        }

        [HttpPost]
        public Respuesta<UsuarioDTO> ActualizarUsuarioPorId([FromBody] UsuarioDTO ObjUsuario)
        {

            Respuesta<UsuarioDTO> respuesta = new Respuesta<UsuarioDTO>();

            try
            {

                var resBLL = _MantUsuarioBLL.ActualizarUsuarioPorId(ObjUsuario);

                if (resBLL != null)
                {

                    respuesta = resBLL;

                }

            }
            catch (Exception ex)
            {

                respuesta.Ok = false;
                respuesta.Mensaje = $"Ha ocurrido un error en el método ActualizarUsuarioPorId en el controlador de Usuario {ex.Message}";
                respuesta.ValorRetorno = null;
            }

            return respuesta;

        }

        public Respuesta<List<UsuarioDTO>> ObtenerUsuarios()
        {

            Respuesta<List<UsuarioDTO>> respuesta = new Respuesta<List<UsuarioDTO>>();

            try
            {

                var ResBLL = _MantUsuarioBLL.ObtenerUsuarios();

                if (ResBLL != null)
                {
                    respuesta = ResBLL;

                    ViewBag.ListaUsuarios = respuesta.ValorRetorno;
                }


            }
            catch (Exception ex)
            {

                respuesta.Ok = false;
                respuesta.Mensaje = $"Ha ocurrido un error en la capa UsuarioController en el método ObtenerUsuarios {ex.Message}";
                respuesta.ValorRetorno = null;
            }

            return respuesta;


        }

        public Respuesta<UsuarioDTO> ObtenerUsuarioPorId([FromBody] UsuarioDTO ObjUsuario)
        {

            Respuesta<UsuarioDTO> respuesta = new Respuesta<UsuarioDTO>();

            try
            {

                var ResBLL = _MantUsuarioBLL.ObtenerUsuarioPorId(ObjUsuario);

                if (ResBLL != null)
                {
                    respuesta = ResBLL;

                }


            }
            catch (Exception ex)
            {

                respuesta.Ok = false;
                respuesta.Mensaje = $"Ha ocurrido un error en la capa UsuarioController en el método ObtenerUsuarioPorId {ex.Message}";
                respuesta.ValorRetorno = null;
            }

            return respuesta;


        }



        #endregion


    }
}
