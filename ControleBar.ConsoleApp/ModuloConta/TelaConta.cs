using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloGarcom;
using ControleBar.ConsoleApp.ModuloMesa;
using ControleBar.ConsoleApp.ModuloProduto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloConta
{
    public class TelaConta : TelaBase
    {
        RepositorioConta repositorioConta = null;
        RepositorioMesa repositorioMesa = null;
        RepositorioProduto repositorioProduto = null;
        RepositorioGarcom repositorioGarcom = null;
        TelaMesa telaMesa = null;
        TelaGarcom telaGarcom = null;
        TelaProduto telaProduto = null;
        public TelaConta(RepositorioConta repositorioConta, RepositorioMesa repositorioMesa, RepositorioProduto repositorioProduto, RepositorioGarcom repositorioGarcom, TelaGarcom telaGarcom, TelaMesa telaMesa, TelaProduto telaProduto)
        {
            this.repositorioMesa = repositorioMesa;
            this.repositorioConta = repositorioConta;
            this.repositorioBase = repositorioConta;
            this.repositorioProduto = repositorioProduto;
            this.repositorioGarcom = repositorioGarcom;
            this.telaGarcom = telaGarcom;
            this.telaMesa = telaMesa;
            this.telaProduto = telaProduto;
            nomeEntidade = "Conta";
            sufixo = "s";
        }

        public override string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo} \n");

            Console.WriteLine($"Digite 1 para Inserir {nomeEntidade}");
            Console.WriteLine($"Digite 2 para inserir um pedido");
            Console.WriteLine($"Digite 3 para Visualizar {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 4 para Editar {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 5 para Excluir {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 6 para Calcular os Pedidos da Conta");
            Console.WriteLine($"Digite 7 para vizualizar as contas em Aberto");
            Console.WriteLine($"Digite 8 para calcular a fatura do dia");
            Console.WriteLine($"Digite 9 para Fechar uma conta.\n");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}| {3, -20}|{4, -20}|", "Id", "Codigo", "Mesa", "Garçom", "Status");

            Console.WriteLine("----------------------------------------------------------------------------------------");

            foreach (Conta conta in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}|{3, -20}|{4, -20}|", conta.Id, conta.Codigo, conta.Mesa.Numero, conta.Garcom.Nome, conta.Status);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o codigo da conta: ");
            string codigo = Console.ReadLine();

            Console.WriteLine("\n");
            telaMesa.VisualizarRegistros(false);

            Console.WriteLine("\nDigite o Id da mesa que a conta pertence: ");
            int idMesa = int.Parse(Console.ReadLine());

            Console.WriteLine("\n");
            telaGarcom.VisualizarRegistros(false);

            Console.WriteLine("\nDigite o Id do garçom que recebeu a conta: ");
            int idGarcom = int.Parse(Console.ReadLine());

            Mesa mesa = (Mesa)repositorioMesa.SelecionarPorId(idMesa);
            Garcom garcom = (Garcom)repositorioGarcom.SelecionarPorId(idGarcom);

            return new Conta(codigo, mesa, garcom);
        }

        public void AlterarStatus()
        {
            int idFechar = EncontrarId();

            Conta conta = null;

            foreach (Conta c in repositorioConta.listaRegistros)
            {
                if (idFechar == c.Id)
                {
                    conta = c;
                }
            }
            repositorioConta.FecharStatus(conta);
            MostrarMensagem("Conta Fechada com Sucesso !", ConsoleColor.Green);
        }

        public void ReceberPedido() 
        {
            VisualizarRegistros(false);

            Console.WriteLine("\nDigite o Id da conta: ");
            int id = int.Parse(Console.ReadLine());
            Conta conta = (Conta)repositorioBase.SelecionarPorId(id);

            Console.WriteLine("\n");
            telaProduto.VisualizarRegistros(false);

            Console.WriteLine("\nDigite o Id do produto desejado: ");
            int idProduto = int.Parse(Console.ReadLine());

            Produto produto = (Produto)repositorioProduto.SelecionarPorId(idProduto);

            Console.WriteLine("\nDigite a quantidade: ");
            double quantidade = double.Parse(Console.ReadLine());

            conta.AdicionarPedido(produto, quantidade);
        }

        public void MostrarValorPedidos() 
        {
            VisualizarRegistros(false);

            Console.WriteLine("\nDigite o Id da conta para calcular os pedidos: ");
            int idConta = int.Parse(Console.ReadLine());

            VisualizarRegistros(false);
            Conta conta = (Conta)repositorioConta.SelecionarPorId(idConta);

            double pedidosCalculados = conta.CalcularPedidos();

            Console.WriteLine($"O valor total dos pedidos é: {pedidosCalculados}"); 

            Console.ReadLine();
        }

        public void MostrarContasAbertas()
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}| {3, -20}|{4, -20}|", "Id", "Codigo", "Mesa", "Garçom", "Status");

            Console.WriteLine("---------------------------------------------------------------------------------------");

            foreach (Conta c in repositorioConta.listaRegistros)
            {
                if (c.Status == "ABERTO")
                {
                    Console.WriteLine("{0, -10} | {1, -20} | {2, -20}|{3, -20}|{4, -20}|", c.Id, c.Codigo, c.Mesa.Numero, c.Garcom.Nome, c.Status);
                }
            }
            Console.ReadLine();
        }

        public void MostrarTotalDia() 
        {
            double total = repositorioConta.CalcularPedidosDoDia();
            Console.WriteLine($"O total faturado do dia foi ${total}");
            Console.ReadLine();
        }
    }
}
