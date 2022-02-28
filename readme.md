Programa criado como pratica de estudo, onde consiste em um aplicativo com banco de dados para cadastrar filmes informando nome, descrição e categoria que está vinculada (Foreign Key) com a categoria de uma outra tabela onde fica cadastrado as categoria.

Foi realizado um CRUD básico e exibido os dados do Banco de Dados em um ListView no form principal. Para banco de dados é usado o SQLite


Form Principal:

- Ao executar o programa o mesmo realiza a verificação se existe o arquivo de banco de dados e a pasta do mesmo, caso não exista o mesmo gera a pasta/arquivo, caso o banco tenha sido criado ao primeiro acesso é necessário gerar as tabelas.

- Para gerar as tabelas automaticamente foi gerado duas rotinas na Class db onde cria as duas tabelas necessária para operar o sistema, sendo chamada em um botão que só se torna visivel ao inserir o acesso restrito do sistema.

- Ao pressionar F12 abre um form de autenticação que ao validar a senha correta (foi inserido no corpo do código em uma Const "senha: 1") o mesmo torna o botão "Criar Banco" visível, assim ao pressionar o mesmo cria as tabelas caso não exista, usando a query SQL: CREATE TABLE IF NOT EXISTS
assim se as tabelas já existirem o mesmo não sobrepõe as existente, presenvando assim os dados cadastrados.

- Foi criado uma rotina de pesquisa no ListView, onde realiza a pesquisa pelo ID ou Pelo nome do mesmo assim selecionando o mesmo, porém só pesquisa através do nome correto.



Cadastro de Filmes:


- Rotina de cadastro de filmes com o ComboBox populado com as categorias cadastradas dentro do banco de dados, onde é possivel realizar o cadastro de um novo filme, atualizar um já existente a partir do selecionado no DataGridView e realizar a exclusão.

- Ao fechar a Janela de Cadastro de Filmes é chamado um método para recarregar as informações do banco para exibir no ListView.

- Criei uma rotina onde ao adicionar um cadastro novo para o filme é realizado a verificação do maior ID no ListView e comparado com o maior ID no banco, assim caso o ultimo ID do banco seja maior é realizado a inserção no ListView ao fechar a janela de Cadstro.

- DataGridView populado com os dados já cadastrados, caso haja alteração nos cadastros ao realizar o UPDATE no db é atualizado também no DGV, o mesmo com INSERT e DELETE.

- Ao ter uma inserção de categoria nova no banco o ComboBox é populado automaticamente.


Cadastro de Categoria:

- Rotinas de CRUD, onde realizo a inserção, atualizo e deleto as informações dentro do banco.


- Se pressioando o botão NOVO o mesmo define a querry de INSERT para o botão SALVAR.


- Usado um DGV onde ao selecionar um item carrega dinamicamente as informações para os textBox onde se for alterado algum caracter habilita o modo de UPDATE.


Programa criado para praticar, fique a vontade para alterar o código e refatorar, caso melhore alguma rotina realize o FORK para que possa atualizar o projeto!! Bons Estudos!!!!!