using SecondTaernCombat;

for (int i = 0; i < 1000000; i++)
{
    Character Char1 = new Character(1, 1000, 1000, (500m*1.27m), 500m, 1000, 0, 0);
    Character Char2 = new Character(2, 1000, 1000, 500m, 500m, 1000, 0.135m, 0);
    Character Char3 = new Character(3, 1000, 1000, 500m, 500m, 1000, 0, 0);
    Character Char4 = new Character(4, 1000, 1000, 500m, 500m, 1000, 0, 0);
    Character Char5 = new Character(5, 1000, 1000, 500m, 500m, 1000, 0, 0);
    Character Char6 = new Character(6, 1000, 1000, 500m, 500m, 1000, 0, 0);

    //MainFlow.Run(Char1, Char2);
    //MainFlow.Run2([Char1, Char2, Char3],[Char4, Char5, Char6]);
    MainFlow.Run2([Char2], [Char1]);
}


Console.WriteLine($"{WinsCounter.firstTeamWins} {WinsCounter.secondTeamWins}");
Console.ReadKey();