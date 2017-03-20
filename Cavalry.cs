using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    class Cavalry : Warrior
    {
        public Cavalry(string Name, int Zdorov, int Power, int Iniciativa, int MaxHealth) : base(Name, Zdorov, Power, Iniciativa, 10)
        {
            if (zdorov > 0) { zdorov = Zdorov = 10; }

            if (Power == 7) { power = Power; }

            if (Iniciativa == 3) { iniciativa = Iniciativa; }
            MaxHealth = 10;
            
        }
    }
}
