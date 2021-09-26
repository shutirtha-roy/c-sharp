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
    public class BoardGame : Game
    {
        public int CheckPawnNumber { get; set; }


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
                    people.PlayerMaxDiceCount = 0;
                    RollDice(people);
                    individualPlayer = people;
                    CheckDiceValue(ref individualPlayer, DiceValue);
                    outputValue.GetOutput($"{people.Name}({people.ColorOfPawn}) has {people.pawn.OutsideBoardPawnAmount} Pawns");
                    outputValue.GetOutput("");
                }
            }
        }

        

        public void CheckDiceValue(ref Player people, int diceValue)
        {
            if(diceValue == dice.Sides && people.pawn.InsideBoardPawnAmount >= 1)
            {
                outputValue.GetOutput("Do you want to Unlock the Pawn? [Press y for YES, n for NO]");
                UnlockPawn = char.Parse(inputValue.GetInput());
                if (UnlockPawn.Equals('y'))
                {
                    people.pawn.InsideBoardPawnAmount--;
                    people.pawn.OutsideBoardPawnAmount++;
                    people.PlayerMaxDiceCount++;
                    Console.WriteLine(people.PlayerMaxDiceCount);
                    if (people.PlayerMaxDiceCount == 3)
                    {
                        PlayerRolledThrice(ref people);
                    }
                    RollDice(people);
                    CheckDiceValue(ref people, DiceValue);
                }
                else if (UnlockPawn.Equals('n'))
                {
                    MovePawn(ref people, diceValue);
                    RollDice(people);
                    CheckDiceValue(ref people, DiceValue);
                }
            }
            else
            {
                MovePawn(ref people, diceValue);
            }
        }

        public void PlayerRolledThrice(ref Player people)
        {
            outputValue.GetOutput("You have rolled 3 times, 2 Pawns will be kept InsideBoardPawnAmount.\nYou need to unlock it again");
            people.pawn.InsideBoardPawnAmount += 3;
            people.pawn.OutsideBoardPawnAmount -= 3;
            people.PlayerMaxDiceCount = 0;
            RollDice(people);
            CheckDiceValue(ref people, DiceValue);
        }

        public void MovePawn(ref Player people, int diceValue)
        {
            if (people.pawn.OutsideBoardPawnAmount == (int)PawnCondition.NoPawn)
            {
            }
            else if (people.pawn.OutsideBoardPawnAmount == (int)PawnCondition.OnePawn)
            {
                OnePawnUnlocked(ref people);
            }
            else if (people.pawn.OutsideBoardPawnAmount == (int)PawnCondition.TwoPawn)
            {
                TwoPawnUnlocked(ref people);
            }
            else if (people.pawn.OutsideBoardPawnAmount == (int)PawnCondition.ThreePawn)
            {
                ThreePawnUnlocked(ref people);
            }
            else if (people.pawn.OutsideBoardPawnAmount == (int)PawnCondition.AllPawn)
            {
                AllPawnUnlocked(ref people);
            }
        }

        public void OnePawnUnlocked(ref Player people)
        {
            if (people.pawn.Position[0] + DiceValue <= 56)
            {
                people.pawn.Position[0] += DiceValue;
            }

            outputValue.GetOutput($"Pawn 1 moved by {people.pawn.Position[0]}");
            CheckPawnPosition(ref people, people.pawn.Position[0], 0);
        }

        public void TwoPawnUnlocked(ref Player people)
        {
            outputValue.GetOutput("Do you want to move the first Pawn or second Pawn? [Press 1 for firstPawn, 2 for secondPawn]");
            CheckPawnNumber = inputValue.GetIntInput();
            if (CheckPawnNumber == (int)PawnCondition.OnePawn)
            {
                if (people.pawn.Position[0] + DiceValue <= 56)
                {
                    people.pawn.Position[0] += DiceValue;
                }

                outputValue.GetOutput($"Pawn 1 moved by {people.pawn.Position[0]}");
                CheckPawnPosition(ref people, people.pawn.Position[0], 0);
            }
            else if (CheckPawnNumber == (int)PawnCondition.TwoPawn)
            {
                if (people.pawn.Position[1] + DiceValue <= 56)
                {
                    people.pawn.Position[1] += DiceValue;
                }

                outputValue.GetOutput($"Pawn 2 moved by {people.pawn.Position[1]}");
                CheckPawnPosition(ref people, people.pawn.Position[1], 1);
            }

            
        }

        public void ThreePawnUnlocked(ref Player people)
        {
            outputValue.GetOutput("Do you want to move the first Pawn or second Pawn or third Pawn? [Press 1 for firstPawn, 2 for secondPawn, 3 for thirdPawn]");
            CheckPawnNumber = inputValue.GetIntInput();
            if (CheckPawnNumber == (int)PawnCondition.OnePawn)
            {
                if (people.pawn.Position[0] + DiceValue <= 56)
                {
                    people.pawn.Position[0] += DiceValue;
                }

                outputValue.GetOutput($"Pawn 1 moved by {people.pawn.Position[0]}");
                CheckPawnPosition(ref people, people.pawn.Position[0], 0);
            }
            else if (CheckPawnNumber == (int)PawnCondition.TwoPawn)
            {
                if (people.pawn.Position[1] + DiceValue <= 56)
                {
                    people.pawn.Position[1] += DiceValue;
                }

                outputValue.GetOutput($"Pawn 2 moved by {people.pawn.Position[1]}");
                CheckPawnPosition(ref people, people.pawn.Position[1], 1);
            }
            else if (CheckPawnNumber == (int)PawnCondition.ThreePawn)
            {
                if (people.pawn.Position[2] + DiceValue <= 56)
                {
                    people.pawn.Position[2] += DiceValue;
                }

                outputValue.GetOutput($"Pawn 3 moved by {people.pawn.Position[2]}");
                CheckPawnPosition(ref people, people.pawn.Position[2], 2);
            }
        }

        public void AllPawnUnlocked(ref Player people)
        {
            outputValue.GetOutput("Do you want to move the first Pawn or second Pawn or third Pawn or fourth Pawn? [Press 1 for firstPawn, 2 for secondPawn, 3 for thirdPawn, 4 for fourthPawn]");
            CheckPawnNumber = inputValue.GetIntInput();
            if (CheckPawnNumber == (int)PawnCondition.OnePawn)
            {
                if(people.pawn.Position[0] + DiceValue <= 56)
                {
                    people.pawn.Position[0] += DiceValue;
                }
                    
                outputValue.GetOutput($"Pawn 1 moved by {people.pawn.Position[0]}");
                CheckPawnPosition(ref people, people.pawn.Position[0], 0);
            }
            else if (CheckPawnNumber == (int)PawnCondition.TwoPawn)
            {
                if(people.pawn.Position[1] + DiceValue <= 56)
                {
                    people.pawn.Position[1] += DiceValue;
                }
                
                outputValue.GetOutput($"Pawn 2 moved by {people.pawn.Position[1]}");
                CheckPawnPosition(ref people, people.pawn.Position[1], 1);
            }
            else if (CheckPawnNumber == (int)PawnCondition.ThreePawn)
            {
                if(people.pawn.Position[2] + DiceValue <= 56)
                {
                    people.pawn.Position[2] += DiceValue;
                }
                    
                outputValue.GetOutput($"Pawn 3 moved by {people.pawn.Position[2]}");
                CheckPawnPosition(ref people, people.pawn.Position[2], 2);
            }
            else if (CheckPawnNumber == (int)PawnCondition.FourthPawn)
            {
                if (people.pawn.Position[3] + DiceValue <= 56)
                {
                    people.pawn.Position[3] += DiceValue;
                }

                outputValue.GetOutput($"Pawn 4 moved by {people.pawn.Position[3]}");
                CheckPawnPosition(ref people, people.pawn.Position[3], 3);
            }
        }

        public void CheckPawnPosition(ref Player people, int positionPawnValue, int pawnPositon)
        {
            if(positionPawnValue == 56)
            {
                people.pawn.OutsideBoardPawnAmount--;
                people.pawn.WinBoardPawnAmount++;
                if(people.pawn.WinBoardPawnAmount == 4)
                {
                    Console.WriteLine($"The Player {people.Name} has won");
                }
            }
            else if(positionPawnValue % 13 == 0)
            {
                Console.WriteLine("{people.Name} can't attack other pawn");
            }
            else if (positionPawnValue <= 50)
            {
                int count = 0;

                foreach(Player competitor in player)
                {
                    if(competitor.Name != people.Name)
                    {
                        count = 0;
                        foreach (int opponentPawnPosition in competitor.pawn.Position)
                        {
                            if(positionPawnValue % 13 == opponentPawnPosition % 13)
                            {
                                CheckAllPawnValue(people, competitor, positionPawnValue, opponentPawnPosition, count);
                            }
                            count++;
                        }
                    }
                }
            }
        }

        public void CheckAllPawnValue(Player people, Player competitor, int positionPawnValue, int opponentPawnPosition, int positionIndex)
        {
            int posPawn = positionPawnValue / 13;
            int oppPawn = opponentPawnPosition / 13;


            if (people.ColorOfPawn == "Red")
            {
                if(competitor.ColorOfPawn == "Blue")
                {
                    if (posPawn == oppPawn + 2)
                    {
                        competitor.pawn.InsideBoardPawnAmount++;
                        competitor.pawn.OutsideBoardPawnAmount--;
                        competitor.pawn.Position[positionIndex] = 0;
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
                else if(competitor.ColorOfPawn == "Yellow")
                {
                    if (posPawn == oppPawn + 3)
                    {
                        competitor.pawn.InsideBoardPawnAmount++;
                        competitor.pawn.OutsideBoardPawnAmount--;
                        competitor.pawn.Position[positionIndex] = 0;
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
                else if(competitor.ColorOfPawn == "Green")
                {
                    if (posPawn == oppPawn + 1)
                    {
                        competitor.pawn.InsideBoardPawnAmount++;
                        competitor.pawn.OutsideBoardPawnAmount--;
                        competitor.pawn.Position[positionIndex] = 0;
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
            }
            else if(people.ColorOfPawn == "Blue")
            {
                if (competitor.ColorOfPawn == "Red")
                {
                    if (posPawn == oppPawn + 2)
                    {
                        competitor.pawn.InsideBoardPawnAmount++;
                        competitor.pawn.OutsideBoardPawnAmount--;
                        competitor.pawn.Position[positionIndex] = 0;
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
                else if (competitor.ColorOfPawn == "Yellow")
                {
                    if(posPawn == oppPawn + 1)
                    {
                        competitor.pawn.InsideBoardPawnAmount++;
                        competitor.pawn.OutsideBoardPawnAmount--;
                        competitor.pawn.Position[positionIndex] = 0;
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
                else if (competitor.ColorOfPawn == "Green")
                {
                    if (posPawn == oppPawn + 3)
                    {
                        competitor.pawn.InsideBoardPawnAmount++;
                        competitor.pawn.OutsideBoardPawnAmount--;
                        competitor.pawn.Position[positionIndex] = 0;
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
            }
            else if(people.ColorOfPawn == "Yellow")
            {
                if (competitor.ColorOfPawn == "Red")
                {
                    if (posPawn == oppPawn + 1)
                    {
                        competitor.pawn.InsideBoardPawnAmount++;
                        competitor.pawn.OutsideBoardPawnAmount--;
                        competitor.pawn.Position[positionIndex] = 0;
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
                else if (competitor.ColorOfPawn == "Blue")
                {
                    if (posPawn == oppPawn + 3)
                    {
                        competitor.pawn.InsideBoardPawnAmount++;
                        competitor.pawn.OutsideBoardPawnAmount--;
                        competitor.pawn.Position[positionIndex] = 0;
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
                else if (competitor.ColorOfPawn == "Green")
                {
                    if (posPawn == oppPawn + 2)
                    {
                        competitor.pawn.InsideBoardPawnAmount++;
                        competitor.pawn.OutsideBoardPawnAmount--;
                        competitor.pawn.Position[positionIndex] = 0;
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
            }
            else if(people.ColorOfPawn == "Green")
            {
                if (competitor.ColorOfPawn == "Red")
                {
                    if (posPawn == oppPawn + 3)
                    {
                        competitor.pawn.InsideBoardPawnAmount++;
                        competitor.pawn.OutsideBoardPawnAmount--;
                        competitor.pawn.Position[positionIndex] = 0;
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
                else if (competitor.ColorOfPawn == "Blue")
                {
                    if (posPawn == oppPawn + 1)
                    {
                        competitor.pawn.InsideBoardPawnAmount++;
                        competitor.pawn.OutsideBoardPawnAmount--;
                        competitor.pawn.Position[positionIndex] = 0;
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
                else if (competitor.ColorOfPawn == "Yellow")
                {
                    if (posPawn == oppPawn + 2)
                    {
                        competitor.pawn.InsideBoardPawnAmount++;
                        competitor.pawn.OutsideBoardPawnAmount--;
                        competitor.pawn.Position[positionIndex] = 0;
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
            }
        }
    }
}
