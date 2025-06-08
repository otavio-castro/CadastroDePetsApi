# Cadastro de Pets API 🐾

Este projeto é uma API REST desenvolvida com **ASP.NET Core** e **.NET 8**, que gerencia o cadastro de animais e seus respectivos proprietários.  
O diferencial é que os dados são armazenados em **arquivos XML**, eliminando a necessidade de um banco de dados relacional.  
Ideal para fins educacionais, testes locais e projetos leves.

---

## 👨‍👩‍👧‍👦 Integrantes do Grupo

- Moises Samuel  
- Sarah Palhares  
- Gustavo Rodrigues  
- Otavio Nascimento  
- Lucas De Jesus  

---

## ✔️ Tecnologias Utilizadas

- ✅ .NET 8  
- ✅ ASP.NET Core Web API  
- ✅ Serialização XML com `System.Xml.Serialization`  
- ✅ Injeção de dependência (`AddScoped`)  
- ✅ Separação por camadas: `Models`, `DTOs`, `Services`, `Context`, `Controllers`  

---

## 🚀 Como Executar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### Passos

1. Clone o repositório:

   ```bash
   git clone https://github.com/seu-usuario/CadastroDePetsApi.git
   cd CadastroDePetsApi
   ```

2. Execute a aplicação:

   ```bash
   dotnet run
   ```

3. A API estará disponível em:

   - https://localhost:5001  
   - http://localhost:5000  

---

## 📂 Armazenamento XML

Os dados de animais e proprietários são salvos e carregados de arquivos `.xml`.  
A classe `AppXmlContext` realiza a serialização e desserialização automaticamente, utilizando genéricos e `XmlSerializer`.

---

## 🤝 Contribuições

Contribuições são bem-vindas!  
Abra uma *issue* ou *pull request* para melhorias ou sugestões.