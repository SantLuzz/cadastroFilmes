Programa criado como pratica de estudo, onde consiste em um aplicativo com banco de dados para cadastrar filmes informando nome, descri��o e categoria que est� vinculada (Foreign Key) com a categoria de uma outra tabela onde fica cadastrado as categoria.

Foi realizado um CRUD b�sico e exibido os dados do Banco de Dados em um ListView no form principal. Para banco de dados � usado o SQLite


Form Principal:

- Ao executar o programa o mesmo realiza a verifica��o se existe o arquivo de banco de dados e a pasta do mesmo, caso n�o exista o mesmo gera a pasta/arquivo, caso o banco tenha sido criado ao primeiro acesso � necess�rio gerar as tabelas.

- Para gerar as tabelas automaticamente foi gerado duas rotinas na Class db onde cria as duas tabelas necess�ria para operar o sistema, sendo chamada em um bot�o que s� se torna visivel ao inserir o acesso restrito do sistema.

- Ao pressionar F12 abre um form de autentica��o que ao validar a senha correta (foi inserido no corpo do c�digo em uma Const "senha: 1") o mesmo torna o bot�o "Criar Banco" vis�vel, assim ao pressionar o mesmo cria as tabelas caso n�o exista, usando a query SQL: CREATE TABLE IF NOT EXISTS
assim se as tabelas j� existirem o mesmo n�o sobrep�e as existente, presenvando assim os dados cadastrados.

- Foi criado uma rotina de pesquisa no ListView, onde realiza a pesquisa pelo ID ou Pelo nome do mesmo assim selecionando o mesmo, por�m s� pesquisa atrav�s do nome correto.



Cadastro de Filmes:


- Rotina de cadastro de filmes com o ComboBox populado com as categorias cadastradas dentro do banco de dados, onde � possivel realizar o cadastro de um novo filme, atualizar um j� existente a partir do selecionado no DataGridView e realizar a exclus�o.

- Ao fechar a Janela de Cadastro de Filmes � chamado um m�todo para recarregar as informa��es do banco para exibir no ListView.

- Criei uma rotina onde ao adicionar um cadastro novo para o filme � realizado a verifica��o do maior ID no ListView e comparado com o maior ID no banco, assim caso o ultimo ID do banco seja maior � realizado a inser��o no ListView ao fechar a janela de Cadstro.

- DataGridView populado com os dados j� cadastrados, caso haja altera��o nos cadastros ao realizar o UPDATE no db � atualizado tamb�m no DGV, o mesmo com INSERT e DELETE.

- Ao ter uma inser��o de categoria nova no banco o ComboBox � populado automaticamente.


Cadastro de Categoria:

- Rotinas de CRUD, onde realizo a inser��o, atualizo e deleto as informa��es dentro do banco.


- Se pressioando o bot�o NOVO o mesmo define a querry de INSERT para o bot�o SALVAR.


- Usado um DGV onde ao selecionar um item carrega dinamicamente as informa��es para os textBox onde se for alterado algum caracter habilita o modo de UPDATE.


Programa criado para praticar, fique a vontade para alterar o c�digo e refatorar, caso melhore alguma rotina realize o FORK para que possa atualizar o projeto!! Bons Estudos!!!!!