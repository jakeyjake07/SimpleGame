namespace SimpleGame
{
    public class Enemy
    {
        public string Name;
        public int Health;
        public int MaxHealth;
        public int Attack;
        public int GoldReward;
        public int XpReward;
      

      public Enemy(string name, int maxHealth, int attack, int goldReward, int xpReward)
        {
            Name = name;
            Health = maxHealth;
            MaxHealth = maxHealth;
            Attack = attack; 
            GoldReward = goldReward;
            XpReward = xpReward;
            
        }
    

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

  /*   public void ShowProfile()
        {
            Console.WriteLine("\n====================");
            Console.WriteLine("     ENEMY INFO     ");
            Console.WriteLine("====================");
            Console.WriteLine($" Name   : {Name}");
            Console.WriteLine($" Health : {Health}/{MaxHealth}");
            Console.WriteLine($" Attack : {Attack}");
            Console.WriteLine("====================");
        } */
    
    }



}
