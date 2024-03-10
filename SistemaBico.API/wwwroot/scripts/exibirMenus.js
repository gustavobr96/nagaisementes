$(document).ready(function () {
    abrirLoader();
    let nomeTabela = 'MenusCadastrados';
    dataTable(nomeTabela);

    fecharLoader();
});

function Alterar(menuId) {
    // Redireciona para a página de edição com o ID do produto
    window.location.href = `/Menus/editar-menu/${menuId}`;
}
