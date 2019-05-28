using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebApplication1.Models
{
	public class AlunoModel
	{
		public List<AlunoDTO> ListarAluno(int? id = null)
		{

			try
			{
				var alunoDB = new AlunoDAO();
				return alunoDB.ListarAlunosBD(id);

			}
			catch (Exception ex)
			{

				throw new Exception($"error ao listar alunos:error=>{ex.Message} ");
			}

		}

		public void Inserir(AlunoDTO Aluno)
		{

			try
			{
				var alunoDB = new AlunoDAO();
				alunoDB.InserirAlunoBD(Aluno);

			}
			catch (Exception ex)
			{

				throw new Exception($"error ao inserir aluno:error=>{ex.Message} ");
			}

		}
		public void Atualizar(AlunoDTO Aluno)
		{
			try
			{
				var alunoDB = new AlunoDAO();
				alunoDB.AtualizarAlunoBD(Aluno);

			}
			catch (Exception ex)
			{

				throw new Exception($"error ao atualizar aluno:error=>{ex.Message} ");
			}

		}

		public void Deletar(int id)
		{
			try
			{
				var alunoDB = new AlunoDAO();
				alunoDB.DeletarAlunoBD(id);

			}
			catch (Exception ex)
			{

				throw new Exception($"error ao deletar aluno:error=>{ex.Message} ");
			}
		}
	}
}