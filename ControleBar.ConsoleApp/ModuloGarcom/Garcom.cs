using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloGarcom
{
    public class Garcom : EntidadeBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }


        public Garcom(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Garcom garcomAtualizado = (Garcom)registroAtualizado;

            Nome = garcomAtualizado.Nome;
            Cpf = garcomAtualizado.Cpf;
        }

        public override ArrayList Validar()
        {
            ArrayList listaErros = new ArrayList();

            if (string.IsNullOrEmpty(Nome.Trim()))
                listaErros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Cpf.Trim()))
                listaErros.Add("O campo \"CPF\" é obrigatório");

            return listaErros;
        }
    }
}
