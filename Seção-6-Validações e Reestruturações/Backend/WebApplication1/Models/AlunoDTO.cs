using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	public class AlunoDTO
	{
		public int id { get; set; }
		[Required(ErrorMessage ="O campo Nome é de preenchimento obrigatorio")]//validacao DataAnnotations com mensagem caso o required não seja atendido
		public string nome { get; set; }
		public string sobrenome { get; set; }
		public string telefone { get; set; }
		public string data { get; set; }
		[Required(ErrorMessage = "O campo Ra é de preenchimento obrigatorio")]
		public int? ra { get; set; }
	}
}