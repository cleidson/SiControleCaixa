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


