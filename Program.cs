using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace model
{
    class Program
    {
        //метод для заполнения армий,     размер армии,  sw - запись в файл ArmyFile.txt
        public static void Create(List<Unit> Army1, int army1size, StreamWriter sw)
        {
            Random a = new Random();
            for (int i = 0; i < army1size; i++)
            {
                switch (a.Next(7))
                {
                    case 0:
                        {
                            Warrior w = new Warrior(" Warrior №" + i, 5, 2, 6, 5); //имя и номер юнита, уровень здоровья, силы, инициативы, MAX здоровья
                            Army1.Add(w);
                            sw.WriteLine(w);
                            break;
                        }
                    case 1:
                        {
                            Cavalry c = new Cavalry(" Cavalry №" + i, 10, 7, 3, 10);
                            Army1.Add(c);
                            sw.WriteLine(c);
                            break;
                        }
                    case 2:
                        {
                            Archer arc = new Archer(" Archer №" + i, 3, 3, 4, 3);
                            Army1.Add(arc);
                            sw.WriteLine(arc);
                            break;
                        }
                    case 3:
                        {
                            CavalryArcher ca = new CavalryArcher(" CavalryArcher №" + i, 7, 10, 2, 7);
                            Army1.Add(ca);
                            sw.WriteLine(ca);
                            break;
                        }
                    case 4:
                        {
                            Healer h = new Healer(" Healer №" + i, 3, 5, 3);
                            Army1.Add(h);
                            sw.WriteLine(h);
                            break;
                        }
                    case 5:
                        {
                            HealingTower ht = new HealingTower(" HealingTower №" + i, 20, 20, 1);
                            Army1.Add(ht);
                            sw.WriteLine(ht);
                            break;
                        }
                    case 6:
                        {
                            AttackingTower at = new AttackingTower(" AttackingTower №" + i, 30, 20, 1);
                            Army1.Add(at);
                            sw.WriteLine(at);
                            break;
                        }
                }
            }

        }
        static void Main(string[] args)
        {
            {
                StreamWriter sw = new StreamWriter("ArmyFile.txt");  // sw - параметр для записи в файл ArmyFile.txt

                List<Unit> Army1 = new List<Unit>();
                List<Unit> Army2 = new List<Unit>();

                Random a1 = new Random();                           //а1 - переменная отвечающая за выбор численности армий (от 0 до 30 юнитов)
                int army1size = a1.Next(30) + 1;                     //+1 чтобы создавался хотя бы один человек в армии
                int army2size = a1.Next(30) + 1;

                sw.WriteLine("Создаем 1 армию:");
                Create(Army1, army1size, sw);                       //вызываем метод Create и передаем полученные значения

                sw.WriteLine("Создаем 2 армию:");
                Create(Army2, army2size, sw);

                sw.WriteLine("Итоговый размер 1 армии " + Army1.Count);
                sw.WriteLine("Итоговый размер 2 армии " + Army2.Count);

                                                                      //создание боя
                sw.WriteLine("Происходит битва!!!");
                Random b1 = new Random();                             //а1 - переменная отвечающая за выбор численности армий (от 0 до 30 юнитов)
                List<Unit> InitiativArmy_1 = new List<Unit>();        //лист для записи отсортированных юнитов по инициативе для армии 1 и 2
                List<Unit> InitiativArmy_2 = new List<Unit>();

                while ((Army2.Count * Army1.Count) > 0)             
                {
                    for (int ini = 1; (ini < 7) && ((Army2.Count * Army1.Count) > 0); ini++)    //ini - отвечает за инициативу юнитов = 1..6, используется только в этом цикле
                    {
                        for (int i = 0; i < Army1.Count(); i++)
                        {
                            if (Army1[i].Iniciativa == ini) InitiativArmy_1.Add(Army1[i]);
                        }
                        for (int i = 0; i < Army2.Count(); i++)
                        {
                            if (Army2[i].Iniciativa == ini) InitiativArmy_2.Add(Army2[i]);
                        }

                        if ((InitiativArmy_1.Count * InitiativArmy_2.Count) > 0)
                        {
                            switch (b1.Next(2))
                            {
                                case 0:                                                         //первым бьет юнит из 1 армии
                                    {
                                        int p;                        
                                        int w1 = b1.Next(InitiativArmy_1.Count());              //рандомно определяем юнита 1 армии из списка инициатив
                                        int w2 = b1.Next(Army2.Count());                        //рандомно определяем юнита 2 армии из спика армии
                                        sw.WriteLine(InitiativArmy_1[w1].ToString() + " участник битвы 1 армии, " + Army2[w2].ToString() + " участник из 2 армии! ");

                                        int w11 = b1.Next(Army1.Count);                     //рандомно определяем юнита 1 армии из спика армии для лечения
                                        if (!(Army1[w11] is HealingTower) || (!(Army1[w11] is AttackingTower)))   //делаем проверку и лечим
                                        {
                                            if (Army1[w11].Zdorov < Army1[w11].MaxHealth)
                                            {
                                                p = Army1[w11].Zdorov + a1.Next((2));
                                                if (p <= Army1[w11].MaxHealth) { Army1[w11].Zdorov = p; }
                                                else { Army1[w11].Zdorov = Army1[w11].MaxHealth; }
                                                sw.WriteLine("Здоровье воина 1 армии " + Army1[w1].Zdorov);
                                            }

                                            if (InitiativArmy_1[w1] is HealingTower)
                                            {
                                                for (int i = 0; i < a1.Next(1, 3); i++)
                                                {
                                                    if (!(Army1[w11] is HealingTower) || (!(Army1[w11] is AttackingTower)))
                                                    {
                                                        if (Army1[w11].Zdorov < Army1[w11].MaxHealth)
                                                        {
                                                            p = Army1[w11].Zdorov + a1.Next((0) + 15);
                                                            if (p <= Army1[w11].MaxHealth) { Army1[w11].Zdorov = p; }
                                                            else { Army1[w11].Zdorov = Army1[w11].MaxHealth; }
                                                            sw.WriteLine("Здоровье воина 1 армии " + Army1[w11].Zdorov);
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        else sw.WriteLine("Здоровье воина 2 армии: " + Army2[w2].Zdorov + ", а здоровье 1 воина: " + InitiativArmy_1[w1].Zdorov);
                                        p = Army2[w2].Zdorov - InitiativArmy_1[w1].Power;
                                        Army2[w2].Zdorov = p;
                                        if (p <= 0)
                                        {
                                            Army2.RemoveAt(w2);
                                            sw.WriteLine("2 воин убит!");
                                        }
                                        break;
                                    }
                                case 1:                                                         //первым бьет юнит из 2 армии
                                    {
                                        int p;
                                        int w2 = b1.Next(InitiativArmy_2.Count());              //рандомно определяем юнита 2 армии из списка инициатив
                                        int w1 = b1.Next(Army1.Count());                        //рандомно определяем юнита 1 армии из спика армии
                                        sw.WriteLine(InitiativArmy_2[w2].ToString() + " участник битвы 2 армии " + Army1[w1].ToString() + " участник из 1 армии");
                                        int w22 = b1.Next(Army2.Count);
                                        if (!(Army2[w22] is HealingTower) || (!(Army2[w22] is AttackingTower))) //делаем проверку и лечим
                                        {
                                            
                                            if (InitiativArmy_2[w2] is Healer)
                                            {
                                                if (!(Army2[w22] is Tower))
                                                {
                                                    if (Army2[w22].Zdorov < Army2[w22].MaxHealth)
                                                    {
                                                        p = Army2[w22].Zdorov + a1.Next((0) + 2);
                                                        if (p <= Army2[w22].MaxHealth) { Army2[w22].Zdorov = p; }
                                                        else { Army2[w22].Zdorov = Army2[w22].MaxHealth; }
                                                        sw.WriteLine("Здоровье воина 2 армии " + Army2[w22].Zdorov);
                                                    }
                                                }
                                            }
                                            if (InitiativArmy_2[w2] is HealingTower)
                                            {
                                                for (int i = 0; i < a1.Next(1, 3); i++)
                                                {
                                                    if (!(Army2[w22] is HealingTower) || (!(Army2[w22] is AttackingTower)))
                                                    {
                                                        if (Army2[w22].Zdorov < Army2[w22].MaxHealth)
                                                        {
                                                            p = Army2[w22].Zdorov + a1.Next((0) + 15);
                                                            if (p <= Army2[w22].MaxHealth) { Army2[w22].Zdorov = p; }
                                                            else { Army2[w22].Zdorov = Army2[w22].MaxHealth; }
                                                            sw.WriteLine("Здоровье воина 2 армии " + Army2[w22].Zdorov);
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        else sw.WriteLine("Здоровье воина 2 армии: " + Army2[w2].Zdorov + ", а здоровье 1 воина: " + Army1[w1].Zdorov);
                                        p = Army1[w1].Zdorov - Army2[w2].Power;
                                        Army1[w1].Zdorov = p;
                                        if (p <= 0)
                                        {
                                            Army1.RemoveAt(w1);
                                            sw.WriteLine("1 воин убит!");
                                        }
                                        break;
                                    }

                            }
                        }


                        else if (InitiativArmy_1.Count() > 0) 
                        {
                            int p;
                            int w1 = b1.Next(InitiativArmy_1.Count());
                            sw.WriteLine(InitiativArmy_1[w1].ToString() + " участник битвы 1 армии");
                            int w2 = b1.Next(Army2.Count());
                            if (InitiativArmy_1[w1] is Healer)
                            {
                                int w11 = b1.Next(Army1.Count);
                                if (!(Army1[w11] is HealingTower) || (!(Army1[w11] is AttackingTower)))
                                {
                                    if (Army1[w11].Zdorov < Army1[w11].MaxHealth)
                                    {
                                        p = Army1[w11].Zdorov + a1.Next((2));
                                        if (p <= Army1[w11].MaxHealth) { Army1[w11].Zdorov = p; }
                                        else { Army1[w11].Zdorov = Army1[w11].MaxHealth; }

                                        sw.WriteLine("Здоровье воина 1 армии " + Army1[w11].Zdorov);
                                    }
                                }
                            }
                            if (InitiativArmy_1[w1] is HealingTower)
                            {
                                for (int i = 0; i < a1.Next(1, 3); i++)
                                {
                                    int w11 = b1.Next(Army1.Count);
                                    if (!(Army1[w11] is HealingTower) || (!(Army1[w11] is AttackingTower)))
                                    {
                                        if (Army1[w11].Zdorov < Army1[w11].MaxHealth)
                                        {
                                            p = Army1[w11].Zdorov + a1.Next((0) + 15);
                                            if (p <= Army1[w11].MaxHealth) { Army1[w11].Zdorov = p; }
                                            else { Army1[w11].Zdorov = Army1[w11].MaxHealth; }
                                            sw.WriteLine("Здоровье воина 1 армии " + Army1[w11].Zdorov);
                                        }
                                    }
                                }
                            }
                            else sw.WriteLine("Здоровье воина 2 армии: " + Army2[w2].Zdorov + ", а здоровье 1 воина: " + InitiativArmy_1[w1].Zdorov);
                            p = Army2[w2].Zdorov - InitiativArmy_1[w1].Power;
                            Army2[w2].Zdorov = p;
                            if (p <= 0)
                            {
                                Army2.RemoveAt(w2);
                                sw.WriteLine("2 воин убит!");
                            }
                        }

                        else if (InitiativArmy_2.Count() > 0) 
                        {
                            int p;
                            int w2 = b1.Next(InitiativArmy_2.Count());
                            sw.WriteLine(InitiativArmy_2[w2].ToString() + " участник битвы 2 армии");
                            int w1 = b1.Next(Army1.Count());

                            if (InitiativArmy_2[w2] is Healer)
                            {
                                Console.WriteLine("Healer");
                                int w22 = b1.Next(Army2.Count);
                                if (!(Army2[w22] is HealingTower) || (!(Army2[w22] is AttackingTower)))
                                {
                                    if (Army2[w22].Zdorov < Army2[w22].MaxHealth)
                                    {
                                        p = Army2[w22].Zdorov + a1.Next((0) + 2);
                                        if (p <= Army2[w22].MaxHealth) { Army2[w22].Zdorov = p; }
                                        else { Army2[w22].Zdorov = Army2[w22].MaxHealth; }
                                        sw.WriteLine("Здоровье воина 2 армии " + Army2[w22].Zdorov);
                                    }
                                }
                            }
                            if (InitiativArmy_2[w2] is HealingTower)
                            {
                                for (int i = 0; i < a1.Next(1, 3); i++)
                                {
                                    int w22 = b1.Next(Army2.Count);
                                    if (!(Army2[w22] is HealingTower) || (!(Army2[w22] is AttackingTower)))
                                    {
                                        if (Army2[w22].Zdorov < Army2[w22].MaxHealth)
                                        {
                                            p = Army2[w22].Zdorov + a1.Next((0) + 15);
                                            if (p <= Army2[w22].MaxHealth) { Army2[w22].Zdorov = p; }
                                            else { Army2[w22].Zdorov = Army2[w22].MaxHealth; }
                                            sw.WriteLine("Здоровье воина 2 армии " + Army2[w22].Zdorov);
                                        }
                                    }
                                }
                            }

                            else sw.WriteLine("Здоровье воина 2 армии: " + InitiativArmy_2[w2].Zdorov + ", а здоровье 1 воина: " + Army1[w1].Zdorov);
                            p = Army1[w1].Zdorov - InitiativArmy_2[w2].Power;
                            Army1[w1].Zdorov = p;
                            if (p <= 0)
                            {
                                Army1.RemoveAt(w1);
                                sw.WriteLine("1 воин убит!");
                            }
                        }
                    }

                    InitiativArmy_1.Clear();
                    InitiativArmy_2.Clear();
                }

                sw.WriteLine("Итоговый размер 1 армии после боя " + Army1.Count);
                sw.WriteLine("Итоговый размер 2 армии после боя " + Army2.Count);


                if ((Army2.Count > Army1.Count))
                {
                    Console.WriteLine("2 армия победила");
                    sw.WriteLine("2 армия победила");
                }
                else
                {
                    Console.WriteLine("1 армия победила");
                    sw.WriteLine("1 армия победила");
                }

                sw.Close(); //закрыли запись в файл

                Console.ReadLine();

            }
        }
    }
}
