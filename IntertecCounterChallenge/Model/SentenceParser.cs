using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using IntertecCounterChallenge.Constants;

namespace IntertecCounterChallenge.Model
{
    public class SentenceParser
    {
        //Global variable for special characters regex validator
        private Regex specialCharactersRegex;

        /// <summary>
        /// Initialize a new instance of SentenceParser class
        /// </summary> 
        public SentenceParser()
        {
            specialCharactersRegex = new Regex(ConstantsValues.SpecialCharacters);
        }

        /// <summary>
        /// Parse sentences identifying the first and last letter of each word, and counting the distinct letters between them
        /// </summary>
        /// <param name="input">Sentence to parse</param>
        /// <returns>Parsed string with the new structure</returns>
        public string WordParser(string input)
        {
            //Initialize variables to use
            string[] wordParts = input.Split(ConstantsValues.WordSeparator);
            StringBuilder parsedSentence = new StringBuilder();
            string parsedWord = string.Empty;
            char[] letters;
             
            //It iterates each word split by white space
            foreach (string part in wordParts)
            {
                if (part.Length == 1 || part.Length == 0)
                {
                    //If the temporal word has a length between 0 and 2 it adds the temporal word to the parsedWord value
                    parsedWord = part;
                }
                else if (specialCharactersRegex.IsMatch(part))
                {
                    //Call to recursive functionality trying to find additional special characters
                    parsedWord = ParseWordBySpecialCharacter(part);
                }
                else
                {
                    //Remove the first and last letter from the temporal word and count the distinct letters between them, finally, it sets the value with the output structure
                    letters = part.Take(part.Length - 1).Skip(1).ToArray();
                    parsedWord = string.Concat(part[0].ToString(), DistinctLetters(letters), part[part.Length - 1]);
                }
                //Append the new parsed word to the parsed sentence
                parsedSentence.Append(string.Concat(parsedWord, " "));
            }

            //It returns the parsed sentence without spaces
            return parsedSentence.ToString().Trim();
        }

        /// <summary>
        /// Parse the word taking into account special characters
        /// </summary>
        /// <param name="word">Word to parse</param>
        /// <returns>Parsed string with the new structure</returns>
        public string ParseWordBySpecialCharacter(string word)
        {
            //Initialize variables to use
            char specialCharacter = char.MinValue;
            string output = string.Empty;
            bool foundSpecialCharacter = false;
            int pos = 0;
            char[] letters;
            string[] words;
            bool isFirst = true;

            //It iterates each character trying to find a special character
            while (!foundSpecialCharacter)
            {
                if (specialCharactersRegex.IsMatch(word[pos].ToString()))
                {
                    //If it found a special character, it sets the value within the special character temporal variable
                    foundSpecialCharacter = true;
                    specialCharacter = word[pos];
                }
                pos++;
            }
            //Split the word with the special character
            words = word.Split(new char[] { specialCharacter }, 2);
            //It iterates the words splitted with the special character
            foreach (string tmpWord in words)
            {
                if (specialCharactersRegex.IsMatch(tmpWord))
                {
                    //Call to recursive functionality trying to find additional special characters
                    output += ParseWordBySpecialCharacter(tmpWord);
                }
                else
                {
                    if (tmpWord.Length == 1 || tmpWord.Length == 0)
                    {
                        //If the temporal word has a length between 0 and 2 it adds the temporal word to the output value
                        output += tmpWord;
                    }
                    else
                    {
                        //Remove the first and last letter from the temporal word and count the distinct letters between them, finally, it sets the value with the output structure
                        letters = tmpWord.Take(tmpWord.Length - 1).Skip(1).ToArray();
                        output += string.Concat(tmpWord[0].ToString(), DistinctLetters(letters), tmpWord[tmpWord.Length - 1]);
                    }
                }

                if (isFirst)
                {
                    output += specialCharacter.ToString();
                    isFirst = false;
                }
            }

            return output;
        }

        /// <summary>
        /// Find the distinct letters into a char array
        /// </summary>
        /// <param name="letters">Char array with the words letter to count</param>
        /// <returns>Quantity of distinct letters as string</returns>
        public string DistinctLetters(char[] letters)
        {
            //Initialize variables to use
            string output = string.Empty;
            int quantity = 0;
            List<char> tmpLetters = new List<char>();

            //It iterates char array counting the distinct letters
            foreach (char letter in letters)
            {
                //If it didn't find the letter before, it counts it 
                if (tmpLetters.FindIndex(x => x == letter) == -1)
                {
                    //It appends the letter inside the character temporal collection and increases the counter
                    tmpLetters.Add(letter);
                    quantity++;
                }
            }

            //it sets the output with the quantity value
            output = quantity.ToString();

            //Return the output value
            return output;
        }
    }
}
