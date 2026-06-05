namespace TextBattleWithMob
{
    internal class Program
    {
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

                                int playerDodgeRoll = random.Next(1, 101);
                                int mobDodgeRoll = random.Next(1, 101);
                                int playerCritRoll = random.Next(1, 101);
                                int mobCritRoll = random.Next(1, 101);

                                if (mobDodgeRoll <=16)
                                {
                                    Console.WriteLine("Враг уворачивается от втоего удара!");
                                }
                                else
                                {
                                    if (playerCritRoll <= 21)
                                    {
                                        mobRandomHP = mobRandomHP - (playerDamege + playerDamege);
                                        Console.WriteLine($"Критчиеское поподание по врагу и нанес ему {playerDamege + playerDamege} урона у врага осталось {mobRandomHP}");
                                    }
                                    else
                                    {
                                        mobRandomHP = mobRandomHP - playerDamege;
                                        Console.WriteLine($"Ты попал по врагу и нанес ему {playerDamege} урона у врага осталось {mobRandomHP}");
                                    }

                                }

                                if (playerDodgeRoll <= 16)
                                { 
                                Console.WriteLine("Ты увернулся от удара");
                                }
                                else
                                {
                                    if (mobCritRoll <= 21)
                                    {
                                        playerHP = playerHP - (mobRandomDamage + mobRandomDamage);
                                        Console.WriteLine($"Враг нанес тебе критический удар {mobRandomDamage + mobRandomDamage} и оставил тебе {playerHP}");
                                    }
                                    else
                                    {
                                        playerHP = playerHP - mobRandomDamage;
                                        Console.WriteLine($"Враг ударил по тебе и наносит {mobRandomDamage} урона и оставил тебе {playerHP}");
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
