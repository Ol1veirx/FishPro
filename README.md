# Documentação FishPro - Sistema de Gerenciamento de Torneios

## 1. Introdução
O FishPro é uma aplicação web projetada para permitir que os usuários criem, gerenciem e acompanhem torneios esportivos. Este documento descreve a arquitetura geral do sistema, incluindo sua estrutura de dados, casos de uso e fluxos de interação do usuário.

## 2. Estrutura de Dados

2.1 Entidades Principais:

2.1.1 Usuário
- ID: Identificador único do usuário (chave primária).
- Nome: Nome do usuário.
- Email: Endereço de e-mail do usuário (deve ser único).
- Senha: Senha do usuário (criptografada).
- Outros campos de perfil, como informações pessoais opcionais, etc.

2.1.2 Torneio
- ID: Identificador único do torneio (chave primária).
- Nome: Nome descritivo do torneio.
- Descrição: Breve descrição do torneio.
- Usuário_ID: Referência ao usuário que criou o torneio (chave estrangeira).

2.1.3 Etapa
- ID: Identificador único da etapa (chave primária).
- Número: Número sequencial da etapa dentro do torneio.
- Data: Data de realização da etapa.
- Torneio_ID: Referência ao torneio ao qual a etapa pertence (chave estrangeira).

2.1.4 Equipe
- ID: Identificador único da equipe (chave primária).
- Nome: Nome da equipe.
- Setor: Setor ao qual a equipe pertence.
- Torneio_ID: Referência ao torneio ao qual a equipe pertence (chave estrangeira).

2.1.5 Resultado
- ID: Identificador único do resultado (chave primária).
- Etapa_ID: Referência à etapa à qual o resultado pertence (chave estrangeira).
- Equipe_ID: Referência à equipe à qual o resultado pertence (chave estrangeira).
- Peso: Peso total da captura pela equipe.
- Quantidade: Número total de capturas pela equipe.
- Pontuação: Pontuação total da equipe na etapa.

2.1.6 Participação
- ID: Identificador único da participação (chave primária).
- Torneio_ID: Referência ao torneio ao qual a participação pertence (chave estrangeira).
- Equipe_ID: Referência à equipe que participa do torneio (chave estrangeira).

2.2 Relacionamentos:
- Um Torneio pode ter várias Etapas (relacionamento um para muitos).
- Cada Etapa pertence a um único Torneio.
- Cada Equipe pode ter vários Resultados em diferentes Etapas (relacionamento um para muitos).
- Cada Resultado está associado a uma única Etapa e uma única Equipe.

## 3. Casos de Uso

3.1 Criar Torneio
- Descrição: O usuário cria um novo torneio.
- Ator Principal: Usuário
- Pré-condições: Usuário autenticado no sistema.
- Fluxo Principal:
  1. Usuário acessa a função de criação de torneios.
  2. Usuário preenche os detalhes do torneio (nome, descrição).
  3. Usuário confirma a criação do torneio.
- Pós-condições: Novo torneio criado no sistema.

3.2 Adicionar Etapa ao Torneio
- Descrição: O usuário adiciona uma nova etapa a um torneio existente.
- Ator Principal: Usuário
- Pré-condições: Usuário autenticado no sistema e torneio existente.
- Fluxo Principal:
  1. Usuário acessa a função de adição de etapas.
  2. Usuário seleciona o torneio ao qual deseja adicionar a etapa.
  3. Usuário preenche os detalhes da nova etapa (número, data).
  4. Usuário confirma a adição da etapa.
- Pós-condições: Nova etapa adicionada ao torneio.

3.3 Adicionar Equipes ao Torneio
- Descrição: O usuário adiciona equipes participantes a um torneio existente.
- Ator Principal: Usuário
- Pré-condições: Usuário autenticado no sistema e torneio existente.
- Fluxo Principal:
  1. Usuário acessa a função de adição de equipes.
  2. Usuário seleciona o torneio ao qual deseja adicionar as equipes.
  3. Usuário insere os detalhes das equipes (nome, setor, etc.).
  4. Usuário confirma a adição das equipes.
- Pós-condições: Equipes adicionadas ao torneio.

## 4. História de Uso do Sistema

4.1 Criação de Torneio
Um usuário loga no sistema e cria um novo torneio chamado "Torneio de Pesca 2024" com uma breve descrição. Em seguida, ele adiciona várias etapas ao torneio, especificando as datas de realização. O torneio é agora visível para os participantes.

4.2 Registro de Resultados
Após cada etapa do torneio, o usuário registra os resultados das equipes. Ele insere os dados de desempenho, como peso, quantidade e pontuação. Os resultados são atualizados automaticamente no sistema e refletidos na interface do usuário do usuário.

## 5. Considerações Adicionais
- O sistema é acessível apenas para usuários autenticados, garantindo que apenas pessoas autorizadas possam criar e gerenciar torneios.
- A estrutura de dados permite uma representação detalhada de torneios esportivos, incluindo a associação de equipes a etapas específicas e o registro de resultados.
- Os casos de uso descrevem as principais funcionalidades do sistema, desde a criação de torneios até o registro de resultados, proporcionando uma experiência completa de gerenciamento de torneios para os usuários.
