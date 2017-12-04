using System.Data.SqlClient;

namespace BusinessLayer
{
    public class Conexion
    {
        // Cadena local contasis
        //public SqlConnection cadena = new SqlConnection("data source=localhost\\MSSQLSERVER01;initial catalog=reportesweb;integrated security=True;MultipleActiveResultSets=True;");
        // Cadena Licenciador server 
        public SqlConnection cadena = new SqlConnection("data source=70.38.70.172;initial catalog=reportesweb;user id=jorge;password=X@cH7k+t^aC[;MultipleActiveResultSets=True;");
        // Cadena local casa
        //public SqlConnection cadenaHome = new SqlConnection("data source=TOSHIBA;initial catalog=reportesweb;integrated security=True;MultipleActiveResultSets=True;");
        //Cadena resplandor final
        //public SqlConnection cadena = new SqlConnection("data source=TOSHIBA;initial catalog=reportesweb;integrated security=True;MultipleActiveResultSets=True;");
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
