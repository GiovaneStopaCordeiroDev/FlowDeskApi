# FlowDesk API

API REST para gerenciamento de chamados, empresas e usuários, construída com ASP.NET Core, Entity Framework Core e PostgreSQL.

## Configuração local

Configure as variáveis de ambiente antes de iniciar a API:

```powershell
$env:ConnectionStrings__FlowDeskConnection = "Host=localhost;Port=5432;Database=FlowDeskDb;Username=postgres;Password=sua-senha"
$env:Jwt__Secret = "gere-uma-chave-secreta-com-pelo-menos-32-caracteres"
dotnet run --project "FlowDesk(API)/FlowDesk(API).csproj"
```

O Swagger/OpenAPI fica disponível no ambiente de desenvolvimento. Nunca publique valores reais de conexão ou chaves JWT.
