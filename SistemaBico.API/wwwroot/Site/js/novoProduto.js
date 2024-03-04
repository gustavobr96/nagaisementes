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

    carregarFornecedores();
});
function carregarFornecedores() {
    // Substitua a URL abaixo pela URL da sua API que retorna a lista de fornecedores
    var apiUrl = 'Fornecedores/ObterFornecedores';

    // Limpa o select antes de preenchê-lo novamente
    $('#FornecedorId').empty();

    // Adiciona a opção inicial
    $('#FornecedorId').append($('<option>', {
        value: '',
        text: 'Selecione Fornecedor',
        selected: true,
        disabled: true
    }));

    // Faz a requisição AJAX para obter a lista de fornecedores
    $.ajax({
        url: apiUrl,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            // Adiciona os options ao select
            $.each(data, function (index, fornecedor) {
                $('#FornecedorId').append($('<option>', {
                    value: fornecedor.id,
                    text: fornecedor.nome
                }));
            });
        },
        error: function (error) {
            console.error('Erro ao obter a lista de fornecedores:', error);
        }
    });
}