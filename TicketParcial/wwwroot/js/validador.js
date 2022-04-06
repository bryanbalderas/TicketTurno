function mensajeAlerta(mensaje, campo) {
    swal(campo, mensaje, "error")
}

function validarNombre(nombre) {
    if (nombre.length < 3) {
        /*alert("El nombre no puede tener menos de 3 letras");*/
        mensajeAlerta("El nombre/apellidos no puede tener menos de 3 letras", "Nombre");
        return false;
    } else {
        return true;
    }
}


function validarCurp(Curp) {
    var validado = true;
    validado = Curp.match(/^([a-z]{4})([0-9]{6})([a-z]{6})([0-9]{2})$/i);
    return validado;
}

function validaciones() {
    var val1 = document.forms["crearTicket"]["nombreRealiza"].value.trim();
    var val2 = document.forms["crearTicket"]["curp"].value.trim();
    var val3 = document.forms["crearTicket"]["nombre"].value.trim();
    var val4 = document.forms["crearTicket"]["paterno"].value.trim();
    var val6 = document.forms["crearTicket"]["telefono"].value.trim();
    var val7 = document.forms["crearTicket"]["celular"].value.trim();
    var val8 = document.forms["crearTicket"]["correo"].value.trim();


    if (val1 == "" || val2 == "" || val3 == "" || val4 == "" || val6 == "" || val7 == "" || val8 == "") {
        /*alert("no pueden haber campos vacios");*/
        mensajeAlerta("no pueden haber campos vacios", "Campo vacio");
        return false;
    }


    var validador = true;

    validador = validarNombre(val3);
    if (validador == false) {
        return validador;
    }

    validador = validarNombre(val4);
    if (validador == false) {
        return validador;
    }

    var validaCurp = true;
    validaCurp = validarCurp(val2);

    if (validaCurp == false) {
        /*alert("El CURP no puede tener menos de 18 elementos ni mas de 18");*/
        mensajeAlerta("El CURP no cumple con las caracteristicas necesarias", "CURP");
        return false;
    }

}