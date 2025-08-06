# Weather Forecast API - Arquitetura Hexagonal

Este projeto foi refatorado para seguir a **Arquitetura Hexagonal** (também conhecida como Ports and Adapters), que promove a separação clara de responsabilidades e facilita a manutenibilidade e testabilidade do código.

## 📁 Estrutura do Projeto

```
WebApplication1/
├── Controllers/              # Web API Controllers (Adaptadores de Entrada)
├── Domain/                   # Camada de Domínio (Núcleo da aplicação)
│   ├── Entities/            # Entidades de negócio
│   ├── Repositories/        # Interfaces dos repositórios (Ports)
│   └── ValueObjects/        # Objetos de valor
├── Application/             # Camada de Aplicação (Casos de Uso)
│   ├── DTOs/               # Data Transfer Objects da aplicação
│   └── UseCases/           # Casos de uso da aplicação
├── Infrastructure/          # Camada de Infraestrutura (Adaptadores Externos)
│   └── Repositories/       # Implementações dos repositórios
└── WebApi/                 # DTOs específicos da API Web
    └── DTOs/
```

## 🏗️ Camadas da Arquitetura

### 1. **Domain** (Núcleo da Aplicação)

- **Entities**: Entidades de negócio que representam os conceitos principais
  - `WeatherForecast`: Entidade principal do domínio
- **Value Objects**: Objetos imutáveis que representam conceitos de valor
  - `Temperature`: Representa temperatura com validações
  - `WeatherSummary`: Representa os tipos de clima possíveis
- **Repositories**: Interfaces que definem os contratos para persistência
  - `IWeatherForecastRepository`: Interface para operações de dados

### 2. **Application** (Casos de Uso)

- **Use Cases**: Implementam os casos de uso da aplicação
  - `GetWeatherForecastUseCase`: Caso de uso para obter previsões do tempo
- **DTOs**: Objetos de transferência de dados da camada de aplicação
  - `WeatherForecastDto`: DTO para transferência de dados entre camadas

### 3. **Infrastructure** (Adaptadores Externos)

- **Repositories**: Implementações concretas das interfaces de repositório
  - `InMemoryWeatherForecastRepository`: Implementação em memória

### 4. **Controllers/WebApi** (Adaptadores de Entrada)

- **Controllers**: Controladores da API que recebem requisições HTTP
- **DTOs**: Objetos específicos para a camada de apresentação web

## 🔄 Fluxo de Dados

```
HTTP Request → Controller → Use Case → Repository → Database
                    ↓           ↓          ↓
               WebApi DTO → App DTO → Domain Entity
```

## 🎯 Benefícios da Arquitetura Hexagonal

1. **Separação de Responsabilidades**: Cada camada tem uma responsabilidade específica
2. **Testabilidade**: Fácil criação de testes unitários com mocks das interfaces
3. **Flexibilidade**: Mudanças na infraestrutura não afetam o domínio
4. **Manutenibilidade**: Código mais organizado e fácil de entender
5. **Evolução**: Permite adicionar novos adaptadores sem modificar o núcleo

## 🔧 Configuração da Injeção de Dependência

No `Program.cs`, as dependências são registradas seguindo o princípio de inversão de dependência:

```csharp
// Repositories (Infrastructure Layer)
builder.Services.AddSingleton<IWeatherForecastRepository, InMemoryWeatherForecastRepository>();

// Use Cases (Application Layer)
builder.Services.AddScoped<IGetWeatherForecastUseCase, GetWeatherForecastUseCase>();
```

## 🚀 Como Executar

```bash
cd WebApplication1
dotnet run
```

## 📝 Endpoints

- `GET /weatherforecast?days=5` - Retorna previsão do tempo para os próximos dias

## 🧪 Próximos Passos

1. Adicionar testes unitários para cada camada
2. Implementar novos repositórios (SQL Server, Cosmos DB, etc.)
3. Adicionar novos casos de uso (criar, atualizar, deletar previsões)
4. Implementar cache
5. Adicionar logging estruturado
