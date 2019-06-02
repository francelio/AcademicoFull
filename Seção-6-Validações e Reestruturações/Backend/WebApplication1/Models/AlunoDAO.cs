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

		public List<AlunoDTO> ListarAlunosBD(int? id)
		{
			var listAlunos = new List<AlunoDTO>();
			try
			{
				IDbCommand selectCMD = conexao.CreateCommand();

				if (id == null)
				{
					selectCMD.CommandText = "select * from Alunos";
				}
				else
				{
					selectCMD.CommandText = $"select * from Alunos where id={id}";
				}


				IDataReader resultado = selectCMD.ExecuteReader();

				while (resultado.Read())
				{
					var alu = new AlunoDTO
					{
						Id = Convert.ToInt32(resultado["Id"]),
						Nome = Convert.ToString(resultado["nome"]),
						Sobrenome = Convert.ToString(resultado["sobrenome"]),
						Telefone = Convert.ToString(resultado["telefone"]),
						Ra = Convert.ToInt32(resultado["ra"]),
					};
					listAlunos.Add(alu);

				}

				return listAlunos;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				conexao.Close();
			}
			
		}

		public void InserirAlunoBD(AlunoDTO aluno)
		{

			try
			{
				IDbCommand insertCMD = conexao.CreateCommand();
				insertCMD.CommandText = "insert into Alunos (nome, sobrenome, telefone, ra) values (@nome,@sobrenome,@telefone,@ra) ";

				IDbDataParameter parmNome = new SqlParameter("nome", aluno.Nome);
				insertCMD.Parameters.Add(parmNome);

				IDbDataParameter parmSobreNome = new SqlParameter("sobrenome", aluno.Sobrenome);
				insertCMD.Parameters.Add(parmSobreNome);

				IDbDataParameter parmTelefone = new SqlParameter("telefone", aluno.Telefone);
				insertCMD.Parameters.Add(parmTelefone);

				IDbDataParameter parmRa = new SqlParameter("ra", aluno.Ra);
				insertCMD.Parameters.Add(parmRa);

				insertCMD.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				conexao.Close();
			}

		}
		public void AtualizarAlunoBD(AlunoDTO aluno)
		{
			try
			{
				IDbCommand updateCMD = conexao.CreateCommand();
				updateCMD.CommandText = "update Alunos set nome = @nome, sobrenome = @sobrenome, telefone = @telefone, ra = @ra where Id=@ID";

				IDbDataParameter parmNome = new SqlParameter("nome", aluno.Nome);
				IDbDataParameter parmSobreNome = new SqlParameter("sobrenome", aluno.Sobrenome);
				IDbDataParameter parmTelefone = new SqlParameter("telefone", aluno.Telefone);
				IDbDataParameter parmRa = new SqlParameter("ra", aluno.Ra);

				updateCMD.Parameters.Add(parmNome);
				updateCMD.Parameters.Add(parmSobreNome);
				updateCMD.Parameters.Add(parmTelefone);
				updateCMD.Parameters.Add(parmRa);

				IDbDataParameter parmID = new SqlParameter("ID", aluno.Id);
				updateCMD.Parameters.Add(parmID);

				updateCMD.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				conexao.Close();
			}


		}
		public void DeletarAlunoBD(int id)
		{
			try
			{
				IDbCommand deleteCMD = conexao.CreateCommand();
				deleteCMD.CommandText = "Delete from Alunos where Id=@ID";

				IDbDataParameter parmID = new SqlParameter("ID", id);
				deleteCMD.Parameters.Add(parmID);

				deleteCMD.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				conexao.Close();
			}

		}
	}
}