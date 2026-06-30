using System;

namespace RPG
{
    class RPG
    {
        public class Character
        {
            // random for random events
            Random rand = new Random();
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
                return Hp < 0;
            }
            // targeting 
            public void AttackTarget(Character target)
            {
                int crit = rand.Next(1, 11) >= 5 ? 0 : 6;
                target.TakeDamage(this.Attack + crit);
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
            public Player(String name) : base(name, 100, 100, 10, 5) { }

        }
        public class Enemy : Character
        {
            public Enemy(String name) : base(name, 100, 100, 10, 5) { }
        }

        public static void Main(String[] args)
        {

            Player player = new Player("Lloyd");
            Enemy enemy = new Enemy("Goblin");
            System.Console.WriteLine("Goblin arrived");
            while(player.IsAlive() || enemy.IsAlive())
            {
                System.Console.WriteLine($"{player.Name}  HP:{player.Hp}");
                System.Console.WriteLine($"{enemy.Name}  HP:{enemy.Hp}");
                System.Console.WriteLine("[0]attack\n[1]block");
                




            }



            Console.WriteLine($"{player.Name} attacks {enemy.Name}!");
            player.AttackTarget(enemy);
            Console.WriteLine($"{enemy.Name} HP: {enemy.Hp}/{enemy.MaxHp}");
        }
    }
}
