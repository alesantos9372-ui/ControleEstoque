using ControleEstoque.Models;
using ControleEstoque.Service;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly ProdutoService _service;

    public ProdutoController(ProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObterTodos()
    {
        return Ok(_service.ObterResumoEstoque());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var produto = await _service.ObterPorId(id);
        return produto is null ? NotFound() : Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar([FromBody] ProdutoEntradaModel entrada)
    {
        var produto = entrada.ParaProduto();
        var novoProduto = await _service.Adicionar(produto);
        return CreatedAtAction(nameof(ObterPorId), new { id = novoProduto.Id }, novoProduto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] ProdutoEntradaModel entrada)
    {
        var produto = entrada.ParaProduto(id);
        return await _service.Atualizar(produto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        return await _service.Remover(id) ? NoContent() : NotFound();
    }
}
