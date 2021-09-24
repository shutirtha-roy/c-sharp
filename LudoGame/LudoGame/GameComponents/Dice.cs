using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LudoGame.Enumerators;
using LudoGame.InputOutput;

namespace LudoGame.GameComponents
{
    public class Dice
    {
        public int Sides { get; set; }
        protected Dice DiceModify { get; set; }
        public int DiceNumber { get; set; }
        private IInput inputValue;
        private IOutput outputValue;
        public Random RandomInt { get; set; }
        public int DiceScore { get; set; }


        public Dice()
        {
            RandomInt = new Random();
        }
        
        public Dice(int player)
        {
            inputValue = new InputOutputProcessor();
            outputValue = new InputOutputProcessor();
            RandomInt = new Random();
            outputValue.GetOutput(OutputMessage.DiceChooseMessage());
            DiceNumber = inputValue.GetIntInput();
            outputValue.ClearScreen();
            DiceModify = ChooseDice(DiceNumber);
            Sides = DiceModify.Sides;
            outputValue.GetOutput($"{Sides}");
        }

        public Dice ChooseDice(int diceNumber)
        {
            if (diceNumber == (int)DiceType.Six)
            {
                return new DiceSix();
            }
            else if (diceNumber == (int)DiceType.Ten)
            {
                return new DiceTen();
            }
            return null;
        }

        public int RollDice()
        {
            return RandomInt.Next(1, Sides + 1);
        }

        
    }
}
