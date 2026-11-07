using System.ComponentModel.DataAnnotations;

namespace LojaBlazor.Models;

public class CategoriaModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
    [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 letras.")]
    // minha regra: nome de categoria só com letras e espaços (sem números ou símbolos)
    [RegularExpression(@"^[A-Za-zÀ-ÿ ]+$", ErrorMessage = "O nome deve conter apenas letras.")]
    public string Nome { get; set; } = string.Empty;

    [Range(0, 100000, ErrorMessage = "A quantidade deve estar entre 0 e 100000.")]
    public int Quantidade { get; set; }
}
