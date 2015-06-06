using System.ComponentModel.DataAnnotations;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(EspecialidadeMetadado))]
    public partial class Especialidade
    {
    }
    public class EspecialidadeMetadado
    {
        [Required(ErrorMessage = "Obrigatório informar o nome da especialidade.")]
        [StringLength(80, ErrorMessage = "O nome da cidade deve possuir no máximo 80 caracteres")]
        public string Nome { get; set; }
    }
}
