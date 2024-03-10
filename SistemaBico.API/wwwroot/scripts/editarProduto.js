$(document).ready(function () {
    abrirLoader();


    $('#ValorUnitarioCompra').inputmask({
        alias: 'numeric',
        autoGroup: true,
        groupSeparator: '.',
        radixPoint: ',',  // Use ponto como separador decimal
        digits: 2,        // Define a quantidade de casas decimais
        digitsOptional: false,
        placeholder: '0',
        numericInput: true,
        rightAlign: false
    });

    $('#Quantidade').inputmask({
        alias: 'numeric',
        autoGroup: true,
        groupSeparator: ',',
        radixPoint: ',',  // Use ponto como separador decimal
        digits: 3,
        digitsOptional: true,
        placeholder: '000,000',
        numericInput: true,
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

    $('#txtValorTotal').inputmask({
        alias: 'numeric',
        autoGroup: true,
        groupSeparator: ',',
        radixPoint: '.',  // Use ponto como separador decimal
        digits: 2,        // Define a quantidade de casas decimais
        digitsOptional: false,
        placeholder: '0',
        numericInput: true,
        rightAlign: false
    });


    document.getElementById('Quantidade').addEventListener('blur', function () {
        // Obter os valores dos campos como números
        var quantidadeCompra = document.getElementById('Quantidade').value.replace(",", ".");

        var QuantidadeFormatada = parseFloat(quantidadeCompra.replace(/\./g, '').replace(',', '.'));

        // Verificar as condições
        var habilitarCampoValor = QuantidadeFormatada > 0;

        // Habilitar ou desabilitar o campo txtValor
        ValorUnitarioCompra.disabled = !habilitarCampoValor;

        // Exibir ou ocultar a mensagem de motivo
        var mensagemMotivo = document.getElementById('mensagemMotivo');
        if (!habilitarCampoValor) {
            document.getElementById('ValorUnitarioCompra').value = "";
            document.getElementById('txtValorTotal').value = "";
            // Se o campo estiver desabilitado, exibe a mensagem
            mensagemMotivo.innerText = 'A quantidade deve ser maior que 0.';
        } else {
            // Se o campo estiver habilitado, oculta a mensagem
            mensagemMotivo.innerText = '';
            CalcularTotal();
        }

        // Executar ação desejada, por exemplo, exibir algo no console
        console.log('Ação executada ao tirar o foco do campo txtQuantidadeVenda!');
    });

    document.getElementById('ValorUnitarioCompra').addEventListener('blur', function () {
        // Obter os valores dos campos como números
        CalcularTotal();
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

        if ($('#MenuId').val() === "") {
            $('#MenuId').after('<div class="text-danger error-message">Selecione um menu.</div>');
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

  
    CalcularTotal();
    fecharLoader();

});

function CalcularTotal() {
    // Redireciona para a página de edição com o ID do produto
    var txtQuantidadeCompra = document.getElementById('Quantidade').value.replace(",", ".");
    var txtValorUnitario = document.getElementById('ValorUnitarioCompra').value;

    if (txtValorUnitario != "" && txtQuantidadeCompra != "") {
        var valorNumerico = parseFloat(txtValorUnitario.replace(/\./g, '').replace(',', '.'));
        var multiplicadorNumerico = parseFloat(txtQuantidadeCompra.replace(/\./g, '').replace(',', '.'));


        if (valorNumerico > 0 && multiplicadorNumerico > 0) {
            var valorTotal = multiplicadorNumerico * valorNumerico;
            document.getElementById('txtValorTotal').value = valorTotal
        }
        else {
            document.getElementById('txtValorTotal').value = "";
        }
    } else {
        document.getElementById('txtValorTotal').value = "";
    }
   
}

document.getElementById('File').addEventListener('change', function () {
    var previewImage = document.getElementById('previewImage');
    var fileInput = this;
    var fileName = fileInput.value.split('\\').pop(); // Extraindo apenas o nome do arquivo

    if (fileInput.files && fileInput.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            previewImage.src = e.target.result;
            previewImage.style.display = 'block';
        };

        reader.readAsDataURL(fileInput.files[0]);

        // Atualizando o texto do label do arquivo
        var customFileLabel = document.querySelector('.custom-file-label');
        customFileLabel.innerText = fileName;
    } else {
        previewImage.style.display = 'none';
    }
});
