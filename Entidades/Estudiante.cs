using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estudiante
    {
        public string Nombre {get;set;}
        public string Carné { get;set;}
        public string Direccion { get;set;}
        public SqlDateTime Fecha_Nacimiento { get;set;} 
    }
}
