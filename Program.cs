using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiffresRomains
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sortir = false;

            while (!sortir)
            {
                bool myNumIsAnInteger = false;
                int myNum = 0;
                string messageInit = "entrer un entier :";

                while (!myNumIsAnInteger)
                {
                    try
                    {
                        Console.WriteLine(messageInit);
                        string myNumString = Console.ReadLine();

                        myNum = Int32.Parse(myNumString);
                        myNumIsAnInteger = true;
                    }
                    catch (Exception)
                    {
                        messageInit = "Il faut que ce soit un entier :";
                    }
                }

                Console.WriteLine("le chiffre rommain correspondant est : ");
                RomanNumber myRomanNumber = new RomanNumber(myNum);
                Console.WriteLine(myRomanNumber.TranslateInRoman());
                Console.WriteLine("ecriture alternative : " + myRomanNumber.EquivalentWriting());

                Console.WriteLine("continuer : entrer 'non' pour sortir");
                string continuerOuiNon = Console.ReadLine();
                if (continuerOuiNon.ToUpper() == "N" || continuerOuiNon.ToUpper() == "NON")
                {
                    sortir = true;
                }
            }

        }
    }
}
