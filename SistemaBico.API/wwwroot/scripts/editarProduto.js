﻿$(document).ready(function () {
    var val = $('#Quantidade').val;
    $('#Quantidade').val(val);

    // Máscara para o campo de Quantidade
    $('#Quantidade').inputmask({
        alias: 'numeric',
        autoGroup: true,
        groupSeparator: ',',
        radixPoint: '.',  // Use ponto como separador decimal
        digits: 0,
        digitsOptional: false,
        placeholder: '0',
        rightAlign: false
    });

    $('#Pureza').inputmask({
        alias: 'numeric',
        autoGroup: true,
        groupSeparator: ',',
        radixPoint: ',',  // Use ponto como separador decimal
        digits: 2,
        digitsOptional: true,
        placeholder: '00,00',
        numericInput: true,
        rightAlign: false
    });

    $('#Tetrazolio').inputmask('numeric', {
        radixPoint: '.', // Ponto como separador decimal
        rightAlign: false, // Alinhar à esquerda
        allowMinus: false, // Não permitir números negativos
        autoGroup: true, // Agrupar automaticamente os números
        digits: 2, // Número máximo de dígitos após o ponto decimal
        groupSeparator: '', // Não usar separador de milhares
        groupSize: 3 // Tamanho do grupo
    });
    // Ao enviar o formulário
    $('#RegistrarProdutos').submit(function (event) {

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
        if ($('#Tipo').val().trim() === '') {
            $('#Tipo').after('<div class="text-danger error-message">Campo obrigatório.</div>');
            isValid = false;
        }

        if ($('#FornecedorId').val() === "") {
            $('#FornecedorId').after('<div class="text-danger error-message">Selecione um fornecedor.</div>');
            isValid = false;
        }

        // Validar Descrição
        if ($('#Descricao').val().trim() === '') {
            $('#Descricao').after('<div class="text-danger error-message">Campo obrigatório.</div>');
            isValid = false;
        }

        if ($('#Quantidade').val().trim() === '') {
            $('#Quantidade').after('<div class="text-danger error-message">Campo obrigatório.</div>');
            isValid = false;
        }

        // Validar Pureza
        if ($('#Pureza').val().trim() === '') {
            $('#Pureza').after('<div class="text-danger error-message">Campo obrigatório.</div>');
            isValid = false;
        }

        // Validar Tetrazólio
        if ($('#Tetrazolio').val().trim() === '') {
            $('#Tetrazolio').after('<div class="text-danger error-message">Campo obrigatório.</div>');
            isValid = false;
        }

        // Se algum campo obrigatório não for preenchido, impedir o envio do formulário
        if (!isValid) {
            event.preventDefault();
        }


    });

});



function formatarDuasCasasDecimais(valor) {
    return valor.toFixed(2);
}