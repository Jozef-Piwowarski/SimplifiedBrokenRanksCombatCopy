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
            while (firstTeam.Any(character => character.health > 0) && SecondTeam.Any(character => character.health > 0))
            {
                DoOneTurn(firstTeam, SecondTeam);
            }
            if (firstTeam.Any(character => character.health > 0)) { WinsCounter.IncreaseWinCounter(0); }
            else WinsCounter.IncreaseWinCounter(1);
        }
        private static void DoOneTurn(Character[] firstTeam, Character[] SecondTeam)
        {
            Character[] initiativeArray = DetermineInitiative(firstTeam.Concat(SecondTeam).ToArray());
            foreach (Character character in initiativeArray)
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
            return ChooseLivingCharacter(ChooseEnemyTeam(attacker, firstTeam, secondTeam));
        }
        private static Character[] ChooseEnemyTeam(Character attacker, Character[] firstTeam, Character[] secondTeam)
        {
            if (firstTeam.Any(character => character.id == attacker.id)) { return secondTeam; }
            else return firstTeam;
        }
        private static Character ChooseLivingCharacter(Character[] enemyTeam)
        {
            Character targetCharacter = null;
            do
            {
                Random rand = new Random();
                targetCharacter = enemyTeam[rand.Next(enemyTeam.Length)];
            }
            while (targetCharacter.health < 0);
            return targetCharacter;
        }
    }
}
