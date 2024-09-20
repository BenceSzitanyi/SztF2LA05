using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntFeladatok
{
    internal interface IFizetoEszkoz
    {
        bool Fizet(int osszeg);
    }

    internal interface ITulajdon
    { 
        string Tulajdonos { get; }
    }

    internal interface IElveszett : ITulajdon
    { 
        DateTime EltunesIdeje { get; set; }
    }
}
