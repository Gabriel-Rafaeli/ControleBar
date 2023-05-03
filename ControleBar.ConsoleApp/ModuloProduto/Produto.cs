using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloProduto
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; set; }
        public double Preco { get; set; }

        public Produto(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Produto produtoAtualizado = (Produto)registroAtualizado;

            Nome = produtoAtualizado.Nome;
            Preco = produtoAtualizado.Preco;
        }

        public override ArrayList Validar()
        {
            ArrayList listaErros = new ArrayList();
            if (string.IsNullOrEmpty(Nome))
            {
                listaErros.Add("O campo \"nome\" é obrigatório");
            }
            return listaErros;
        }
    }
}
