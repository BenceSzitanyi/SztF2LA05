using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace IntFeladatok
{
    internal class PlasztikKartya : ITulajdon
    {
        string tulajdonos;
        public string Tulajdonos { get { return tulajdonos; } }

        public PlasztikKartya(string tulajdonos)
        {
            this.tulajdonos = tulajdonos;
        }
    }

    internal class BankKartya : PlasztikKartya, IFizetoEszkoz
    {
        int egyenleg;

        public int Egyenleg { get { return egyenleg; } }
        
        public BankKartya(string tulajdonos) : base(tulajdonos)
        {
            egyenleg = Util.rnd.Next(15000);
        }

        public virtual bool Fizet(int osszeg)
        {
            if (egyenleg < osszeg)
            {
                Console.WriteLine("Nem tudsz fizetni");
                return false;
            }
            else
            {
                egyenleg = egyenleg - osszeg;
                return true;
            }
        }
    }
    internal class LetiltottBankKartya : BankKartya, ITulajdon, IElveszett
    {
        DateTime eltunesIdeje;
        public LetiltottBankKartya(string tulajdonos) : base(tulajdonos)
        {

        }

        public DateTime EltunesIdeje { get { return eltunesIdeje; } set { eltunesIdeje = value; } }

        public override bool Fizet(int osszeg)
        {
            Console.WriteLine("A kártya letiltva. Fizetés nem lehetséges");
            return false;
        }
    }

    internal class Hitel : IFizetoEszkoz
    {
        int hitelOsszege;

        public Hitel()
        {
            hitelOsszege = Util.rnd.Next(15000);
        }

        public bool Fizet(int osszeg)
        {
            hitelOsszege -= osszeg;
            return true;
        }
    }
}
