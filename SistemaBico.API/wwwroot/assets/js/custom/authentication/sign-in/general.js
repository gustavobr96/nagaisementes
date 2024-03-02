"use strict";

var KTSigninGeneral = function () {
    var form, submitButton, formValidation;

    return {
        init: function () {
            form = document.querySelector("#kt_sign_in_form");
            submitButton = document.querySelector("#kt_sign_in_submit");
            formValidation = FormValidation.formValidation(form, {
                fields: {
                    email: {
                        validators: {
                            notEmpty: {
                                message: "Email address is required"
                            },
                            emailAddress: {
                                message: "The value is not a valid email address"
                            }
                        }
                    },
                    password: {
                        validators: {
                            notEmpty: {
                                message: "The password is required"
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger,
                    bootstrap: new FormValidation.plugins.Bootstrap5({
                        rowSelector: ".fv-row"
                    })
                }
            });

            submitButton.addEventListener("click", function () {
                formValidation.validate().then(function (status) {
                    if (status === "Valid") {
                        // Adicionar um indicador de carregamento
                        submitButton.innerHTML = '<span class="spinner-border spinner-border-sm me-1"></span>Entrando...';

                        // Desativar o bot�o durante o envio
                        submitButton.setAttribute("disabled", true);

                        // Se a valida��o for bem-sucedida, envie o formul�rio manualmente
                        form.submit();
                    } else {
                        // Se houver erros, deixe o formul�rio seguir seu fluxo padr�o

                        // Remover o indicador de carregamento
                        submitButton.innerHTML = 'Entrar';

                        // Habilitar o bot�o
                        submitButton.removeAttribute("disabled");
                    }
                });
            });
        }
    };
}();

KTUtil.onDOMContentLoaded(function () {
    KTSigninGeneral.init();
});
