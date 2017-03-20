using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Archer : Unit
    {
        public Archer(string Name, int Zdorov, int Power, int Iniciativa, int MaxHealth) : base(Name, Zdorov, Power, Iniciativa, 3)
        {
           

           if (Zdorov == 3) { zdorov = Zdorov; }

           if (Power == 3) { power = Power; }

            if (Iniciativa == 4) { iniciativa = Iniciativa; }

            MaxHealth = 3;
        }
    }
       
}
