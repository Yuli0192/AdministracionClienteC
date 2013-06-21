using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CllAccesoDatos;
namespace CllLogicaNegocios
{
   public class ClientePersist
    {
       AccesoDatos accesoDatos = new AccesoDatos();

       public void registrar(String pnombre, int pedad, String ptelefono) 
       {
           try 
           {
               accesoDatos.registrar(pnombre, pedad, ptelefono);
           }catch(Exception ex)
           {
               throw new Exception(ex.Message);
           }
       }

       public List<Cliente> listar() 
       {
           List<Cliente> objsClientes = new List<Cliente>();
           IDataReader datos;

           try
           {
               datos = accesoDatos.listar();
               while(datos.Read())
               {
                   objsClientes.Add(new Cliente(datos.GetInt32(0), datos.GetString(1), datos.GetInt32(2), datos.GetString(3)));
               }
           }
           catch (Exception ex) 
           {
               throw new Exception(ex.Message);
           }
           datos.Close();
           return objsClientes;
       }
    }
}
