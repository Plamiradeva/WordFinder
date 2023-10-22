using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace WordAnalalyzerHomework
{
    class Program
    {
        static string RemovePunctuation(string allWords)
        {
            StringBuilder simpleWord = new StringBuilder();
            foreach (char c in allWords)
            {
                if (char.IsLetterOrDigit(c))
                {
                    simpleWord.Append(c);
                }
            }
            return simpleWord.ToString();
        }
        static string[] GetWords(string text)
        {
            string[] components = text.Split(new[] { ' ', '\t', '\n', '\r', '\f', '\v' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> validWords = new List<string>();
            foreach (var part in components)
            {
                string cleanedWord = RemovePunctuation(part);
                if (cleanedWord.Length >= 3)
                {
                    validWords.Add(cleanedWord);
                }
            }
            return validWords.ToArray();
        }
        static int CountWords(string text)
        {
            string[] allWords = GetWords(text);
            return allWords.Length;
        }
        static string FindShortestWord(string text)
        {
            string[] allWords = GetWords(text);
            if (allWords.Length == 0)
                return string.Empty;

            string shortestWord;
            shortestWord = allWords[0];
            foreach (var word in allWords)
            {
                if (allWords.Length < shortestWord.Length)
                {
                    shortestWord = word;
                }
            }
            return shortestWord;
        }
        static string FindLongestWord(string text)
        {
            string[] allWords = GetWords(text);
            if (allWords.Length == 0)
                return string.Empty;
            string longestWord;
            longestWord = allWords[0];
            foreach (var word in allWords)
            {
                if (allWords.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }
            return longestWord;
        }
        static double CalculateAverageWordLength(string text)
        {
            string[] allWords = GetWords(text);
            if (allWords.Length == 0)
                return 0.0;

            double allWordsLength = 0;
            foreach (var word in allWords)
            {
                allWordsLength += allWords.Length;
            }
            return allWordsLength / allWords.Length;
        }
        static List<string> FindMostCommonWords(string text, int count)
        {
            string[] allWords = GetWords(text);
            Dictionary<string, int> allWordsCounts = new Dictionary<string, int>();
            foreach (var word in allWords)
            {
                if (allWordsCounts.ContainsKey(word))
                {
                    allWordsCounts[word]++;
                }
                else
                {
                    allWordsCounts[word] = 1;
                }
            }
            List<string> mostCommonWords = new List<string>();
            for (int i = 0; i < count; i++)
            {
                string mostCommonWord = null;
                int allWordsCount = 0;
                foreach (var kvp in allWordsCounts)
                {
                    if (kvp.Value > allWordsCount && !mostCommonWords.Contains(kvp.Key))
                    {
                        allWordsCount = kvp.Value;
                        mostCommonWord = kvp.Key;
                    }
                }
                if (mostCommonWord != null)
                {
                    mostCommonWords.Add(mostCommonWord);
                }
            }
            return mostCommonWords;
        }
        static List<string> FindLeastCommonWords(string text, int count)
        {
            string[] allWords = GetWords(text);
            Dictionary<string, int> allWordsCounts = new Dictionary<string, int>();

            foreach (var word in allWords)
            {
                if (allWordsCounts.ContainsKey(word))
                {
                    allWordsCounts[word]++;
                }
                else
                {
                    allWordsCounts[word] = 1;
                }
            }
            List<string> leastCommonWords = new List<string>();
            for (int i = 0; i < count; i++)
            {
                string leastCommonWord = null;
                int lowestCount = int.MaxValue;
                foreach (var kvp in allWordsCounts)
                {
                    if (kvp.Value < lowestCount && !leastCommonWords.Contains(kvp.Key))
                    {
                        lowestCount = kvp.Value;
                        leastCommonWord = kvp.Key;
                    }
                }
                if (leastCommonWord != null)
                {
                    leastCommonWords.Add(leastCommonWord);
                }
            }
            return leastCommonWords;
        }
        static void Main(string[] args)
        {
            string filePath = @"/Users/Plamena/Downloads/Farley-Mowat_-_I_ptitsite_ne_peeha_-_11489-b.txt"; 
            string text = File.ReadAllText(filePath);   
            int numWords = CountWords(text); 
            string shortestWord = FindShortestWord(text); 
            string longestWord = FindLongestWord(text); 
            double averageWordLength = CalculateAverageWordLength(text);
            List<string> mostCommonWords = FindMostCommonWords(text, 5);      
            List<string> leastCommonWords = FindLeastCommonWords(text, 5);
            Console.WriteLine($"1. Number of allWords: {numWords}");
            Console.WriteLine($"2. Shortest allWords: {shortestWord}");
            Console.WriteLine($"3. Longest allWords: {longestWord}");
            Console.WriteLine($"4. Average allWords length: {averageWordLength:F2}");
            Console.WriteLine("5. Five most common allWords:");
            foreach (var allWords in mostCommonWords)
            {
                Console.WriteLine($"   - {allWords}");
            }
            Console.WriteLine("6. Five least common allWords:");
            foreach (var allWords in leastCommonWords)
            {
                Console.WriteLine($"   - {allWords}");
            }
        }     
    }
}

