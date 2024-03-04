$(document).ready(function () {


    let nomeTabela = 'ProdutosCadastrados';
    dataTable(nomeTabela);
});

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
        const response = await fetch("Produtos/ativarDesativar", config)
        const data = await response.json();

        if (data == "true") {
            jQuery('#modalConfirmarExclusao').modal('hide');
            toastr['success'](MSG_EXCLUIDO, TITULO_TOASTR_SUCESSO);
            location.reload();
        } else {
            toastr['error'](MSG_ERRO_EXCLUIR, TITULO_TOASTR_ERRO);
        }

    });
}
