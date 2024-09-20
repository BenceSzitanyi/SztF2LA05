using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntFeladatok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFizetoEszkoz[] eszkozok = new IFizetoEszkoz[3];

            eszkozok[0] = new LetiltottBankKartya("Béla");
            eszkozok[1] = new BankKartya("Tsaba");
            eszkozok[2] = new LetiltottBankKartya("Kitti");

            bool a = Fizet(eszkozok);

            Console.WriteLine(a);

            Console.ReadLine();
        }

        static bool Fizet(IFizetoEszkoz[] eszkozok)
        {
            for (int i = 0; i < eszkozok.Length; i++)
            {
                bool fel = eszkozok[i].Fizet(Util.rnd.Next(2));
                if (fel)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
