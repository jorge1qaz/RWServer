using System;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class Foro_Comentarios
    {
        public string IdComentario { get; set; }
        public string Descripcion { get; set; }
        public int IdForo { get; set; }
        public string IdCliente { get; set; }
        public bool CreateComentario(string storeProcedure)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = storeProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con.cadena;

            SqlParameter paramDescripcion = new SqlParameter();
            paramDescripcion.SqlDbType = SqlDbType.NVarChar;
            paramDescripcion.ParameterName = "@Descripcion";
            paramDescripcion.Value = Descripcion;
            cmd.Parameters.Add(paramDescripcion);

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
        public bool FuncIdComentario(string storeProcedure)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = storeProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con.cadena;

            SqlParameter paramIdComentario = new SqlParameter();
            paramIdComentario.SqlDbType = SqlDbType.Int;
            paramIdComentario.ParameterName = "@IdComentario";
            paramIdComentario.Value = IdComentario;
            cmd.Parameters.Add(paramIdComentario);

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
    }
}
