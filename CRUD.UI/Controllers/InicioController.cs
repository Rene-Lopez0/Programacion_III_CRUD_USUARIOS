using Microsoft.AspNetCore.Mvc;
using CRUD.ENTIDADES;
using Microsoft.AspNetCore.Server.HttpSys;
using CRUD.LOGICA.NEGOCIO;
using Microsoft.AspNetCore.Authorization;

namespace CRUD.UI.Controllers
{
    [AllowAnonymous]
    public class InicioController : Controller
    {

        //Instancias

        private readonly IniciarSesionBLL _AccesoInicioSesionBLL;


        //Constructor

        public InicioController(IniciarSesionBLL iniciarSesionBLL)
        {
            _AccesoInicioSesionBLL = iniciarSesionBLL;

        }


        public IActionResult Iniciosesion()
        {
            return View();
        }


        [HttpPost]
        public Respuesta<UsuarioDTO> IniciarSesion([FromBody] UsuarioDTO ObjUsuario)
        {

            Respuesta<UsuarioDTO> respuesta = new Respuesta<UsuarioDTO>();

            try
            {

                var resBLL = _AccesoInicioSesionBLL.IniciarSesion(ObjUsuario);

                if (resBLL != null)
                {

                    respuesta = resBLL;


                    if (respuesta.Ok && respuesta.ValorRetorno != null)
                    {

                        HttpContext.Session.SetInt32("IdUsuario", respuesta.ValorRetorno.IdUsuario);
                        HttpContext.Session.SetString("NombreCompleto", respuesta.ValorRetorno.NombreCompleto ?? string.Empty);
                        HttpContext.Session.SetString("Correo", respuesta.ValorRetorno.Correo ?? string.Empty);


                    }

                }

            }
            catch (Exception ex)
            {

                respuesta.Ok = false;
                respuesta.Mensaje = $"Ha ocurrido un error en la función IniciarSesion en la clase InicioController {ex.Message}";

            }

            return respuesta;



        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CerrarSesion()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("InicioSesion", "Inicio");

        }





    }
}
