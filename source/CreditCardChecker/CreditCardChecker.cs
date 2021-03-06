﻿using System;

namespace CreditCardChecker
{
    public class CreditCardChecker
    {
        /// <summary>
        /// Diese Methode überprüft eine Kreditkartenummer, ob diese gültig ist.
        /// Regeln entsprechend der Angabe.
        /// </summary>
        public static bool IsCreditCardValid(string creditCardNumber)
        {
            if (creditCardNumber.Length != 16) return false;
            

            int sumEven = 0;
           
            for (int i = 0; i % 2 == 0 && i < creditCardNumber.Length-1; i++)
            {
                if (!Char.IsDigit(creditCardNumber[i])) return false;
                
                if (ConvertToInt(creditCardNumber[i]) * 2 < 10) sumEven += ConvertToInt(creditCardNumber[i]);
                else  sumEven += CalculateDigitSum(ConvertToInt(creditCardNumber[i]));
            }

            int sumOdd = 0;
            for(int i = 0; i % 2 != 0 && i < creditCardNumber.Length-1; i++)
            {
                if (!Char.IsDigit(creditCardNumber[i])) return false;
                sumOdd += ConvertToInt(creditCardNumber[i]);
            }

            if (CalculateCheckDigit(sumOdd, sumEven).Equals(ConvertToInt(creditCardNumber[15]))) return true;

            return false;

        }

        /// <summary>
        /// Berechnet aus der Summe der geraden Stellen (bereits verdoppelt) und
        /// der Summe der ungeraden Stellen die Checkziffer.
        /// </summary>
        private static int CalculateCheckDigit(int oddSum, int evenSum)
        {
            for (int i = 0; i < 9; i++)
            {
                if (((oddSum + evenSum) + i) % 10 == 0) return i;
            }
            return -1;
        }

        /// <summary>
        /// Berechnet die Ziffernsumme einer Zahl.
        /// </summary>
        private static int CalculateDigitSum(int number)
        {
            int digitsum = 0;
            while(number > 0)
            {
                digitsum += number % 10;
                number /= 10;
            }
            return digitsum;
        }

        private static int ConvertToInt(char ch)
        {
            return ch - '0';
        }
    }
}
