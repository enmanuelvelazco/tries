using System;
using System.Text;
using System.Collections.Generic;

namespace Tries
{
    public class Program
    {
        static StringTrie trie = new StringTrie();
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
                    trie.AddString(feed.ToString());
                else
                    break;

                feed.Clear();
            }

            string temp = string.Empty;
            while (temp != "exit")
            {
                Console.WriteLine("Gimme template!");
                temp = Console.ReadLine();
                var options = trie.GetStrings(temp);
                foreach (var item in options)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            Console.WriteLine();
            Console.WriteLine($"That's all!");
        }
    }
}
