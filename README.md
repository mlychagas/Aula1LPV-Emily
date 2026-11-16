Responda em 3 a 5 linhas: por que o FormProduto não adiciona o produto direto na lista? Quem faz isso, e como ele fica sabendo que precisa fazer?

O formProduto  coleta e  valida o produto, dessa forma esse componente não tem acesso a lista. A lista está presente dentro de Produtos.razor e é privada. 
Quem adiciona o produto é a própria página /produtos, pelo método adicionarProdutos.
A página fica sabendo por meio de um EventCallback, fazendo a ligação do evento onprodutoCadastrado do formulário ao metodo.
Quando o usuario envia o formulário, o editForm faz a validação e chama salvar(), que executa OnProdutoCadastrado.InvokeAsync(novoProduto).
Assim a pagina faz a adição do produto na lista e a tabelaProdutos recebe a lista atualizada pelo parameter.
