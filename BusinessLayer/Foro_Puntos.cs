using System;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class Foro_Puntos
    {
        public int IdForo { get; set; }
        public string IdCliente { get; set; }
        public bool Punto { get; set; }

        public bool CreatePuntoItem(string storeProcedure)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = storeProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con.cadena;

            SqlParameter paramIdForo = new SqlParameter();
            paramIdForo.SqlDbType = SqlDbType.Int;
            paramIdForo.ParameterName = "@IdForo";
            paramIdForo.Value = IdForo;
            cmd.Parameters.Add(paramIdForo);

            SqlParameter paramIdCliente = new SqlParameter();
            paramIdCliente.SqlDbType = SqlDbType.NVarChar;
            paramIdCliente.ParameterName = "@IdCliente";
            paramIdCliente.Value = IdCliente;
            cmd.Parameters.Add(paramIdCliente);

            SqlParameter paramPunto = new SqlParameter();
            paramPunto.SqlDbType = SqlDbType.Bit;
            paramPunto.ParameterName = "@Punto";
            paramPunto.Value = Punto;
            cmd.Parameters.Add(paramPunto);

            SqlParameter paramComprobacion = new SqlParameter();
            paramComprobacion.Direction = ParameterDirection.Output;
            paramComprobacion.SqlDbType = SqlDbType.Bit;
            paramComprobacion.ParameterName = "@Comprobacion";
            cmd.Parameters.Add(paramComprobacion);

            con.Connect();
            cmd.ExecuteNonQuery();
            con.Disconnect();
            return bool.Parse(cmd.Parameters["@Comprobacion"].Value.ToString());
        }
        public bool GetValuePuntoItem(string storeProcedure)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = storeProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con.cadena;

            SqlParameter paramIdForo = new SqlParameter();
            paramIdForo.SqlDbType = SqlDbType.Int;
            paramIdForo.ParameterName = "@IdForo";
            paramIdForo.Value = IdForo;
            cmd.Parameters.Add(paramIdForo);

            SqlParameter paramIdCliente = new SqlParameter();
            paramIdCliente.SqlDbType = SqlDbType.NVarChar;
            paramIdCliente.ParameterName = "@IdCliente";
            paramIdCliente.Value = IdCliente;
            cmd.Parameters.Add(paramIdCliente);

            SqlParameter paramValorPuntaje = new SqlParameter();
            paramValorPuntaje.Direction = ParameterDirection.Output;
            paramValorPuntaje.SqlDbType = SqlDbType.Bit;
            paramValorPuntaje.ParameterName = "@ValorPuntaje";
            cmd.Parameters.Add(paramValorPuntaje);

            con.Connect();
            cmd.ExecuteNonQuery();
            con.Disconnect();
            return bool.Parse(cmd.Parameters["@ValorPuntaje"].Value.ToString());
        }
    }
}
