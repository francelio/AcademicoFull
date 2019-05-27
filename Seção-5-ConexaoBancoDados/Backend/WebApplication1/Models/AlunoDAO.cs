using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	public class AlunoDAO
	{
		//string stringConexao = ConfigurationManager.AppSettings["ConnectionString"];
		private string stringConexao = ConfigurationManager.ConnectionStrings["ConexaoDev"].ConnectionString;
		private IDbConnection conexao;
		public AlunoDAO()
		{
			conexao = new SqlConnection(stringConexao);
			conexao.Open();
		}

		public List<Aluno> ListarAlunosBD()
		{

			var listAlunos = new List<Aluno>();

			IDbCommand selectCMD = conexao.CreateCommand();
			selectCMD.CommandText = "select * from Alunos";

			IDataReader resultado = selectCMD.ExecuteReader();

			while (resultado.Read())
			{
				var alu = new Aluno();
				alu.id = Convert.ToInt32(resultado["Id"]);
				alu.nome = Convert.ToString(resultado["nome"]);
				alu.sobrenome = Convert.ToString(resultado["sobrenome"]);
				alu.telefone = Convert.ToString(resultado["telefone"]);
				alu.ra = Convert.ToInt32(resultado["ra"]);

				listAlunos.Add(alu);

			}
			conexao.Close();
			return listAlunos;
		}

		public void InserirAlunoBD(Aluno aluno) {

			IDbCommand insertCMD = conexao.CreateCommand();
			insertCMD.CommandText = "insert into Alunos (nome, sobrenome, telefone, ra) values (@nome,@sobrenome,@telefone,@ra) ";

			IDbDataParameter parmNome = new SqlParameter("nome",aluno.nome);
			insertCMD.Parameters.Add(parmNome);

			IDbDataParameter parmSobreNome = new SqlParameter("sobrenome", aluno.sobrenome);
			insertCMD.Parameters.Add(parmSobreNome);

			IDbDataParameter parmTelefone = new SqlParameter("telefone", aluno.telefone);
			insertCMD.Parameters.Add(parmTelefone);

			IDbDataParameter parmRa = new SqlParameter("ra", aluno.ra);
			insertCMD.Parameters.Add(parmRa);

			insertCMD.ExecuteNonQuery();
		}
		public void AtualizarAlunoBD(Aluno aluno)
		{

			IDbCommand updateCMD = conexao.CreateCommand();
			updateCMD.CommandText = "update Alunos set nome = @nome, sobrenome = @sobrenome, telefone = @telefone, ra = @ra where Id=@ID";

			IDbDataParameter parmNome = new SqlParameter("nome", aluno.nome);
			IDbDataParameter parmSobreNome = new SqlParameter("sobrenome", aluno.sobrenome);
			IDbDataParameter parmTelefone = new SqlParameter("telefone", aluno.telefone);
			IDbDataParameter parmRa = new SqlParameter("ra", aluno.ra);

			updateCMD.Parameters.Add(parmNome);
			updateCMD.Parameters.Add(parmSobreNome);
			updateCMD.Parameters.Add(parmTelefone);
			updateCMD.Parameters.Add(parmRa);

			IDbDataParameter parmID = new SqlParameter("ID", aluno.id);
			updateCMD.Parameters.Add(parmID);

			updateCMD.ExecuteNonQuery();
		}
		public void DeletarAlunoBD(int id)
		{

			IDbCommand deleteCMD = conexao.CreateCommand();
			deleteCMD.CommandText = "Delete from Alunos where Id=@ID";

			IDbDataParameter parmID = new SqlParameter("ID", id);
			deleteCMD.Parameters.Add(parmID);

			deleteCMD.ExecuteNonQuery();
		}
	}
}