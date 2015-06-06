using System.ComponentModel.DataAnnotations;

namespace CadeMeuMedico.Models
{

    [MetadataType(typeof(CidadeMetadado))]
    public partial class Cidade
    {
    }
    public class CidadeMetadado
    {
        [Required(ErrorMessage = "Obrigatório informar o nome da cidade.")]
        [StringLength(100, ErrorMessage = "O nome da cidade deve possuir no máximo 100 caracteres")]
        public string Nome { get; set; }
    }

}
