# 🐙♾️💡 Doctopus - Gestão Interdisciplinar para Clínicas
> "O abraço completo que sua clínica e seus pacientes precisam."

**Um projeto acadêmico, utilizando a linguagem C# e o banco de dados MySQL**

![Badge .NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Badge WPF](https://img.shields.io/badge/WPF-Windows-blue?style=for-the-badge)
![Badge MySQL](https://img.shields.io/badge/MySQL-00000F?style=for-the-badge&logo=mysql&logoColor=white)

## 💻 Sobre o Projeto

O **Doctopus** é uma aplicação Desktop desenvolvida como Projeto Acadêmico, focada na gestão de clínicas de atendimento a pacientes com desenvolvimento atípico.

O diferencial do sistema é o foco na **atenção interdisciplinar**, permitindo que fonoaudiólogos, psicólogos e terapeutas ocupacionais compartilhem uma visão única da evolução do paciente, além de ferramentas específicas para o acolhimento sensorial.

### 🎯 Funcionalidades Principais

- **Gestão de Pacientes Humanizada:** Cadastro contendo não apenas dados médicos, mas perfil sensorial (interesses, restrições e hiperfocos).
- **Prontuário Interdisciplinar:** Registro de sessões com notas de participação (1 a 5) e descrição evolutiva.
- **Dashboard Visual:** Listagem rápida de pacientes com filtros de busca em tempo real.
- **Análise de Evolução (Gráficos):** Visualização gráfica do progresso do paciente ao longo das sessões (integração com LiveCharts).
- **Gestão de Equipe:** Cadastro de profissionais com identificação visual por cores (ex: Azul para Fono, Vermelho para Psico).

---
## 📸 Capturas de Tela

| Dashboard Principal | Histórico e Gráficos |
|:-------------------:|:--------------------:|
| <img width="972" height="654" alt="Captura de tela 2025-11-30 140632" src="https://github.com/user-attachments/assets/fb2147b9-54c4-40c0-b0a8-de5ef696245b" /> | <img width="858" height="642" alt="Captura de tela 2025-11-30 140701" src="https://github.com/user-attachments/assets/de95d72b-2b74-4561-8393-794b6e810e7a" /> |

| Cadastro de Paciente | Registro de Evolução |
|:--------------------:|:--------------------:|
| <img width="455" height="594" alt="Captura de tela 2025-11-30 140645" src="https://github.com/user-attachments/assets/e2a671a8-0b87-4ddd-83e5-0a1737027b97" /> | <img width="856" height="620" alt="Captura de tela 2025-11-30 141220" src="https://github.com/user-attachments/assets/58ba6235-d825-493b-9c31-84bebd630227" /> |

---

## 🛠 Tecnologias Utilizadas

O projeto foi desenvolvido utilizando as seguintes tecnologias:

- **Linguagem:** C# (.NET 6/8)
- **Framework Visual:** WPF (Windows Presentation Foundation)
- **Banco de Dados:** MySQL (via XAMPP)
- **ORM:** Entity Framework Core
- **Design:** MaterialDesignInXamlToolkit (Google Material Design para WPF)
- **Gráficos:** LiveCharts.Wpf

---

## 🚀 Como Executar o Projeto

### Pré-requisitos
Para rodar o projeto, você precisará ter instalado:
1.  [Visual Studio 2022](https://visualstudio.microsoft.com/) (Com a carga de trabalho ".NET Desktop Development").
2.  [XAMPP](https://www.apachefriends.org/) (Para rodar o servidor MySQL localmente).

### Passo a Passo

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/SEU-USUARIO/Doctopus.git](https://github.com/SEU-USUARIO/Doctopus.git)
    ```

2.  **Configure o Banco de Dados:**
    * Abra o painel do **XAMPP** e inicie os módulos **Apache** e **MySQL**.
    * A conexão padrão configurada no projeto é `server=localhost;user=root;password=;database=doctopus_db`.
    * Caso seu MySQL tenha senha, altere o arquivo `Data/AppDbContext.cs`.

3.  **Execute as Migrations (Criar Tabelas):**
    * Abra o projeto no Visual Studio.
    * Vá em `Ferramentas > Gerenciador de Pacotes do NuGet > Console do Gerenciador`.
    * Execute o comando:
      ```powershell
      Update-Database
      ```
    * Isso criará o banco `doctopus_db` e todas as tabelas automaticamente.

4.  **Inicie a Aplicação:**
    * Aperte `F5` ou clique no botão "Iniciar" no Visual Studio.

---

## 📂 Estrutura do Projeto


 ```bash
Doctopus/
├── Data/ # Contexto do Banco de Dados (EF Core)
├── Models/ # Classes (Paciente, Profissional, Evolucao)
├── Views/ # Telas (XAML) do Sistema
│ ├── CadastroPaciente.xaml
│ ├── HistoricoPaciente.xaml
│ └── ...
├── Migrations/ # Histórico de versões do Banco de Dados
└── MainWindow.xaml # Tela Principal (Dashboard)
````
---

## 👨‍💻 Autor

Desenvolvido por **IsaqueR02** como requisito para a disciplina de **Criação de Aplicações com Templates e Banco de Dados**.

Entre em contato!
* [LinkedIn](https://www.linkedin.com/in/isaque-roberto-zulato-henriques/)
* [Email](mailto:isaquezulato@gmail.com)

---
