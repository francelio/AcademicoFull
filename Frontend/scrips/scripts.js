    var tbory = document.querySelector('table tbody');
        var aluno= {};
        function Cadastrar(){
             aluno.nome=document.querySelector('#nome').value;
             aluno.sobrenome=document.querySelector('#sobrenome').value;
             aluno.telefone=document.querySelector('#telefone').value;
             aluno.ra= document.querySelector('#ra').value;
            
             if(aluno.id===undefined || aluno.id === 0){
                salvarEstudantes('POST',0,aluno);
             }else{
               salvarEstudantes('PUT',aluno.id,aluno);
             }
               
         carregarEstudantes();
        }

        function carregarEstudantes(){
            tbory.innerHTML='';
            var xhr= new XMLHttpRequest();
          
                xhr.open(`GET`,`http://localhost:50886/api/aluno/`,true);
                
                xhr.onload= function(){
                   var estudantes = JSON.parse(this.responseText);
                   for(var indice in estudantes){
                       adicionaLinha(estudantes[indice]);
                   }
                }
                    xhr.send();
        }

        function salvarEstudantes(metodo, id , corpo ){
             var xhr= new XMLHttpRequest();
            if(id===undefined || id === 0)
                id='';
                xhr.open(metodo,`http://localhost:50886/api/aluno/${id}`,false);
                 xhr.setRequestHeader('content-type','application/json');  
                xhr.send(JSON.stringify(corpo));
           
                  
        }
        carregarEstudantes(); 
    
        function adicionaLinha(estudante){
           
            var trow=` <tr>
                                <td>${estudante.nome}</td>
                                <td>${estudante.sobrenome}</td>
                                <td>${estudante.telefone}</td>
                                <td>${estudante.ra}</td>
                                    <td>
                                        <button class="btn btn-info" onclick='editarEstudante(${JSON.stringify(estudante)})'> Editar</button>
                                        <button  class="btn btn-danger" onclick='excluir(${estudante.id})'> Deletar</button>
                                    </td>
                              </tr>
                             `;
            tbory.innerHTML+= trow;
       }

       function editarEstudante(estudante){
           var btnSalvar = document.querySelector('#btnSalvar');
           var btnCancelar = document.querySelector('#btnCancelar');
           var titulo = document.querySelector('#titulo');
         
            document.querySelector('#nome').value = estudante.nome;
            document.querySelector('#sobrenome').value = estudante.sobrenome;
             document.querySelector('#telefone').value = estudante.telefone;
            document.querySelector('#ra').value = estudante.ra;

            btnSalvar.textContent='Salvar';
            btnCancelar.textContent='Cancelar';
            titulo.textContent=`Editar Aluno ${estudante.nome}`;
            aluno=estudante;
           console.log(aluno);
       }

       function deletarEstudante(id){
        var xhr= new XMLHttpRequest();
                xhr.open(metodo,`http://localhost:50886/api/aluno/${id}`,false);
                xhr.send();
           
       }
       function excluir(id){
            deletarEstudante(id);
            carregarEstudantes();
       }
       function Cancelar(){
            var btnSalvar = document.querySelector('#btnSalvar');
            var btnCancelar = document.querySelector('#btnCancelar');
            var titulo = document.querySelector('#titulo');
            document.querySelector('#nome').value = '';
            document.querySelector('#sobrenome').value ='';
             document.querySelector('#telefone').value ='';
            document.querySelector('#ra').value = '';
            aluno={};
            titulo.textContent='Cadastrar Aluno';
            btnSalvar.textContent='Cadastrar';
            btnCancelar.textContent='Limpar';
       }