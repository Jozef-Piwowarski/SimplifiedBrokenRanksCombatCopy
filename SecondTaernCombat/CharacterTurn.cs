using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTaernCombat
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
            if (DoesAttackHit() == false) { return; }
            Defender.ReceiveDamage(Attacker.PlaceholderDamage);
        }
        private decimal CalculateHitChance()
        {
            return Attacker.HitStat / (Attacker.HitStat + Defender.DefenceStat);
        }
        private bool DoesAttackHit()
        {
            if (Dice.Roll(1000) >= CalculateHitChance())
            {
                if ((Dice.Roll(1000) / 1000) < Attacker.DoubleHitRollChance)
                {
                    if ((Dice.Roll(1000) / 1000) >= CalculateHitChance()) { return false; }
                }
                else return false;
            }
            if (Dice.Roll(1000) <= Defender.DoubleDefenceRollChance) 
            {
                if ((Dice.Roll(1000) / 1000) >= CalculateHitChance()) { return false; }
            }
            return true;
        }
    }
}
