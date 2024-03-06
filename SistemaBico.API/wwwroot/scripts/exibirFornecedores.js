$(document).ready(function () {
    abrirLoader();
    let nomeTabela = 'FornecedoresCadastrados';
    dataTable(nomeTabela);

    fecharLoader();
});

function Alterar(fornecedorId) {
    // Redireciona para a página de edição com o ID do produto
    window.location.href = `/Fornecedores/editar-fornecedor/${fornecedorId}`;
}
