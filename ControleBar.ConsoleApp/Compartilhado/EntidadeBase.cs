using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase
    {
        public int Id;

        public abstract void AtualizarInformacoes(EntidadeBase registroAtualizado);

        public abstract ArrayList Validar();

    }
}

