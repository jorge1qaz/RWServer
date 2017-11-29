using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLayer
{
    public class Directorios
    {
        Paths paths = new Paths();
        public bool CheckDirectory(string path)
        {
            bool directorio = false;
            if (Directory.Exists(path))
                directorio = true;
            return directorio;
        }
        public void CreateDirectory(string path, string nameDirectory)
        {
            if (!CheckDirectory(path + "/" + nameDirectory))
                Directory.CreateDirectory(path + "/" + nameDirectory);
            else
            {
                Directory.Delete(path + "/" + nameDirectory, true);
                Directory.CreateDirectory(path + "/" + nameDirectory);
            }
        }
        //Jorge Luis|10/11/2017|RW-19
        /*Método para crear una estructura de directorios del cliente*/
        public List<string> ListarDirectorios(string path, string lastId)
        {
            List<string> listIdCompany = new List<string>();
            try
            {
                string dirPath = path + lastId;
                var dirs = from dir in Directory.EnumerateDirectories(dirPath, "*") select dir;
                foreach (var dir in dirs)
                    listIdCompany.Add(dir.Substring(dir.LastIndexOf("\\") + 1));
            }
            catch (UnauthorizedAccessException UAEx)
            {
                //MessageBox.Show(UAEx.Message.ToString(), "Error en la comprobación de años", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (PathTooLongException PathEx)
            {
                //MessageBox.Show(PathEx.Message.ToString(), "Error en la comprobación de años, ruta demasiado larga.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listIdCompany;
        }
    }
}
