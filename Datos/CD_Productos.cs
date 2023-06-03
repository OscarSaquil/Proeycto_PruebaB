using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static System.Collections.Specialized.BitVector32;
using Entidades;
namespace CapaDatos
{
    public class CD_Productos
    {
        private ConexionBD conexion = new ConexionBD();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        Estudiante Estudiante = new Estudiante();
        public DataTable Mostrar()
        {
            SqlCommand comando = new SqlCommand();
            //Transacr sql
            comando.Connection = conexion.AbrirConexion(conexion.GetConexion());
            comando.CommandText = "MostrarDatos";
            comando.CommandType = CommandType.StoredProcedure;

            leer = comando.ExecuteReader(); 
            tabla.Load(leer);   
            conexion.CerrarConexion();
            return tabla;   
        }
        public void Insertar(Estudiante Estudiante)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion(conexion.GetConexion());
            comando.CommandText = "InsertarDatos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", Estudiante.Nombre);
            comando.Parameters.AddWithValue("@Carné", Estudiante.Carné);
            comando.Parameters.AddWithValue("@Direccion", Estudiante.Direccion);
            comando.Parameters.AddWithValue("@Fecha_Nacimiento", Estudiante.Fecha_Nacimiento);
          
            comando.ExecuteNonQuery();  

            comando.Parameters.Clear();
        }
        public void Editar(Estudiante Estudiante, int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion(conexion.GetConexion());
            comando.CommandText = "EditarDatos";
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@Nombre", Estudiante.Nombre);
            comando.Parameters.AddWithValue("@Carné", Estudiante.Carné);
            comando.Parameters.AddWithValue("@Direccion", Estudiante.Direccion);
            comando.Parameters.AddWithValue("@Fecha_Nacimiento", Estudiante.Fecha_Nacimiento);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        //Eliminar datos
        public void Eliminar (int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion(conexion.GetConexion());
            comando.CommandText = "EliminarDatos";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idDatos",id);
            comando.ExecuteNonQuery();
            //Limpiamos los datos
            comando.Parameters.Clear();

        }
    }

}
