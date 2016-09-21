using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Ionic.Zip;
using Ionic.Crc;

namespace Scrapcenter.Util
{
    class Zip
    {

        public static string[] GetFilesInDir(ZipFile file, string directoryPath)
        {
            List<string> filePaths = new List<string>();
            if (!directoryPath.EndsWith("/"))
                directoryPath = directoryPath + "/";
            
            foreach (ZipEntry e in file.Entries)
            {
                if (e.FileName.StartsWith(directoryPath))
                    filePaths.Add(e.FileName);
            }
            return filePaths.ToArray();
        }

        public static string ReadText(ZipEntry entry) {
            CrcCalculatorStream stream = entry.OpenReader();
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
            reader.Close();
            stream.Close();
            return text;
        }

    }
}
