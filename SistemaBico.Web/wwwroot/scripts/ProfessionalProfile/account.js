document.addEventListener('DOMContentLoaded', function () {
    SetSelectEspeciality();
    FormValidation.formValidation(
        document.getElementById('kt_form_update'),
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
                            message: 'Insira seu nome [3 até 70 letras].'
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
                            message: 'Insira seu sobrenome [3 até 70 letras].'
                        }
                    }
                },
                Phone: {
                    validators: {
                        notEmpty: {
                            message: 'Por favor, preencha o telefone para contato.',
                        },
                        stringLength: {
                            min: 14,
                            max: 14,
                            message: 'Insira seu número de telefone no formato correto.'
                        }
                    }
                },

                Especiality: {
                    validators: {
                        notEmpty: {
                            message: 'Selecione pelo menos uma especialidade.'
                        }
                    }
                }
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


async function SetSelectEspeciality() {
    const response = await fetch('professionalProfile/GetProfissionalEspeciality');
    const data = await response.json();

    data.especiality.forEach(e => $("#kt_select2_11").append(new Option(e, e, true, true)));
}

const phoneMask = (value) => {
    if (!value) return ""
    value = value.replace(/\D/g, '')
    value = value.replace(/(\d{2})(\d)/, "($1)$2")
    value = value.replace(/(\d)(\d{4})$/, "$1-$2")
    return value
}

