﻿$(document).ready(function () {
    var formulario = $("#Formulario");
    //jQuery.validator.setDefaults({
    //    debug: true,
    //    success: "valid"
    //});
    $(formulario).validate({
        rules: {
            ctl00$MainContent$txtEmail: {
                required: true,
                email: true,
                minlength: 10,
                maxlength: 100
            },
            ctl00$MainContent$txtConfirmarEmail: {
                required: true,
                email: true,
                minlength: 10,
                maxlength: 100,
                equalTo: "#MainContent_txtEmail"
            },
            ctl00$MainContent$txtPassword: {
                required: true,
                minlength: 6
            },
            ctl00$MainContent$txtConfirmarPassword: {
                required: true,
                minlength: 6,
                equalTo: "#MainContent_txtPassword"
            },
            ctl00$MainContent$txtNombre: {
                required: true,
                minlength: 2,
                maxlength: 100,
            },
            ctl00$MainContent$txtApellidos: {
                required: true,
                minlength: 2,
                maxlength: 100,
            },
            ctl00$MainContent$txtRUC: {
                required: true,
                integer: true,
                minlength: 10,
                maxlength: 11,
            }
        },
        messages: {
            ctl00$MainContent$txtEmail: {
                required: "Este campo es obligatorio",
                email: "Ingrese un correo electrónico, valido.",
                minlength: "El número mínimo de carácteres es 10",
                maxlength: "El número máximo de carácteres es 100"
            },
            ctl00$MainContent$txtConfirmarEmail: {
                required: "Este campo es obligatorio",
                email: "Ingrese un correo electrónico, valido.",
                minlength: "El número mínimo de carácteres es 10",
                maxlength: "El número máximo de carácteres es 100",
                equalTo: "Este correo electrónico no coincide con el anterior"
            },
            ctl00$MainContent$txtPassword: {
                required: "Este campo es obligatorio",
                minlength: "El número mínimo de carácteres es 6"
            },
            ctl00$MainContent$txtConfirmarPassword: {
                required: "Este campo es obligatorio",
                minlength: "El número mínimo de carácteres es 6",
                equalTo: "Esta contraseña no coincide con la anterior"
            },
            ctl00$MainContent$txtNombre: {
                required: "Este campo es obligatorio",
                minlength: "El número mínimo de carácteres es 2",
                maxlength: "El número máximo de carácteres es 50"
            },
            ctl00$MainContent$txtApellidos: {
                required: "Este campo es obligatorio",
                minlength: "El número mínimo de carácteres es 2",
                maxlength: "El número máximo de carácteres es 50"
            },
            ctl00$MainContent$txtRUC: {
                required: "Este campo es obligatorio",
                integer: "Sólo se admiten números enteros",
                minlength: "El número mínimo de carácteres es 10",
                maxlength: "El número máximo de carácteres es 11"
            }
        },
        errorElement: "em",
        errorPlacement: function (error, element) {
            error.addClass("text-muted text-danger");
            if (element.prop("type") === "checkbox") {
                error.insertAfter(element.parent("label"));
            } else {
                error.insertAfter(element);
            }
        },
        highlight: function (element, errorClass, validClass) {
            $(element).parents("input").addClass("text-danger").removeClass("text-sucess");
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).parents("input").addClass("text-sucess").removeClass("text-danger");
        }
    });
});