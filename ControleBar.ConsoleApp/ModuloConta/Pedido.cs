using ControleBar.ConsoleApp.Compartilhado;
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
    public class Pedido 
    {
        public Produto Produto { get; set; }
        public double Quantidade { get; set; }

        public Pedido(Produto produto, double quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
        }

        public double CalcularPedido() 
        {
            double pedidoCalculado = Quantidade * Produto.Preco;
            return pedidoCalculado;
        }
    }
}
