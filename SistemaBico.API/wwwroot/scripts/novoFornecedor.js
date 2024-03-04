$(document).ready(function () {
    // Ao enviar o formulário

    $('#Telefone').inputmask('(99) 999999999');

    $('#kt_ecommerce_add_product_form').submit(function (event) {
        // Resetar mensagens de erro
        $('.error-message').remove();

        // Validar campos obrigatórios
        var isValid = true;

        // Validar Nome
        if ($('#Nome').val().trim() === '') {
            $('#Nome').after('<div class="text-danger error-message">Campo obrigatório.</div>');
            isValid = false;
        }

        // Validar Tipo
        if ($('#Telefone').val().trim() === '') {
            $('#Telefone').after('<div class="text-danger error-message">Campo obrigatório.</div>');
            isValid = false;
        }

        // Se algum campo obrigatório não for preenchido, impedir o envio do formulário
        if (!isValid) {
            event.preventDefault();
        }
    });
});