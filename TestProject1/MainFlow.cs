using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTaernCombat
{
    public static class MainFlow
    {
        public static void Run(Character firstCharacter, Character secondCharacter)
        {
            //Character[] temp = new Character[] { firstCharacter, secondCharacter };
            //while (temp.Any(t => t.health > 0))
            while (firstCharacter.health > 0 && secondCharacter.health > 0)
            {
                DoOneTurn(firstCharacter, secondCharacter);
            }
            if (firstCharacter.health > secondCharacter.health) { WinsCounter.IncreaseWinCounter(0); }
            else WinsCounter.IncreaseWinCounter(1);
        }
        public static void Run2(Character[] firstTeam, Character[] SecondTeam)
        {
            //Character[] temp = new Character[] { firstCharacter, secondCharacter };
            //while (temp.Any(t => t.health > 0))
            while (firstTeam.Any(t => t.health > 0) && SecondTeam.Any(t => t.health > 0))
            {
                DoOneTurn2(firstTeam, SecondTeam);
            }
            if (firstTeam.Any(t => t.health > 0)) { WinsCounter.IncreaseWinCounter(0); }
            else WinsCounter.IncreaseWinCounter(1);
        }
        private static void DoOneTurn(Character firstCharacter, Character secondCharacter)
        {
            Character[] temp = new Character[] { firstCharacter, secondCharacter };
            Random rand = new Random();
            Character[] initiative = DetermineInitiative(firstCharacter, secondCharacter);
            foreach (Character character in initiative)
            {
                if (character.health! <= 0) { continue; }
                //Console.WriteLine($"{character.id} attacks");
                var turn = new CharacterTurn(character, ChooseTarget(character, temp));
                turn.DoCharacterTurn();
            }

        }
        private static void DoOneTurn2(Character[] firstTeam, Character[] SecondTeam)
        {
            Character[] temp = firstTeam.Concat(SecondTeam).ToArray();
            Character[] initiative = DetermineInitiative(temp);
            foreach (Character character in initiative)
            {
                if (character.health !<= 0) { continue; }
                //Console.WriteLine($"{character.id} attacks");
                var turn = new CharacterTurn(character, ChooseTarget2(character, firstTeam, SecondTeam));
                turn.DoCharacterTurn();
            }

        }
        private static Character[] DetermineInitiative(Character firstCharacter, Character secondCharacter)
        {
            Random rand = new Random();
            Character[] temp = [firstCharacter, secondCharacter];
            rand.Shuffle(temp);
            return temp;
        }
        private static Character[] DetermineInitiative(Character[] characters)
        {
            Random rand = new Random();
            rand.Shuffle(characters);
            return characters;
        }

        private static Character ChooseTarget(Character attacker, Character[] characters)
        {
            foreach (Character character in characters)
            {
                if (attacker.id == character.id) { continue;}
                else return character;
            }
            return null;
        }
        private static Character ChooseTarget2(Character attacker, Character[] firstTeam, Character[] secondTeam)
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
