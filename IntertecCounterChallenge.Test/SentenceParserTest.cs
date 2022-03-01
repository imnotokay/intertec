using IntertecCounterChallenge.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IntertecCounterChallenge.Test
{
    [TestClass]
    public class SentenceParserTest
    {
        private SentenceParser sentenceParser;
        /// <summary>
        /// It initializes the test class. Test code coverage over 90% 
        /// </summary>
        public SentenceParserTest()
        {
            sentenceParser = new SentenceParser();
        }

        [TestMethod]
        public void ParseWordBySpecialCharacter_Test()
        {
            string wordToFind = string.Empty;
            string result = string.Empty;


            //Test expecting i0t as value
            wordToFind = "it-a";
            result = sentenceParser.ParseWordBySpecialCharacter(wordToFind);
            Assert.AreEqual(result, "i0t-a");

            //Test expecting s4g-u0p as value
            wordToFind = "setting-up";
            result = sentenceParser.ParseWordBySpecialCharacter(wordToFind);
            Assert.AreEqual(result, "s4g-u0p");


            //Test expecting s4g-u0p;s4g-d2n as value
            wordToFind = "setting-up;setting-down";
            result = sentenceParser.ParseWordBySpecialCharacter(wordToFind);
            Assert.AreEqual(result, "s4g-u0p;s4g-d2n");
        }

        [TestMethod]
        public void DistinctLetters_Test()
        {
            string wordToCount = string.Empty;
            string result = string.Empty;

            //Test expecting 4 as value
            wordToCount = "four";
            result = sentenceParser.DistinctLetters(wordToCount.ToCharArray());
            Assert.AreEqual(result, "4");


            //Test expecting 0 as value
            wordToCount = "";
            result = sentenceParser.DistinctLetters(wordToCount.ToCharArray());
            Assert.AreEqual(result, "0");
        }

        [TestMethod]
        public void WordParser_Test()
        {
            string sentenceToParse = string.Empty;
            string result = string.Empty;

            //Test expecting I0t w1s m2y a1d m2y a y2r a1o as value
            sentenceToParse = "It was many and many a year ago";
            result = sentenceParser.WordParser(sentenceToParse);
            Assert.AreEqual(result, "I0t w1s m2y a1d m2y a y2r a1o");


            //Test expecting C7t,M6t:C6n as value
            sentenceToParse = "Copyright,Microsoft:Corporation";
            result = sentenceParser.WordParser(sentenceToParse);
            Assert.AreEqual(result, "C7t,M6t:C6n");
        }
    }
}
