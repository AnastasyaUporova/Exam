using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    abstract class Tower : Unit
    {
        public Tower(string Name, int Zdorov, int Power, int Iniciativa, int MaxHealth) : base(Name, Zdorov, Power, Iniciativa, MaxHealth)
        {

            
        }
    }
}
