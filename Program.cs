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

            InitDB();

            StringBuilder feed = new();
            ConsoleKeyInfo key = default(ConsoleKeyInfo);

            do
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Tab)
                    feed.Append(GetProposals(feed.ToString()));
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (feed.Length > 0)
                        trie.AddString(feed.ToString());
                    Console.WriteLine();
                    feed.Clear();
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (Console.CursorLeft > 0)
                    {
                        Console.CursorLeft--;
                        Console.Write(" ");
                        Console.CursorLeft--;
                        feed.Remove(feed.Length - 1, 1);
                    }
                }
                else
                {
                    feed.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }

            } while (feed.ToString() != "exit");
        }

        static void InitDB()
        {
            string[] db = { "dir", "del", "do", "delete", "dele" };

            foreach (string item in db)
                trie.AddString(item);
        }

        static string GetProposals(string str)
        {
            var proposals = trie.GetStrings(str);

            if (proposals.Count == 1)
            {
                Console.Write(proposals[0].ToString().Replace(str, ""));
                return proposals[0].ToString().Replace(str, "");
            }
            else if (proposals.Count > 1)
            {
                Console.WriteLine();
                for (int i = 0; i < proposals.Count; i++)
                {
                    Console.Write(proposals[i].ToString());

                    if ((i + 1) % 4 == 0)
                        Console.WriteLine();
                    else
                        Console.Write("\t\t");
                }
                Console.WriteLine();
                Console.Write(str);
                return string.Empty;
            }
            return string.Empty;
        }
    }
}
