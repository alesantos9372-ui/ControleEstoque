namespace ControleEstoque.Models;

public class ProdutoModel
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public string Lote { get; set; } = string.Empty;
    public DateTime Validade { get; set; }
}
    
