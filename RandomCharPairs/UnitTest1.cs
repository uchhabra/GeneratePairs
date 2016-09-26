using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomCharPairsImpl;
namespace RandomCharPairsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PrimeNumberTest()
        {
            int iXGeneratePairCount = 20;
            int iYTimesExpectedPrimeNumbers = 3;

            GetPairs objGetPairs = new GetPairs();

            var lstPairs = objGetPairs.GetRandomCharPairs(iXGeneratePairCount);

            //Calculate No of Prime Numbers
            int iPrimeNumCount = objGetPairs.GetNoOfPrimeNumbers(lstPairs);

            //Calculate Non Prime Numbers
            int iNonPrimeCount = iXGeneratePairCount - iPrimeNumCount;

            try
            {
                Assert.IsTrue(iPrimeNumCount > (iNonPrimeCount * iYTimesExpectedPrimeNumbers), "Prime Number is " + iYTimesExpectedPrimeNumbers + " times more than normal numbers");
            }
            catch (Exception)
            {
                Assert.Fail("Prime Number is not " + iYTimesExpectedPrimeNumbers + " times more than normal numbers");
            }
        }

        [TestMethod]
        public void PerfectSquareTest()
        {
            int iXGeneratePairCount = 10;

            GetPairs objGetPairs = new GetPairs();

            var lstPairs = objGetPairs.GetRandomCharPairs(iXGeneratePairCount);

            //Calculate No of Prime Numbers
            int iPrimeNumCount = objGetPairs.GetNoOfPrimeNumbers(lstPairs);

            //Calculate Perfect Square Numbers
            int iCountPerfectSquare = objGetPairs.GetNoOfPerfectSquare(lstPairs);

            try
            {
                Assert.IsTrue((iCountPerfectSquare * 3) >= iPrimeNumCount, "Perfects squares should be one third (1/3)x as likely as prime numbers");
            }
            catch (Exception)
            {
                Assert.Fail("Perfects squares are not one third (1/3)x as likely as prime numbers");
            }
            
        }
        [TestMethod]
        public void VowelCountTest()
        {
            int iXGeneratePairCount = 10;
            int zTimesOfConstansts = 3;

            GetPairs objGetPairs = new GetPairs();
            var lstPairs = objGetPairs.GetRandomCharPairs(iXGeneratePairCount);

            //Calculate Vowels
            int iCountVowels = objGetPairs.GetNumOfVowels(lstPairs);

            //Calculate Constants
            int iConstantCount = iXGeneratePairCount - iCountVowels;

            try
            {
                Assert.IsTrue((iConstantCount * zTimesOfConstansts) <= iCountVowels, "Vowels (a, e, i, o, u) should be Z times more likely than consonants");
            }
            catch (Exception)
            {
                Assert.Fail("Vowels (a, e, i, o, u) are not Z times more likely than consonants");
            }
        }

        [TestMethod]
        public void YLetterCountTest()
        {
            int iXGeneratePairCount = 100;

            GetPairs objGetPairs = new GetPairs();
            var lstPairs = objGetPairs.GetRandomCharPairs(iXGeneratePairCount);

            //Calculate Vowels
            int iCountVowels = objGetPairs.GetNumOfVowels(lstPairs);

            //Calculate Y Letter Count
            int iYLetterCount = objGetPairs.GetYLetterCount(lstPairs);

            try
            {
                Assert.IsTrue((iCountVowels * 2) <= iYLetterCount, "The letter y should be twice (2x) as likely as vowels");
            }
            catch (Exception)
            {
                Assert.Fail("The letter y is not twice (2x) as likely as vowels");
            }
        }

        [TestMethod]
        public void DisplayWinLossStreak()
        {
            int iXGeneratePairCount = 100;

            //generate 10 pairs
            GetPairs objGetPairs = new GetPairs();
            var lstPairs = objGetPairs.GetRandomCharPairs(iXGeneratePairCount);

            //get Comparision esult in JSON format
            string jsonResult = objGetPairs.ComparePairs(lstPairs);

            Console.WriteLine(jsonResult);

        }
    }
}
