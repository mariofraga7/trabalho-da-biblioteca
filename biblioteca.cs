using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoBiblioteca.Models
{
    public class Biblioteca
    {
        public List<Livro> Livros { get; private set; } = new List<Livro>();
        public List<Usuario> Usuarios { get; private set; } = new List<Usuario>();
        public List<Emprestimo> Emprestimos { get; private set; } = new List<Emprestimo>();

        public void CadastrarLivro(string titulo, string autor, string isbn, int quantidade)
        {
            Livros.Add(new Livro(titulo, autor, isbn, quantidade));
        }

        public void CadastrarUsuario(string nome, string matricula)
        {
            Usuarios.Add(new Usuario(nome, matricula));
        }

        public void RegistrarEmprestimo(string isbn, string matricula)
        {
            var livro = Livros.FirstOrDefault(l => l.ISBN == isbn && l.Quantidade > 0);
            var usuario = Usuarios.FirstOrDefault(u => u.Matricula == matricula);

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado ou sem estoque.");
                return;
            }

            if (usuario == null)
            {
                Console.WriteLine("Usuário não encontrado.");
                return;
            }

            livro.Quantidade--;
            Emprestimos.Add(new Emprestimo(livro, usuario));
            Console.WriteLine("Empréstimo registrado com sucesso.");
        }

        public void RegistrarDevolucao(string isbn, string matricula)
        {
            var emprestimo = Emprestimos
                .Where(e => e.LivroEmprestado.ISBN == isbn &&
                            e.Usuario.Matricula == matricula &&
                            !e.Finalizado)
                .FirstOrDefault();

            if (emprestimo == null)
            {
                Console.WriteLine("Empréstimo não encontrado.");
                return;
            }

            emprestimo.Devolver();
            Console.WriteLine("Devolução registrada com sucesso.");
        }

        public void ListarLivros()
        {
            Console.WriteLine("Lista de livros:");
            foreach (var livro in Livros)
            {
                Console.WriteLine($"{livro.Titulo} - {livro.Autor} | ISBN: {livro.ISBN} | Disponível: {livro.Quantidade}");
            }
        }

        public void ExibirRelatorios()
        {
            Console.WriteLine("\nLivros emprestados:");
            foreach (var e in Emprestimos.Where(e => !e.Finalizado))
            {
                Console.WriteLine($"{e.LivroEmprestado.Titulo} - para {e.Usuario.Nome}");
            }

            Console.WriteLine("\nLivros disponíveis:");
            foreach (var livro in Livros.Where(l => l.Quantidade > 0))
            {
                Console.WriteLine($"{livro.Titulo} | Quantidade: {livro.Quantidade}");
            }

            Console.WriteLine("\nUsuários com livros emprestados:");
            var usuariosComLivros = Emprestimos
                .Where(e => !e.Finalizado)
                .Select(e => e.Usuario.Nome)
                .Distinct();

            foreach (var nome in usuariosComLivros)
            {
                Console.WriteLine(nome);
            }
        }
    }
}
