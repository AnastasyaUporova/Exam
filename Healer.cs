using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    class Healer : Unit
    {
        public Healer(string Name, int Zdorov, int Iniciativa, int MaxHealth) : base (Name, Zdorov, 0, Iniciativa, 3)
        {

            if (zdorov > 0) { zdorov = Zdorov = 3; }
            
            MaxHealth = 3;
            Iniciativa = 5;
        }
    }
}