const validateTicketForm = (e) => {

    e.preventDefault();

    const processedBy = document.getElementById('nombreRealiza');
    const curp = document.getElementById('curp');
    const name = document.getElementById('nombre');
    const paternalLastName = document.getElementById('paterno');
    const telephone = document.getElementById('telefono');
    const cellphone = document.getElementById('celular');
    const email = document.getElementById('correo');
    const educationLevel = document.getElementById('nivel');
    const town = document.getElementById('municipio');
    const subject = document.getElementById('asunto');

    if (!validateInput(processedBy, 3)) {
        handleError("Ingresa un nombre válido para continuar.");
        return false;
    }

    if (!validateCurp(curp)) {
        handleError("Ingresa una CURP válida para continuar.");
        return false;
    }

    if (!validateAge(curp)) {
        handleError("Tu fecha de nacimiento no está en el rango permitido de 3 a 15 años para los diferentes tipos de trámite, te recomendamos acudir personalmente a la oficina correspondiente.");
        return false;
    }

    if (!validateInput(name, 3)) {
        handleError("Ingresa un nombre válido para continuar.");
        return false;
    }

    if (!validateInput(paternalLastName, 3)) {
        handleError("Ingresa un apellido paterno válido para continuar.");
        return false;
    }

    if (!validatePhoneNumber(telephone, 3)) {
        handleError("Ingresa un teléfono válido para continuar.");
        return false;
    }

    if (!validatePhoneNumber(cellphone)) {
        handleError("Ingresa un celular válido para continuar.");
        return false;
    }

    if (!validateEmail(email)) {
        handleError("Ingresa un correo válido para continuar.");
        return false;
    }

    if (!validateSelect(educationLevel)) {
        handleError("Selecciona un nivel acádemico para continuar.");
        return false;
    }

    if (!validateSelect(town)) {
        handleError("Selecciona un municipio para continuar.");
        return false;
    }

    if (!validateSelect(subject)) {
        handleError("Selecciona un asunto para continuar.");
        return false;
    }
    
    document.querySelector("#ticket-form").submit();

};

const validateTownForm = (e) => {

    e.preventDefault();

    const town = document.getElementById('descripcion');

    if (!validateInput(town, 3)) {
        handleError("Ingresa un municipio válido para continuar.");
        return false;
    }

    document.querySelector("#town-form").submit();

};

const validateSubjectForm = (e) => {

    e.preventDefault();

    const subject = document.getElementById('descripcion');

    if (!validateInput(subject, 3)) {
        handleError("Ingresa un asunto válido para continuar.");
        return false;
    }

    document.querySelector("#subject-form").submit();

};

const validateLevelForm = (e) => {

    e.preventDefault();

    const level = document.getElementById('descripcion');

    if (!validateInput(level, 3)) {
        handleError("Ingresa un nivel válido para continuar.");
        return false;
    }

    document.querySelector("#level-form").submit();

};

const confirmDelete = (e) => {
    e.preventDefault();
    Swal.fire({
        title: '¿Estás seguro que quieres proceder?',
        showConfirmButton: false,
        showDenyButton: true,
        showCancelButton: true,
        denyButtonText: 'Eliminar',
        cancelButtonText: `Cancelar`,
    }).then((result) => {
        if (result.isDenied) {
            document.querySelector("#form").submit();
        }
    })
}

const validateLogin = (e) => {

    e.preventDefault();

    const email = document.getElementById('email');
    const password = document.getElementById('password');

    if (!validateInput(email, 1)) {
        handleError("Ingresa un correo para continuar.");
        return false;
    }

    if (!validateEmail(email)) {
        handleError("Ingresa un correo válido para continuar.");
        return false;
    }

    if (!validateInput(password, 1)) {
        handleError("Ingresa una contraseña para continuar.");
        return false;
    }

    document.querySelector("#account").submit();

};

const validateSignup = (e) => {

    e.preventDefault();

    const nombre = document.getElementById('nombre');
    const apellido = document.getElementById('apellido');
    const email = document.getElementById('email');
    const password = document.getElementById('password');
    const repeat_password = document.getElementById('repeat-password');

    if (!validateInput(nombre, 3)) {
        handleError("Ingresa un nombre válido para continuar.");
        return false;
    }

    if (!validateInput(apellido, 3)) {
        handleError("Ingresa un apellido válido para continuar.");
        return false;

    }
    if (!validateInput(email, 1)) {
        handleError("Ingresa un correo para continuar.");
        return false;
    }

    if (!validateEmail(email)) {
        handleError("Ingresa un correo válido para continuar.");
        return false;
    }

    if (!validateInput(password, 6)) {
        handleError("Ingresa una contraseña de al menos 6 caracteres y máximo 100 para continuar.");
        return false;
    }

    if (!validateInput(repeat_password, 6)) {
        handleError("Ingresa una contraseña de al menos 6 caracteres y máximo 100 para continuar.");
        return false;
    }

    if (password.value.trim() != repeat_password.value.trim()) {
        handleError("Las contraseñas no coinciden.");
        return false;
    }

    document.querySelector("#signup-form").submit();

};