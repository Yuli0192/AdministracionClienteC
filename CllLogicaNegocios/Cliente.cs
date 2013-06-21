using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CllLogicaNegocios
{
    public class Cliente
    {
        public int id {get; set; }
        public String nombre { get; set; }
        public int edad { get; set; }
        public String telefono { get; set; }

        public Cliente(int pid, String pnombre, int pedad, String ptelefono) 
        {
            id = pid;
            nombre = pnombre;
            edad = pedad;
            telefono = ptelefono;
        }
    }
}
