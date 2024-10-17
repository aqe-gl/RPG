using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    enum TypeOfCharacter
    {
        None,
        Archer,
        Knight,
        Wizard,
        Thief,
        Artist,
        Warrior
    }
    enum TypeOfBonus
    {
        None,
        HP,
        Damage,
        Luck
    }
    internal class Character
    {
        public string name;
        public int hp = 100;
        public int damage = 30;
        public int luck = 30;
        public TypeOfCharacter type = TypeOfCharacter.None;
        public TypeOfBonus bonus = TypeOfBonus.None;

        public void Attack(Character target)
        {
            target.hp -= damage;
            Console.WriteLine($"{name} is attacking {target.name}");
            Console.WriteLine($"HP of {name}: {hp} | HP of {target.name}: {target.hp}");
        }
    }
}
