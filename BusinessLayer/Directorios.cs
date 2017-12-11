using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLayer
{
    public class Directorios
    {
        Paths paths = new Paths();
        //Jorge Luis|10/11/2017|RW-19
        /*Método para comprobar la existencia de un directorio*/
        public bool CheckDirectory(string path)
        {
            bool directorio = false;
            if (Directory.Exists(path))
                directorio = true;
            return directorio;
        }
        //Jorge Luis|10/11/2017|RW-19
        /*Método para crear un directorio*/
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
    }
}
