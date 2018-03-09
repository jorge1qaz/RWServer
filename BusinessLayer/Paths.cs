using System;
using System.IO;

namespace BusinessLayer
{
    public class Paths
    {
        //public string pathDatosZip = @"D:\git\ReportesWeb\Web\AppWebReportes\Datos\";
        //public string pathDatosZipExtract = @"D:\git\ReportesWeb\Web\AppWebReportes\Cls\";
        public string pathDatosZip = "/Datos/";
        public string pathDatosZipExtract = "/Cls/";
        public string pathNameRPC = "/rptCntsPndts/";
        //Jorge Luis|07/11/2017|RW-19
        /*Método para leer un archivo*/
        public string readFile(string path)
        {
            string text;
            /*llama al método 'ComprobarExistenciaPathFile' para verficar la existencia de un archivo, sólo 
             despues de haber comprobado su existencia, procede a leer este archivo*/
            if (ComprobarExistenciaPathFile(path))
            {
                StreamReader pathInstanceFile = new StreamReader(path);
                text = pathInstanceFile.ReadLine();
            }
            else
                text = "SinTexto";
            return text;
        }
        //Jorge Luis|24/10/2017|RW-19
        /*Método para comprobar la existencia de un archivo, con un parámetro.*/
        public bool ComprobarExistenciaPathFile(string path)
        {
            bool resultado = false;
            /*Comprueba la existencia de un archivo mediante un path*/
            if (File.Exists(path))
                resultado = true;
            return resultado;
        }
        //Jorge Luis|17/01/2018|RW-97
        /*Método para obtener una dataset json con una ruta absoluta obtenida mediante una petición al mismo servidor, leerlo y retornarlo como un dataset asp*/
        public string GetStringByFileJson(string nameFile, String rootPath, string user, string nameReport, string idCompany, string year)
        {
            //@   "/rptStdPmS/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + nameFile + ".json"
            string JsonDataset = readFile(@rootPath + pathDatosZipExtract + user + "/" + nameReport + "/" + idCompany + "/" + year + "/" + nameFile + ".json").Trim().Replace("\\'", "'");
            return JsonDataset;
        }
    }
}
