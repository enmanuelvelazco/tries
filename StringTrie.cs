using System;
using System.Collections.Generic;
using System.Text;

namespace Tries
{
    public class StringTrie : Trie<char>
    {
        public static int Count { set; get; } = 0;

        public StringTrie()
        {
            root = new TrieNode<char>();
        }

        public void AddString(String str)
        {
            Count++;
            if (String.IsNullOrEmpty(str))
                throw new ArgumentException();
            AddStringRecursive(root, str);
        }

        private void AddStringRecursive(TrieNode<char> node, String str)
        {
            if (str.Length <= 0)
                return;
            TrieNode<char> next;
            // If Key is default then is a newly created node.
            if (node.Key == default)
            {
                node.Key = str[0];
                str = str.Substring(1);
                if (str.Length > 0)
                {
                    node.Child = new();
                    next = node.Child;
                    AddStringRecursive(next, str);
                }
                else
                    node.End = true;
            }
            else
            {
                if (node.Key == str[0])
                {
                    str = str.Substring(1);
                    if (str.Length > 0)
                    {
                        if (node.Child == null)
                            node.Child = new();
                        next = node.Child;
                        AddStringRecursive(next, str);
                    }
                    else
                        node.End = true;
                }
                else
                {
                    if (node.Brother == null)
                        node.Brother = new();
                    next = node.Brother;
                    AddStringRecursive(next, str);
                }
            }                                  
        }

        public List<StringBuilder> GetStrings(String init)
        {
            List<StringBuilder> array = new List<StringBuilder>();
            array.Add(new StringBuilder(init));

            TrieNode<char> node = GetStringNode(init);
            if (node is not null)
            {
                // If node has child means it can have brothers too.
                if (node.HasChild())
                {
                    GetStringRecursive(node.Child, array, array[0]);
                }
            }

            return array;
        }

        private void GetStringRecursive(TrieNode<char> node, List<StringBuilder> array, StringBuilder current)
        {
            if (node is null)
                return;

            if (node.HasBrother())
            {
                var bro = GenerateNewBuilder(array, current);
                GetStringRecursive(node.Brother, array, bro);
            }

            current.Append(node.Key);
            if (node.End && (node.HasChild() || node.HasBrother()))
                current = GenerateNewBuilder(array, current);

            if (node.HasChild())
            {
                GetStringRecursive(node.Child, array, current);
            }
        }

        private TrieNode<char> GetStringNode(String str)
        {
            return GetStringNodeRecursive(root, str);
        }

        private TrieNode<char> GetStringNodeRecursive(TrieNode<char> node, string template)
        {
            if (node == null)
                return null;
            TrieNode<char> next = null;
            if (node.Key == template[0])
            {
                template = template.Substring(1);
                next = node.Child;
            }
            else
            {
                next = node.Brother;
            }
            if (template.Length == 0)
                return node;

            return GetStringNodeRecursive(next, template);
        }

        private StringBuilder GenerateNewBuilder(List<StringBuilder> array, StringBuilder copy)
        {
            StringBuilder str = new StringBuilder(copy.ToString());
            array.Add(str);

            return str;
        }

    }
}
