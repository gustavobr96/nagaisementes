﻿$(document).ready(function () {
    // Ao enviar o formulário
    abrirLoader();

    $('#RegistrarMenus').submit(function (event) {
        // Resetar mensagens de erro
        $('.error-message').remove();

        // Validar campos obrigatórios
        var isValid = true;

        // Validar Nome
        if ($('#Nome').val().trim() === '') {
            $('#Nome').after('<div class="text-danger error-message">Campo obrigatório.</div>');
            isValid = false;
        }

        // Se algum campo obrigatório não for preenchido, impedir o envio do formulário
        if (!isValid) {
            event.preventDefault();
        }
    });

    fecharLoader();
});