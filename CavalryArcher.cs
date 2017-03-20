using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    class CavalryArcher : Archer
    {
        public CavalryArcher(string Name, int Zdorov, int Power, int Iniciativa, int MaxHealth) : base(Name, Zdorov, Power, Iniciativa, 7)
        {
            if (zdorov > 0) { zdorov = Zdorov = 7; }

            if (Power == 10) { power = Power; }

            if (Iniciativa == 2) { iniciativa = Iniciativa; }
            MaxHealth = 7;
        }
    }
}
