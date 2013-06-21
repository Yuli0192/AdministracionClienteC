using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace CllAccesoDatos
{
   public class AccesoDatos
    {
        static SqlConnection conn = new SqlConnection("Initial Catalog=BDPrueba;Data Source=YULI-PC;Integrated Security=True;");
        static SqlCommand comm;
        String sql;
        public void registrar(String pnombre, int pedad, String ptelefono) 
        {
            sql = "INSERT INTO TEmpleado(Nombre,Edad,Telefono) ";
            sql += "VALUES('" + pnombre + "', " + pedad + ", '" + ptelefono + "') ";

            comm = new SqlCommand(sql,conn);

            try
            {
                if(conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                comm.ExecuteNonQuery();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            comm.Connection.Close();
        }

        public IDataReader listar() 
        {
            IDataReader result;
            sql = "SELECT E.ID, E.Nombre, E.Edad, E.Telefono  FROM TEmpleado E";

            comm = new SqlCommand(sql, conn);
            try 
            {
                if(conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                result = comm.ExecuteReader();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

    }
}
