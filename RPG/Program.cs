using System;

namespace RPG
{
    class RPG
    {
        public class Character
        {
            public string Name {get; set;}
            public int Hp {get; set;}
            public int MaxHp {get; set;}
            public int Attack {get; set;}
            public int Defense {get; set;}

            public void TakeDamage(int damage)
            {
                Hp -= Math.Max(0, damage - Defense);
            }
            public bool IsAlive()
            {
                return Hp > 0;
            }
            public void AttackTarget(Character target)
            {
                target.TakeDamage(this.Attack);
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
        public class Player : Character
        {

            public Player(String name) : base(name, 100, 100, 10, 5)
            {

            }
        }
        public class Enemy : Character
        {
            public Enemy(String name) : base(name, 100, 100, 20, 5)
            {

            }
        }

        public static void Main(String[] args)
        {

            Player player = new Player("Lloyd");
            Enemy enemy = new Enemy("Goblin");

            Console.WriteLine($"{player.Name} attacks {enemy.Name}!");
            player.AttackTarget(enemy);
            Console.WriteLine($"{enemy.Name} HP: {enemy.Hp}/{enemy.MaxHp}");

        }
    }
}
