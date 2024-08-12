using System;
using System.Collections.Generic;
using System.IO;

namespace FHP.RES
{
    public class IniFile
    {
        private readonly Dictionary<string, Dictionary<string, string>> sections;

        public IniFile(string filePath)
        {
            sections = new Dictionary<string, Dictionary<string, string>>();

            string currentSection = null;
            foreach (var line in File.ReadLines(filePath))
            {
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    currentSection = line.Substring(1, line.Length - 2);
                    sections[currentSection] = new Dictionary<string, string>();
                }
                else if (!string.IsNullOrWhiteSpace(line) && currentSection != null)
                {
                    int equalsIndex = line.IndexOf('=');
                    if (equalsIndex >= 0)
                    {
                        string key = line.Substring(0, equalsIndex).Trim();
                        string value = line.Substring(equalsIndex + 1).Trim();
                        sections[currentSection][key] = value;
                    }
                }
            }
        }

        public string ReadValue(string section, string key)
        {
            if (sections.TryGetValue(section, out var keys))
            {
                if (keys.TryGetValue(key, out var value))
                {
                    return value;
                }
            }
            return null;
        }
    }
}
