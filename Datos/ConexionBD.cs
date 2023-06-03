using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Datos.Properties;

namespace CapaDatos
{
    public class ConexionBD
    {
        private SqlConnection Conexion = new SqlConnection(Settings.Default.cadenaDeConexion);

        public SqlConnection GetConexion()
        {
            return Conexion;
        }

        public SqlConnection AbrirConexion(SqlConnection conexion)
        {
            if (Conexion.State == ConnectionState.Closed)
                conexion.Open();
            return Conexion;    
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;    
        }
    }
}
