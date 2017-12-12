using Ionic.Zip;
using System.IO;

namespace BusinessLayer
{
    public class Zips
    {
        public bool checkZipExists(string pathZip) {
            bool validate = false;
            if (File.Exists(pathZip))
                validate = true;
            return validate;
        }
        public bool ExtractDataZip(string pathZip, string pathDirectoryExtract)
        {
            bool validate = false;
            if (checkZipExists(pathZip))
            {
                using (ZipFile zip1 = ZipFile.Read(pathZip))
                {
                    foreach (ZipEntry e in zip1)
                    {
                        try
                        {
                            e.Password = "reportesweb";
                            e.Extract(pathDirectoryExtract, ExtractExistingFileAction.OverwriteSilently);
                        }
                        catch (System.Exception)
                        {
                            validate = false;
                        }
                    }
                }
                validate = true;
            }
            return validate;
        }
        //Jorge Luis|07/11/2017|RW-19
        /*Método para extraer un archivo*/
        public bool ExtractFile(string pathZip, string pathDirectoryExtract)
        {
            bool validate = false;
            using (ZipFile zip = ZipFile.Read(pathZip))
            {
                try
                {
                    ZipEntry e = zip["LastUpdate.txt"];
                    e.Password = "reportesweb";
                    e.Extract(pathDirectoryExtract, ExtractExistingFileAction.OverwriteSilently);
                    validate = true;
                }
                catch (System.Exception)
                {
                    validate = false;
                }
                return validate;
            }
        }
        //Jorge Luis|07/11/2017|RW-19
        /*Método para leer un archivo*/
        public string ReadFile(string path)
        {
            string text;
            /*llama al método 'ComprobarExistenciaPathFile' para verficar la existencia de un archivo, sólo 
             despues de haber comprobado su existencia, procede a leer este archivo*/
            if (File.Exists(path))
            {
                StreamReader File = new StreamReader(path);
                text = File.ReadLine().Trim();
            }
            else
                text = "SinTexto";
            return text;
        }
    }
}
