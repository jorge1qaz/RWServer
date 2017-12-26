using System;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class Cliente
    {
        public string IdCliente { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string RUC { get; set; }
        public string ImagenEmpresa { get; set; }
        public string ImagenPerfil { get; set; }
        public string IdRol { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime DateUpdate { get; set; }

        //Jorge Luis|08/11/2017|RW-19
        /*Método para ejecutar un procedimiento almacenado, con todos los atributos de Cliente y un parámetro de salida.*/
        public bool AllParametersUser(string storedProcedure)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = storedProcedure;   
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con.cadena;

            SqlParameter paramIdCliente = new SqlParameter();
            paramIdCliente.SqlDbType = SqlDbType.NVarChar;
            paramIdCliente.ParameterName = "@IdCliente";
            paramIdCliente.Value = IdCliente;
            cmd.Parameters.Add(paramIdCliente);

            SqlParameter paramContrasenia = new SqlParameter();
            paramContrasenia.SqlDbType = SqlDbType.NVarChar;
            paramContrasenia.ParameterName = "@Contrasenia";
            paramContrasenia.Value = Contrasenia;
            cmd.Parameters.Add(paramContrasenia);

            SqlParameter paramNombre = new SqlParameter();
            paramNombre.SqlDbType = SqlDbType.NVarChar;
            paramNombre.ParameterName = "@Nombre";
            paramNombre.Value = Nombre;
            cmd.Parameters.Add(paramNombre);

            SqlParameter paramApellidos = new SqlParameter();
            paramApellidos.SqlDbType = SqlDbType.NVarChar;
            paramApellidos.ParameterName = "@Apellidos";
            paramApellidos.Value = Apellidos;
            cmd.Parameters.Add(paramApellidos);

            SqlParameter paramRUC = new SqlParameter();
            paramRUC.SqlDbType = SqlDbType.NVarChar;
            paramRUC.ParameterName = "@RUC";
            paramRUC.Value = RUC;
            cmd.Parameters.Add(paramRUC);

            SqlParameter paramImagenEmpresa = new SqlParameter();
            paramImagenEmpresa.SqlDbType = SqlDbType.NVarChar;
            paramImagenEmpresa.ParameterName = "@ImagenEmpresa";
            paramImagenEmpresa.Value = ImagenEmpresa;
            cmd.Parameters.Add(paramImagenEmpresa);

            SqlParameter paramImagenPerfil = new SqlParameter();
            paramImagenPerfil.SqlDbType = SqlDbType.NVarChar;
            paramImagenPerfil.ParameterName = "@ImagenPerfil";
            paramImagenPerfil.Value = ImagenPerfil;
            cmd.Parameters.Add(paramImagenPerfil);

            SqlParameter paramIdRol = new SqlParameter();
            paramIdRol.SqlDbType = SqlDbType.SmallInt;
            paramIdRol.ParameterName = "@IdRol";
            paramIdRol.Value = IdRol;
            cmd.Parameters.Add(paramIdRol);

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
        //Jorge Luis|08/11/2017|RW-19
        /*Método para ejecutar un procedimiento almacenado, sólo con el atributo de id(correo) del Cliente y un parámetro de salida.*/
        public bool IdParameterUser(string storeProcedure)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = storeProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con.cadena;

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
        //Jorge Luis|08/11/2017|RW-19
        /*Método para ejecutar un procedimiento almacenado, sólo con el atributo de id(correo) del Cliente y un parámetro de salida.*/
        public string IdParameterUserName(string storeProcedure)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = storeProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con.cadena;

            SqlParameter paramIdCliente = new SqlParameter();
            paramIdCliente.SqlDbType = SqlDbType.NVarChar;
            paramIdCliente.ParameterName = "@IdCliente";
            paramIdCliente.Value = IdCliente;
            cmd.Parameters.Add(paramIdCliente);

            SqlParameter paramNombre = new SqlParameter();
            paramNombre.Direction = ParameterDirection.Output;
            paramNombre.SqlDbType = SqlDbType.NVarChar;
            paramNombre.Size = 50;
            paramNombre.ParameterName = "@Nombre";
            cmd.Parameters.Add(paramNombre);

            con.Connect();
            cmd.ExecuteNonQuery();
            con.Disconnect();
            return cmd.Parameters["@Nombre"].Value.ToString();
        }
        //Jorge Luis|08/11/2017|RW-19
        /*Método para ejecutar un procedimiento almacenado, con dos atributos (id, correo) del Cliente y un parámetro de salida.*/
        public bool TwoParametersUser(string storeProcedure)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = storeProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con.cadena;

            SqlParameter paramIdCliente = new SqlParameter();
            paramIdCliente.SqlDbType = SqlDbType.NVarChar;
            paramIdCliente.ParameterName = "@IdCliente";
            paramIdCliente.Value = IdCliente;
            cmd.Parameters.Add(paramIdCliente);

            SqlParameter paramContrasenia = new SqlParameter();
            paramContrasenia.SqlDbType = SqlDbType.NVarChar;
            paramContrasenia.ParameterName = "@Contrasenia";
            paramContrasenia.Value = Contrasenia;
            cmd.Parameters.Add(paramContrasenia);

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
        //Jorge Luis|08/11/2017|RW-19
        /*Método para ejecutar un procedimiento almacenado, con dos atributos (id, correo) del Cliente y un parámetro de salida.*/
        public DateTime ReadParametersUserLastUpdate(string storeProcedure)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = storeProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con.cadena;

            SqlParameter paramIdCliente = new SqlParameter();
            paramIdCliente.SqlDbType = SqlDbType.NVarChar;
            paramIdCliente.ParameterName = "@IdCliente";
            paramIdCliente.Value = IdCliente;
            cmd.Parameters.Add(paramIdCliente);

            SqlParameter paramLastUpdate = new SqlParameter();
            paramLastUpdate.Direction = ParameterDirection.Output;
            paramLastUpdate.SqlDbType = SqlDbType.DateTime;
            paramLastUpdate.ParameterName = "@LastUpdate";
            cmd.Parameters.Add(paramLastUpdate);

            con.Connect();
            cmd.ExecuteNonQuery();
            con.Disconnect();
            return DateTime.Parse(cmd.Parameters["@LastUpdate"].Value.ToString());
        }
        public bool WriteParametersUserLastUpdate(string storeProcedure)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = storeProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con.cadena;

            SqlParameter paramIdCliente = new SqlParameter();
            paramIdCliente.SqlDbType = SqlDbType.NVarChar;
            paramIdCliente.ParameterName = "@IdCliente";
            paramIdCliente.Value = IdCliente;
            cmd.Parameters.Add(paramIdCliente);

            SqlParameter paramLastUpdate = new SqlParameter();
            paramLastUpdate.SqlDbType = SqlDbType.DateTime;
            paramLastUpdate.ParameterName = "@LastUpdate";
            paramLastUpdate.Value = LastUpdate;
            cmd.Parameters.Add(paramLastUpdate);

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
