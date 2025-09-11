using System;
using SimpleGame;

class Player
{
    public string Name;
    public string Class;
    public int Health;
    public int MaxHealth;
    public int Attack;
    public int Level;
    public int Gold;
    public int XP;
    public int xpToNextLevel;

    public Player(string name,string playerClass, int maxHealth, int attack)
    {   
        Name = name;
        Class = playerClass;
        Health = maxHealth;
        MaxHealth = maxHealth;
        Attack = attack;
        Level = 1;
        Gold = 0;
        XP = 0;
        xpToNextLevel = 100;
    }


    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
    }

    public void Heal(int amount)
    {
        Health += amount;
        if (Health > MaxHealth) Health = MaxHealth;
    }

    public void EarnReward(int gold, int xp)
    {
        Gold += gold;
        XP += xp;
        Console.WriteLine($"You earned {gold} gold and {xp} xp!");
        CheckLevelUp();

    }

    private void CheckLevelUp()
    {
        while (XP >= xpToNextLevel)
        {
            XP -= xpToNextLevel;
            Level++;
            xpToNextLevel = (int)(xpToNextLevel * 1.5);
            Health += 10;
            Attack += 2;
            Health = MaxHealth;
            Console.WriteLine($"You leveled up to level {Level}!");
        }
    }


    public void ShowProfile()
    {
        Console.Clear();
        Console.WriteLine("\n====================");
        Console.WriteLine("   PLAYER PROFILE   ");
        Console.WriteLine("====================");
        Console.WriteLine($" Name   : {Name}");
        Console.WriteLine($" Class  : {Class}");
        Console.WriteLine($" Health : {Health}/{MaxHealth}");
        Console.WriteLine($" Attack : {Attack}");
        Console.WriteLine($" Gold   : {Gold}");
        Console.WriteLine($" Level  : {Level}");
        Console.WriteLine($" XP     : {XP}/{xpToNextLevel}");
        Console.WriteLine("====================");
        Console.WriteLine("Press any key to close profile...");
        Console.ReadKey();
        Console.Clear();
    }


}

