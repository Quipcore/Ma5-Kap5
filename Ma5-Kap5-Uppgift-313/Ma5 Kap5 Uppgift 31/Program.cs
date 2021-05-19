using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Ma5_Kap5_Uppgift_31
{
    /*Ett primtal är ett naturligt tal, som är större än 1 och som inte har några andra positiva delare än 1 och talet självt - Wikipedia
  * 
  * a) De franska matematikerna Mersenne och Fermat som levede på 1600-talet studerade primtalen i olika talföljder.
  *      Mn = (2^n) - 1, där n är ett positivit heltal
  *      Mersenne ansåg att talföljden gav primtal för n = 2, 3, 5, 7, 13, 17, 19, 31, 67, 127 och 257.
  *      Hade han rätt?
  *      
  *      Fermat ansåg att talföljden:
  *      Fn = (2^(2n)) + 1, där n = 0, 1, 2, 3, 4,...
  *      gav primtal för alla n. Han verifierade detta för upp till n = 4.
  *      Hur är det för n = 5 och n = 6?
  *  
  *  b) Finns det alltid ett primtal mellan n^2 och (n+1)^2, där n är ett postitiv heltal?
  *      Formulera en hypotes
  * 
  */
    class Program
    {
        static void Mersenne_Talföljd()
        {
            //Mn = (2 ^ n) - 1, där n är ett positivit heltal
            //Mersenne ansåg att talföljden gav primtal för n = 2, 3, 5, 7, 13, 17, 19, 31, 67, 127 och 257. Hade han rätt

            BigInteger Mn;
            int[] Mtn = new int[11] { 2, 3, 5, 7, 13, 17, 19, 31, 67, 127, 257 }; //Mtn = Mersenne Talföljd Nummer

            for(int k = 0; k < Mtn.Length; k++)
            {
                Mn = BigInteger.Pow(2, Mtn[k]) - 1;
            }

            string[] primtal = new string[11];
            Console.WriteLine("");

            for(int n = 0; n < Mtn.Length; n++)
            {
                Mn = BigInteger.Pow(2, Mtn[n]) - 1;

                Console.WriteLine(Mtn[n] + " " + Mn);

                for (int i = 2; i <= Mn; i++)
                {
                    if ((Mn % i == 0) && (Mn != i))
                    {
                       // Console.WriteLine(Mn + " Är inget Primtal, minsta faktor är " + i);
                        primtal[n] = "n = " + n + ", Fn =" + Mn + " Är INTE ett primtal";
                        break;
                    }
                    else if ((Mn % i == 0) && (Mn == i))
                    {
                        //Console.WriteLine(Mn + " Är ett Primtal");
                        primtal[n] = "n = " + n + ", Fn = " + Mn + " Är ett primtal";
                    }
                    Console.WriteLine(i + ", " + n + ", " + Mn);
                }
                Console.WriteLine("");
            }
            for (int l = 0; l < primtal.Length; l++)
            {
                Console.WriteLine(primtal[l]);
            }
        }

        static void Mersenne_Talföljd_LucasLehmer()
        {
            int[] Mtn = new int[11] { 2, 3, 5, 7, 13, 17, 19, 31, 67, 127, 257 }; //Mtn = Mersenne Talföljd Nummer
            string[] primtal = new string[11];

            for (int k = 0; k < Mtn.Length; k++)
            {
                BigInteger s = 4;
                int n = Mtn[k];
                BigInteger M = BigInteger.Pow(2, n) - 1;

                if(n==2)
                {
                    primtal[k] = ("n = " + n + ", M = " + M + ", Talet är ett primtal");
                }
                else
                {
                    for (int i = 3; i <= n; i++)
                    {
                        s = (BigInteger.Pow(s, 2) - 2) % M;
                        Console.WriteLine("i = " + i + ", s = " + s);
                    }

                    if (s == 0)
                    {
                        primtal[k] = ("n = " + n + ", M = " + M + ", Talet är ett primtal");
                    }
                    else
                    {
                        primtal[k] = ("n = " + n + ", M = " + M + ", Talet är inte ett primtal");
                    }
                }
                Console.WriteLine("");
            }


            Console.WriteLine("M = 2^n - 1");
            Console.WriteLine("");
            for (int l = 0; l < primtal.Length; l++)
            {
                Console.WriteLine(primtal[l]);
            }
            Console.WriteLine();
        }

        static void Fermat_Talföljd()
        {
            /*
            *Fermat ansåg att talföljden:
            *Fn = (2 ^ (2^n)) +1, där n = 0, 1, 2, 3, 4,...
             *gav primtal för alla n. Han verifierade detta för upp till n = 4.
            * Hur är det för n = 5 och n = 6 ?
            */

            BigInteger BigFn;
            string[] primtal = new string[7]; 

            int Gräns = 6;
            for (int n = 0; n <= Gräns; n++)
            {
                //Fn = Math.Pow(2, 2*n) + 1;
                BigInteger Q = BigInteger.Pow(2, n);
                BigFn = BigInteger.Pow(2, (int)Q) + 1;

                Console.WriteLine("n = " + n + ", Fn = " + BigFn);

                for (int i = 2; i <= BigFn; i++)
                {
                    if ((BigFn % i == 0) && (BigFn != i))
                    {
                        //Console.WriteLine(BigFn + " Är inget Primtal, minsta faktor är " + i);
                        primtal[n] = "n = " + n + ", Fn = " + BigFn + ", Är INTE ett primtal";
                        break;
                    }
                    else if ((BigFn % i == 0) && (BigFn == i))
                    {
                        //Console.WriteLine(BigFn + " Är ett Primtal");
                        primtal[n] = "n = " + n + ", Fn = " + BigFn + ", Är ett primtal";
                    }
                    Console.WriteLine(i + ", " + n + ", " + BigFn);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Fn = 2^(2^n) + 1");
            Console.WriteLine();
            for (int k = 0; k < primtal.Length; k++)
            {
                Console.WriteLine(primtal[k]);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Boolean Rep = true;
            while (Rep)
            {
                Console.WriteLine("1. Mersennes Talföljden (Utan Lucas-Lehmer metoden)");
            Console.WriteLine("2. Mersennes Talföljd (med Lucas-Lehmer metoden)");
            Console.WriteLine("3. Fermats Talföljd");

            int caseSwitch = Int32.Parse(Console.ReadLine());


                switch (caseSwitch)
                {
                    case 1:
                        Mersenne_Talföljd(); //Utan Lucas-Lehmer metoden
                        break;
                    case 2:
                        Mersenne_Talföljd_LucasLehmer(); //Med Lucas-Lehmer metoden
                        break;
                    case 3:
                        Fermat_Talföljd();
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }

                Console.WriteLine("");
                Console.WriteLine("1. Avsluta");
                Console.WriteLine("2. Fortsätt");
                int RepSwitch = Int32.Parse(Console.ReadLine());
                switch (RepSwitch)
                {
                    case 1:
                        Rep = false;
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }
            //Console.ReadKey();
        }
    }
}
