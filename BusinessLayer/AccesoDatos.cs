using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AccesoDatos
    {
        Conexion con = new Conexion();
        //Jorge Luis|13/11/2017|RW-19
        /*Método para extraer datos de la base de datos web, mediante una consulta como parámetro*/
        public DataTable Extrae(string consulta)
        {
            DataTable tabla = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            tabla = new DataTable();
            //cmd.Connection = con.cadena;
            cmd.Connection = con.cadena;
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.StoredProcedure;
            con.Connect();
            da.SelectCommand = cmd;
            da.Fill(tabla);
            con.Disconnect();
            return tabla;
        }
        //Jorge Luis|02/04/2018|RW-
        /*Método para extraer datos de la base de datos web, mediante una consulta como parámetro*/
        public List<string> ExtraeList(string consulta)
        {
            List<string> lista;
            SqlDataAdapter da   = new SqlDataAdapter();
            SqlCommand cmd      = new SqlCommand();
            lista               = new List<string>();
            cmd.Connection      = con.cadena;
            cmd.CommandText     = consulta;
            cmd.CommandType     = CommandType.StoredProcedure;
            con.Connect();
            da.SelectCommand    = cmd;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(reader.GetString(0));
                }
            }
            con.Disconnect();
            return lista;
        }
    }
}
