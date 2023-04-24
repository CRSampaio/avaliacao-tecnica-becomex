# R.O.B.O
API Restful para controlar o R.O.B.O + Interface gráfica que consumirá a API para exibir o estado do Robô

## Tecnologias e bibliotecas
- Web API Restful
  - NET 7.0
    - Entity Framework Core 7.0
    - Microsoft.Extensions.DependencyInjection 7.0
    - Microsoft.EntityFrameworkCore.InMemory 7.0.5
    - NUnit 3.13.3
- Frontend    
  - NodeJS v18.15
    - LiteServer 2.6.1
  - Bootstrap 5.2.3

## Como subir o projeto
- Primeiro, suba a WebAPI dentro de src/api utilizando o comando: `dotnet run --project RoboAPI.WebAPI`
- Depois, caso queira consultar a interface gráfica, dentro de src/webapp, rode: `npm install` e depois: `npm run start`

## Observação
Os arquivos de build estão sendo subidos junto ao projeto, para caso o projeto seja executado em alguma rede com restrições de acesso e não consiga baixar as dependências do Nuget ou NPM.