using System;

namespace tries
{
    class Program
    {
        static TrieNode root = new();
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

        static void AddString(TrieNode node, string str)
        {
            TrieNode next;
            if (str.Length == 0)
                return;
            else if (node.Key == Char.MinValue)
            {
                node.Key = str[0];
                str = str.Substring(1);
                if (str.Length > 0)
                    node.Child = new();
                next = node.Child;
            }
            else
            {
                if (node.Key == str[0])
                {
                    str = str.Substring(1);
                    if (node.Child == null && str.Length > 0)
                        node.Child = new();
                    next = node.Child;
                }
                else
                {
                    if (node.Brother == null && str.Length > 0)
                        node.Brother = new();
                    next = node.Brother;
                }
            }

            AddString(next, str);
        }

        static void AddString2(TrieNode node, string str)
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
