document.addEventListener('DOMContentLoaded', function () {
	carregarDadosTabelaBancos();
});


function getLocation() {

    var spanLoc = document.getElementById("spanLoc");

    if (!('geolocation' in navigator)) {
        alert("Navegador não tem suporte API Geolocation");
    }

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition, showError);
    }
    else { spanLoc.innerHTML = "Geolocalização não é suportada nesse browser."; }
}


async function carregarDadosTabelaBancos() {

    //const dto = {
    //    Skip: 0,
    //    Take: 10
    //};

    //const config = {
    //    method: 'POST',
    //    headers: {
    //        'Accept': 'application/json',
    //        'Content-Type': 'application/json',
    //    },
    //    body: JSON.stringify(dto)
    //}
    //const response = await fetch("Professional/ProfessionalProfilePaginated", config);
    //const data = await response.json();

 //   data.professionalProfile.map(dado => {
 //       let tr = '';
 //       tr += `
 //          <div class="col-xl-3 col-lg-6 col-md-6 col-sm-6">
	//									<!--begin::Card-->
	//									<div class="card card-custom gutter-b card-stretch">
	//										<!--begin::Body-->
	//										<div class="card-body pt-4">
	//											<!--begin::Toolbar-->
	//											<div class="d-flex justify-content-end">
	//												<div class="dropdown dropdown-inline" data-toggle="tooltip" title="Quick actions" data-placement="left">
	//													<a href="#" class="btn btn-clean btn-hover-light-primary btn-sm btn-icon" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
	//														<i class="ki ki-bold-more-hor"></i>
	//													</a>
	//													<div class="dropdown-menu dropdown-menu-md dropdown-menu-right">
	//														<!--begin::Navigation-->
	//														<ul class="navi navi-hover">
	//															<li class="navi-header font-weight-bold py-4">
	//																<span class="font-size-lg">Choose Label:</span>
	//																<i class="flaticon2-information icon-md text-muted" data-toggle="tooltip" data-placement="right" title="Click to learn more..."></i>
	//															</li>
	//															<li class="navi-separator mb-3 opacity-70"></li>
	//															<li class="navi-item">
	//																<a href="#" class="navi-link">
	//																	<span class="navi-text">
	//																		<span class="label label-xl label-inline label-light-success">Customer</span>
	//																	</span>
	//																</a>
	//															</li>
	//															<li class="navi-item">
	//																<a href="#" class="navi-link">
	//																	<span class="navi-text">
	//																		<span class="label label-xl label-inline label-light-danger">Partner</span>
	//																	</span>
	//																</a>
	//															</li>
	//															<li class="navi-item">
	//																<a href="#" class="navi-link">
	//																	<span class="navi-text">
	//																		<span class="label label-xl label-inline label-light-warning">Suplier</span>
	//																	</span>
	//																</a>
	//															</li>
	//															<li class="navi-item">
	//																<a href="#" class="navi-link">
	//																	<span class="navi-text">
	//																		<span class="label label-xl label-inline label-light-primary">Member</span>
	//																	</span>
	//																</a>
	//															</li>
	//															<li class="navi-item">
	//																<a href="#" class="navi-link">
	//																	<span class="navi-text">
	//																		<span class="label label-xl label-inline label-light-dark">Staff</span>
	//																	</span>
	//																</a>
	//															</li>
	//															<li class="navi-separator mt-3 opacity-70"></li>
	//															<li class="navi-footer py-4">
	//																<a class="btn btn-clean font-weight-bold btn-sm" href="#">
	//																<i class="ki ki-plus icon-sm"></i>Add new</a>
	//															</li>
	//														</ul>
	//														<!--end::Navigation-->
	//													</div>
	//												</div>
	//											</div>
	//											<!--end::Toolbar-->
	//											<!--begin::User-->
	//											<div class="d-flex align-items-end mb-7">
	//												<!--begin::Pic-->
	//												<div class="d-flex align-items-center">
	//													<!--begin::Pic-->
	//													<div class="flex-shrink-0 mr-4 mt-lg-0 mt-3">
	//														<div class="symbol symbol-circle symbol-lg-75">
	//															<img src="assets/media/users/300_1.jpg" alt="image" />
	//														</div>
	//														<div class="symbol symbol-lg-75 symbol-circle symbol-primary d-none">
	//															<span class="font-size-h3 font-weight-boldest">JM</span>
	//														</div>
	//													</div>
	//													<!--end::Pic-->
	//													<!--begin::Title-->
	//													<div class="d-flex flex-column">
	//														<a href="#" class="text-dark font-weight-bold text-hover-primary font-size-h4 mb-0">Luca Doncic</a>
	//														<span class="text-muted font-weight-bold">Head of Development</span>
	//													</div>
	//													<!--end::Title-->
	//												</div>
	//												<!--end::Title-->
	//											</div>
	//											<!--end::User-->
	//											<!--begin::Desc-->
	//											<p class="mb-7">I distinguish three
	//											<a href="#" class="text-primary pr-1">#XRS-54PQ</a>objectives First objectives and nice cooked rice</p>
	//											<!--end::Desc-->
	//											<!--begin::Info-->
	//											<div class="mb-7">
	//												<div class="d-flex justify-content-between align-items-center">
	//													<span class="text-dark-75 font-weight-bolder mr-2">Email:</span>
	//													<a href="#" class="text-muted text-hover-primary">luca@festudios.com</a>
	//												</div>
	//												<div class="d-flex justify-content-between align-items-cente my-1">
	//													<span class="text-dark-75 font-weight-bolder mr-2">Phone:</span>
	//													<a href="#" class="text-muted text-hover-primary">44(76)34254578</a>
	//												</div>
	//												<div class="d-flex justify-content-between align-items-center">
	//													<span class="text-dark-75 font-weight-bolder mr-2">Location:</span>
	//													<span class="text-muted font-weight-bold">Barcelona</span>
	//												</div>
	//											</div>
	//											<!--end::Info-->
	//											<a href="#" class="btn btn-block btn-sm btn-light-warning font-weight-bolder text-uppercase py-4">write message</a>
	//										</div>
	//										<!--end::Body-->
	//									</div>
	//									<!--end::Card-->
	//								</div>`;

 //       jQuery('#listProfessional').append(tr);
	//});

}

