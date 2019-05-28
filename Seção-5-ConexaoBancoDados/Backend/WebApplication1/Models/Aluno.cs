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
	public class Aluno
	{
		public int id { get; set; }
		public string nome { get; set; }
		public string sobrenome { get; set; }
		public string telefone { get; set; }
		public string data { get; set; }
		public int ra { get; set; }

		public List<Aluno> ListarAluno(int? id = null) {

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

		public bool ReescreverArquivo(List<Aluno> listaAlunos) {

			var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\base.json");
			var json = JsonConvert.SerializeObject(listaAlunos,Formatting.Indented);

			File.WriteAllText(caminhoArquivo,json);

			return true;
		}
		public void Inserir(Aluno Aluno) {

			try
			{
				var alunoDB = new AlunoDAO();
				alunoDB.InserirAlunoBD(Aluno);

			}
			catch (Exception ex)
			{

				throw new Exception($"error ao inserir aluno:error=>{ex.Message} ");
			}


			//var listaAlunos = this.ListarAluno();

			//var maxId = listaAlunos.Max(aluno => aluno.id);
			//Aluno.id = maxId + 1;
			//listaAlunos.Add(Aluno);

			//ReescreverArquivo(listaAlunos);

			//return Aluno;
		}
		public void Atualizar(Aluno Aluno) {
			try
			{
				var alunoDB = new AlunoDAO();
				alunoDB.AtualizarAlunoBD(Aluno);

			}
			catch (Exception ex)
			{

				throw new Exception($"error ao atualizar aluno:error=>{ex.Message} ");
			}



			//var listaAlunos = this.ListarAluno();
			//var itemIndex = listaAlunos.FindIndex(p => p.id == id);

			//if (itemIndex >= 0)
			//{
			//	Aluno.id = id;
			//	listaAlunos[itemIndex] = Aluno;
			//}
			//else {
			//	return null;
			//}

			//ReescreverArquivo(listaAlunos);

			//return Aluno;
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
			//var listaAlunos = this.ListarAluno();
			//var itemIndex = listaAlunos.FindIndex(p => p.id == id);

			//if (itemIndex >= 0)
			//{

			//	listaAlunos.RemoveAt(itemIndex);
			//}
			//else
			//{
			//	return false;
			//}

			//ReescreverArquivo(listaAlunos);

			//return true;

		}
	}
}