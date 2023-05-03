using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloMesa
{
    public class TelaMesa : TelaBase
    {
        public TelaMesa(RepositorioMesa repositorioMesa)
        {
            this.repositorioBase = repositorioMesa;
            nomeEntidade = "Mesa";
            sufixo = "s";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} |", "Id", "Numero Da Mesa");

            Console.WriteLine("--------------------------------------");

            foreach (Mesa mesa in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} |", mesa.Id, mesa.Numero);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o numero da mesa: ");
            string numero = Console.ReadLine();

            return new Mesa(numero);
        }
    }
}
