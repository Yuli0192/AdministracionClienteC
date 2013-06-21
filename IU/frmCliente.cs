using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CllLogicaNegocios;
namespace IU
{
    public partial class frmCliente : Form
    {
        Gestor gestor = new Gestor();
        public frmCliente()
        {
            InitializeComponent();
        }

        private void bntRegistrar_Click(object sender, EventArgs e)
        {
            String nombre = txttNombre.Text;
            int edad = Convert.ToInt32(txtEdad.Text);
            String telefono = txtTelefono.Text;

            try
            {
                gestor.registrar(nombre,edad,telefono);
                cargarClientes();
                MessageBox.Show("Los datos del cliente se registraron correctamente", "Registrar Cliente");
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error " + ex, "Registrar Cliente");
            }

        }

        public void cargarClientes() 
        {
            List<Array> datos;
            String[] row;
            dgvCliente.Rows.Clear();
            try
            {
                datos = gestor.listar();
                for (int i = 0; i <= datos.Count() - 1; i++) 
                {
                    row = new String[datos[i].Length];
                    for (int j = 0; j <= datos[i].Length - 1; j++)
                    {
                        row[j] = datos[i].GetValue(j).ToString();
                    }
                    dgvCliente.Rows.Add(row);
             }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error " + ex, "Buscar Cliente");
            }
            
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            cargarClientes();
        }
    }
}
