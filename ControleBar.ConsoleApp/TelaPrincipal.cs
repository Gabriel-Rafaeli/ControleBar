using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp
{
    public class TelaPrincipal
    {
        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("GerenciamentoBar de Bar 1.0\n");

            Console.WriteLine("Digite 1 para Gerenciar Garçons");
            Console.WriteLine("Digite 2 para Gerenciar Mesas");
            Console.WriteLine("Digite 3 para Gerenciar Produtos");
            Console.WriteLine("Digite 4 para Gerenciar Contas");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}
