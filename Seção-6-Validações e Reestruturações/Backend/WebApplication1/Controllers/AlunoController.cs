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
	[EnableCors("*", "*", "*")]
	[RoutePrefix("api/Aluno")]
	public class AlunoController : ApiController
	{
		// GET: api/Aluno
		[HttpGet]
		[Route("Recuperar")]
		public IHttpActionResult Recuperar()
		{
			try
			{
				AlunoModel alunosIns = new AlunoModel();
				return Ok(alunosIns.ListarAluno());
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}

		}

		// GET: api/Aluno/5
		[HttpGet]
		[Route("Recuperar/{id:int}/{nome?}/{sobrenome?}")]
		public IHttpActionResult Get(int id, string nome=null, string sobrenome=null)
		{
			try
			{
				AlunoModel alunosIns = new AlunoModel();
				return Ok(alunosIns.ListarAluno(id).FirstOrDefault());
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}

			
		}

		[HttpGet]
		[Route(@"RecuperarPorDataNome/{data:regex([0-9]{4}\-[0-9]{2})}/{nome:minlength(5)}")]
		public IHttpActionResult Recuperar(string data, string nome)
		{
			try
			{
				AlunoModel alunosIns = new AlunoModel();
				IEnumerable<AlunoDTO> alunos = alunosIns.ListarAluno().Where(x => x.data == data || x.nome == nome);

				if (!alunos.Any())
					return NotFound();

				return Ok(alunos);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}

			
		}

		
		[HttpPost]
		public IHttpActionResult Post(AlunoDTO aluno)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			try
			{
				AlunoModel _alunosIns = new AlunoModel();
				_alunosIns.Inserir(aluno);
				return Ok(_alunosIns.ListarAluno(null));

			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}

		
		}

		[HttpPut]
		public IHttpActionResult Put(int id, [FromBody]AlunoDTO aluno)
		{
			try
			{
				AlunoModel _alunosIns = new AlunoModel();
				aluno.id = id;
				_alunosIns.Atualizar(aluno);
				
				return Ok(_alunosIns.ListarAluno(id).FirstOrDefault());

			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}

			

		}

		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			try
			{
				AlunoModel _alunosIns = new AlunoModel();
				_alunosIns.Deletar(id);

				return Ok("Deletado com sucesso");

			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
			
		}
	}
}
