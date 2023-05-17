# SiControleCaixa
Sistema responsável por gerenciar o fluxo de caixa.

### Como Rodar
```
Será necessário subir o backup do banco de dados ou rodar o migration.
```
### Database 
```
Basta abrir o Sql Server management Studio
> Botão em Databases > Restor Database > indiciar o local do arquivo > selecionar o arquivo (TestArquiteto);

Após subir o banco de dados, será necessário rodar os seguintes comandos nos arquivos .sql que estão na pasta sql.

createUser.sql // Responsável por criar o usuário da aplicação
rulesUser.sql
```

### Arquitetura 

![arquitetura](/Arquitetura.png)



### Explicação

#### Arquitetura
A arquitetura utilizada neste projeto consiste em três camadas:
- **Presentation** : A camada Presentation é responsável por traduzir as ações do usuário em solicitações de serviços e também por exibir as informações resultantes aos usuários de forma compreensíve

- **Application** Core: Essa camada é responsável por coordenar a lógica de negócio e as regras de aplicação, fornecendo serviços e funcionalidades específicas do domínio da aplicação.

- **Infrastructure**: Essa camada lida com os aspectos técnicos e de infraestrutura da aplicação, fornecendo recursos para persistência de dados e etc. 
 <br/>
 
   > :memo: <strong>Observação:</strong> No projeto SiControleCaixa.Infrastructure.Data, será desacoplado futuramente, separando toda parte de configuração, <i>migration</i> e contexto. Sendo criado futuramente o projeto SiControleCaixa.Infrastructure.Data.SqlServer, onde armazenará toda configuração referente ao banco de dados Microsoft Sql Server. 
    
   > Dessa forma, o ganho se dará no desacoplamento das entidades, podendo ser reaproveitado em outras configurações de outros bancos, trabalhando com contextos diferentes.

 

#### Negocial
- O atributo referente ao <strong>Tipo da Transação</strong> é composta pelo seguintes valores, sendo eles:

   <br/>
  Valor <strong>0</strong>: Corresponde a transação do tipo <strong>Débito</strong>
   <br/>
  Valor <strong>1</strong>: Corresponde a transação do tipo <strong>Crédito</strong>
  
   <br/>
   <br/>

    > :memo: **Nota:** Caso necessário o tipo de transação poderá ser transformado em um Enum ou uma tabela de Domínio no banco de dados, facilitando a leitura e interpretação de valores. 

