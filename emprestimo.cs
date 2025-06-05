using System;

namespace ProjetoBiblioteca.Models
{
    public class Emprestimo
    {
        public Livro LivroEmprestado { get; set; }
        public Usuario Usuario { get; set; }
        public PeriodoEmprestimo Periodo { get; set; }
        public bool Finalizado => Periodo.DataDevolucao.HasValue;

        public Emprestimo(Livro livro, Usuario usuario)
        {
            LivroEmprestado = livro;
            Usuario = usuario;
            Periodo = new PeriodoEmprestimo
            {
                DataEmprestimo = DateTime.Now,
                DataDevolucao = null
            };
        }

        public void Devolver()
        {
            Periodo = new PeriodoEmprestimo
            {
                DataEmprestimo = Periodo.DataEmprestimo,
                DataDevolucao = DateTime.Now
            };
            LivroEmprestado.Quantidade++;
        }
    }
}
