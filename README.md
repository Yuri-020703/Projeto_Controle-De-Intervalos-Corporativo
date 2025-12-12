# 📊 Controle de Intervalos Corporativos

Este projeto foi desenvolvido com foco na **prática do ORM Entity Framework Core**, utilizando o banco de dados **SQLite** para registrar e gerenciar os horários de pausas durante o expediente corporativo.

## 🚀 Tecnologias Utilizadas

- 💻 **C#**  
- 🛠️ **.NET Core
- 🗃️ **Entity Framework Core**  
- 🧱 **SQLite**  
- 🖥️ **Console Application**

## 📌 Objetivo

O objetivo principal é permitir o registro de diferentes tipos de **intervalos corporativos** de forma simples, prática e persistente. A ideia é aplicar conceitos de banco de dados com EF Core, como:

- Mapeamento de entidades com Data Annotations (`[Key]`, `[DatabaseGenerated]`, etc)  
- Criação e configuração de um contexto (`DbContext`)  
- Uso do SQLite como banco local simples e leve  
- Operações básicas de **CRUD** (registrar, consultar e remover intervalos)

## 📋 Funcionalidades

- Registrar **3 tipos de pausa**:  
  - ☕ Café da Manhã – 30 minutos  
  - 🍽️ Almoço – 1h30  
  - ☕ Café da Tarde – 15 minutos  
- Listar todos os intervalos registrados  
- Remover um registro específico por ID  
- Persistência local dos dados com banco `.db`

## 🧠 Lógica Principal

O sistema roda em um `while` que apresenta opções para o usuário via terminal. A cada escolha, a aplicação interage com o banco de dados usando EF Core:

```csharp
Intervalo pausa = new Intervalo(DateTime.Now);
pausa.PausaAlmoço(); // ou outro tipo
db.Intervalos.Add(pausa);
db.SaveChanges();
