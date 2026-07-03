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


        //Modal Editar Usuarios

        btnObtenerUsuarioPorId: '.btnObtenerUsuarioPorId',
        ModalInputIdUsuario: '#ModalInputIdUsuario',
        ModalInputCorreo: '#ModalInputCorreo',
        ModalInputContrasena: '#ModalInputContrasena',
        ModalInputRol: '#ModalInputRol',
        ModalInputNombre: '#ModalInputNombre',
        ModalInputApellido1: '#ModalInputApellido1',
        ModalInputApellido2: '#ModalInputApellido2',
        ModalInputFechaNac: '#ModalInputFechaNac',
        ModalInputGenero: '#ModalInputGenero',
        ModalInputTelefono: '#ModalInputTelefono',
        ModalInputDireccion: '#ModalInputDireccion',





    },


    Modals: {



    },


    Tablas: {


    },


    botones: {

        btnCrearUsuario: '#btnCrearUsuario',
        btnCancelar: '#btnCancelar',
        ModalbtnGuardarUsuario: '#ModalbtnGuardarUsuario',

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

        ObtenerUsuarioPorId: function (event) {

            try {

                let button = $(event.currentTarget);

                let IdUsuarioBoton = button.data("idusuario")

                let ObjUsuario = {

                    IdUsuario: IdUsuarioBoton

                };

                fetch('../Usuario/ObtenerUsuarioPorId', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(ObjUsuario)
                })
                    .then(respuesta => respuesta.json())
                    .then(resultado => {

                        console.log(resultado)


                        if (resultado.ok) {


                            $(jsMantUsuario.controles.ModalInputIdUsuario).val(resultado.valorRetorno.idUsuario)
                            $(jsMantUsuario.controles.ModalInputCorreo).val(resultado.valorRetorno.correo)
                            $(jsMantUsuario.controles.ModalInputContrasena).val(resultado.valorRetorno.contrasena)
                            $(jsMantUsuario.controles.ModalInputRol).val(resultado.valorRetorno.idRol)
                            $(jsMantUsuario.controles.ModalInputNombre).val(resultado.valorRetorno.nombre)
                            $(jsMantUsuario.controles.ModalInputApellido1).val(resultado.valorRetorno.apellido1)
                            $(jsMantUsuario.controles.ModalInputApellido2).val(resultado.valorRetorno.apellido2)
                            $(jsMantUsuario.controles.ModalInputFechaNac).val(resultado.valorRetorno.fechaNacimiento)
                            $(jsMantUsuario.controles.ModalInputGenero).val(resultado.valorRetorno.genero)
                            $(jsMantUsuario.controles.ModalInputTelefono).val(resultado.valorRetorno.telefono)
                            $(jsMantUsuario.controles.ModalInputDireccion).val(resultado.valorRetorno.direccion)

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


            } catch (e) {
                console.log("Ha ocurrido un error al Obtener el usuario, en el método ObtenerUsuarioPorId en el JS")
            }


        },

        ActualizarUsuarioPorId: function () {

            event.preventDefault();


            try {


                let ObjUsuario = {

                    IdUsuario: $(jsMantUsuario.controles.ModalInputIdUsuario).val(),
                    Correo: $(jsMantUsuario.controles.ModalInputCorreo).val(),
                    Contrasena: $(jsMantUsuario.controles.ModalInputContrasena).val(),
                    IdRol: $(jsMantUsuario.controles.ModalInputRol).val(),
                    Nombre: $(jsMantUsuario.controles.ModalInputNombre).val(),
                    Apellido1: $(jsMantUsuario.controles.ModalInputApellido1).val(),
                    Apellido2: $(jsMantUsuario.controles.ModalInputApellido2).val(),
                    FechaNacimiento: $(jsMantUsuario.controles.ModalInputFechaNac).val(),
                    Genero: $(jsMantUsuario.controles.ModalInputGenero).val(),
                    Telefono: $(jsMantUsuario.controles.ModalInputTelefono).val(),
                    Direccion: $(jsMantUsuario.controles.ModalInputDireccion).val(),


                };


                if (ObjUsuario.Correo !== "" && ObjUsuario.Contrasena !== "" && ObjUsuario.IdRol !== "0" && ObjUsuario.Nombre !== "" && ObjUsuario.Apellido1 !== "" &&
                    ObjUsuario.Apellido2 !== "" && ObjUsuario.FechaNacimiento !== "" && ObjUsuario.Genero !== "0" && ObjUsuario.Telefono !== "" && ObjUsuario.Direccion !== "") {


                    Swal.fire({
                        title: "¿Estás seguro que quieres editar este usuario?",
                        text: "Esta acción es irreversible",
                        icon: "warning",
                        showCancelButton: true,
                        confirmButtonColor: "#297ea6",
                        cancelButtonColor: "#d33",
                        confirmButtonText: "Sí, Editar",
                        cancelButtonText: 'No'
                    }).then((result) => {
                        if (result.isConfirmed) {


                            fetch('../Usuario/ActualizarUsuarioPorId', {
                                method: 'POST',
                                headers: {
                                    'Content-Type': 'application/json',
                                },
                                body: JSON.stringify(ObjUsuario)
                            })
                                .then(respuesta => respuesta.json())
                                .then(resultado => {



                                    Swal.fire({
                                        title: "Éxito",
                                        text: `${resultado.mensaje}`,
                                        icon: "success",
                                        confirmButtonText: "Entendido",
                                        confirmButtonColor: "#297ea6"
                                    });

                                    setTimeout(() => {

                                        window.location.reload();

                                    }, 2100)




                                })



                        } else {

                            Swal.fire({
                                title: "Advertencia",
                                text: `${resultado.mensaje}`,
                                icon: "warning",
                                confirmButtonText: "Entendido",
                                confirmButtonColor: "#297ea6"
                            });

                        }





                    });





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

                console.warn("Ha ocurrido un error en la función ActualizarUsuarioPorId en el JS: ", e)


            }



        },



    },
    eventos:
        function () {

            $(jsMantUsuario.botones.btnCrearUsuario).on('click', function () {

                jsMantUsuario.metodos.RegistrarUsuario();

            });

            $(jsMantUsuario.controles.btnObtenerUsuarioPorId).on('click', function (event) {

                jsMantUsuario.metodos.ObtenerUsuarioPorId(event);

            });


            $(jsMantUsuario.botones.ModalbtnGuardarUsuario).on('click', function () {

                jsMantUsuario.metodos.ActualizarUsuarioPorId();

            });

        }

}

$(function () {
    jsMantUsuario.eventos();
});
