namespace ControleEstoque.Models;

public class ProdutoResumoModel
{
    public string Nome { get; set; } = string.Empty;
    public int QuantidadeTotal { get; set; }
    public IList<LoteResumoModel> Lotes { get; set; } = new List<LoteResumoModel>();
}

public class LoteResumoModel
{
    public int Id { get; set; }
    public string Lote { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public DateTime Validade { get; set; }
}
