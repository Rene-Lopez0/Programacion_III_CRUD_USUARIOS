// Write your JavaScript code.
/// <summary>
/// JavaScript para la pantalla de Inicio de sesión
/// </summary>
/// <createdate>18/06/2026</createdate>
/// <author>René López Morales</author>
/// <lastmodificationdate></lastmodificationdate>
/// <lastmodificationdescription></lastmodificationdescription>
/// <lastmodifierauthor></lastmodifierauthor>



jsMantUsuario = {

    objetos: {


    },
    controles: {

        InputCorreo: '#InputCorreo',
        InputContrasena: '#InputContrasena',
        InputRol: '#InputRol',
        InputNombre: '#InputNombre',
        InputApellido1: '#InputApellido1',
        InputApellido2: '#InputApellido2',
        InputFechaNac: '#InputFechaNac',
        InputGenero: '#InputGenero',
        InputTelefono: '#InputTelefono',
        InputDireccion: '#InputDireccion',






    },


    Modals: {



    },


    Tablas: {


    },


    botones: {

        btnCrearUsuario: '#btnCrearUsuario',
        btnCancelar: '#btnCancelar',


    },

    variables: {




    },
    metodos: {


        RegistrarUsuario: function () {

            event.preventDefault();

            try {

                let ObjUsuario = {

                    Correo: $(jsMantUsuario.controles.InputCorreo).val(),
                    Contrasena: $(jsMantUsuario.controles.InputContrasena).val(),
                    IdRol: $(jsMantUsuario.controles.InputRol).val(),
                    Nombre: $(jsMantUsuario.controles.InputNombre).val(),
                    Apellido1: $(jsMantUsuario.controles.InputApellido1).val(),
                    Apellido2: $(jsMantUsuario.controles.InputApellido2).val(),
                    FechaNacimiento: $(jsMantUsuario.controles.InputFechaNac).val(),
                    Genero: $(jsMantUsuario.controles.InputGenero).val(),
                    Telefono: $(jsMantUsuario.controles.InputTelefono).val(),
                    Direccion: $(jsMantUsuario.controles.InputDireccion).val()


                }

                if (ObjUsuario.Correo !== "" && ObjUsuario.Contrasena !== "" && ObjUsuario.IdRol !== "0" && ObjUsuario.Nombre !== "" && ObjUsuario.Apellido1 !== "" && ObjUsuario.Apellido2 !== "" &&
                    ObjUsuario.FechaNacimiento !== "" && ObjUsuario.Genero !== "0" && ObjUsuario.Telefono !== "" && ObjUsuario.Direccion !== "") {


                    fetch('../Usuario/RegistrarUsuarios', {
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
                                    text: `${resultado.mensaje}`,
                                    icon: "success",
                                    confirmButtonText: "Entendido",
                                    confirmButtonColor: "#297ea6"
                                });

                                setTimeout(() => {

                                    window.location.reload();

                                }, 2000)


                            } else {


                                Swal.fire({
                                    title: "Advertencia",
                                    text: `${resultado.mensaje}`,
                                    icon: "warning",
                                    confirmButtonText: "Entendido",
                                    confirmButtonColor: "#297ea6"
                                });


                            }





                        })




                } else {

                    Swal.fire({
                        title: "Advertencia",
                        text: `Debe rellenar todos los campos`,
                        icon: "warning",
                        confirmButtonText: "Entendido",
                        confirmButtonColor: "#297ea6"
                    });

                }




            } catch (e) {

                console.log("Ha ocurrido un error en el método RegistrarUsuario en el JS: ", e)

            }



        },





    },
    eventos:
        function () {

            $(jsMantUsuario.botones.btnCrearUsuario).on('click', function () {

                jsMantUsuario.metodos.RegistrarUsuario();

            });





        }

}

$(function () {
    jsMantUsuario.eventos();
});
