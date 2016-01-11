using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Story_of_my_life
{
    static class Resource
    {
        public static string Resource_Path {
            get {

                return Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\..\Resources\");

                //string[] a = AppDomain.CurrentDomain.BaseDirectory.Split('\\');
                //for (int i = 0; i < a.Length; i++)
                //{
                //    if (a[i] == "Story_of_my_life")
                //    {
                //        pathFile += a[i] + "\\";
                //        break;
                //    }
                //    pathFile += a[i] + "\\";
                //}
                //pathFile += "Resources\\";
                //return pathFile;
            }
        }

        public static string get_File_Path(string filename) {
            try
            {
                return Resource_Path + filename;
            }
            catch
            {
                throw new FileNotFoundException("Datei existiert nicht: " + Resource_Path + filename);
            }
        }
    }
}
