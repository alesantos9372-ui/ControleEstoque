using ControleEstoque.Models;
using ControleEstoque.Repositorie;

namespace ControleEstoque.Service;

public class ProdutoService
{
    private readonly ProdutoRepositorie _repositorie;

    public ProdutoService(ProdutoRepositorie repositorie)
    {
        _repositorie = repositorie;
    }

    public IList<ProdutoModel> ObterTodos()
    {
        return _repositorie.ObterTodos();
    }

    public IList<ProdutoResumoModel> ObterResumoEstoque()
    {
        return _repositorie.ObterTodos()
            .GroupBy(produto => produto.Nome?.Trim(), StringComparer.OrdinalIgnoreCase)
            .Where(grupo => !string.IsNullOrWhiteSpace(grupo.Key))
            .OrderBy(grupo => grupo.Key)
            .Select(grupo => new ProdutoResumoModel
            {
                Nome = grupo.Key!,
                QuantidadeTotal = grupo.Sum(produto => produto.Quantidade),
                Lotes = grupo
                    .OrderBy(produto => produto.Validade)
                    .Select(produto => new LoteResumoModel
                    {
                        Id = produto.Id,
                        Lote = produto.Lote ?? string.Empty,
                        Quantidade = produto.Quantidade,
                        Validade = produto.Validade
                    })
                    .ToList()
            })
            .ToList();
    }

    public async Task<ProdutoModel?> ObterPorId(int id)
    {
        return await _repositorie.ObterPorId(id);
    }

    public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
    {
        ValidarProduto(produto);
        return await _repositorie.Adicionar(produto);
    }

    public async Task<bool> Atualizar(ProdutoModel produto)
    {
        ValidarProduto(produto);
        return await _repositorie.Atualizar(produto);
    }

    public async Task<bool> Remover(int id)
    {
        return await _repositorie.Remover(id);
    }

    private static void ValidarProduto(ProdutoModel produto)
    {
        ArgumentNullException.ThrowIfNull(produto);

        if (string.IsNullOrWhiteSpace(produto.Nome))
            throw new ArgumentException("O nome do produto é obrigatório.");

        if (produto.Quantidade <= 0)
            throw new ArgumentException("A quantidade deve ser maior que zero.");

        if (string.IsNullOrWhiteSpace(produto.Lote))
            throw new ArgumentException("O lote é obrigatório.");

        if (produto.Validade == default)
            throw new ArgumentException("A validade é obrigatória.");

        if (produto.Validade.Date < DateTime.Today)
            throw new ArgumentException("A validade não pode estar no passado.");
    }
}
