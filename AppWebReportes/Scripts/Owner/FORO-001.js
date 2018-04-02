$(document).ready(function () {
    var formulario = $("#Formulario");
    $(formulario).validate({
        rules: {
            ctl00$MainContent$txtTitulo: {
                required: true,
                minlength: 15,
                maxlength: 200
            },
            ctl00$MainContent$txtDescripcion: {
                required: false,
                minlength: 20
            },
            ctl00$MainContent$txtCodigo: {
                required: false,
                minlength: 3,
                maxlength: 50
            }
        },
        messages: {
            ctl00$MainContent$txtTitulo: {
                required: "Este campo es obligatorio",
                minlength: "El número mínimo de carácteres es 15",
                maxlength: "El número máximo de carácteres es 200"
            },
            ctl00$MainContent$txtDescripcion: {
                required: "Este campo es obligatorio",
                minlength: "El número mínimo de carácteres es 20"
            },
            ctl00$MainContent$txtCodigo: {
                required: "Este campo es obligatorio",
                minlength: "El número mínimo de carácteres es  3",
                maxlength: "El número máximo de carácteres es 50"
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