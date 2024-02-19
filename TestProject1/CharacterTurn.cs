using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class CharacterTurn
    {
        public CharacterTurn(Character attacker, Character defender)
        {
            Attacker = attacker;
            Defender = defender;
        }

        Character Attacker { get; set; }
        Character Defender { get; set; }

        public void DoCharacterTurn()
        {
            DoAttack();
        }
        private void DoAttack()
        {
            Random rand = new Random();
            if ((Convert.ToDecimal(rand.Next(1, 1001)) / 1000) >= CalculateHitChance())
            {
                if ((Convert.ToDecimal(rand.Next(1, 1001)) / 1000) < Attacker.DoubleHitRollChance)
                {
                    //Console.WriteLine("REROLL");
                    if ((Convert.ToDecimal(rand.Next(1, 1001)) / 1000) >= CalculateHitChance()) { return; }
                }
                else return;
            }
            Defender.ReceiveDamage(Attacker.PlaceholderDamage);
        }
        private decimal CalculateHitChance()
        {
            return Attacker.HitStat / (Attacker.HitStat + Defender.DefenceStat);
        }
    }
}
