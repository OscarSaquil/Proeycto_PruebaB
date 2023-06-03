using GestionDeEstudiantes_ProyectoFinal;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_Estudiantes
{
    public partial class Inicio : Form
    {
        
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Generamos una instancia hacia el Formulario Registro
            GestionEstudiantes AbrirGestion = new GestionEstudiantes();
            AbrirGestion.Show();      //Muestro el formulario actual
        }

        private void BtnEstadisticas_Click(object sender, EventArgs e)
        {
            Estadisticas AbrirEstadisticas = new Estadisticas();
            AbrirEstadisticas.Show();
        }
        public void MostrarFormOculto()
        {
            this.Show(); // Vuelve a mostrar el form
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
