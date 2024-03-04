$(document).ready(function () {
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

        if ($('#FornecedorId').val() === '') {
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

