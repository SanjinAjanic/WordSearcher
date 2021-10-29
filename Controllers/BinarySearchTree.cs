using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordSearcher.Model;

namespace WordSearcher.Controllers
{
    class BinarySearchTree
    {
        public Node root { get; set; }
        public BinarySearchTree()
        {
            root = null;
        }
        /// <summary>
        /// Metod som lägger till strings till trädet.
        /// </summary>
        /// <param name="data"></param>
        public void Add(string data)
        {
            Node newNode = new Node(); // Implementerar newNode
            newNode.Data = data; // sätter newNodes värde till det värdet vi skickar in.
            if (root == null) // om det inte finns någont värde i trädet så sätter vi root till newNode;
            {
                root = newNode; // sätter root till newNode
            }
            else 
            {
                Node current = root; // skapar current och tilldelar roots värde
                Node parrent; // deklarerar parrent
                while (true)
                {
                    parrent = current; // sätter värdet på parrent till current
                    if (data[0] < current.Data[0]) // kollar datan vi skickar in om den är mindre än tidigare node i trädet
                    {
                        current = current.LeftChild; // sätter current till current.LeftChild
                        if (current == null) 
                        {
                            parrent.LeftChild = newNode; // om current är null sätter vi parrent.LeftChild till newNode;
                            break;
                        }
                    }
                    else 
                    {
                        current = current.RightChild; // sätter current till current.RightChild
                        if (current == null) // om RightChild inte har något värde (null)
                        {
                            parrent.RightChild = newNode; // sätter parrent.RightChild till newNode's värde
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// REKURSIV som hämtar noderna i trädet
        /// </summary>
        /// <param name="root"></param>
        public void Get(Node root)
        {
            root.GetData(); // skriver ut första noden
            if (root.LeftChild != null)
            {
                Get(root.LeftChild); // skriver ut alla LeftChild genom att kalla på sig själv tills det inte finns några mer LeftChilds
            }
            if (root.RightChild != null)
            {
                Get(root.RightChild); // skriver ut alla RightChild genom att kalla på sig själv till det inte finns några mer RightChilds
            }
            
        }
    }
}
