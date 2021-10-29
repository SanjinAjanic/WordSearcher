using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearcher.Model
{
    class Node
    {
        public string Data { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        /// <summary>
        /// Metod som skriver ut inehållet i Data
        /// </summary>
        public void GetData()
        {
            Console.WriteLine($"{Data}");
        }

    }
}
