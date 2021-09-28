using System;
using System.Text;
using System.Collections.Generic;

namespace tries
{
    public class Program
    {
        static TrieNode root = new();
        static void Main(string[] args)
        {
            Console.WriteLine("Tries Started!");

            StringBuilder feed = new StringBuilder();

            while (feed.ToString() != "exit")
            {
                ConsoleKeyInfo k = new ConsoleKeyInfo();
                while (true)
                {
                    k = Console.ReadKey(false);
                    if (k.Key == ConsoleKey.Enter)
                    {
                        Console.Write("\n");
                        break;
                    }
                    if (!Char.IsPunctuation(k.KeyChar))
                        feed.Append(k.KeyChar);

                }

                if (feed.ToString() != "exit")
                    AddString(root, feed.ToString());
                else
                    break;

                feed.Clear();
            }

            string temp = string.Empty;
            while (temp != "exit")
            {
                Console.WriteLine("Gimme template!");
                temp = Console.ReadLine();
                var options = GetStrings(GetStringNode(root, temp), temp);
                foreach (var item in options)
                {
                    Console.WriteLine(item.ToString());
                }
            }

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
            if (template.Length == 0)
                return node;

            return GetStringNode(next, template);
        }

        static List<StringBuilder> GetStrings(TrieNode node, string init)
        {
            List<StringBuilder> array = new List<StringBuilder>();
            array.Add(new StringBuilder(init));

            if (node is not null)
            {
                // If node has child means it can have brothers too.
                if (node.HasChild())
                {
                    GetStringHelper(node.Child, array, array[0]);
                }
            }

            return array;
        }

        static void GetStringHelper(TrieNode node, List<StringBuilder> array, StringBuilder current)
        {
            if (node is null)
                return;

            if (node.HasBrother())
            {
                var bro = GenerateNewBuilder(array, current);
                GetStringHelper(node.Brother, array, bro);
            }

            current.Append(node.Key);

            if (node.HasChild())
            {
                GetStringHelper(node.Child, array, current);
            }
        }

        public static StringBuilder GenerateNewBuilder(List<StringBuilder> array, StringBuilder copy)
        {
            StringBuilder str = new StringBuilder(copy.ToString());
            array.Add(str);

            return str;
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
