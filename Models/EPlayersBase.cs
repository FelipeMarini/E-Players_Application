using System.Collections.Generic;
using System.IO;

namespace E_Players_Application.Models
{
    public abstract class EPlayersBase
    {
        public void CreateFolderAndFile (string path)
        {

            string folder = path.Split("/")[0];
    
            if (!Directory.Exists(folder))
            {

                Directory.CreateDirectory(folder);

            }
        
            if (!File.Exists(path))
            {

                File.Create(path);

            }
        
        }


        public List<string> ReadAllLinesCSV(string path)
        {

            List<string> csvLines = new List<string>();

            using (StreamReader file = new StreamReader(path))
            {
                
                string line;

                while ( (line = file.ReadLine()) != null )
                {

                    csvLines.Add(line);

                }

            }
            
            
            return csvLines;
        
        }


        
        public void RewriteCSV( string path, List<string> linesCSV)
        {

            using (StreamWriter output = new StreamWriter(path))
            {
                
                foreach (var item in linesCSV)
                {
                    
                    output.Write(item + '\n');


                }
            
            
            }

        
        }

    
    }
}