using System;

namespace tries
{
    class Program
    {
        static TrieNode root = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Tries Started!");

            string feed = string.Empty;

            while (feed != "exit")
            {
                feed = Console.ReadLine();
                if (feed != "exit")
                    AddString(root, feed);

                // TrieNode node = GetStringNode(root, feed);
                // if (node == null)
                //     Console.WriteLine("nope");
                // else
                //     Console.WriteLine(node.Key);
            }

            PrintDown(root);
            Console.WriteLine();
            PrintSide(root);
            Console.WriteLine();
            Console.WriteLine($"That's all! There are {TrieNode.count} nodes.");
        }

        static void AddString(ref TrieNode node, string str)
        {
            TrieNode next;
            if (str.Length == 0)
                return;
            else if (node == null)
            {
                node = new TrieNode();
                node.Key = str[0];
                str = str.Substring(1);
                next = node.Child;
            }
            else
            {
                if (node.Key == str[0])
                {
                    str = str.Substring(1);
                    next = node.Child;
                }
                else
                    next = node.Brother;
            }

            AddString(ref next, str);
        }

        static void AddString(TrieNode node, string str)
        {
            TrieNode temp = node;
            foreach (char c in str)
            {
                temp.Child = new TrieNode(c);
                temp = temp.Child;
            }
        }

        static TrieNode GetStringNode(TrieNode node, string template)
        {
            if (template.Length == 0)
                return node;

            if (node == null)
                return null;
            TrieNode next = null;
            if (node.Key == template[0])
            {
                template = template.Substring(1);
                next = node.Child;
            }
            else //if (node.HasBrother())
            {
                next = node.Brother;
            }

            return GetStringNode(next, template);
        }

        static string[] GetStrings(TrieNode node)
        {
            return null;
        }

        static void PrintDown(TrieNode node)
        {
            if (node != null)
            {
                Console.Write(node.Key);
                PrintDown(node.Child);
            }
        }

        static void PrintSide(TrieNode node)
        {
            if (node != null)
            {
                Console.Write(node.Key);
                PrintSide(node.Brother);
            }
        }
    }
}
