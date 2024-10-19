public class Trie
{
    private Dictionary<char, TrieNode> Heads = new Dictionary<char, TrieNode>();

    public Trie()
    {

    }

    public void Insert(string word)
    {
        if(string.IsNullOrEmpty(word)) 
            return;
        
        if (!Heads.ContainsKey(word[0]))
            Heads.Add(word[0], new TrieNode(word[0]));

        var current = Heads[word[0]];

        for (int i = 1; i < word.Length; i++)
        {
            char letter = word[i];
            
            if (!current.ContainsSubNode(letter))
                current.AddNode(letter);

            current = current.GetNode(letter);
        }

        current.MarkAsEndOfWord();
            
    }

    public bool Search(string word)
    {
        if (!Heads.ContainsKey(word[0]))
            return false;

        var current = Heads[word[0]];
        for (int i = 1; i < word.Length; i++)
        {
            char letter = word[i];

            if (!current.ContainsSubNode(letter))
                return false;

            current = current.GetNode(letter);
        }

        return current.IsEndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        if (!Heads.ContainsKey(prefix[0]))
            return false;

        var current = Heads[prefix[0]];
        for (int i = 1; i < prefix.Length; i++)
        {
            char letter = prefix[i];

            if (!current.ContainsSubNode(letter))
                return false;

            current = current.GetNode(letter);
        }
        return true;
    }


    private class TrieNode
    {
        public char Key { get; }
        public bool IsEndOfWord { get; private set; }
        private Dictionary<char, TrieNode> SubNodes = new Dictionary<char, TrieNode>();


        public TrieNode(char key, bool isEndOfWord = false)
        {
            Key = key;
            IsEndOfWord = isEndOfWord;
        }

        public bool ContainsSubNode(char c) => SubNodes.ContainsKey(c);
        public TrieNode GetNode(char c) => SubNodes[c];
        public void AddNode(char c) => SubNodes.Add(c,new TrieNode(c));



        public void MarkAsEndOfWord() => IsEndOfWord = true;
    }
}
