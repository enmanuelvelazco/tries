namespace Tries
{
    public class TrieNode<T>
    {
        public T Key { get; set; }
        public bool End { get; set; }
        public T Brother { get; set; }
        public T Child { get; set; }

        public TrieNode()
        {
            Key = default(T);
        }

        public TrieNode(T key)
        {
            Key = key;
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