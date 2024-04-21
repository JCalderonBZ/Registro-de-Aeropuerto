using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejercicio1
{
    class tabla:database
    {
        string instruccion;
        public DataTable vistaTabla()
        {
            instruccion = "SELECT * FROM registro";
            MySqlDataAdapter adp = new MySqlDataAdapter(instruccion, ObtenerConexion());
            DataTable consulta = new DataTable();
            adp.Fill(consulta);
            return consulta;
        }

    }
}
