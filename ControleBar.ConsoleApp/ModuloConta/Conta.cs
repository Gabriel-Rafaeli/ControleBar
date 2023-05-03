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
    public class Conta : EntidadeBase
    {
        public string Codigo { get; set; }
        public string Status { get; set; }
        public ArrayList Pedidos { get; set; }
        public Mesa Mesa { get; set; }
        public Garcom Garcom { get; set; }
        public DateTime DataDoPedido { get; set; }

        public Conta(string codigo, Mesa mesa, Garcom garcom)
        {
            Codigo = codigo;
            Mesa = mesa;
            Garcom = garcom;
            Status = "ABERTO";
            Pedidos = new ArrayList();
            DataDoPedido = DateTime.Now.Date;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Conta contaAtualizada = (Conta)registroAtualizado;

            Codigo = contaAtualizada.Codigo;
        }

        public override ArrayList Validar()
        {
            ArrayList listaErros = new ArrayList();

            if (string.IsNullOrEmpty(Codigo))
            {
                listaErros.Add("O campo \"Codigo\" é obrigatório");
            }
            return listaErros;
        }

        public void AdicionarPedido(Produto produto, double quantidade) 
        {
            Pedido pedido = new Pedido(produto, quantidade);
            Pedidos.Add(pedido);
        }

        public double CalcularPedidos()
        {
            double pedidosCalculados = 0;

            foreach (Pedido p in Pedidos)
            {
                pedidosCalculados = p.CalcularPedido();
            }
            return pedidosCalculados;
        }
    }
}
