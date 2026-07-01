using System;

namespace RPG
{
    class RPG
    {
        public class Character
        {
            // random for random events
            static Random rand = new Random();
            public string Name { get; set; }
            public int Hp { get; set; }
            public int MaxHp { get; set; }
            public int Attack { get; set; }
            public int Defense { get; set; }
            //Taking damage 
            public void TakeDamage(int damage)
            {
                Hp -= Math.Max(0, damage - Defense);
            }
            // char status check
            public bool IsAlive()
            {
                return Hp <= 0;
            }
            // targeting 
            public void AttackTarget(Character target, int block)
            {
                int crit = rand.Next(1, 11) >= 5 ? 10 : 0;
                target.TakeDamage((this.Attack + crit) - block);
            }
            public Character(String name, int hp, int maxHp, int attack, int defense)
            {
                this.Name = name;
                this.Hp = hp;
                this.MaxHp = maxHp;
                this.Attack = attack;
                this.Defense = defense;
            }

        }
        // player and enemy maker
        public class Player : Character
        {
            public Player(String name) : base(name, 100, 100, 20, 5) { }

        }
        public class Enemy : Character
        {
            public Enemy(String name) : base(name, 100, 100, 20, 5) { }
        }

        public static void Main(String[] args)
        {
            Random random = new Random();
            Player player = new Player("Lloyd");
            Enemy enemy = new Enemy("Goblin");
            System.Console.WriteLine($"{enemy.Name} has arrived");
            bool battle = true;

            while (battle)
            {
                System.Console.WriteLine($"\n{player.Name}  HP:{player.Hp}");
                System.Console.WriteLine($"{enemy.Name}  HP:{enemy.Hp}");
                System.Console.WriteLine("[a]attack\n[b]block");
                char action = Console.ReadKey().KeyChar;
                switch (action)
                {   //ATTACK ENEMY
                    case 'a':
                        Console.Clear();
                        player.AttackTarget(enemy, 0);
                        Console.WriteLine($"\n{player.Name} attacks {enemy.Name}!");
                        Console.WriteLine($"{enemy.Name} HP: {enemy.Hp}/{enemy.MaxHp}");
                        Console.WriteLine($"\n{enemy.Name} attacks {player.Name}!");
                        enemy.AttackTarget(player, 0);
                        Console.WriteLine($"{player.Name} HP: {player.Hp}/{player.MaxHp}");
                        break;
                    //TRY BLOCK THE ENEMY ATTACK
                    case 'b':
                        Console.Clear();
                        int blockPowerNChance = random.Next(0, 10) >= 5 ? random.Next(1, 20) : 0;
                        enemy.AttackTarget(player, blockPowerNChance);
                        Console.WriteLine($"\n{enemy.Name} attacks {player.Name}!");
                        string msg = blockPowerNChance == 0 ? $"{player.Name} failed to block attack" : $"{player.Name} blocked {blockPowerNChance + player.Defense} of the dmg";
                        Console.WriteLine(msg);
                        Console.WriteLine($"{player.Name} HP: {player.Hp}/{player.MaxHp}");
                        break;
                }
                if (player.IsAlive()) { System.Console.WriteLine($"{player.Name} is Dead!"); battle = false; } else if (enemy.IsAlive()) { System.Console.WriteLine($"{enemy.Name} is Dead! HURRAY!"); battle = false; }

            }




        }
    }
}
