using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	[EnableCors("*","*","*")]
    public class AlunoController : ApiController
    {
        // GET: api/Aluno
        public IEnumerable<Aluno> Get()
        {
			Aluno alunosIns = new Aluno();
			return alunosIns.ListarAluno();
		}

        // GET: api/Aluno/5
        public Aluno Get(int id)
        {

			Aluno alunosIns = new Aluno();
			return alunosIns.ListarAluno().Where(x =>x.id==id).FirstOrDefault();
		}

        // POST: api/Aluno
        public List<Aluno> Post(Aluno aluno)
        {
			Aluno _alunosIns = new Aluno();
			_alunosIns.Inserir(aluno);
			return _alunosIns.ListarAluno();
		}

        // PUT: api/Aluno/5
        public Aluno Put(int id, [FromBody]Aluno aluno)
        {
			Aluno _alunosIns = new Aluno();
			return _alunosIns.Atualizar(id,aluno);

		}

        // DELETE: api/Aluno/5
        public void Delete(int id)
        {
			Aluno _alunosIns = new Aluno();
			_alunosIns.Deletar(id);
		}
    }
}
