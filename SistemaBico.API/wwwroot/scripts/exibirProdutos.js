$(document).ready(function () {
    abrirLoader();
    $('#ProdutosCadastrados').DataTable(); // Certifique-se de chamar o DataTable() aqui se não estiver sendo chamado


    let nomeTabela = 'ProdutosCadastrados';


    dataTable(nomeTabela);

    $(".table-row").each(function () {
        if ($(this).hasClass("table-disabled-row")) {
            $(this).css("opacity", "0.5"); // Altere o valor conforme necessário
        }
    });

    fecharLoader();
});

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