function showPosition(position) {
    var spanLoc = document.getElementById("spanLoc");
    Address(position.coords.latitude, position.coords.longitude);

    //spanLoc.innerHTML = "Latitude: " + position.coords.latitude +
    //    "<br>Longitude: " + position.coords.longitude;
}

async function Address(lat, long) {
    const response = await fetch('https://nominatim.openstreetmap.org/reverse?format=json&lat=' + lat + '&lon=' + long);
    const data = await response.json();

    document.getElementById("CepCity").value = data.address.city_district;
}

function showError(error) {
    var spanLoc = document.getElementById("spanLoc");

    switch (error.code) {
        case error.PERMISSION_DENIED:
            spanLoc.innerHTML = "Usuário rejeitou a solicitação de Geolocalização."
            break;
        case error.POSITION_UNAVAILABLE:
            spanLoc.innerHTML = "Localização indisponível."
            break;
        case error.TIMEOUT:
            spanLoc.innerHTML = "O tempo da requisição expirou."
            break;
        case error.UNKNOWN_ERROR:
            spanLoc.innerHTML = "Algum erro desconhecido aconteceu."
            break;
    }
}

function limpa_formulário_cep() {
    //Limpa valores do formulário de cep.
    document.getElementById('CepCity').value = ("");
}

function meu_callback(conteudo) {
    if (!("erro" in conteudo)) {
        //Atualiza os campos com os valores.
        document.getElementById('CepCity').value = (conteudo.localidade);
    } //end if.
}

function pesquisacep(valor) {

    //Nova variável "cep" somente com dígitos.
    var cep = valor.replace(/\D/g, '');

    //Expressão regular para validar o CEP.
    var validacep = /^[0-9]{8}$/;

    //Valida o formato do CEP.
    if (validacep.test(cep)) {
        //Cria um elemento javascript.
        var script = document.createElement('script');

        //Sincroniza com o callback.
        script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=meu_callback';

        //Insere script no documento e carrega o conteúdo.
        document.body.appendChild(script);

    } //end if.

};
