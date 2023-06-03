using System.Data;
using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using CapaNegocio;
using Entidades;
using System.Data.SqlClient;

namespace Gestion_de_Estudiantes
{
    public partial class GestionEstudiantes : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        Estudiante objEstudiante = new Estudiante();
        private int idDatos;
        private bool Editar = false;    
        public GestionEstudiantes()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'practicaDataSet.Gestion' Puede moverla o quitarla según sea necesario.
            this.gestionTableAdapter.Fill(this.practicaDataSet.Gestion);
            Mostrar();
        }
        private void Mostrar()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarProd();
        }
        //Agregamos datos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objEstudiante.Nombre = txtNombre.Text;
                    objEstudiante.Carné = txtCarné.Text;
                    objEstudiante.Direccion = txtDireccion.Text;
                    objEstudiante.Fecha_Nacimiento = Fecha_nacimiento.Value.Date;
                    objetoCN.InsertarDatos(objEstudiante);
                    MessageBox.Show("Se Agrego Correctamente");
                    Mostrar();
                    limpiarForm();
                }

                catch (Exception ex)
                {

                    MessageBox.Show("No se pudieron agregar los datos: " + ex);

                }
            }
            //Editamos datos
            if (Editar == true) 
            {
                try
                {
                    objetoCN.EditarDatos(objEstudiante,idDatos);
                    MessageBox.Show("Se edito Correctamente");
                    Mostrar();
                    Editar = false;  
                    limpiarForm();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("No se pudieron editar los datos: " + ex);
                }
            }
       }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idDatos = (int)dataGridView1.CurrentRow.Cells["id"].Value;
                Editar = true;   
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtCarné.Text = dataGridView1.CurrentRow.Cells["Carné"].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells["Direccion"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione una fila");
        }
        private void limpiarForm()
        {
            txtNombre.Clear();
            txtCarné.Clear();
            txtDireccion.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idDatos = (int)dataGridView1.CurrentRow.Cells["id"].Value;
                objetoCN.EliminarDatos(idDatos);
                MessageBox.Show("Eliminado Correctamente");
                Mostrar();
            }
            else
                MessageBox.Show("Seleccione una fila");
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
        }
    }
}