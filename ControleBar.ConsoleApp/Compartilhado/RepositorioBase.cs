using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.Compartilhado
{
    public abstract class RepositorioBase
    {
        public ArrayList listaRegistros;
        protected int contadorRegistros = 0;

        public virtual void Inserir(EntidadeBase registro)
        {
            contadorRegistros++;

            registro.Id = contadorRegistros;

            listaRegistros.Add(registro);
        }

        public virtual void Editar(int id, EntidadeBase registroAtualizado)
        {
            EntidadeBase registroSelecionado = SelecionarPorId(id);

            registroSelecionado.AtualizarInformacoes(registroAtualizado);
        }

        public virtual void Excluir(int id)
        {
            EntidadeBase registroSelecionado = SelecionarPorId(id);

            listaRegistros.Remove(registroSelecionado);
        }

        public virtual EntidadeBase SelecionarPorId(int id)
        {
            EntidadeBase registroSelecionado = null;

            foreach (EntidadeBase registro in listaRegistros)
            {
                if (registro.Id == id)
                {
                    registroSelecionado = registro;
                    break;
                }
            }

            return registroSelecionado;
        }

        public virtual ArrayList SelecionarTodos()
        {
            return listaRegistros;
        }

        public bool TemRegistros()
        {
            return listaRegistros.Count > 0;
        }
    }
}
