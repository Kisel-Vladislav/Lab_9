using System;
using System.Collections.Generic;
using System.Linq;


namespace Задание_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "что  точто чт тоо что ч тото что что то что что то что то";
            var dic = TopWords(text);
            foreach (var item in dic)
            {
                Console.WriteLine(@"{0,-10} - {1,-5}",item.Key,item.Value);
            }
        }

        static Dictionary<string, int> TopWords(string text)
        {
            Dictionary<string, int> topWords = new Dictionary<string, int>();
            char [] chars = {' ', ',', '?', '.', '-'};
            string[] words = text.Split(chars, StringSplitOptions.RemoveEmptyEntries);
            
            int count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[i] == words[j])
                        count++;
                }
                topWords[words[i]] = count;
                count = 0;
            }

            Dictionary<string, int> sortedDict = topWords.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return sortedDict;
        }
    }
}
