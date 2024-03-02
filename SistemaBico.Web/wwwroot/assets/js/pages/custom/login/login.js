document.addEventListener('DOMContentLoaded', function () {
    KTLoginGeneral.init();
    FormValidation.formValidation(
        document.getElementById('form_login_signup'),
        {
            fields: {
                Name: {
                    validators: {
                        notEmpty: {
                            message: 'Por favor, preencha o nome.'
                        },
                        stringLength: {
                            min: 3,
                            max: 70,
                            message: 'Insira seu nome [3 ate 70 letras].'
                        }
                    }
                },
                LastName: {
                    validators: {
                        notEmpty: {
                            message: 'Por favor, preencha o sobrenome.',
                        },
                        stringLength: {
                            min: 3,
                            max: 70,
                            message: 'Insira seu sobrenome [3 ate 70 letras].'
                        }
                    }
                },
                email: {
                    validators: {
                        notEmpty: {
                            message: 'Por favor, preencha o email.'
                        },
                        emailAddress: {
                            message: 'Preencha seu email correatamente.'
                        }
                    }
                },
                CpfCnpj: {
                    validators: {
                        notEmpty: {
                            message: 'Por favor, preencha o CPF.',
                        },
                        stringLength: {
                            min: 14,
                            max: 15,
                            message: 'Preencha corretamente seu CPF'
                        }
                    }
                },
                PhoneNumber: {
                    validators: {
                        notEmpty: {
                            message: 'Por favor, preencha o telefone para contato.',
                        },
                        stringLength: {
                            min: 14,
                            max: 14,
                            message: 'Preencha corretamente o telefone no formato correto.'
                        }
                    }
                },
                Password: {
                    validators: {
                        notEmpty: {
                            message: 'Por favor, preencha a senha.',
                        },
                        stringLength: {
                            min: 6,
                            max: 10,
                            message: 'Insira sua senha corretamente [6 ate 10 letras].'
                        }
                    }
                },
                RPassword: {
                    validators: {
                        notEmpty: {
                            message: 'Por favor, preencha a senha.',
                        },
                        stringLength: {
                            min: 6,
                            max: 10,
                            message: 'Insira sua senha corretamente [6 ate 10 letras].'
                        }
                    }
                },
                agree: {
                    validators: {
                        notEmpty: {
                            message: 'Por favor, aceite os termos.'
                        }
                    }
                },
            },

            plugins: {
                trigger: new FormValidation.plugins.Trigger(),
                submitButton: new FormValidation.plugins.SubmitButton(),
                defaultSubmit: new FormValidation.plugins.DefaultSubmit(),
                bootstrap: new FormValidation.plugins.Bootstrap({
                    eleInvalidClass: '',
                    eleValidClass: '',
                })
            }
        }
    );
});


const handlePhone = (event) => {
    let input = event.target
    input.value = phoneMask(input.value)
}


const phoneMask = (value) => {
    if (!value) return ""
    value = value.replace(/\D/g, '')
    value = value.replace(/(\d{2})(\d)/, "($1)$2")
    value = value.replace(/(\d)(\d{4})$/, "$1-$2")
    return value
}

function ValidaCPF() {
    var RegraValida = document.getElementById("CpfCnpj").value;
    var cpfValido = /^(([0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2})|([0-9]{11}))$/;
    if (cpfValido.test(RegraValida) == true) {
        console.log("CPF V�lido");
    } else {
        console.log("CPF Inv�lido");
    }
}
function fMasc(objeto, mascara) {
    obj = objeto
    masc = mascara
    setTimeout("fMascEx()", 1)
}

function fMascEx() {
    obj.value = masc(obj.value)
}

function mCPF(cpf) {
    cpf = cpf.replace(/\D/g, "")
    cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2")
    cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2")
    cpf = cpf.replace(/(\d{3})(\d{1,2})$/, "$1-$2")
    return cpf
}



"use strict";

