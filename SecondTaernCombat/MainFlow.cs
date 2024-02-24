using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTaernCombat
{
    public static class MainFlow
    {
        public static void Run(Character[] firstTeam, Character[] SecondTeam)
        {
            while (firstTeam.Any(t => t.health > 0) && SecondTeam.Any(t => t.health > 0))
            {
                DoOneTurn(firstTeam, SecondTeam);
            }
            if (firstTeam.Any(t => t.health > 0)) { WinsCounter.IncreaseWinCounter(0); }
            else WinsCounter.IncreaseWinCounter(1);
        }
        private static void DoOneTurn(Character[] firstTeam, Character[] SecondTeam)
        {
            Character[] temp = firstTeam.Concat(SecondTeam).ToArray();
            Character[] initiative = DetermineInitiative(temp);
            foreach (Character character in initiative)
            {
                if (character.health !<= 0) { continue; }
                var turn = new CharacterTurn(character, ChooseTarget(character, firstTeam, SecondTeam));
                turn.DoCharacterTurn();
            }
        }
        private static Character[] DetermineInitiative(Character[] characters)
        {
            Random rand = new Random();
            rand.Shuffle(characters);
            return characters;
        }
        private static Character ChooseTarget(Character attacker, Character[] firstTeam, Character[] secondTeam)
        {
            Character target = ChooseLivingCharacter(ChooseEnemyTeam(attacker, firstTeam, secondTeam));
            return target;
        }
        private static Character[] ChooseEnemyTeam(Character attacker, Character[] firstTeam, Character[] secondTeam)
        {
            if (firstTeam.Any(t => t.id == attacker.id)) { return secondTeam; }
            else return firstTeam;
        }
        private static Character ChooseLivingCharacter(Character[] enemyTeam)
        {
            Character character = null;
            do
            {
                Random rand = new Random();
                character = enemyTeam[rand.Next(enemyTeam.Length)];
            }
            while (character.health < 0);
            return character;
        }
    }
}
