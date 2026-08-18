using ControleEstoque.Data;
using ControleEstoque.Models;

namespace ControleEstoque.Repositorie;

public class ProdutoRepositorie
{
    private readonly AppDbContext _context;

    public ProdutoRepositorie(AppDbContext context)
    {
        _context = context;
    }

    public IList<ProdutoModel> ObterTodos()
    {
        return _context.Produtos.OrderBy(produto => produto.Nome).ToList();
    }

    public async Task<ProdutoModel?> ObterPorId(int id)
    {
        return await _context.Produtos.FindAsync(id);
    }

    public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
    {
        await _context.Produtos.AddAsync(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<bool> Atualizar(ProdutoModel produto)
    {
        var produtoExistente = await ObterPorId(produto.Id);

        if (produtoExistente is null)
            return false;

        produtoExistente.Nome = produto.Nome;
        produtoExistente.Quantidade = produto.Quantidade;
        produtoExistente.Lote = produto.Lote;
        produtoExistente.Validade = produto.Validade;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Remover(int id)
    {
        var produtoRemovido = await ObterPorId(id);

        if (produtoRemovido is null)
            return false;

        _context.Produtos.Remove(produtoRemovido);
        await _context.SaveChangesAsync();
        return true;
    }
}
