using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LudoGame.InputOutput;
using LudoGame.GameComponents;
using LudoGame.Enumerators;

namespace LudoGame.Game
{
    public class BoardGame
    {
        private IOutput outputValue;
        private IInput inputValue;
        public List<Player> player;
        public Player individualPlayer;
        public Dice dice;
        public int DiceValue { get; set; }
        public char UnlockPawn { get; set; }

        public BoardGame()
        {
            outputValue = new InputOutputProcessor();
            inputValue = new InputOutputProcessor();
            outputValue.GetOutput(OutputMessage.GameStartMessage());
            StartGame();
        }

        public BoardGame(List<Player> person, Dice dice)
        {
            outputValue = new InputOutputProcessor();
            inputValue = new InputOutputProcessor();
            player = person;
            this.dice = dice;
            StartGame();
        }

        public void StartGame()
        {
            while (true)
            {
                foreach (Player people in player)
                {
                    Console.WriteLine($"{people.Name} is rolling the Dice.");
                    outputValue.GetOutput("Press any key to continue");
                    inputValue.ReadKey();
                    DiceValue = dice.RollDice();
                    outputValue.GetOutput($"{people.Name} rolled {DiceValue}");
                    individualPlayer = people;
                    CheckDiceValue(ref individualPlayer, DiceValue);
                    outputValue.GetOutput($"{people.Name} has {people.pawn.OutsideBoardPawnAmount} Pawns");
                }
            }
            
        }

        public void CheckDiceValue(ref Player people, int diceValue)
        {
            if(diceValue == dice.Sides)
            {
                outputValue.GetOutput("Do you want to Unlock the Pawn? [Press y for YES, n for NO]");
                UnlockPawn = char.Parse(inputValue.GetInput());
                if (UnlockPawn.Equals('y'))
                {
                    people.pawn.InsideBoardPawnAmount--;
                    people.pawn.OutsideBoardPawnAmount++;
                }
                else if (UnlockPawn.Equals('n'))
                {
                    MovePawn(ref people, diceValue);
                }
            }
            else
            {
                MovePawn(ref people, diceValue);
            }
        }

        public void MovePawn(ref Player people, int diceValue)
        {
            if (people.pawn.OutsideBoardPawnAmount == (int)PawnCondition.NoPawn)
            {
            }
            else if (people.pawn.OutsideBoardPawnAmount == (int)PawnCondition.OnePawn)
            {
                people.pawn.Position[0] += dice.Sides;
            }
            else if (people.pawn.OutsideBoardPawnAmount == (int)PawnCondition.TwoPawn)
            {
                outputValue.GetOutput("Do you want to move the first Pawn or second Pawn? [Press 1 for firstPawn, 2 for secondPawn]");
                if (inputValue.GetIntInput() == (int)PawnCondition.OnePawn)
                {
                    people.pawn.Position[0] += dice.Sides;
                }
                else if (inputValue.GetIntInput() == (int)PawnCondition.TwoPawn)
                {
                    people.pawn.Position[1] += dice.Sides;
                }
            }
            else if (people.pawn.OutsideBoardPawnAmount == (int)PawnCondition.ThreePawn)
            {
                outputValue.GetOutput("Do you want to move the first Pawn or second Pawn or third Pawn? [Press 1 for firstPawn, 2 for secondPawn, 3 for thirdPawn]");
                if (inputValue.GetIntInput() == (int)PawnCondition.OnePawn)
                {
                    people.pawn.Position[0] += dice.Sides;
                }
                else if (inputValue.GetIntInput() == (int)PawnCondition.TwoPawn)
                {
                    people.pawn.Position[1] += dice.Sides;
                }
                else if (inputValue.GetIntInput() == (int)PawnCondition.ThreePawn)
                {
                    people.pawn.Position[2] += dice.Sides;
                }
            }
            else if (people.pawn.OutsideBoardPawnAmount == (int)PawnCondition.AllPawn)
            {
                outputValue.GetOutput("Do you want to move the first Pawn or second Pawn or third Pawn or fourth Pawn? [Press 1 for firstPawn, 2 for secondPawn, 3 for thirdPawn, 4 for fourthPawn]");
                if (inputValue.GetIntInput() == (int)PawnCondition.OnePawn)
                {
                    people.pawn.Position[0] += dice.Sides;
                }
                else if (inputValue.GetIntInput() == (int)PawnCondition.TwoPawn)
                {
                    people.pawn.Position[1] += dice.Sides;
                }
                else if (inputValue.GetIntInput() == (int)PawnCondition.ThreePawn)
                {
                    people.pawn.Position[2] += dice.Sides;
                }
                else if (inputValue.GetIntInput() == (int)PawnCondition.FourthPawn)
                {
                    people.pawn.Position[3] += dice.Sides;
                }
            }
        }
    }
}
