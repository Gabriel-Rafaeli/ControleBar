using ControleBar.ConsoleApp.ModuloConta;
using ControleBar.ConsoleApp.ModuloGarcom;
using ControleBar.ConsoleApp.ModuloMesa;
using ControleBar.ConsoleApp.ModuloProduto;
using System.Collections;

namespace ControleBar.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioGarcom repositorioGarcom = new RepositorioGarcom(new ArrayList());
            RepositorioMesa repositorioMesa = new RepositorioMesa(new ArrayList());
            RepositorioProduto repositorioProduto = new RepositorioProduto(new ArrayList());
            RepositorioConta repositorioConta = new RepositorioConta(new ArrayList());

            TelaGarcom telaGarcom = new TelaGarcom(repositorioGarcom);
            TelaMesa telaMesa = new TelaMesa(repositorioMesa);
            TelaProduto telaProduto = new TelaProduto(repositorioProduto);
            TelaConta telaConta = new TelaConta(repositorioConta, repositorioMesa, repositorioProduto, repositorioGarcom, telaGarcom, telaMesa, telaProduto);

            TelaPrincipal principal = new TelaPrincipal();

            #region//RegistrosCadastrados
            Produto produto0 = new Produto("vinho", 30);
            Produto produto1 = new Produto("bife", 20);
            Produto produto2 = new Produto("lamen", 20);
            Produto produto3 = new Produto("sopa", 10);
            repositorioProduto.Inserir(produto0);
            repositorioProduto.Inserir(produto1);
            repositorioProduto.Inserir(produto2);
            repositorioProduto.Inserir(produto3);

            Garcom garcom1 = new Garcom("Gandalf", "0123912492");
            Garcom garcom2 = new Garcom("Legolas", "0123912312");
            repositorioGarcom.Inserir(garcom1);
            repositorioGarcom.Inserir(garcom2);

            Mesa mesa1 = new Mesa("1");
            Mesa mesa2 = new Mesa("2");
            Mesa mesa3 = new Mesa("3");
            repositorioMesa.Inserir(mesa1);
            repositorioMesa.Inserir(mesa2);
            repositorioMesa.Inserir(mesa3);

            repositorioConta.Inserir(new Conta("123", mesa1, garcom1));
            repositorioConta.Inserir(new Conta("234", mesa2, garcom1));
            repositorioConta.Inserir(new Conta("345", mesa3, garcom2));
            #endregion

            while (true)
            {
                string opcao = principal.ApresentarMenu();

                if (opcao == "s")
                    break;

                if (opcao == "1")
                {
                    string subMenu = telaGarcom.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaGarcom.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaGarcom.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaGarcom.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaGarcom.ExcluirRegistro();
                    }
                }
                else if (opcao == "2")
                {
                    string subMenu = telaMesa.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaMesa.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaMesa.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaMesa.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaMesa.ExcluirRegistro();
                    }
                }
                else if (opcao == "3")
                {
                    string subMenu = telaProduto.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaProduto.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaProduto.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaProduto.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaProduto.ExcluirRegistro();
                    }
                }
                else if (opcao == "4")
                {
                    string subMenu = telaConta.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaConta.InserirNovoRegistro();
                    }
                    if(subMenu == "2") 
                    {
                        telaConta.ReceberPedido();
                    }
                    else if (subMenu == "3")
                    {
                        telaConta.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "4")
                    {
                        telaConta.EditarRegistro();
                    }
                    else if (subMenu == "5")
                    {
                        telaConta.ExcluirRegistro();
                    }
                    else if (subMenu == "6")
                    {
                        telaConta.MostrarValorPedidos();
                    }
                    else if (subMenu == "7") 
                    {
                        telaConta.MostrarContasAbertas();
                    }
                    else if(subMenu == "8") 
                    {
                        telaConta.MostrarTotalDia();
                    }
                    else if(subMenu== "9") 
                    {
                        telaConta.AlterarStatus();
                    }
                }
            }
        }
    }
}