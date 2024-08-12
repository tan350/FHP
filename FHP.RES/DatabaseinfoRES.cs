using System;

namespace FHP.RES
{
    public class DatabaseInfoRES
    {
        public string ConnectionStringPath(string iniFilePath)
        {
            string connectionString = null;
            try
            {
                IniFile iniFile = new IniFile(iniFilePath);
                connectionString = iniFile.ReadValue("Database", "ConnectionString");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading connection string from INI file: {ex.Message}");
            }
            return connectionString;
        }
    }
}
