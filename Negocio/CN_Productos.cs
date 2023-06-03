using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using Entidades;

namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();

        public DataTable MostrarProd()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarDatos(Estudiante objEstudiante)
        {
            objetoCD.Insertar(objEstudiante);
        }
        public void EditarDatos(Estudiante objEstudiante, int id)
        {
            objetoCD.Editar(objEstudiante,id);
        }

        public void EliminarDatos(int id)
        {
            objetoCD.Eliminar(id); 
        }
    }
}
