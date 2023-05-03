using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloProduto
{
    public class TelaProduto : TelaBase
    {
        RepositorioProduto repositorioProduto = null;

        public TelaProduto(RepositorioProduto repositorioProduto)
        {
            this.repositorioProduto = repositorioProduto;
            this.repositorioBase = repositorioProduto;
            nomeEntidade = "Produto";
            sufixo = "s";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} |", "Id", "Nome", "Preço");

            Console.WriteLine("--------------------------------------------------------");

            foreach (Produto produto in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} |", produto.Id, produto.Nome, produto.Preco);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome do produto: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o preço do produto: ");
            double preco = double.Parse(Console.ReadLine());

            return new Produto(nome, preco);
        }


    }
}
