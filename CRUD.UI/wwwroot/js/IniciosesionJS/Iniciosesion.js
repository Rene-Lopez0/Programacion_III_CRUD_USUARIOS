// Write your JavaScript code.
/// <summary>
/// JavaScript para la pantalla de Inicio de sesión
/// </summary>
/// <createdate>21/05/2026</createdate>
/// <author>René López Morales</author>
/// <lastmodificationdate></lastmodificationdate>
/// <lastmodificationdescription></lastmodificationdescription>
/// <lastmodifierauthor></lastmodifierauthor>


jsIniciarSesion = {

    objetos: {


    },
    controles: {

        Correo: '#InputCorreo',
        Contrasena: '#InputContrasena'



    },

    Tablas: {


    },

    botones: {

        btnIniciarSesion: '#btnIniciarSesion'

    },

    variables: {




    },
    metodos: {


        IniciarSesion: function () {

            event.preventDefault();


            try {

                let ObjUsuario = {

                    Correo: $(jsIniciarSesion.controles.Correo).val(),
                    Contrasena: $(jsIniciarSesion.controles.Contrasena).val()

                }

                if (ObjUsuario.Correo !== "" && ObjUsuario.Contrasena !== "") {


                    fetch('../Inicio/IniciarSesion', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify(ObjUsuario)
                    })
                        .then(respuesta => respuesta.json())
                        .then(resultado => {


                        
                            if (resultado.ok) {


                                Swal.fire({
                                    title: "Éxito",
                                    text: `${resultado.mensaje} Bienvenid@: ${resultado.valorRetorno.nombreCompleto}.`,
                                    icon: "success",
                                    confirmButtonText: 'Entendido',
                                    confirmButtonColor: '#297ea6'
                                });


                                setTimeout(function () {


                                    window.location.href = '/Home/Index';

                                }, 2000)



                            } else {

                                Swal.fire({
                                    title: "Advertencia",
                                    text: `${resultado.mensaje}`,
                                    icon: "warning",
                                    confirmButtonText: 'Entendido',
                                    confirmButtonColor: '#297ea6'
                                });


                            }
                            



                        })







                } else {


                    Swal.fire({
                        title: "Advertencia",
                        text: "Debe rellenar todos los campos",
                        icon: "warning",
                        confirmButtonText: 'Entendido',
                        confirmButtonColor: '#297ea6'
                    });
                }

            } catch (ex) {

                console.log("Ha ocurrido un error en el método del JS llamado IniciarSesion ", ex)

                Swal.fire({
                    title: "Advertencia",
                    text: "Ha ocurrido un error en el js",
                    icon: "error",
                    confirmButtonText: 'Entendido',
                    confirmButtonColor: '#297ea6'
                });

            }


        },





    },
    eventos:
        function () {

            $(jsIniciarSesion.botones.btnIniciarSesion).on('click', function () {

                jsIniciarSesion.metodos.IniciarSesion();

            });

        }

}

$(function () {
    jsIniciarSesion.eventos();
});