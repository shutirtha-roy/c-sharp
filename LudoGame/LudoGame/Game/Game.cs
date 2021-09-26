using LudoGame.GameComponents;
using LudoGame.InputOutput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LudoGame.Game;

namespace LudoGame.Game
{
    public abstract class Game
    {
        public IOutput outputValue;
        public IInput inputValue;
        public List<Player> player;
        public Dice dice;
        public Player individualPlayer;
        public int DiceValue { get; set; }
        public char UnlockPawn { get; set; }
        public StringBuilder pawnPos = new StringBuilder();


        public void RollDice(Player people)
        {
            outputValue.GetOutput($"{people.Name}({people.ColorOfPawn}) has Pawns {people.pawn.OutsideBoardPawnAmount}");
            outputValue.GetOutput($"{people.Name}({people.ColorOfPawn})is rolling the Dice.");
            

            if (people.pawn.Position[0] != 0)
            {
                pawnPos.AppendLine($"Position 0:{people.pawn.Position[0]}");
            }
            if (people.pawn.Position[1] != 0)
            {
                pawnPos.AppendLine($"Position 1:{people.pawn.Position[1]}");
            }
            if (people.pawn.Position[2] != 0)
            {
                pawnPos.AppendLine($"Position 2:{people.pawn.Position[2]}");
            }
            if (people.pawn.Position[3] != 0)
            {
                pawnPos.AppendLine($"Position 3:{people.pawn.Position[3]}");
            }

            for (int i = 0; i < pawnPos.ToString().Length; i++)
            {
                Console.Write(pawnPos[i].ToString());
            }
            pawnPos.Clear();



            outputValue.GetOutput("Press any key to continue");
            inputValue.ReadKey();
            DiceValue = dice.RollDice();
            outputValue.GetOutput($"{people.Name}({people.ColorOfPawn}) rolled {DiceValue}");
        }



    }
}
