using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloGarcom
{
    public class RepositorioGarcom : RepositorioBase
    {
        public RepositorioGarcom(ArrayList listaGarcom)
        {
            this.listaRegistros = listaGarcom;
        }
    }
}
