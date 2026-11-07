# Atividade EAD – Aula 3: validação de formulário em Blazor

## 1) Produtos não aceita lixo

**Onde a regra mora?** No model (`Models/ProdutoModel.cs`), com DataAnnotations:
- `[Required]` no Nome → nome vazio (ou só espaços) é recusado.
- `[Range(0.01, double.MaxValue)]` no Preço → preço menor ou igual a zero é recusado.
- Todas as mensagens estão em português, no `ErrorMessage`.

**Quem confere?** O `<DataAnnotationsValidator />` dentro do `<EditForm>`. Ele lê os atributos do model e valida os campos quando o usuário envia o formulário.

**Como o aviso chega na tela?** Pelo `<ValidationMessage For="() => produto.Nome" />` colocado logo abaixo de cada campo.

**Só entra se estiver válido:** usei `OnValidSubmit="SalvarProduto"`, então o método só roda se não tiver nenhum erro.

**Formulário volta vazio:** depois de adicionar na lista faço `produto = new ProdutoModel();`, e o EditForm passa a usar um objeto novo, sem nada preenchido.

## 2) Tela de Categorias

Página `/categorias` (`Components/Pages/Categorias.razor`), no mesmo padrão de Produtos: formulário, tabela e aviso quando a lista está vazia. Link adicionado no `NavMenu.razor`.

Regras (`Models/CategoriaModel.cs`):
- Nome: `[Required]` + `[MinLength(3)]`
- Quantidade: `[Range(0, 100000)]`
- **Minha regra:** `[RegularExpression]` → o nome só aceita letras e espaços.
  *Por quê:* nome de categoria descreve um grupo de produtos (ex.: "Informática"), então números e símbolos como "123" ou "@@@" não fazem sentido ali.

## Erro CS0117

O Blazor gera uma classe C# com o mesmo nome do arquivo `.razor`. Se a página se chamar `Categoria.razor` e o model também se chamar `Categoria`, dentro da página `new Categoria { Nome = ... }` aponta para a classe da **página** (que não tem `Nome` nem `Quantidade`), e o compilador reclama com CS0117 ("não contém uma definição para 'Nome'").

**Correção:** dar nomes diferentes para as duas classes. A página se chama `Categorias.razor` (plural) e o model se chama `CategoriaModel`, igual ao padrão `ProdutoModel`.
