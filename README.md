# YourProductApi

*PROJETO*
Desenvolvi de forma direta. Evitei abstrações profundas. Meu objetivo principal não era fazer um código elegante, por conta de existirem muitos pontos tecnológicos que eu precisei aprender do zero, foquei meu trabalho em atender todos os requisitos e tornar as funcionalidades funcionais.

Como o domínio do sistema era basicamente composto por uma entidade Produto, criei um repositório para servi-la, um serviço de domínio baseado na validação do Produto, um serviço de aplicação que possui um fluxo separado para persistência de dados e outro para buscas. Decidi separar dessa maneira, pois achei que ficaria confuso operações de persistência e busca de dados dentro da mesma classe.

Distingui as models que passavam pela camada de apresentação entre Request e Response para tornar o fluxo do sistema mais amigável. Pensei em juntar todas dentro do mesmo conceito de DTO, mas achei genérico demais para a função que elas teriam no sistema. As nomeei usando os verbos HTTP como prefixo para especificar exatamente a qual fluxo cada uma pertence. 

Criei um serviço de mapeamento de objetos apartado do resto do sistema, caso fosse necessário alterar o framework utilizado, de AutoMapper para FastMapper, por exemplo, bastaria criar outra implementação para a interface IMapperCore e trocar sua implementação na injeção de dependência.

Criei uma classe intermediária, na camada de infraestrutura, entre o repositório e a classe de domínio por ter que decorar seus atributos para ser convertido para os tipos usados pelo Mongo. Foi a alternativa que usei para não decorar a classe de domínio e torna-la dependente do tipo de tecnologia que o sistema usa no momento.

As camadas de models que servem infraestrutura e aplicação foram criadas pois haveria referencia circular entre a elas duas e a camada de mapeamento de objetos se suas models estivessem dentro da mesma biblioteca.

*TESTES*	
Segui o padrão System Under Teste (SUT) e nomenclatura dos métodos de teste começando com Should.
Os testes criados para infraestrutura, principalmente para o repositório, foram de integração na sua grande maioria. Meu objetivo com isso era conhecer melhor o Mongo e saber como funciona o seu driver que faz a integração com a aplicação.

*MONGODB*
Criei a coleção products com os campos requeridos e adicionei um index único para o atributo de código do produto(“code”).
Por eu ter tido problemas com o Docker e não ter criado uma imagem pro banco, criei o arquivo products.json com a especificação da minha coleção.

*FRACASSOS*
Docker: Dediquei muito tempo a criação da minha aplicação inteira com docker (sistema + banco). Consegui criar e publicar minha imagem no Docker Hub apenas com a aplicação, sem o Mongo. O sistema sempre retorna exceção ao receber requisições, por não ter banco. Publiquei mesmo nessas condições para deixar claro que eu realmente estudei e coloquei a mão na massa para conseguir o melhor resultado.
Consegui rodar os conteiners e manipular as imagens local.
Como imaginei que teria uma curva de aprendizado grande para aprender a lidar com Mongo e Docker, decidi não me dedicar ao código a maior parte do tempo, seguindo a filosofia de primeiro tornar o software funcional, refatorar e abstrair.

*CONSIDERAÇÕES*
Gostei muito de passar uma semana inteira mergulhado no estudo dessas tecnologias. Posso dizer que cresci muito me dedicando ao desafio. Descobrir a injeção de dependência nativa do .NET Core e a forma que ele implementa API em comparação com o .net framework foi incrível. Conectar o Mongo ao .NET e entender seu funcionamento foi a melhor parte do desafio pra mim.
Só tenho a agradecer a oportunidade que me deram e espero que gostem do resultado.
Leonardo Jorge
