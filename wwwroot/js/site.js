const apiUrl = "/api/produto";
const form = document.querySelector("#produto-form");
const lista = document.querySelector("#produtos-lista");
const mensagem = document.querySelector("#mensagem");
const listaVazia = document.querySelector("#lista-vazia");
const totalProdutos = document.querySelector("#total-produtos");
const botaoSalvar = document.querySelector("#salvar");

document.addEventListener("DOMContentLoaded", carregarProdutos);
form.addEventListener("submit", adicionarLote);
document.querySelector("#atualizar-lista").addEventListener("click", carregarProdutos);

async function carregarProdutos() {
  try {
    const resposta = await fetch(apiUrl);
    if (!resposta.ok) throw new Error("Não foi possível carregar os produtos.");
    renderizarProdutos(await resposta.json());
  } catch (erro) { mostrarMensagem(erro.message, "danger"); }
}

function renderizarProdutos(produtos) {
  lista.innerHTML = "";
  totalProdutos.textContent = produtos.length;
  listaVazia.classList.toggle("d-none", produtos.length !== 0);

  for (const [indice, produto] of produtos.entries()) {
    const linhaProduto = document.createElement("tr");
    const detalhesId = `lotes-${indice}`;
    linhaProduto.innerHTML = `<td><span class="product-name">${escaparHtml(produto.nome)}</span></td><td><span class="quantity-badge">${produto.quantidadeTotal}</span></td><td>${produto.lotes.length}</td><td class="text-end"><button class="btn btn-sm btn-outline-primary expandir" type="button" aria-expanded="false" aria-controls="${detalhesId}">Ver lotes</button></td>`;

    const linhaLotes = document.createElement("tr");
    linhaLotes.id = detalhesId;
    linhaLotes.className = "d-none";
    const celula = document.createElement("td");
    celula.colSpan = 4;
    celula.className = "p-0";
    celula.appendChild(criarTabelaLotes(produto.lotes, produto.nome));
    linhaLotes.appendChild(celula);

    const botao = linhaProduto.querySelector(".expandir");
    botao.addEventListener("click", () => {
      const expandido = botao.getAttribute("aria-expanded") === "true";
      botao.setAttribute("aria-expanded", String(!expandido));
      botao.textContent = expandido ? "Ver lotes" : "Ocultar lotes";
      linhaLotes.classList.toggle("d-none", expandido);
    });

    lista.append(linhaProduto, linhaLotes);
  }
}

function criarTabelaLotes(lotes, nomeProduto) {
  const tabela = document.createElement("table");
  tabela.className = "table table-light mb-0 tabela-lotes";
  tabela.innerHTML = "<thead><tr><th>Lote</th><th>Quantidade do lote</th><th>Validade</th><th class='text-end'>Ação</th></tr></thead>";
  const corpo = document.createElement("tbody");

  for (const lote of lotes) {
    const linha = document.createElement("tr");
    linha.innerHTML = `<td>${escaparHtml(lote.lote)}</td><td>${lote.quantidade}</td><td>${formatarData(lote.validade)}</td><td class="text-end"><button class="btn btn-sm btn-outline-danger" type="button">Excluir lote</button></td>`;
    linha.querySelector("button").addEventListener("click", () => excluirLote(lote.id, lote.lote, nomeProduto));
    corpo.appendChild(linha);
  }
  tabela.appendChild(corpo);
  return tabela;
}

async function adicionarLote(evento) {
  evento.preventDefault();
  if (!form.reportValidity()) return;
  const produto = {
    nome: document.querySelector("#nome").value.trim(),
    quantidade: Number(document.querySelector("#quantidade").value),
    lote: document.querySelector("#lote").value.trim(),
    validade: document.querySelector("#validade").value
  };

  try {
    botaoSalvar.disabled = true;
    botaoSalvar.textContent = "Adicionando...";
    const resposta = await fetch(apiUrl, { method: "POST", headers: { "Content-Type": "application/json" }, body: JSON.stringify(produto) });
    if (!resposta.ok) throw new Error(await mensagemErro(resposta));
    form.reset();
    mostrarMensagem("Lote adicionado ao estoque.", "success");
    await carregarProdutos();
  } catch (erro) { mostrarMensagem(erro.message, "danger"); }
  finally { botaoSalvar.disabled = false; botaoSalvar.textContent = "Adicionar lote"; }
}

async function excluirLote(id, lote, nomeProduto) {
  if (!confirm(`Excluir o lote ${lote} de ${nomeProduto}?`)) return;
  try {
    const resposta = await fetch(`${apiUrl}/${id}`, { method: "DELETE" });
    if (!resposta.ok) throw new Error(await mensagemErro(resposta));
    mostrarMensagem("Lote excluído e total do produto recalculado.", "success");
    await carregarProdutos();
  } catch (erro) { mostrarMensagem(erro.message, "danger"); }
}

function mostrarMensagem(texto, tipo) { mensagem.textContent = texto; mensagem.className = `alert alert-${tipo}`; }
async function mensagemErro(resposta) { return (await resposta.text()) || "Não foi possível concluir a operação."; }
function formatarData(data) { return new Intl.DateTimeFormat("pt-BR", { timeZone: "UTC" }).format(new Date(data)); }
function escaparHtml(valor) { const elemento = document.createElement("div"); elemento.textContent = valor ?? ""; return elemento.innerHTML; }
