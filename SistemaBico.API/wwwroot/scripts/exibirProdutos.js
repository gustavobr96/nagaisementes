document.addEventListener('DOMContentLoaded', function () {
    abrirLoader();

    $('#txtQuantidadeVenda').inputmask({
        alias: 'numeric',
        autoGroup: true,
        groupSeparator: '.',
        radixPoint: '.',
        digits: 3,
        digitsOptional: true,
        numericInput: true,
        rightAlign: false
    });

    $('#txtValor').inputmask({
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


    $('#ProdutosCadastrados').DataTable(); // Certifique-se de chamar o DataTable() aqui se não estiver sendo chamado

    let nomeTabela = 'ProdutosCadastrados';


    dataTable(nomeTabela);

    $(".table-row").each(function () {
        if ($(this).hasClass("table-disabled-row")) {
            $(this).css("opacity", "0.5"); // Altere o valor conforme necessário
        }
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

    var txtQuantidadeVenda;

    // Adiciona um event listener para o evento focus no campo txtQuantidadeVenda
    document.getElementById('txtQuantidadeVenda').addEventListener('blur', function () {
        // Obter os valores dos campos como números
        var quantidadeVenda = this.value.replace(",", ".");
        var quantidadeTotal = txtQuantidade.value.replace(",", ".");

        var quantidadeVendaFormatada = parseFloat(quantidadeVenda.replace(/\./g, '').replace(',', '.'));
        var quantidadeTotalFormatada = parseFloat(quantidadeTotal.replace(/\./g, '').replace(',', '.'));

        //var quantidadeVenda = parseDecimal(nm);
        //var quantidadeTotal = parseDecimal(txtQuantidade.value);

        // Verificar as condições
        var habilitarCampoValor = quantidadeVendaFormatada > 0 && quantidadeVendaFormatada <= quantidadeTotalFormatada;

        // Habilitar ou desabilitar o campo txtValor
        txtValor.disabled = !habilitarCampoValor;

        // Exibir ou ocultar a mensagem de motivo
        var mensagemMotivo = document.getElementById('mensagemMotivo');
        if (!habilitarCampoValor) {
            document.getElementById('txtValor').value = "";
            document.getElementById('txtValorTotal').value = "";
            // Se o campo estiver desabilitado, exibe a mensagem
            mensagemMotivo.innerText = 'A quantidade de venda não é válida, informe pelo menos um número maior que 0, e a quantidade deve ser menor que sua quantidade de pontos disponíveis.';
        } else {
            // Se o campo estiver habilitado, oculta a mensagem
            mensagemMotivo.innerText = '';
        }

        // Executar ação desejada, por exemplo, exibir algo no console
        console.log('Ação executada ao tirar o foco do campo txtQuantidadeVenda!');
    });

    document.getElementById('txtValor').addEventListener('blur', function () {
        // Obter os valores dos campos como números
        var txtQuantidadeVenda = document.getElementById('txtQuantidadeVenda').value.replace(",", ".");
        var txtValorUnitario = document.getElementById('txtValor').value;

        var valorNumerico = parseFloat(txtValorUnitario.replace(/\./g, '').replace(',', '.'));
        var multiplicadorNumerico = parseFloat(txtQuantidadeVenda.replace(/\./g, '').replace(',', '.'));


        if (valorNumerico > 0 && multiplicadorNumerico > 0) {
            var valorTotal = multiplicadorNumerico * valorNumerico;
            document.getElementById('txtValorTotal').value = valorTotal
        }
       
    });

    fecharLoader();
});

function parseDecimal(inputValue) {
    // Remover todos os caracteres não numéricos, exceto ponto e vírgula
    var numericString = inputValue.replace(/[^0-9.,]/g, '');

    // Substituir vírgulas por pontos para garantir que a conversão para número funcione corretamente
    numericString = numericString.replace(',', '.');

    // Remover múltiplos pontos, mantendo apenas o último
    numericString = numericString.replace(/\.(?=.*\.)/g, '');

    // Converter para decimal
    return parseFloat(numericString) || 0;
}

function Alterar(produtoId) {
    // Redireciona para a página de edição com o ID do produto
    window.location.href = `/Produtos/editar-produto/${produtoId}`;
}
function AtivarDesativar(id) {

    jQuery('#modalConfirmarDesativacao').modal({
        backdrop: 'static',
        keyboard: false
    }).one('click', '#delete_registro', async function (e) {

        const config = {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(id)
        }
        const response = await fetch("ativarDesativar", config)
        const data = await response.json();

        if (data.success) {
            jQuery('#modalConfirmarDesativacao').modal('hide');
            toastr['success'](MSG_EXCLUIDO, TITULO_TOASTR_SUCESSO);
            location.reload();
        } else {
            toastr['error'](MSG_ERRO_EXCLUIR, TITULO_TOASTR_ERRO);
        }

    });
}


async function Venda(id) {

    const response = await fetch('../Produtos/obter-produto/' + id);
    const data = await response.json();

    document.getElementById('txtNome').value = data.nome;
    var numeroConvertido = formatarNumero(data.quantidadeString);
    numeroConvertido = numeroConvertido.replace(",", ".");


    document.getElementById('txtQuantidade').value = numeroConvertido;
    

    document.getElementById('txtObservacao').value = data.observacao;

    jQuery('#modalNovaVenda').modal({
        backdrop: 'static',
        keyboard: false
    });

}

function formatarNumero(numero) {
    // Converte o número para string e substitui vírgula por ponto
    var numeroFormatado = numero.toString().replace(",", ".");

    // Formata o número com separador de milhares
    return parseFloat(numeroFormatado).toLocaleString('pt-BR', { minimumFractionDigits: 3, maximumFractionDigits: 3 });
}
