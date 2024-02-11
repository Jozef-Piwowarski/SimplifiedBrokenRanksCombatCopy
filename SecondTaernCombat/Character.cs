using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTaernCombat
{
    public class Character
    {
        public Character(int id, int health, int maxHealth, decimal hitStat, decimal defenceStat, int placeholderDamage, decimal doubleHitRollChance, decimal doubleDefenceRollChance)
        {
            this.id = id;
            this.health = health;
            this.maxHealth = maxHealth;
            HitStat = hitStat;
            DefenceStat = defenceStat;
            PlaceholderDamage = placeholderDamage;
            DoubleHitRollChance = doubleHitRollChance;
            DoubleDefenceRollChance = doubleDefenceRollChance;
            DefenceStat = defenceStat;
        }
        public int id { get; set; }
        public int health { get; private set; }
        public int maxHealth { get; private set; }
        public decimal HitStat { get; private set; }
        public decimal DefenceStat { get; private set; }
        public decimal DoubleHitRollChance { get; private set; }
        public decimal DoubleDefenceRollChance { get; private set; }
        public int PlaceholderDamage { get; private set; }

        public void ReceiveDamage(int damage)
        {
            health -= damage;
        }

    }
}
