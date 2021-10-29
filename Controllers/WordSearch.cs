using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WordSearcher.View;

namespace WordSearcher.Controllers
{
    public static class WordSearch
    {
        static string[] firstDoc = DocumentHandler.SplitDocument("Text_1.txt");
        static string[] secondDoc = DocumentHandler.SplitDocument("Text_2.txt");
        static string[] thirdDoc = DocumentHandler.SplitDocument("Text_3.txt");
        static BinarySearchTree tree = new BinarySearchTree();
        static string resultFromPreviousSearch = ""; // en sträng för att spara senaste sök resultatet
        /// <summary>
        /// En metod som skriver ut huvud-menyn och tar emot ett val från användaren
        /// </summary>
        public static void MainMenu()
        {
            int exit = 4;
            int userChoice;
            do
            {
                Printer.PrintMainMenu();
                int.TryParse(Console.ReadLine(), out userChoice);
                HandleMainMenuChoice(userChoice);
            } while (userChoice != exit);
        }
        /// <summary>
        /// Metod som hanterar användarens val i huvudmenyn
        /// </summary>
        /// <param name="userChoice"></param>
        public static void HandleMainMenuChoice(int userChoice)
        {
            Console.Clear();
            switch (userChoice)
            {
                case 1: 
                    SearchWord ();
                    break;
                case 2:
                    SortMenu();
                    break;
                case 3: 
                    if (tree.root != null)
                    {
                        tree.Get(tree.root); // kallar på trädet och skriver ut noderna
                    }
                    else
                    {
                        Printer.NoSearchesFound();
                    }
                    break;
                case 4:
                    Printer.ByeMessage();
                    Environment.Exit(0); // exits the program
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// En metod som skriver ut sorterings-menyn och tar emot ett val från användaren 
        /// </summary>
        /// ORDO = O(3+n)
        private static void SortMenu()
        {
            bool parseSuccessfull;
            int userInput = 0;
            bool validInput = userInput <= 4 || userInput > 0;
            do
            {
                Printer.PrintSortMenu();
                parseSuccessfull = int.TryParse(Console.ReadLine(), out userInput);
                HandleSortMenuChoice(userInput);

                if (!parseSuccessfull || !validInput)
                {
                    Console.WriteLine("Wrong input try again!");
                }
            } while (!parseSuccessfull || !validInput);


        }
        /// <summary>
        /// Metod som hanterar användarens val i sorterings-menyn
        /// </summary>
        /// <param name="userInput"></param>
        private static void HandleSortMenuChoice(int userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case 1:
                    inputSort(firstDoc);
                    break;
                case 2:
                    inputSort(secondDoc);
                    break;
                case 3:
                    inputSort(thirdDoc);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Metod som sorterar en string array i alfabetisk ordning och skriver det antalet ord användaren vill ha
        /// </summary>
        /// <param name="list"></param>
        private static void inputSort(string[] list)
        {
            bool parseSuccessfull;
            int input = 0;
            Array.Sort(list);
            
            do
            {
            Console.Write("Enter how many words you want to sort: ");
            parseSuccessfull = int.TryParse(Console.ReadLine(), out input);
            
            if (input > list.Count())
            {
                Console.WriteLine("The document has not that many words try again");
            }
            else
            {
                Console.WriteLine($"The list is now sorted alfphabeticly and the first {input} word's are :");
                for (int i = 0; i < input; i++)
                {
                    Console.WriteLine(list[i]);
                }
            }

            } while (!parseSuccessfull || input > list.Count());
        }
        /// <summary>
        /// Metod där användaren kan skriva in ord att söka efter, eller hoppa ut till huvud-menyn 
        /// </summary>
        private static void SearchWord()
        {
            string input;
            do
            {
                Printer.PrintSearchWord();
                input = Console.ReadLine();
                if (input == "0")
                {
                    break;
                }
                CountWord(input);
                HandleSearchMenu(input);
            } while (input != "0");

        }
        /// <summary>
        /// En metod som skriver ut sök-menyn och tar emot ett val från användaren
        /// </summary>
        /// <param name="input"></param>
        private static void HandleSearchMenu(string input)
        {
            bool parseSuccessfull;
            int userInput = 0;
            bool validInput = userInput <= 3 || userInput >= 0;
            do
            {
                Printer.PrintSearchMenu();
                parseSuccessfull = int.TryParse(Console.ReadLine(), out userInput);
                HandleSearchMenuChoice(userInput);

                if (!parseSuccessfull || !validInput)
                {
                    Console.WriteLine("Wrong input try again!");
                }
            } while (!parseSuccessfull || !validInput);
        }
        /// <summary>
        /// Metod som hanterar användarens val i sök-menyn
        /// </summary>
        /// <param name="input"></param>
        /// <param name="userInput"></param>
        private static void HandleSearchMenuChoice(int userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case 1:
                    tree.Add(resultFromPreviousSearch);
                    Printer.SearchSaved();
                    MainMenu();
                    break;
                case 2: 
                    // gå tillbaka till sök
                    break;
                case 3:
                    MainMenu();
                    break;
                default:
                    break;
            }
        }
        
        /// <summary>
        /// Metod som tar emot ett ord att söka efter, loopar igenom arryerna och för varje gång orden hittas så ökas resultatet i counter variabler med ett.
        /// Vi sparar resultatet i en Dictionary och sorterar Dictionaryn för att få ut resultaten i ordning
        /// </summary>
        /// <param name="input"></param>
        /// ORDO = O(9+4n)
        private static void CountWord(string input)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            int firstListCounter = 0;
            int secoundListCounter = 0;
            int thirdListCounter = 0;
            for (int i = 0; i < firstDoc.Length; i++)
            {
                if (input == firstDoc[i])
                {
                    firstListCounter++;
                }
            }
            result.Add($"Number of times ({input}) was found in the first list: ", firstListCounter);

            for (int i = 0; i < secondDoc.Length; i++)
            {
                if (input == secondDoc[i])
                {
                    secoundListCounter++;
                }
            }
            result.Add($"Number of times ({input}) was found in the second list: ", secoundListCounter);
            for (int i = 0; i < thirdDoc.Length; i++)
            {
                if (input == thirdDoc[i])
                {
                    thirdListCounter++;
                }
            }
            result.Add($"Number of times ({input}) was found in the third list: ", thirdListCounter);

            // Sorterar Dictionaryn efter värdet och sparar resultaten i sorted variabeln.
            var sorted = result.OrderByDescending(s => s.Value);
            Console.WriteLine("");
            foreach (var item in sorted)
            {
                Console.Write(item.Key);
                Console.WriteLine(item.Value);
            }
            // Lägger till resultatet i resultFromPreviousSearch för att komma åt resultatet ifall användaren väljer att spara det senare.
            resultFromPreviousSearch = $"{input} : was found {firstListCounter} times in the firstlist\n" +
                $"{input} : was found {secoundListCounter} times in the secondlist\n" +
                $"{input} : was found {thirdListCounter} times in the thirdlist\n";
        }
    }
}
