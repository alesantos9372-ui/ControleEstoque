using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Models;

public class ProdutoEntradaModel
{
    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Range(1, 1_000_000, ErrorMessage = "A quantidade deve estar entre 1 e 1.000.000.")]
    public int Quantidade { get; set; }

    [Required(ErrorMessage = "O lote é obrigatório.")]
    [StringLength(60, ErrorMessage = "O lote pode ter no máximo 60 caracteres.")]
    public string Lote { get; set; } = string.Empty;

    [Required(ErrorMessage = "A validade é obrigatória.")]
    public DateTime Validade { get; set; }

    public ProdutoModel ParaProduto(int id = 0)
    {
        return new ProdutoModel
        {
            Id = id,
            Nome = Nome.Trim(),
            Quantidade = Quantidade,
            Lote = Lote.Trim(),
            Validade = Validade
        };
    }
}
