# BankTrade

Ola,

Esta api foi criada para testar meus conhecimentos. Nela foi linkado um banco de dados local.

Foi feita uma controller principal chamada BankTradesController que visa captar os dados para realizar busca,criação, atualização ou deleção de transações bancarias simples.

Foi implementado injeção de dependencia e foi implementado a interface para que a controller não olhe diretamente para a service e a service não olhe diretamente para a repository.

Foi criado o arquivo de conexão ao banco de dados para que seja realizada as instruções SQL de maneira mais segura não expondo a string de conexão.

Foram criados os metodos olhando para o CRUD, porem o metodo de deleção está realizando uma deleção logica, por se tratar de transações bancarias é importante manter o registro
