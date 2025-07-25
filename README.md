﻿# Cadastro de Pets API 🐾

Este projeto é uma API REST desenvolvida com **ASP.NET Core** e **.NET 8**, que gerencia o cadastro de animais e seus respectivos proprietários.  
O diferencial é que os dados são armazenados em **arquivos XML**, eliminando a necessidade de um banco de dados relacional.  
Ideal para fins educacionais, testes locais e projetos leves.

---

## 👨‍👩‍👧‍👦 Integrantes do Grupo

- Breno Viana
- Gustavo Rodrigues  
- Moises Samuel  
- Lucas De Jesus  
- Otavio Nascimento
- Sarah Palhares  

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

1. Clonar o repositório:

   ```bash
   git clone https://github.com/otavio-castro/CadastroDePetsApi.git
   cd CadastroDePetsApi
   ```

2. Baixar os pacotes:

   ```bash
   dotnet restore
   ```

3. Executar a aplicação:

   ```bash
   dotnet run
   ```

4. A API estará disponível localmente.

---

## 📂 Armazenamento XML

Os dados de animais e proprietários são salvos e carregados de arquivos `.xml`.  
A classe `AppXmlContext` realiza a serialização e desserialização automaticamente, utilizando genéricos e `XmlSerializer`.

---

## 🤝 Contribuições

Contribuições são bem-vindas!  
Abra uma *issue* ou *pull request* para melhorias ou sugestões.