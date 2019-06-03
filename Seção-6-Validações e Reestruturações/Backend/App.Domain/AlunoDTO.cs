using System.ComponentModel.DataAnnotations;

namespace App.Domain
{
	public class AlunoDTO
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="O campo Nome é de preenchimento obrigatorio")]//validacao DataAnnotations com mensagem caso o required não seja atendido
		[StringLength(50,ErrorMessage ="Nome pode ter no mínimo 2 caracteres e no máximo 50",MinimumLength =2)]
		public string Nome { get; set; }
		public string Sobrenome { get; set; }
		public string Telefone { get; set; }
		[RegularExpression(@"[0-9]{4}\-[0-9]{2}",ErrorMessage ="A data está fora do formato YYYY-MM")]
		public string Data { get; set; }
		[Required(ErrorMessage = "O campo Ra é de preenchimento obrigatorio")]
		[Range(1,9099,ErrorMessage ="O intervalo para cadastro de RA está entre 1 e 9099")]
		public int? Ra { get; set; }
	}
}