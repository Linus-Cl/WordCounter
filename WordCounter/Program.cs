using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchWord = getSearchWord();
            string fileData = getFileData();

            int wordCount = countWordAppearances(searchWord, fileData);
            Console.WriteLine(wordCount);
        }

        static string getSearchWord()
        {
            Console.Write("Enter Searchword: ");
            string input = Console.ReadLine();
            var searchWord = Regex.Match(input, @"^([\w\-]+)");
            return searchWord.Value;
        }

        static string getFileData()
        {
            string path = "Data.txt";
            string data = "";
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while((s = sr.ReadLine())!= null)
                {
                    data += s;
                }
            }
            return data;
        }

        static int countWordAppearances(string word, string text)
        {
            int count = 0;
            for(int i=0; i<text.Length; i++)
            {
                int index = 0;
                bool match = matchChar(word[index], text[i]);
                while (match)
                {

                    index++;
                    
                    if (index >= word.Length)
                    {
                        count++;
                        break;
                    }

                    if (i + index < text.Length)
                    {
                        match = matchChar(word[index], text[i + index]);
                    }
                    else { break; }
                }
            }
            return count;
        }

        static bool matchChar(char wChar, char tChar)
        {
            return wChar == tChar;
        }
    }
}
