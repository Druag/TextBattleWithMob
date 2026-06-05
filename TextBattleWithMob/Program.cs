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
                            while(playerHP > 0 && mobRandomHP > 0)
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

                                Console.Write($"{namePlayer} делает свой ход, результат атаки =  ");
                                playerHP = Attack(playerDamege, mobRandomHP, mobDodgeRoll, playerCritRoll);
                                Console.Write($"{selectNameMob} делает свой ход, результат атаки =  ");
                                mobRandomHP = Attack(mobRandomDamage, playerHP, playerDodgeRoll, mobCritRoll);

                                /*
                                if (mobDodgeRoll <= dodgeChance)
                                {
                                    Console.WriteLine("Враг уворачивается от втоего удара!");
                                }
                                else
                                {
                                    if (playerCritRoll <= critChance)
                                    {
                                        mobRandomHP = mobRandomHP - (playerDamege * 2);
                                        Console.WriteLine($"Критчиеское поподание по врагу и нанес ему {playerDamege * 2} урона у врага осталось {mobRandomHP}");
                                    }
                                    else
                                    {
                                        mobRandomHP = mobRandomHP - playerDamege;
                                        Console.WriteLine($"Ты попал по врагу и нанес ему {playerDamege} урона у врага осталось {mobRandomHP}");
                                    }

                                }
                                

                                if (playerDodgeRoll <= dodgeChance)
                                { 
                                Console.WriteLine("Ты увернулся от удара");
                                }
                                else
                                {
                                    if (mobCritRoll <= critChance)
                                    {
                                        playerHP = playerHP - (mobRandomDamage * 2);
                                        Console.WriteLine($"Враг нанес тебе критический удар {mobRandomDamage * 2} и оставил тебе {playerHP}");
                                    }
                                    else
                                    {
                                        playerHP = playerHP - mobRandomDamage;
                                        Console.WriteLine($"Враг ударил по тебе и наносит {mobRandomDamage} урона и оставил тебе {playerHP}");
                                    }

                                }
                                */

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
