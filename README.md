# trabalho-da-biblioteca
projeto simples com c#
Projeto Biblioteca
Este é um sistema de gerenciamento de biblioteca simples feito em C# para controle de livros, usuários e empréstimos.

 Funcionalidades
Cadastro de livros com título, autor, ISBN e quantidade.

Cadastro de usuários com nome e matrícula.

Registro de empréstimos de livros para usuários.

Registro de devoluções de livros.

Relatórios sobre:

Livros emprestados.

Livros disponíveis.

Usuários com livros em posse.

Estrutura do Projeto

ProjetoBiblioteca

. Program.cs                      
. Models/
.  Biblioteca.cs               
.  Livro.cs                    
.  Usuario.cs                  
.  Pessoa.cs                    
.  Emprestimo.cs               
.  PeriodoEmprestimo.cs 

Como executar
Clone o repositório:git clone https://github.com/mariofraga7/projeto-biblioteca.git

Compile e execute:dotnet run

Exemplo de uso

    MENU 
1. Cadastrar Livro
2. Cadastrar Usuário
3. Registrar Empréstimo
4. Registrar Devolução
5. Listar Livros
6. Exibir Relatórios
0. Sair
   
 Requisitos
.NET SDK instalado (versão 6.0 ou superior recomendada)
