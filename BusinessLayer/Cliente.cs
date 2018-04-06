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
        public bool ActivacionCuenta { get; set; }
        public string PrivateIP { get; set; }
        public string PublicIP { get; set; }
        public DateTime LastAccess { get; set; }

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

            SqlParameter paramActivacionCuenta = new SqlParameter();
            paramActivacionCuenta.SqlDbType = SqlDbType.Bit;
            paramActivacionCuenta.ParameterName = "@ActivacionCuenta";
            paramActivacionCuenta.Value = ActivacionCuenta;
            cmd.Parameters.Add(paramActivacionCuenta);

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
        /*Método para ejecutar un procedimiento almacenado, con el atributo de id(correo) del Cliente, nombre, apellido y RUC con un parámetro de salida.*/
        public bool EditDataUser(string storeProcedure)
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
        /*Método para ejecutar un procedimiento almacenado, con dos atributos (id, correo) del Cliente y dos parámetros de salida. Es empleado para autenticar al usuario*/
        public bool[] TwoParametersUserArray(string storeProcedure)
        {
            bool[] states = new bool[2];
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

            SqlParameter paramActivateAccount = new SqlParameter();
            paramActivateAccount.Direction = ParameterDirection.Output;
            paramActivateAccount.SqlDbType = SqlDbType.Bit;
            paramActivateAccount.ParameterName = "@ActivateAccount";
            cmd.Parameters.Add(paramActivateAccount);

            con.Connect();
            cmd.ExecuteNonQuery();
            con.Disconnect();
            states[0] = bool.Parse(cmd.Parameters["@Comprobacion"].Value.ToString());
            states[1] = bool.Parse(cmd.Parameters["@ActivateAccount"].Value.ToString());
            return states;
        }
        //Jorge Luis|08/11/2017|RW-19
        /*Método para ejecutar un procedimiento almacenado, con dos atributos (id, (Contrasenia || ActivacionCuenta) del Cliente y un parámetro de salida. Es empleado para cambiar la contraseña del usuario
         Retorna sólo una variable de salida*/
        public bool TwoParametersUser(string storeProcedure, Int16 typeProcedure)
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

            switch (typeProcedure)
            {
                case 1: // Cuando se emplea la contraseña
                    SqlParameter paramContrasenia = new SqlParameter();
                    paramContrasenia.SqlDbType = SqlDbType.NVarChar;
                    paramContrasenia.ParameterName = "@Contrasenia";
                    paramContrasenia.Value = Contrasenia;
                    cmd.Parameters.Add(paramContrasenia);
                    break;
                case 2: // Cuando se emplea la activacion de cuenta
                    SqlParameter paramActivacionCuenta = new SqlParameter();
                    paramActivacionCuenta.SqlDbType = SqlDbType.Bit;
                    paramActivacionCuenta.ParameterName = "@ActivacionCuenta";
                    paramActivacionCuenta.Value = ActivacionCuenta;
                    cmd.Parameters.Add(paramActivacionCuenta);
                    break;
            }

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
        //Jorge Luis|08/11/2017|RW-19
        /*Método para ejecutar un procedimiento almacenado, con dos atributos (id, correo) del Cliente y un parámetro de salida.*/
        public DateTime ReadParametersUserDateUpdate(string storeProcedure)
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

            SqlParameter paramDateUpdate = new SqlParameter();
            paramDateUpdate.Direction = ParameterDirection.Output;
            paramDateUpdate.SqlDbType = SqlDbType.DateTime;
            paramDateUpdate.ParameterName = "@DateUpdate";
            cmd.Parameters.Add(paramDateUpdate);

            con.Connect();
            cmd.ExecuteNonQuery();
            con.Disconnect();
            return DateTime.Parse(cmd.Parameters["@DateUpdate"].Value.ToString());
        }
        //Jorge Luis|08/11/2017|RW-19
        /*Método para ejecutar un procedimiento almacenado, con dos atributos (id, correo) del Cliente y un parámetro de salida.*/
        public bool CheckEmailAndRUC(string storeProcedure)
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

            SqlParameter paramRUC = new SqlParameter();
            paramRUC.SqlDbType = SqlDbType.NVarChar;
            paramRUC.ParameterName = "@RUC";
            paramRUC.Value = RUC;
            cmd.Parameters.Add(paramRUC);

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
        //Jorge Luis|19/03/2018|RW-19
        /*Método para ejecutar un procedimiento almacenado, con tres atributos del Cliente y dos parámetros de salida. */
        public bool[] ParametersUser(string storeProcedure, Int16 typeProcedure)
        {
            bool[] states;
            string customOutputVariable = "";
            Int16 customOutputVariableValue = 0;
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

            switch (typeProcedure)
            {
                case 1: // Cuando se emplea validar los accesos
                    SqlParameter paramPrivateIP = new SqlParameter();
                    paramPrivateIP.SqlDbType = SqlDbType.NVarChar;
                    paramPrivateIP.ParameterName = "@PrivateIP";
                    paramPrivateIP.Value = PrivateIP;
                    cmd.Parameters.Add(paramPrivateIP);

                    SqlParameter paramPublicIP = new SqlParameter();
                    paramPublicIP.SqlDbType = SqlDbType.NVarChar;
                    paramPublicIP.ParameterName = "@PublicIP";
                    paramPublicIP.Value = PublicIP;
                    cmd.Parameters.Add(paramPublicIP);

                    SqlParameter paramStatusIP = new SqlParameter();
                    paramStatusIP.Direction = ParameterDirection.Output;
                    paramStatusIP.SqlDbType = SqlDbType.TinyInt;
                    paramStatusIP.ParameterName = "@StatusIP"; // Ya que éste método tiene DOS variables de salida, aquí se le esta asignando la variable de salida personalizada
                    cmd.Parameters.Add(paramStatusIP);

                    states = new bool[5];
                    customOutputVariable = "@StatusIP";
                    break;
                default:
                    states = new bool[5];
                    break;
            }

            SqlParameter paramComprobacion = new SqlParameter();
            paramComprobacion.Direction = ParameterDirection.Output;
            paramComprobacion.SqlDbType = SqlDbType.Bit;
            paramComprobacion.ParameterName = "@Comprobacion";
            cmd.Parameters.Add(paramComprobacion);
            
            con.Connect();
            cmd.ExecuteNonQuery();
            con.Disconnect();
            states[0] = bool.Parse(cmd.Parameters["@Comprobacion"].Value.ToString()); // Variable de comprobación del sp
            customOutputVariableValue = Int16.Parse(cmd.Parameters[customOutputVariable].Value.ToString());
            switch (typeProcedure)
            {
                case 1:
                    switch (customOutputVariableValue) // Arma un array con lo valores de la variable de salida personalizada
                    {
                        case 1: // Significa que accede sin problemas
                            states[1] = true;
                            states[2] = false;
                            states[3] = false;
                            states[4] = false;
                            break;
                        case 2: // PrivateIP no es igual, pero PublicIP si son iguales, entonces tal vez esta accediendo desde la misma máquina pero el DHCP le cambio la IP, o sino esta accediendo desde otro dispositivo pero en la misma red
                            states[1] = false;
                            states[2] = true;
                            states[3] = false;
                            states[4] = false;
                            break;
                        case 3: // PrivateIP y PublicIP no son iguales, entonces le pedimos que bloquee su otra sesión
                            states[1] = false;
                            states[2] = false;
                            states[3] = true;
                            states[4] = false;
                            break;
                        case 4: // PrivateIP y PublicIP son nulos
                            states[1] = false;
                            states[2] = false;
                            states[3] = false;
                            states[4] = true;
                            break;
                        default:
                            states[1] = false;
                            states[2] = false;
                            states[3] = false;
                            states[4] = false;
                            break;
                    }
                    break;
            }
            return states;
        }
        //Jorge Luis|19/03/2018|RW-19
        /*Método para ejecutar un procedimiento almacenado, con tres atributos del Cliente y dos parámetros de salida. */
        public bool[] ParametersUserAsynchronous(string storeProcedure)
        {
            bool[] states;
            string customOutputVariable = "";
            Int16 customOutputVariableValue = 0;
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

            SqlParameter paramPrivateIP = new SqlParameter();
            paramPrivateIP.SqlDbType = SqlDbType.NVarChar;
            paramPrivateIP.ParameterName = "@PrivateIP";
            paramPrivateIP.Value = PrivateIP;
            cmd.Parameters.Add(paramPrivateIP);

            SqlParameter paramPublicIP = new SqlParameter();
            paramPublicIP.SqlDbType = SqlDbType.NVarChar;
            paramPublicIP.ParameterName = "@PublicIP";
            paramPublicIP.Value = PublicIP;
            cmd.Parameters.Add(paramPublicIP);

            SqlParameter paramStatusIP = new SqlParameter();
            paramStatusIP.Direction = ParameterDirection.Output;
            paramStatusIP.SqlDbType = SqlDbType.TinyInt;
            paramStatusIP.ParameterName = "@StatusIP"; // Ya que éste método tiene DOS variables de salida, aquí se le esta asignando la variable de salida personalizada
            cmd.Parameters.Add(paramStatusIP);

            states = new bool[5];
            customOutputVariable = "@StatusIP";

            SqlParameter paramComprobacion = new SqlParameter();
            paramComprobacion.Direction = ParameterDirection.Output;
            paramComprobacion.SqlDbType = SqlDbType.Bit;
            paramComprobacion.ParameterName = "@Comprobacion";
            cmd.Parameters.Add(paramComprobacion);

            con.Connect();
            cmd.ExecuteNonQuery();
            con.Disconnect();
            states[0] = bool.Parse(cmd.Parameters["@Comprobacion"].Value.ToString()); // Variable de comprobación del sp
            customOutputVariableValue = Int16.Parse(cmd.Parameters[customOutputVariable].Value.ToString());

            switch (customOutputVariableValue) // Arma un array con lo valores de la variable de salida personalizada
            {
                case 1: // Significa que accede sin problemas
                    states[1] = true;
                    states[2] = false;
                    states[3] = false;
                    states[4] = false;
                    break;
                case 2: // PrivateIP no es igual, pero PublicIP si son iguales, entonces tal vez esta accediendo desde la misma máquina pero el DHCP le cambio la IP, o sino esta accediendo desde otro dispositivo pero en la misma red
                    states[1] = false;
                    states[2] = true;
                    states[3] = false;
                    states[4] = false;
                    break;
                case 3: // PrivateIP y PublicIP no son iguales, entonces le pedimos que bloquee su otra sesión
                    states[1] = false;
                    states[2] = false;
                    states[3] = true;
                    states[4] = false;
                    break;
                case 4: // PrivateIP y PublicIP son nulos
                    states[1] = false;
                    states[2] = false;
                    states[3] = false;
                    states[4] = true;
                    break;
                default:
                    states[1] = false;
                    states[2] = false;
                    states[3] = false;
                    states[4] = false;
                    break;
            }
            return states;
        }
        //Jorge Luis|19/03/2018|RW-19
        /*Método para ejecutar un procedimiento almacenado, con atributos del Cliente y UN parámetro de salida. */
        public bool ParametersUserOneOutPut(string storeProcedure, Int16 typeProcedure)
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

            switch (typeProcedure)
            {
                case 1: // Cuando se emplea validar los accesos, actualizar sesión(IPs)
                    SqlParameter paramPrivateIP = new SqlParameter();
                    paramPrivateIP.SqlDbType = SqlDbType.NVarChar;
                    paramPrivateIP.ParameterName = "@PrivateIP";
                    paramPrivateIP.Value = PrivateIP;
                    cmd.Parameters.Add(paramPrivateIP);

                    SqlParameter paramPublicIP = new SqlParameter();
                    paramPublicIP.SqlDbType = SqlDbType.NVarChar;
                    paramPublicIP.ParameterName = "@PublicIP";
                    paramPublicIP.Value = PublicIP;
                    cmd.Parameters.Add(paramPublicIP);
                    break;
                default:
                    break;
            }

            SqlParameter paramComprobacion = new SqlParameter();
            paramComprobacion.Direction = ParameterDirection.Output;
            paramComprobacion.SqlDbType = SqlDbType.Bit;
            paramComprobacion.ParameterName = "@Comprobacion";
            cmd.Parameters.Add(paramComprobacion);

            con.Connect();
            cmd.ExecuteNonQuery();
            con.Disconnect();
            return bool.Parse(cmd.Parameters["@Comprobacion"].Value.ToString()); // Variable de comprobación del sp
        }
    }
}
