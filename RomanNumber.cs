using System;
using System.Collections.Generic;

namespace ChiffresRomains
{
    internal class RomanNumber
    {
        private int myNum;
        public string myRomanNum { get; private set; }
        public List<RomanValue> RomanValues { get; set; }
        public List<EquivalentPattern> EquivalentPatterns { get; set; }

        public RomanNumber(int myNum)
        {
            this.myNum = myNum;

            BuildRomanValues();
        }

        /// <summary>
        /// définition des chiffres romains de base
        /// </summary>
        private void BuildRomanValues()
        {
            this.RomanValues = new List<RomanValue>()
            {
                new RomanValue(){Letter = 'M', Numeric = 1000},
                new RomanValue(){Letter = 'D', Numeric = 500},
                new RomanValue(){Letter = 'C', Numeric = 100},
                new RomanValue(){Letter = 'L', Numeric = 50},
                new RomanValue(){Letter = 'X', Numeric = 10},
                new RomanValue(){Letter = 'V', Numeric = 5},
                new RomanValue(){Letter = 'I', Numeric = 1},
            };

            this.EquivalentPatterns = new List<EquivalentPattern>()
            {
                new EquivalentPattern(){Num1 = "VIIII", Num2 = "IX"},
                new EquivalentPattern(){Num1 = "IIII", Num2 = "IV"},
                new EquivalentPattern(){Num1 = "LXXXX", Num2 = "XC"},
                new EquivalentPattern(){Num1 = "XXXX", Num2 = "XL"},
                new EquivalentPattern(){Num1 = "DCCCC", Num2 = "CM"},
                new EquivalentPattern(){Num1 = "CCCC", Num2 = "CD"}
            };
        }

        public string TranslateInRoman()
        {
            foreach (var itemRomanVal in RomanValues)
            {
                CompleteRomanNumber(itemRomanVal);
            }

            return this.myRomanNum;
        }

        /// <summary>
        /// calcule et stocke (dans myRomanNum) les chiffres rommains correspondants
        /// </summary>
        /// <param name="romanValue"></param>
        private void CompleteRomanNumber(RomanValue romanValue)
        {
            int nbOfM = this.myNum / romanValue.Numeric;

            if (nbOfM >= 1)
            {
                this.myRomanNum += new string(romanValue.Letter, nbOfM);

                this.myNum -= nbOfM * romanValue.Numeric;
            }
        }

        /// <summary>
        /// génére une ecriture équivalante, pour les nombres qui contiennent les chiffres 4 et 9
        /// </summary>
        /// <returns></returns>
        public string EquivalentWriting()
        {
            string myAlternateRomanNum = this.myRomanNum;

            foreach (var itemAlternate in this.EquivalentPatterns)
            {
                myAlternateRomanNum = myAlternateRomanNum.Replace(itemAlternate.Num1, itemAlternate.Num2);
            }

            if (myAlternateRomanNum != this.myRomanNum)
            {
                return myAlternateRomanNum;
            }

            return "pas d'ecriture équivalente";
        }
    }
}