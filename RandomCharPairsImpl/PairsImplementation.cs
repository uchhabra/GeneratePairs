using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCharPairsImpl
{
    public class Pair
    {
        private int m_Numbers;
        private char m_Letter;

        public int Numbers
        {
            get { return m_Numbers; }
            set { m_Numbers = value; }
        }
        public char Letter
        {
            get { return m_Letter; }
            set { m_Letter = value; }
        }
    }

    public class GetPairs
    {
        public List<Pair> m_Pairs;

        public List<Pair> GetRandomCharPairs(int xNoOfChallenges)
        {
            List<Pair> lstPairs = new List<Pair>();
            for (int i = 0; i < xNoOfChallenges; i++)
            {
                Pair objPair = new Pair();
                objPair.Numbers = GenerateRandom.GetRandomNumber(0, 99);
                objPair.Letter = GenerateRandom.GetRandomCharRepresentedAsNumber(0, 25);
                lstPairs.Add(objPair);
            }
            return lstPairs;
        }
        
        private int GetRandomNumber()
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            return r.Next(1,99);
        }

        /// <summary>
        /// Ascii value of Letter a is 97
        /// Add random number from 0 to 25, 0 donates a and 25 donates z, to 'a' or 97
        /// Convert output to char
        /// </summary>
        /// <returns></returns>

        public int GetNoOfPrimeNumbers(List<Pair> lstPairs)
        {
            bool bIsPrime = true;
            int iCount = 0;
            foreach (var number in lstPairs)
            {
                bIsPrime = CheckIfPrime(number.Numbers);
                if (bIsPrime)
                {
                    iCount++;
                }    
            }
            return iCount;
        }

        public int GetNoOfPerfectSquare(List<Pair> lstPairs)
        {
            bool bIsPerfectSqrt = true;
            int iCount = 0;
            foreach (var number in lstPairs)
            {
                bIsPerfectSqrt = CheckIfPerfectSquare(number.Numbers);
                if (bIsPerfectSqrt)
                {
                    iCount++;
                }
            }
            return iCount;
        }

        private bool CheckIfPrime(int iNumber)
        {
            //get sq root of the number
            var sqrt = Math.Sqrt(iNumber);

            if (iNumber == 0 || iNumber == 1)
            {
                return false;
            }
            else
            {
                //loop starting from 2 to sq root of number
                for (int iCount = 2; iCount <= sqrt; iCount++)
                {
                    if ((iNumber % iCount) == 0)
                    {   
                        return false;
                    }
                }
            }
            return true;
        }

        private bool CheckIfPerfectSquare(int iNumber)
        {
            //get sq root of the number
            double sqrt = Math.Sqrt(iNumber);

            return sqrt % 1 == 0;
        }

        public int GetNumOfVowels(List<Pair> lstPairs)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            return lstPairs.Count(X => vowels.Contains(X.Letter));
        }

        public int GetYLetterCount(List<Pair> lstPairs)
        {
            return lstPairs.Count(X => "y".Equals(X.Letter));
        }

        public string ComparePairs(List<Pair> lstPairs)
        {
            int iLetterWinCount = 0;
            int iNumberWinCount = 0;
            
            int iLetterWinMaxStreak = 0;
            int iNumberWinMaxStreak = 0;

            int iLetterCurrentWinStreak = 0;
            int iNumberCurrentWinStreak = 0;

            foreach (var pair in lstPairs)
            {
                //Get letter as number
                int iLetterValue = ((int)pair.Letter) - 96;

                //compare letter and number pair
                if (pair.Numbers > iLetterValue)
                {
                    //increment number win  count
                    iNumberWinCount++;

                    //increment number current win streak
                    iNumberCurrentWinStreak++;
                    
                    //if current streak is greater than overall streak then reset overall win streak
                    if(iNumberCurrentWinStreak > iNumberWinMaxStreak)
                    {
                        iNumberWinMaxStreak = iNumberCurrentWinStreak;
                    }

                    //reset Letter current win streak
                    iLetterCurrentWinStreak = 0;
                }
                else
                {
                    //increment Letter win  count
                    iLetterWinCount++;

                    //increment Letter current win streak
                    iLetterCurrentWinStreak++;

                    //if current streak is greater than overall streak then reset overall win streak
                    if (iLetterCurrentWinStreak > iLetterWinMaxStreak)
                    {
                        iLetterWinMaxStreak = iLetterCurrentWinStreak;
                    }

                    //reset Number current win streak
                    iNumberCurrentWinStreak = 0;
                }
            }

            //get json from current values
            string jsonResult = GetJsonValues(iNumberWinCount, iNumberWinMaxStreak, iLetterWinCount, iLetterWinMaxStreak);

            return jsonResult;
        }

        private string GetJsonValues(int iNumberWinCount, int iNumberWinMaxStreak, int iLetterWinCount, int iLetterWinMaxStreak)
        {
            Numbers objNumber = new Numbers();
            Letters objLetters = new Letters();

            objNumber.wins = iNumberWinCount;
            objNumber.streak = iNumberWinMaxStreak;

            objLetters.wins = iLetterWinCount;
            objLetters.streak = iLetterWinMaxStreak;

            var jsonResult = new RootObject();

            jsonResult.numbers = objNumber;
            jsonResult.letters = objLetters;
            
            return JsonConvert.SerializeObject(jsonResult);
        }
    }
   
}


