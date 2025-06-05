# 🏨 RESERVA FÁCIL - Sistema de Reservas de Hotel DIO 🗝️

```
██████╗ ███████╗███████╗██████╗ ███████╗ █████╗     ███████╗ █████╗  ██████╗██╗██╗
██╔══██╗██╔════╝██╔════╝██╔══██╗██╔════╝██╔══██╗    ██╔════╝██╔══██╗██╔════╝██║██║
██████╔╝█████╗  █████╗  ██████╔╝█████╗  ███████║    █████╗  ███████║██║     ██║██║
██╔══██╗██╔══╝  ██╔══╝  ██╔══██╗██╔══╝  ██╔══██║    ██╔══╝  ██╔══██║██║     ╚═╝╚═╝
██║  ██║███████╗███████╗██║  ██║███████╗██║  ██║    ██║     ██║  ██║╚██████╗██╗██╗
╚═╝  ╚═╝╚══════╝╚══════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝    ╚═╝     ╚═╝  ╚═╝ ╚═════╝╚═╝╚═╝
```

Sistema de reservas de hotel desenvolvido como desafio da DIO, com interface de console interativa, validações e visual retrô!

## ✨ Funcionalidades

- Cadastro de hóspedes durante a reserva
- Seleção automática de suítes compatíveis
- Validação de datas, nomes e capacidade
- Cálculo automático do valor total (com desconto para estadias longas)
- Exibição de resumo e detalhes da reserva
- Interface com ASCII art e emojis para uma experiência divertida

## 🚀 Como executar

1. Clone o repositório
2. Abra a pasta `trilha-net-explorando-desafio` no VS Code ou terminal
3. Execute:
   ```bash
   dotnet run
   ```

## 📝 Exemplo de uso

```
╔══════════════════════════════════════════════════════════════╗
║   🏨 RESERVA FÁCIL - Sistema de Reservas de Hotel DIO 🗝️   ║
╚══════════════════════════════════════════════════════════════╝
Bem-vindo ao sistema de reservas de hospedagem!
1 - Realizar reserva
2 - Exibir informações da reserva
3 - Sair
Escolha uma opção: 1
Quantos hóspedes deseja cadastrar? 2
Digite o nome completo do hóspede 1 (nome e sobrenome): Maria Silva
Digite o nome completo do hóspede 2 (nome e sobrenome): João Souza
Suítes disponíveis:
1 - Standard (Capacidade: 2, Valor diária: R$ 100,00)
2 - Premium (Capacidade: 4, Valor diária: R$ 180,00)
3 - Master (Capacidade: 6, Valor diária: R$ 250,00)
Escolha o número da suíte desejada: 1
Quantos dias de estadia? 5
Data de entrada (formato dd/MM/yyyy, não pode ser hoje): 10/06/2025

--- RESUMO DA RESERVA ---
Data de entrada: 10/06/2025
Dias reservados: 5
Suíte: Standard (Capacidade: 2)
Valor diária: R$ 100,00
Hóspedes:
- MARIA SILVA
- JOÃO SOUZA
Valor total: R$ 500,00
-------------------------
```

## 📚 Regras de negócio

- Não é possível reservar uma suíte para mais hóspedes do que sua capacidade
- O valor total é calculado multiplicando os dias pelo valor da diária
- Reservas de 10 dias ou mais recebem 10% de desconto
- Não é permitido reservar para o dia atual ou datas passadas

## 🏆 Aprendizados

- Manipulação de listas e objetos em C#
- Validação de entrada do usuário
- Uso de propriedades, construtores e métodos
- Interface de console com ASCII art

## 📢 Créditos

Desafio proposto pela [DIO](https://www.dio.me/) na Trilha .NET

---

> "A melhor forma de aprender é praticando!"
