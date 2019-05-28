var tbory = document.querySelector('table tbody');
var aluno = {};
function Cadastrar() {
    aluno.nome = document.querySelector('#nome').value;
    aluno.sobrenome = document.querySelector('#sobrenome').value;
    aluno.telefone = document.querySelector('#telefone').value;
    aluno.ra = document.querySelector('#ra').value;

    if (aluno.id === undefined || aluno.id === 0) {
        salvarEstudantes('POST', 0, aluno);
    } else {
        salvarEstudantes('PUT', aluno.id, aluno);
    }

    carregarEstudantes();
    $('#exampleModal').modal('hide');
}

function carregarEstudantes() {
    tbory.innerHTML = '';
    var xhr = new XMLHttpRequest();
    console.log('UNSENT', xhr.readyState);

    xhr.open(`GET`, `http://localhost:50886/api/aluno/`, true);
    console.log('OPENED', xhr.readyState);

    xhr.onprogress = function () {
        console.log('LOADING', xhr.readyState);
    };

    xhr.onerror = function () {
        console.log('ERRO', xhr.readyState);
    };


    xhr.onreadystatechange = function () {
        if (this.readyState == 4) {
            if (this.status == 200) {
                var estudantes = JSON.parse(this.responseText);
                console.log('DONE', xhr.readyState);
                for (var indice in estudantes) {
                    adicionaLinha(estudantes[indice]);
                }
            }
            else if(this.status == 500){
                var error = JSON.parse(this.responseText);
                console.log(error);
                console.log(error.Message);
                console.log(error.ExceptionMessage);
            }
        }
        else {
            console.log('');
        }

    }
    xhr.send();
}

function salvarEstudantes(metodo, id, corpo) {
    var xhr = new XMLHttpRequest();
    if (id === undefined || id === 0)
        id = '';
    xhr.open(metodo, `http://localhost:50886/api/aluno/${id}`, false);
    xhr.setRequestHeader('content-type', 'application/json');
    xhr.send(JSON.stringify(corpo));


}
carregarEstudantes();

function adicionaLinha(estudante) {

    var trow = ` <tr>
                                <td>${estudante.nome}</td>
                                <td>${estudante.sobrenome}</td>
                                <td>${estudante.telefone}</td>
                                <td>${estudante.ra}</td>
                                    <td>
                                        <button class="btn btn-info"  data-toggle="modal" data-target="#exampleModal" onclick='editarEstudante(${JSON.stringify(estudante)})'> Editar</button>
                                        <button  class="btn btn-danger"  onclick='excluir(${JSON.stringify(estudante)})'> Deletar</button>
                                    </td>
                              </tr>
                             `;
    tbory.innerHTML += trow;
}

function editarEstudante(estudante) {
    var btnSalvar = document.querySelector('#btnSalvar');
    var tituloModal = document.querySelector('#tituloModal');

    document.querySelector('#nome').value = estudante.nome;
    document.querySelector('#sobrenome').value = estudante.sobrenome;
    document.querySelector('#telefone').value = estudante.telefone;
    document.querySelector('#ra').value = estudante.ra;

    btnSalvar.textContent = 'Salvar';
    tituloModal.textContent = `Editar Aluno ${estudante.nome}`;
    aluno = estudante;
    console.log(aluno);
}

function deletarEstudante(id) {
    var xhr = new XMLHttpRequest();
    xhr.open(`DELETE`, `http://localhost:50886/api/aluno/${id}`, false);
    xhr.send();

}
function excluir(estudante) {
    bootbox.confirm({
        message: `Tem certeza que deseja excluir excluir o estudante ${estudante.nome}`,
        buttons: {
            confirm: {
                label: 'Sim',
                className: 'btn-success'
            },
            cancel: {
                label: 'Não',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result) {
                deletarEstudante(estudante.id);
                carregarEstudantes();
            }

        }
    });




}
function Cancelar() {
    var btnSalvar = document.querySelector('#btnSalvar');
    var tituloModal = document.querySelector('#tituloModal');

    document.querySelector('#nome').value = '';
    document.querySelector('#sobrenome').value = '';
    document.querySelector('#telefone').value = '';
    document.querySelector('#ra').value = '';
    aluno = {};
    tituloModal.textContent = 'Cadastrar Aluno';
    btnSalvar.textContent = 'Cadastrar';

    $('#exampleModal').modal('hide');
}
function NovoAluno() {
    var btnSalvar = document.querySelector('#btnSalvar');
    var tituloModal = document.querySelector('#tituloModal');

    document.querySelector('#nome').value = '';
    document.querySelector('#sobrenome').value = '';
    document.querySelector('#telefone').value = '';
    document.querySelector('#ra').value = '';
    aluno = {};
    tituloModal.textContent = 'Cadastrar Aluno';
    btnSalvar.textContent = 'Cadastrar';

    $('#exampleModal').modal('show');
}