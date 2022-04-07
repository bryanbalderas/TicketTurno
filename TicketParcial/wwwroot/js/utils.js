
/**
 * @function
 * @param {any} input - Input that will be validated.
 * @param {number} minValue - Minimum length allowed.
 * @returns {boolean} - Returns a boolean depending the validation result.
 */
const validateInput = (input, minValue) => {
    const isValid = input.value.trim().length >= minValue;
    if (isValid) {
        input.classList.remove("input-error");
    }
    return isValid;
}
/**
 * @function
 * @param {any} input - Input that will be validated.
 * @param {number} minValue - Minimum length allowed.
 * @returns {boolean} - Returns a boolean depending the validation result.
 */
const validateSelect = (select) => {
    const isValid = select.options[select.selectedIndex].value >= 1;
    if (isValid) {
        select.classList.remove("input-error");
    }
    return isValid;
}
/**
 * @function
 * @param {any} input - Input that will be validated as a curp.
 * @returns {boolean} - Returns a boolean depending the validation result.
 */
const validateCurp = (input) => {

    if (input.value.trim().length != 18) {
        return false;
    };

    const regex = /^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$/;
    const regexResult = input.value.trim().match(regex);

    if (!regexResult) {
        return false;
    }

    input.classList.remove("input-error");
    return true;
}
/**
 * @function
 * @param {any} curp - Curp element where we will get the age.
 * @returns {number} - Returns years difference between date of birth and current year.
 */
const getAgeFromCurp = (curp) => {

    const formatedCurp = curp.value.trim().substring(4, 10);
    let yearCURP = parseInt(formatedCurp.substring(0, 2)) + 1900;
    const monthCURP = parseInt(formatedCurp.substring(2, 4)) - 1;
    const dayCURP = parseInt(formatedCurp.substring(4, 6));

    if (yearCURP < 1950) {
        yearCURP += 100;
    }

    const studentDate = new Date(yearCURP, monthCURP, dayCURP)
    const currentDate = Date.now();
    const differenceDates = Math.abs(currentDate - studentDate);
    const yearsDifference = parseInt(Math.ceil(differenceDates / (1000 * 60 * 60 * 24)) / 365);

    return yearsDifference;
}

/**
 * @function
 * @param {any} curp - Curp element where we will get the age.
 * @returns {boolean} - Returns a boolean depending the validation result.
 */
const validateAge = (curp) => {
    let isValid = false;
    const studentAge = getAgeFromCurp(curp);
    if (studentAge >= 3 && studentAge <= 15) {
        isValid = true;
    }
    return isValid;
}
/**
 * @function
 * @param {any} input - Input that will be validated as a curp.
 * @returns {boolean} - Returns a boolean depending the validation result.
 */
const validatePhoneNumber = (input) => {
    const isValid = input.value.match(/^[0-9]/) && (input.value.length === 10 || input.value.length === 12);
    if (isValid) {
        input.classList.remove("input-error");
    }
    return isValid;
}
/**
 * @function
 * @param {any} input - Input that will be validated as a curp.
 * @returns {boolean} - Returns a boolean depending the validation result.
 */
const validateEmail = (input) => {
    const isValid = input.value.match(/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/);
    if (isValid) {
        input.classList.remove("input-error");
    }
    return isValid;
}
/**
 * @function
 * @param {string} text - Modal's message.
 */
const handleError = (text) => {
    Swal.fire({
        icon: 'error',
        title: '¡Ha ocurrido un error!',
        text,
    });
}