using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP.RES
{
    public class FileInfoRES
    {
        string filePath = null;

        public string FilePath(string iniFilePath)
        {
            IniFile iniFile = new IniFile(iniFilePath);
            filePath = iniFile.ReadValue("FileInfo", "FileInfoPath");
            try
            {
                if (!File.Exists(filePath))
                {
                    using (FileStream fs = File.Create(filePath))
                    {
                        //you can write initial content to the file if needed
                    }
                }
                return filePath;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in checking existing/creating file: {ex.Message}");
                return null;
            }
        }
    }
}
