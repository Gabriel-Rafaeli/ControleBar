using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloGarcom
{
    public class TelaGarcom : TelaBase
    {

        public TelaGarcom(RepositorioGarcom repositorioGarcom)
        {
            this.repositorioBase = repositorioGarcom;
            nomeEntidade = "Garçom";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}|", "Id", "Nome", "CPF");

            Console.WriteLine("----------------------------------------------------");

            foreach (Garcom garcom in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}|", garcom.Id, garcom.Nome, garcom.Cpf);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine();

            return new Garcom(nome, cpf);
        }
    }
}
