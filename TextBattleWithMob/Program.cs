using System.Diagnostics.Contracts;

namespace TextBattleWithMob
{
    internal class Program
    {
        static int Attack(int damage,int hp, int dodgeRoll, int personCritRoll)
        {
            int dodgeChance = 15;
            int critChance = 20;

            if (dodgeRoll <= dodgeChance)
            {
                Console.WriteLine("Уворот от атаки!");
            }
            else
            {
                if (personCritRoll <= critChance)
                {
                    hp = hp - (damage * 2);
                    Console.WriteLine($"Критчиеское поподание, нанесено {damage * 2} урона, осталось {hp} здровья");
                }
                else
                {
                    hp = hp - damage;
                    Console.WriteLine($"Попадание, нанесено {damage} урона, осталось {hp} здровья");
                }
            }
            return hp;
        }

        static int Deffence(int damage, int hp, int dodgeRoll, int personCritRoll)
        {
            int dodgeChance = 15;
            int critChance = 20;

            if (dodgeRoll <= dodgeChance)
            {
                Console.WriteLine("Уворот от атаки!");
            }
            else
            {
                if (personCritRoll <= critChance)
                {
                    hp = hp - (damage / 2);
                    Console.WriteLine($"Критчиеское поподание, нанесено {damage / 2} урона, осталось {hp} здровья");
                }
                else
                {
                    hp = hp - (damage / 3);
                    Console.WriteLine($"Попадание, нанесено {damage / 3} урона, осталось {hp} здровья");
                }
            }
            return hp;
        }

        static int Counterattack(int damage, int hp, int dodgeRoll, int personCritRoll)
        {
            int dodgeChance = 15;
            int critChance = 20;

            if (dodgeRoll <= dodgeChance)
            {
                Console.WriteLine("Уворот от атаки!");
            }
            else
            {
                if (personCritRoll <= critChance)
                {
                    hp = hp - (damage * 3);
                    Console.WriteLine($"Критчиеское поподание, нанесено {damage * 3} урона, осталось {hp} здровья");
                }
                else
                {
                    hp = hp - (damage * 2);
                    Console.WriteLine($"Попадание, нанесено {damage * 2} урона, осталось {hp} здровья");
                }
            }
            return hp;
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            string[] nameMobs = { "Варвар", "Лучник", "Убийца", "Громила", "Корманик", "Маг" };


            while (true)
            {

                int mobRandomHP = random.Next(8, 14) * 10;
                int mobRandomDamage = random.Next(1, 5) * 10;

                Console.Write("Введите имя игрока: ");
                string namePlayer = Console.ReadLine();
                int playerHP = random.Next(10,16) * 10;
                int playerDamege = random.Next(1, 3) * 10;

                string selectNameMob = nameMobs[random.Next(nameMobs.Length)];
                Console.WriteLine($"Твое имя: {namePlayer} HP: {playerHP} Атака: {playerDamege}");
                Console.WriteLine($"Твой противник:");
                Console.WriteLine($"Имя твоего врага: {selectNameMob} HP: {mobRandomHP} Атака: {mobRandomDamage}");
                Console.WriteLine("Твои действия: 1 - Сражаться 2 - Бежать");
                string checkSwitch = Console.ReadLine();
                switch (checkSwitch)
                {
                    case "1":
                        {
                            //int timeHPPlayer, timeHPMobs;
                            int raund = 1;

                            while (playerHP > 0 && mobRandomHP > 0)
                            {
                                Console.WriteLine("=================================================================");
                                Console.WriteLine($"Раунд {raund}");
                                Console.WriteLine("=================================================================");
                                
                                //int dodgeChance = 15; 
                                //int critChance = 20;

                                int playerDodgeRoll = random.Next(1, 101);
                                int mobDodgeRoll = random.Next(1, 101);
                                int playerCritRoll = random.Next(1, 101);
                                int mobCritRoll = random.Next(1, 101);
                                int mobAction = random.Next(1, 4);

                                Console.WriteLine("Вывбери дейсвие: 1 - атаковать 2 - защищаться 3 - контратака");
                                string playerChoice = Console.ReadLine();
                                if (!int.TryParse(playerChoice, out int playerChoiceInt))
                                {
                                    Console.WriteLine("Введите число от 1 до 2");
                                    continue;
                                }

                                if (playerChoiceInt == mobAction)
                                {
                                    Console.WriteLine("Равный бой — атаки отменяют друг друга!");
                                }
                                else
                                {

                                    switch (playerChoice)
                                    {
                                        case "1":
                                            {
                                                Console.Write($"{namePlayer} делает свой ход, результат атаки =  ");
                                                mobRandomHP = Attack(playerDamege, mobRandomHP, mobDodgeRoll, playerCritRoll);
                                                break;
                                            }
                                        case "2":
                                            {
                                                Console.Write($"{namePlayer} делает свой ход, результат атаки =  ");
                                                mobRandomHP = Deffence(playerDamege, mobRandomHP, mobDodgeRoll, playerCritRoll);
                                                break;
                                            }
                                        case "3":
                                            {
                                                Console.Write($"{namePlayer} делает свой ход, результат атаки =  ");
                                                mobRandomHP = Counterattack(playerDamege, mobRandomHP, mobDodgeRoll, playerCritRoll);
                                                break;
                                            }
                                        default:
                                            {
                                                Console.WriteLine("Такого варианта действия нет, пока ты думал ты пропустил ход");
                                                break;
                                            }
                                    }

                                    switch (mobAction)
                                    {
                                        case 1:
                                            {
                                                Console.Write($"{selectNameMob} делает свой ход, результат атаки =  ");
                                                playerHP = Attack(mobRandomDamage, playerHP, playerDodgeRoll, mobCritRoll);
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.Write($"{selectNameMob} делает свой ход, результат атаки =  ");
                                                playerHP = Deffence(mobRandomDamage, playerHP, playerDodgeRoll, mobCritRoll);
                                                break;
                                            }
                                        case 3:
                                            {
                                                Console.Write($"{selectNameMob} делает свой ход, результат атаки =  ");
                                                playerHP = Counterattack(mobRandomDamage, playerHP, playerDodgeRoll, mobCritRoll);
                                                break;
                                            }
                                        default:
                                            {
                                                Console.WriteLine("Такого варианта действия нет, пока ты думал ты пропустил ход");
                                                break;
                                            }
                                    }
                                }
        

                                raund++;

                                if (playerHP <= 0 && mobRandomHP <= 0)
                                {
                                    Console.WriteLine("Храбрые войны погибли в бою");
                                }
                                else if (mobRandomHP <= 0)
                                {
                                    Console.WriteLine("Боги улыбаюсят твоей победе");
                                }
                                else if (playerHP <= 0)
                                {
                                    Console.WriteLine($"Нет, {namePlayer}. Ты храбро сражался. Ты сохранил честь");
                                }

                                Console.WriteLine("-----------------------------------------------------------------");
                                Console.WriteLine("Нажми Enter чтобы перейти к следующему раунду");
                                Console.ReadKey();
                            }
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Ты мог бы и попытать удачу в сражении!");
                            break;
                        }
                    default: 
                        {
                            Console.WriteLine("Тaкого варианта дейсвия нет!"); break;
                        }
                }

            }

        }
    }
}
