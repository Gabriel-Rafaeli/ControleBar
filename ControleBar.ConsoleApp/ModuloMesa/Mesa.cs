using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloConta;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public string Numero { get; set; }

        public Mesa(string numero)
        {
            Numero = numero;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizada = (Mesa)registroAtualizado;

            Numero = mesaAtualizada.Numero;
        }

        public override ArrayList Validar()
        {
            ArrayList listaErros = new ArrayList();

            if (string.IsNullOrEmpty(Numero.Trim()))
                listaErros.Add("O campo \"numero\" é obrigatório");

            return listaErros;
        }
    }
}
