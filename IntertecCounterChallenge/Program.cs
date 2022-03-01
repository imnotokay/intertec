using IntertecCounterChallenge.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntertecCounterChallenge
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        public Program()
        {
        }

        static void Main(string[] args)
        {
            //Initialize the sentence parser class
            SentenceParser sentenceParser = new SentenceParser();

            string welcomeMessage = string.Empty;
            //It reads the main function arguments
            foreach(string arg in args)
            {
                Console.Write(string.Concat(arg, " "));
            }

            Console.WriteLine("");
            //It iterates always waiting for a new word for parsing
            while(true)
            {
                //It reads a new line from the console and parses it using sentence parser instance after that write the result in the console
                string inputValue = Console.ReadLine();
                string outputValue = sentenceParser.WordParser(inputValue);
                Console.WriteLine(outputValue);
            }
        }
    }
}
