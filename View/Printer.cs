using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearcher.View
{
    public static class Printer
    {
        /// <summary>
        /// Skriver ut huvud-menyn
        /// </summary>
        public static void PrintMainMenu()
        {
            Console.WriteLine("\n---MAIN MENU---\n");
            Console.WriteLine("Choose a number below: ");
            Console.WriteLine("[1] Search Word");
            Console.WriteLine("[2] Sort Document");
            Console.WriteLine("[3] See Saved Searches");
            Console.WriteLine("[4] Exit");
        }
        /// <summary>
        /// Ber användaren om ett sökord
        /// </summary>
        public static void PrintSearchWord()
        {
            Console.Write("Enter a word to search for (Press 0 to return to main menu): ");
        }
        /// <summary>
        /// Skriver ut att sökningen sparas
        /// </summary>
        public static void SearchSaved()
        {
            Console.WriteLine("Search saved successfully!");
        }
        /// <summary>
        /// Skriver ut att sökningen ej hittas
        /// </summary>
        public static void NoSearchesFound()
        {
            Console.WriteLine("No saved searches found!");
        }
        /// <summary>
        /// Skriver ut hejdå meddelande
        /// </summary>
        public static void ByeMessage()
        {
            Console.WriteLine("Good bye!");
        }
        /// <summary>
        /// Skriver ut sök-menyn
        /// </summary>
        public static void PrintSearchMenu()
        {
            Console.WriteLine("\n---SEARCH MENU---\n");
            Console.WriteLine("[1] Save previous search");
            Console.WriteLine("[2] Search again");
            Console.WriteLine("[3] Back to main menu");
        }
        /// <summary>
        /// Skriver ut sorterings-menyn
        /// </summary>
        public static void PrintSortMenu()
        {
            Console.WriteLine("\n---SORT MENU---\n");
            Console.WriteLine("Choose a document to sort");
            Console.WriteLine("[1] First document");
            Console.WriteLine("[2] Second document");
            Console.WriteLine("[3] Third document");
            Console.WriteLine("[4] Back to main menu");
        }
    }
}
