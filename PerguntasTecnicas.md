# Teste para WAY2

# Para Rodar
**Para a API Football.Api**
- No diretório Football.Api rodar o comando **dotnet run** ou abrir no Visual Studio e rodar

**Para o projeto Football.Web**

 - Rodar o mando ***npm install*** para instalar as dependências 
 - Rodar o comando ***ng serve*** para subir a aplicação que ficará acessível no endereço **http://localhost:4200**


# PerguntasTecnicas
 - Quanto tempo você usou para completar a solução apresentada? Em torno de 6 horas.

 - O que você faria se tivesse mais tempo? Usaria mais patterns e abstrações, Talves usasse um framework SPA mais leve como Vue.js, mas como queria garantir a entrega e não perder tempo com a curva de aprendizagem optei pelo Angular que domino totalmente.

 - Se usou algum framework javascript ou c#, qual foi o motivo de ter usado este? Caso contrário, por que não utilizou nenhum? Usei várias coisas: No front optei por utilizar angular-cli para ter um start mais rápido do projeto é começar logo a codificar. O único pacote extra foi o bootstrap para dar uma "cara" melhor para a APP. No BackEnd usei várias coisas: como DDD por padrão de projeto, Xunit para os teste, AutoMapper para mapeamento de objetos, Swagger para documentar as APIS, .NET Core 2.0 para os projetos backend.

 - Descreva você mesmo utlizando json: 
```json
{
  "name": "Allan Weber",
  "age": 34,
  "address":[
    {
      "city": "Porto Alegre",
      "state": "RS"
    } 
  ],
  "maritalStatus": "Casado",
  "children": [],
  "recreation": [
    "Filmes",
    "PS4",
    "RPG de Mesa",
    "Codar",
    "Estudar",
    "Cevas artesanais"
  ],
  "techSkils": [
    {
      "name": ".NET Core",
      "level": "80"
    },
    {
      "name": "Angular",
      "level": "90"
    },
    {
      "name": "Node.Js",
      "level": "50"
    },
    {
      "name": "Git",
      "level": "80"
    },
    {
      "name": "C#",
      "level": "100"
    }
  ],
  "foods": [
    "Massa",
    "Churrasco",
    "Hamburguer"
  ],
  "behavior":[
    "amigável",
    "gosta de ajudar e ensinar",
    "ser desafiado sempre",
    "persistente"
  ]
}
```
