using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Unit
    {
        protected String name;
        protected int zdorov;
        protected int power;
        public int iniciativa;
        protected int maxHealth; //переменная отвечающая за макисмальное здоровье, нужна в бою при лечении


        public Unit(string Name, int Zdorov, int Power, int Iniciativa, int MaxHealth)
        {
            name = Name;
            zdorov = Zdorov;
            power = Power;
            iniciativa = Iniciativa;
            maxHealth = MaxHealth;
        }
        public override string ToString()
        {
            return name + " " + zdorov + " " + power + " " + iniciativa;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Zdorov
        {
            get { return zdorov; }
            set { zdorov = value; }
        }


        public int Iniciativa
        {
            get { return iniciativa; }
            set { iniciativa = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public int MaxHealth
        {


            get { return maxHealth; }
            set { maxHealth = value; }
        }

    }
}
