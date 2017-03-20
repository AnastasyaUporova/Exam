using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    class AttackingTower : Tower
    {
        public AttackingTower(string Name, int Zdorov, int Power, int Iniciativa) : base(Name, Zdorov, Power, Iniciativa, 30)
        {

            if (Zdorov == 30) { zdorov = Zdorov; }

            if (Power == 20) { power = Power; }

            if (Iniciativa == 1) { iniciativa = Iniciativa; }
            MaxHealth = 30;

        }
    }
}
