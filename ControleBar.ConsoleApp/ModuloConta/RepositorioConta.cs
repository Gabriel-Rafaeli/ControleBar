using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloConta
{
    public class RepositorioConta : RepositorioBase
    {
        public RepositorioConta(ArrayList listaConta)
        {
            this.listaRegistros = listaConta;
        }

        public void FecharStatus(Conta conta)
        {
            conta.Status = "FECHADO";
        }

        public double CalcularPedidosDoDia() 
        {
            double totalDia = 0;

            foreach (Conta c in listaRegistros)
            {
                if (c.DataDoPedido == DateTime.Now.Date)
                {
                    totalDia += c.CalcularPedidos(); 
                }
            }
            return totalDia;
        }  
    }
}
