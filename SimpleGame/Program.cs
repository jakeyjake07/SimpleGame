namespace SimpleGame;

class Program
{
    static Random rng = new Random();

    static void Main(string[] args)
    {   //Player setup
        System.Console.WriteLine("-----Welcome to SimpleGame!----- ");
        System.Console.WriteLine("Enter your name: ");
        string name = Console.ReadLine();

        System.Console.WriteLine("Choose your class: ");
        System.Console.WriteLine("1. Warrior");
        System.Console.WriteLine("2. Mage");


        Player player = null;

        while (true)
        {
            System.Console.WriteLine("Enter 1 or 2:");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                player = new Player(name, "Warrior", 120, 15);
                break;
            }

            else if (choice == "2")
            {
                player = new Player(name, "Mage", 80, 25);
                break;
            }

            else
            {
                System.Console.WriteLine("Invalid choice. Please enter 1 or 2.");
            }



        }



        System.Console.WriteLine($"\nWelcome, {name} the {player.Class}!");
        player.ShowProfile();


        //Enemy setup

        Enemy[] enemies = new Enemy[]
        {
            new Enemy("Goblin", 50, 10,  5,  10),
            new Enemy("Orc", 80, 15, 10,  20),
            new Enemy("Skeleton", 40, 12,  8,  15),
            new Enemy("Dark Mage", 60, 18, 20,  30),
            new Enemy("Dragon", 200, 30, 50, 100)
        };


        //Menu Loop

        bool isRunning = true;
        bool hasRested = false;

        while (isRunning)
        {
            
            Console.WriteLine("\n-----Menu------");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Rest");
            Console.WriteLine("3. Show Profile");
            Console.WriteLine("4. Exit Game");

            Console.WriteLine("Choose an option: ");
            string input = Console.ReadLine();
            Console.Clear();

            switch (input)
            {
                case "1":
                    Fight(player, enemies);
                    hasRested = false;
                    break;

                case "2":
                    if (!hasRested)
                    {
                        Rest(player);
                        hasRested = true;
                    }
                    else
                    {
                        Console.WriteLine("You have already rested.");
                    }
                    break;

                case "3":
                    player.ShowProfile();
                    break;

                case "4":
                    Console.WriteLine("Goodbye!");
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }

    }


    static void Fight(Player player, Enemy[] enemies)
    {
        Enemy template = enemies[rng.Next(enemies.Length)];
        Enemy enemy = new Enemy(template.Name, template.MaxHealth, template.Attack, template.GoldReward, template.XpReward);
        Console.WriteLine($"You encountered a {enemy.Name}!");
        int healUsed = 0;

        while (player.Health > 0 && enemy.Health > 0)
        {
            
            Console.WriteLine("-----Fight Menu------");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Heal");
            Console.WriteLine("3. Run");
            Console.WriteLine("Choose an option: ");
            string action = Console.ReadLine();
            Console.Clear();

            //Player turn
            switch (action)
            {
                case "1":
                    Console.WriteLine($"You attacked the {enemy.Name} for {player.Attack} damage.");
                    enemy.TakeDamage(player.Attack);
                    Console.WriteLine($"The {enemy.Name} HP: {enemy.Health}/{enemy.MaxHealth}.");
                    break;

                case "2":
                    if (healUsed < 3)
                    {

                        int healAmount = player.Level * 20;
                        player.Heal(healAmount);
                        healUsed++;
                        Console.WriteLine($"You healed for {healAmount} health.");
                        Console.WriteLine($"Your HP: {player.Health}/{player.MaxHealth}");
                        System.Console.WriteLine($"You have used {healUsed}/3 heals.");

                    }

                    else
                    {
                        Console.WriteLine("You have used all your heals.");
                    }

                    break;

                case "3":
                    Console.WriteLine($"You ran away from the {enemy.Name}.");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;

            }


            if (enemy.Health <= 0)
            {
                Console.WriteLine($"You have defeated {enemy.Name}!");
                player.EarnReward(enemy.GoldReward, enemy.XpReward);
                return;
            }


            //Enemy turn
            Console.WriteLine($"{enemy.Name} attacks you for {enemy.Attack} damage.");
            player.TakeDamage(enemy.Attack);
            Console.WriteLine($"Your HP: {player.Health}/{player.MaxHealth}");


            if (player.Health <= 0)
            {
                Console.WriteLine("You have been defeated!");

                Console.WriteLine("-----Game Over------");
                Console.WriteLine("1. Retry (new character)");
                Console.WriteLine("2. Exit Game");
                Console.WriteLine("Choose an option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Main(new string[0]);
                }

                else if (choice == "2")
                {
                    Environment.Exit(0);
                }

                else
                {
                    Console.WriteLine("Invalid option. Please choose again.");
                }

            }



        }


    }

    static void Rest(Player player)
    {
        int healAmount = player.Level * 50;
        player.Heal(healAmount);
        Console.WriteLine($"You rested and recovered {healAmount} health.");
        Console.WriteLine($"Your HP: {player.Health}/{player.MaxHealth}");

    }


}

