

namespace tries
{
    public class TrieNode
    {
        public static int count = 0;
        public char Key { get; set; }
        public TrieNode Brother { get; set; }
        public TrieNode Child { get; set; }

        public TrieNode()
        {
            Key = char.MinValue;
            count++;
        }

        public TrieNode(char c)
        {
            Key = c;
            count++;
        }

        public bool HasBrother()
        {
            return (Brother != null);
        }
        public bool HasChild()
        {
            return (Child != null);
        }


    }
}