using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

		public List<Aluno> ListarAluno() {

			var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\base.json");
			var json = File.ReadAllText(caminhoArquivo);

			var listAlunos = JsonConvert.DeserializeObject<List<Aluno>>(json);

			return listAlunos;
		}
		public string stringConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=~/App_Data/Database.mdf;Integrated Security = True";
		public IDbConnection conexao;
		public List<Aluno> ListarAlunosBD()
		{
			conexao = new SqlConnection(stringConexao);
			var listAlunos = new List<Aluno>();

			return listAlunos;
		}
		public bool ReescreverArquivo(List<Aluno> listaAlunos) {

			var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\base.json");
			var json = JsonConvert.SerializeObject(listaAlunos,Formatting.Indented);

			File.WriteAllText(caminhoArquivo,json);

			return true;
		}
		public Aluno Inserir(Aluno Aluno) {
			var listaAlunos = this.ListarAluno();

			var maxId = listaAlunos.Max(aluno => aluno.id);
			Aluno.id = maxId + 1;
			listaAlunos.Add(Aluno);

			ReescreverArquivo(listaAlunos);

			return Aluno;
		}
		public Aluno Atualizar(int id, Aluno Aluno) {
			var listaAlunos = this.ListarAluno();
			var itemIndex = listaAlunos.FindIndex(p => p.id == id);

			if (itemIndex >= 0)
			{
				Aluno.id = id;
				listaAlunos[itemIndex] = Aluno;
			}
			else {
				return null;
			}

			ReescreverArquivo(listaAlunos);

			return Aluno;
		}

		public bool Deletar(int id)
		{
			var listaAlunos = this.ListarAluno();
			var itemIndex = listaAlunos.FindIndex(p => p.id == id);

			if (itemIndex >= 0)
			{
				
				listaAlunos.RemoveAt(itemIndex);
			}
			else
			{
				return false;
			}

			ReescreverArquivo(listaAlunos);

			return true;
		}
	}
}