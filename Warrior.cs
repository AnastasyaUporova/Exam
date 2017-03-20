using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    class Warrior : Unit
    {
        public Warrior(string Name, int Zdorov, int Power, int Iniciativa, int MaxHealth) : base(Name, Zdorov, Power, Iniciativa, 5)
        {

            if (Zdorov == 5) { zdorov = Zdorov; }

            if (Power == 2) { power = Power; }

            if (Iniciativa == 6) { iniciativa = Iniciativa; }
            MaxHealth = 5;
        }
    }
}
