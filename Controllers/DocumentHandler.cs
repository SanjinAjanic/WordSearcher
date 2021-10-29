using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearcher.Controllers
{
    public static class DocumentHandler
    {
        /// <summary>
        /// Metod som retunerar en text fil från projektets bin mapp 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetDocument(string fileName)
        {

            return File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName));

        }
        /// <summary>
        /// Metod som splitar ett dokument på mellanslag och tabb och sparar det i en string array
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string[] SplitDocument(string name)
        {
            var document = GetDocument(name);
            string[] splitDocument = document.Split(' ','\t');
            splitDocument = splitDocument.Select(t => t.Trim()).ToArray(); // Säkerställer att det inte finns mellanrum
            return splitDocument;  
        }
    }
}
