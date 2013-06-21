using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CllLogicaNegocios
{
    public class Gestor
    {
        ClientePersist objClientePersist = new ClientePersist();
        
        public void registrar(String pnombre, int pedad, String ptelefono) 
        {
            try
            {
                objClientePersist.registrar(pnombre, pedad, ptelefono);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Array> listar() 
        {
            List<Array> datos = new List<Array>();
            List<Cliente> objsClientes;

            try 
            {
                objsClientes = objClientePersist.listar();
                foreach(Cliente objCliente in objsClientes)
                {
                    String[] campos = {objCliente.id.ToString(), objCliente.nombre.ToString(), objCliente.edad.ToString(), objCliente.telefono.ToString() };
                    datos.Add(campos);
                }
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

            return datos;
        }
    }
}
