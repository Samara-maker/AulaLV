using System.ComponentModel.DataAnnotations;

namespace LojaBlazor.Models;

public class ProdutoModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    public string Nome { get; set; } = string.Empty;

    // preço tem que ser maior que zero (0,01 é o menor valor aceito)
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
    public decimal Preco { get; set; }
}
