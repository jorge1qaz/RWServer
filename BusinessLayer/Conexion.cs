using System.Data.SqlClient;

namespace BusinessLayer
{
    public class Conexion
    {
        public SqlConnection cadena = new SqlConnection("data source=localhost\\MSSQLSERVER01;initial catalog=reportesweb;integrated security=True;MultipleActiveResultSets=True;");
        //Jorge Luis|08/11/2017|RW-19
        /*Método para realizar la conexión a la base de datos*/
        public void Connect()
        {
           cadena.Open();
        }
        //Jorge Luis|08/11/2017|RW-19
        /*Método para desconectar la base de datos*/
        public void Disconnect()
        {
            cadena.Close();
        }
    }
}
