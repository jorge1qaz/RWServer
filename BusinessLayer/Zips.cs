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
                        e.Password = "reportesweb";
                        e.Extract(pathDirectoryExtract, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                validate = true;
            }
            return validate;
        }
    }
}