// Class Definition
var KTLoginGeneral = function () {

    var login = $('#kt_login');

    var showErrorMsg = function (form, type, msg) {
        var alert = $('<div class="mb-10 alert alert-custom alert-light-' + type + ' alert-dismissible" role="alert">\
			<div class="alert-text font-weight-bold ">'+ msg + '</div>\
			<div class="alert-close">\
                <i class="ki ki-remove" data-dismiss="alert"></i>\
            </div>\
		</div>');

        form.find('.alert').remove();
        alert.prependTo(form);
        //alert.animateClass('fadeIn animated');
        KTUtil.animateClass(alert[0], 'fadeIn animated');
        alert.find('span').html(msg);
    }

    // Private Functions
    var displaySignUpForm = function () {
        login.removeClass('login-forgot-on');
        login.removeClass('login-signin-on');

        login.addClass('login-signup-on');
        KTUtil.animateClass(login.find('.login-signup')[0], 'flipInX animated');
    }

    var displaySignInForm = function () {
        login.removeClass('login-forgot-on');
        login.removeClass('login-signup-on');

        login.addClass('login-signin-on');
        KTUtil.animateClass(login.find('.login-signin')[0], 'flipInX animated');
        //login.find('.login-signin').animateClass('flipInX animated');
    }

    var displayForgotForm = function () {
        login.removeClass('login-signin-on');
        login.removeClass('login-signup-on');

        login.addClass('login-forgot-on');
        //login.find('.login-forgot-on').animateClass('flipInX animated');
        KTUtil.animateClass(login.find('.login-forgot')[0], 'flipInX animated');

    }

    var handleFormSwitch = function () {
        $('#kt_login_forgot').click(function (e) {
            e.preventDefault();
            displayForgotForm();
        });

        $('#kt_login_forgot_cancel').click(function (e) {
            e.preventDefault();
            displaySignInForm();
        });

        $('#kt_login_signup').click(function (e) {
            e.preventDefault();
            displaySignUpForm();
        });

        $('#kt_login_signup_cancel').click(function (e) {
            e.preventDefault();
            displaySignInForm();
        });
    }



    //var handleSignInFormSubmit = function() {
    //    $('#kt_login_signin_submit').click(function(e) {
    //        e.preventDefault();
    //        var btn = $(this);
    //        var form = $(this).closest('form');

    //        form.validate({
    //            rules: {
    //                username: {
    //                    required: true,
    //                    email: true
    //                },
    //                password: {
    //                    required: true
    //                }
    //            }
    //        });

    //        if (!form.valid()) {
    //            return;
    //        }

    //        btn.addClass('spinner spinner-right pr-12 spinner-sm spinner-white').attr('disabled', true);

    //        form.ajaxSubmit({
    //            url: '',
    //            success: function(response, status, xhr, $form) {
    //            	// similate 2s delay
    //            	setTimeout(function() {
    //                 btn.removeClass('spinner spinner-right pr-12 spinner-sm spinner-white').attr('disabled', false);
    //                 showErrorMsg(form, 'danger', 'Incorrect username or password. Please try again.');
    //                }, 2000);
    //            }
    //        });
    //    });
    //}

    //var handleSignUpFormSubmit = function() {
    //    $('#kt_login_signup_submit').click(function(e) {
    //        e.preventDefault();

    //        var btn = $(this);
    //        var form = $(this).closest('form');

    //        form.validate({
    //            rules: {
    //                fullname: {
    //                    required: true
    //                },
    //                email: {
    //                    required: true,
    //                    email: true
    //                },
    //                password: {
    //                    required: true
    //                },
    //                rpassword: {
    //                    required: true
    //                },
    //                agree: {
    //                    required: true
    //                }
    //            }
    //        });

    //        if (!form.valid()) {
    //            return;
    //        }

    //        btn.addClass('spinner spinner-right pr-12 spinner-sm spinner-white').attr('disabled', true);

    //        form.ajaxSubmit({
    //            url: '',
    //            success: function(response, status, xhr, $form) {
    //            	// similate 2s delay
    //            	setTimeout(function() {
    //                 btn.removeClass('spinner spinner-right pr-12 spinner-sm spinner-white').attr('disabled', false);
    //                 form.clearForm();
    //                 form.validate().resetForm();

    //                 // display signup form
    //                 displaySignInForm();
    //                 var signInForm = login.find('.login-signin form');
    //                 signInForm.clearForm();
    //                 signInForm.validate().resetForm();

    //                 showErrorMsg(signInForm, 'success', 'Thank you. To complete your registration please check your email.');
    //             }, 2000);
    //            }
    //        });
    //    });
    //}

    //var handleForgotFormSubmit = function() {
    //    $('#kt_login_forgot_submit').click(function(e) {
    //        e.preventDefault();

    //        var btn = $(this);
    //        var form = $(this).closest('form');

    //        form.validate({
    //            rules: {
    //                email: {
    //                    required: true,
    //                    email: true
    //                },
    //                username: {
    //                    required: true,
    //                    email: true
    //                }
    //            }
    //        });

    //        if (!form.valid()) {
    //            return;
    //        }

    //        btn.addClass('spinner spinner-right pr-12 spinner-sm spinner-white').attr('disabled', true);

    //        form.ajaxSubmit({
    //            url: '',
    //            success: function(response, status, xhr, $form) {
    //            	// similate 2s delay
    //            	setTimeout(function() {
    //            		btn.removeClass('spinner spinner-right pr-12 spinner-sm spinner-white').attr('disabled', false); // remove
    //                 form.clearForm(); // clear form
    //                 form.validate().resetForm(); // reset validation states

    //                 // display signup form
    //                 displaySignInForm();
    //                 var signInForm = login.find('.login-signin form');
    //                 signInForm.clearForm();
    //                 signInForm.validate().resetForm();

    //                 showErrorMsg(signInForm, 'success', 'Cool! Password recovery instruction has been sent to your email.');
    //            	}, 2000);
    //            }
    //        });
    //    });
    //}

    // Public Functions
    return {
        // public functions
        init: function () {
            handleFormSwitch();
            //handleSignInFormSubmit();
            //handleSignUpFormSubmit();
            //handleForgotFormSubmit();
        }
    };
}();
