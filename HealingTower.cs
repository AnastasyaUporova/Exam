using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    class HealingTower : Tower
    {
        public HealingTower(string Name, int Zdorov, int Iniciativa, int MaxHealth) : base(Name, Zdorov, 0, Iniciativa, 20)
        {
            if (zdorov > 0) { zdorov = Zdorov = 20; }

            if (Iniciativa == 1) { iniciativa = Iniciativa; }
            MaxHealth = 20;

        }
    }
}
