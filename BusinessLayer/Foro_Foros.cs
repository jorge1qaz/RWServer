using System;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class Foro_Foros
    {
        public string IdForo { get; set; }
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Respondido { get; set; }
        public int VotosUtiles { get; set; }
        public Int16 IdProducto { get; set; }
        public string IdCliente { get; set; }
        public string DetalleEdicion { get; set; }
        

        public bool CreateItem(string storeProcedure, Int16 typeProcedure)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = storeProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con.cadena;

            SqlParameter paramCodigo = new SqlParameter();
            paramCodigo.SqlDbType = SqlDbType.NVarChar;
            paramCodigo.ParameterName = "@Codigo";
            paramCodigo.Value = Codigo;
            cmd.Parameters.Add(paramCodigo);

            SqlParameter paramTitulo = new SqlParameter();
            paramTitulo.SqlDbType = SqlDbType.NVarChar;
            paramTitulo.ParameterName = "@Titulo";
            paramTitulo.Value = Titulo;
            cmd.Parameters.Add(paramTitulo);

            SqlParameter paramDescripcion = new SqlParameter();
            paramDescripcion.SqlDbType = SqlDbType.NVarChar;
            paramDescripcion.ParameterName = "@Descripcion";
            paramDescripcion.Value = Descripcion;
            cmd.Parameters.Add(paramDescripcion);

            SqlParameter paramFechaCreacion = new SqlParameter();
            paramFechaCreacion.SqlDbType = SqlDbType.DateTime;
            paramFechaCreacion.ParameterName = "@FechaCreacion";
            paramFechaCreacion.Value = FechaCreacion;
            cmd.Parameters.Add(paramFechaCreacion);

            SqlParameter paramRespondido = new SqlParameter();
            paramRespondido.SqlDbType = SqlDbType.Bit;
            paramRespondido.ParameterName = "@Respondido";
            paramRespondido.Value = Respondido;
            cmd.Parameters.Add(paramRespondido);

            SqlParameter paramVotosUtiles = new SqlParameter();
            paramVotosUtiles.SqlDbType = SqlDbType.Int;
            paramVotosUtiles.ParameterName = "@VotosUtiles";
            paramVotosUtiles.Value = VotosUtiles;
            cmd.Parameters.Add(paramVotosUtiles);

            SqlParameter paramComprobacion = new SqlParameter();
            paramComprobacion.Direction = ParameterDirection.Output;
            paramComprobacion.SqlDbType = SqlDbType.Bit;
            paramComprobacion.ParameterName = "@Comprobacion";
            cmd.Parameters.Add(paramComprobacion);

            SqlParameter paramIdProducto = new SqlParameter();
            paramIdProducto.SqlDbType = SqlDbType.SmallInt;
            paramIdProducto.ParameterName = "@IdProducto";
            paramIdProducto.Value = IdProducto;
            cmd.Parameters.Add(paramIdProducto);

            con.Connect();
            cmd.ExecuteNonQuery();
            con.Disconnect();
            return bool.Parse(cmd.Parameters["@Comprobacion"].Value.ToString());
        }
        public bool EditItem(string storeProcedure, Int16 typeProcedure)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = storeProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con.cadena;

            SqlParameter paramIdForo = new SqlParameter();
            paramIdForo.SqlDbType = SqlDbType.NVarChar;
            paramIdForo.ParameterName = "@IdForo";
            paramIdForo.Value = IdForo;
            cmd.Parameters.Add(paramIdForo);

            SqlParameter paramCodigo = new SqlParameter();
            paramCodigo.SqlDbType = SqlDbType.NVarChar;
            paramCodigo.ParameterName = "@Codigo";
            paramCodigo.Value = Codigo;
            cmd.Parameters.Add(paramCodigo);

            SqlParameter paramTitulo = new SqlParameter();
            paramTitulo.SqlDbType = SqlDbType.NVarChar;
            paramTitulo.ParameterName = "@Titulo";
            paramTitulo.Value = Titulo;
            cmd.Parameters.Add(paramTitulo);

            SqlParameter paramDescripcion = new SqlParameter();
            paramDescripcion.SqlDbType = SqlDbType.NVarChar;
            paramDescripcion.ParameterName = "@Descripcion";
            paramDescripcion.Value = Descripcion;
            cmd.Parameters.Add(paramDescripcion);
            
            SqlParameter paramRespondido = new SqlParameter();
            paramRespondido.SqlDbType = SqlDbType.Bit;
            paramRespondido.ParameterName = "@Respondido";
            paramRespondido.Value = Respondido;
            cmd.Parameters.Add(paramRespondido);
            
            SqlParameter paramIdProducto = new SqlParameter();
            paramIdProducto.SqlDbType = SqlDbType.SmallInt;
            paramIdProducto.ParameterName = "@IdProducto";
            paramIdProducto.Value = IdProducto;
            cmd.Parameters.Add(paramIdProducto);

            SqlParameter paramIdCliente = new SqlParameter();
            paramIdCliente.SqlDbType = SqlDbType.NVarChar;
            paramIdCliente.ParameterName = "@IdCliente";
            paramIdCliente.Value = IdCliente;
            cmd.Parameters.Add(paramIdCliente);

            SqlParameter paramDetalleEdicion = new SqlParameter();
            paramDetalleEdicion.SqlDbType = SqlDbType.NVarChar;
            paramDetalleEdicion.ParameterName = "@DetalleEdicion";
            paramDetalleEdicion.Value = DetalleEdicion;
            cmd.Parameters.Add(paramDetalleEdicion);

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
