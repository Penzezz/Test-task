class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            Console.WriteLine($"Reading file: {path}");
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            foreach (var line in File.ReadLines(path))
            {
                var words = line.Split(new char[] { ' ', ',', '.', '!', '?', ':', ';', '-' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(var word in words)
                {
                    if(!wordsCount.ContainsKey(word))
                    {
                        wordsCount.Add(word, 1);
                    }
                    else
                    {
                        wordsCount[word]++;
                    }
                }
            }
            using (StreamWriter file = new StreamWriter("out.txt"))
            {
                foreach (var word in wordsCount.OrderByDescending(_ => _.Value))
                {
                    file.WriteLine($"{word.Key} {word.Value}");
                }
            }
            Console.WriteLine("New output file created");
        }      
    }