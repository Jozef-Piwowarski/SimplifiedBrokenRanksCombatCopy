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
            if (DoesAttackHit() == false && DoesDoubleAttackRollHit() == false)
            {
                return;
            }
            if (DoesDoubleDefenceRollBlock())
            {
                return;
            }
            DoAttack();
        }
        private void DoAttack() => Defender.ReceiveDamage(Attacker.PlaceholderDamage);
        private bool DoesAttackHit() => Dice.Roll(1000) / 1000 <= CalculateHitChance();
        private bool DoesDoubleAttackRollHit()
        {
            if (Dice.Roll(1000) / 1000 < Attacker.DoubleHitRollChance)
            {
                if (DoesAttackHit()) { return true; }
            }
            return false;
        }
        private bool DoesDoubleDefenceRollBlock()
        {
            if (Dice.Roll(1000) / 1000 < Defender.DoubleDefenceRollChance)
            {
                if (!DoesAttackHit()) { return true; }
            }
            return false;
        }
        private decimal CalculateHitChance()
        {
            return Attacker.HitStat / (Attacker.HitStat + Defender.DefenceStat);
        }
    }
}
