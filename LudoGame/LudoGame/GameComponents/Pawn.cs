using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LudoGame.Game;
using LudoGame.Enumerators;
using LudoGame.InputOutput;

namespace LudoGame.GameComponents
{
    public class Pawn : GameComponent
    {
        public int[] Position { get; set; }
        public int InsideBoardPawnAmount { get; set; }
        public int OutsideBoardPawnAmount { get; set; }
        public int WinBoardPawnAmount { get; set; }


        public Pawn()
        {
            InsideBoardPawnAmount = (int)PawnCondition.AllPawn;
            OutsideBoardPawnAmount = (int)PawnCondition.NoPawn;
            Position = new int[(int)PawnCondition.AllPawn];
        }


        public void MovePawn(ref Player people, int diceValue, ref List<Player> player)
        {
            DiceValue = diceValue;
            this.player = player;
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
            MoveFirstPawn(ref people);
        }

        public void TwoPawnUnlocked(ref Player people)
        {
            outputValue.GetOutput("Do you want to move the first Pawn or second Pawn? [Press 1 for firstPawn, 2 for secondPawn]");
            CheckPawnNumber = inputValue.GetIntInput();
            if (CheckPawnNumber == (int)PawnCondition.OnePawn)
            {
                MoveFirstPawn(ref people);
            }
            else if (CheckPawnNumber == (int)PawnCondition.TwoPawn)
            {
                MoveSecondPawn(ref people);
            }
        }

        public void ThreePawnUnlocked(ref Player people)
        {
            outputValue.GetOutput("Do you want to move the first Pawn or second Pawn or third Pawn? [Press 1 for firstPawn, 2 for secondPawn, 3 for thirdPawn]");
            CheckPawnNumber = inputValue.GetIntInput();
            if (CheckPawnNumber == (int)PawnCondition.OnePawn)
            {
                MoveFirstPawn(ref people);
            }
            else if (CheckPawnNumber == (int)PawnCondition.TwoPawn)
            {
                MoveSecondPawn(ref people);
            }
            else if (CheckPawnNumber == (int)PawnCondition.ThreePawn)
            {
                MoveThirdPawn(ref people);
            }
        }

        public void AllPawnUnlocked(ref Player people)
        {
            outputValue.GetOutput("Do you want to move the first Pawn or second Pawn or third Pawn or fourth Pawn? [Press 1 for firstPawn, 2 for secondPawn, 3 for thirdPawn, 4 for fourthPawn]");
            CheckPawnNumber = inputValue.GetIntInput();
            if (CheckPawnNumber == (int)PawnCondition.OnePawn)
            {
                MoveFirstPawn(ref people);
            }
            else if (CheckPawnNumber == (int)PawnCondition.TwoPawn)
            {
                MoveSecondPawn(ref people);
            }
            else if (CheckPawnNumber == (int)PawnCondition.ThreePawn)
            {
                MoveThirdPawn(ref people);
            }
            else if (CheckPawnNumber == (int)PawnCondition.FourthPawn)
            {
                MoveFourthPawn(ref people);
            }
        }

        public void MoveFirstPawn(ref Player people)
        {
            if (people.pawn.Position[0] + DiceValue <= 56)
            {
                people.pawn.Position[0] += DiceValue;
            }

            outputValue.GetOutput($"Pawn 1 moved by {people.pawn.Position[0]}");
            CheckPawnPosition(ref people, people.pawn.Position[0], 0);


        }

        public void MoveSecondPawn(ref Player people)
        {
            if (people.pawn.Position[1] + DiceValue <= 56)
            {
                people.pawn.Position[1] += DiceValue;
            }

            outputValue.GetOutput($"Pawn 2 moved by {people.pawn.Position[1]}");
            CheckPawnPosition(ref people, people.pawn.Position[1], 1);
        }

        public void MoveThirdPawn(ref Player people)
        {
            if (people.pawn.Position[2] + DiceValue <= 56)
            {
                people.pawn.Position[2] += DiceValue;
            }

            outputValue.GetOutput($"Pawn 3 moved by {people.pawn.Position[2]}");
            CheckPawnPosition(ref people, people.pawn.Position[2], 2);
        }

        public void MoveFourthPawn(ref Player people)
        {
            if (people.pawn.Position[3] + DiceValue <= 56)
            {
                people.pawn.Position[3] += DiceValue;
            }

            outputValue.GetOutput($"Pawn 4 moved by {people.pawn.Position[3]}");
            CheckPawnPosition(ref people, people.pawn.Position[3], 3);
        }

        public void CheckPawnPosition(ref Player people, int positionPawnValue, int pawnPositon)
        {
            if (positionPawnValue == 56)
            {
                ReachedDestination(ref people, positionPawnValue, pawnPositon);
            }
            else if (positionPawnValue % 13 == 0)
            {
                outputValue.GetOutput($"{people.Name} can't attack other pawn");
            }
            else if (positionPawnValue <= 50)
            {
                CheckCompetitorPawn(ref people, positionPawnValue, pawnPositon);
            }
        }

        public void ReachedDestination(ref Player people, int positionPawnValue, int pawnPositon)
        {
            people.pawn.OutsideBoardPawnAmount--;
            people.pawn.WinBoardPawnAmount++;

            if (people.pawn.WinBoardPawnAmount == 4)
            {
                outputValue.GetOutput($"The Player {people.Name} has won");
            }
        }

        public void CheckCompetitorPawn(ref Player people, int positionPawnValue, int pawnPositon)
        {
            int count = 0;

            foreach (Player competitor in player)
            {
                if (competitor.Name != people.Name)
                {
                    count = 0;
                    foreach (int opponentPawnPosition in competitor.pawn.Position)
                    {
                        if (positionPawnValue % 13 == opponentPawnPosition % 13)
                        {
                            CheckAllPawnValue(people, competitor, positionPawnValue, opponentPawnPosition, count);
                        }
                        count++;
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
                PlayerPawnRed(people, competitor, positionPawnValue, opponentPawnPosition, positionIndex, posPawn, oppPawn);
            }
            else if (people.ColorOfPawn == "Blue")
            {
                if (competitor.ColorOfPawn == "Red")
                {
                    if (posPawn == oppPawn + 2)
                    {
                        CompetitorPawnLock(ref competitor, ref positionIndex);
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
                else if (competitor.ColorOfPawn == "Yellow")
                {
                    if (posPawn == oppPawn + 1)
                    {
                        CompetitorPawnLock(ref competitor, ref positionIndex);
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
                else if (competitor.ColorOfPawn == "Green")
                {
                    if (posPawn == oppPawn + 3)
                    {
                        CompetitorPawnLock(ref competitor, ref positionIndex);
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
            }
            else if (people.ColorOfPawn == "Yellow")
            {
                if (competitor.ColorOfPawn == "Red")
                {
                    if (posPawn == oppPawn + 1)
                    {
                        CompetitorPawnLock(ref competitor, ref positionIndex);
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
                else if (competitor.ColorOfPawn == "Blue")
                {
                    if (posPawn == oppPawn + 3)
                    {
                        CompetitorPawnLock(ref competitor, ref positionIndex);
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
                else if (competitor.ColorOfPawn == "Green")
                {
                    if (posPawn == oppPawn + 2)
                    {
                        CompetitorPawnLock(ref competitor, ref positionIndex);
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
            }
            else if (people.ColorOfPawn == "Green")
            {
                if (competitor.ColorOfPawn == "Red")
                {
                    if (posPawn == oppPawn + 3)
                    {
                        CompetitorPawnLock(ref competitor, ref positionIndex);
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
                else if (competitor.ColorOfPawn == "Blue")
                {
                    if (posPawn == oppPawn + 1)
                    {
                        CompetitorPawnLock(ref competitor, ref positionIndex);
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
                else if (competitor.ColorOfPawn == "Yellow")
                {
                    if (posPawn == oppPawn + 2)
                    {
                        CompetitorPawnLock(ref competitor, ref positionIndex);
                        outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                    }
                }
            }
        }

        public void PlayerPawnRed(Player people, Player competitor, int positionPawnValue, int opponentPawnPosition, int positionIndex, int posPawn, int oppPawn)
        {
            if (competitor.ColorOfPawn == "Blue")
            {
                if (posPawn == oppPawn + 2)
                {
                    CompetitorPawnLock(ref competitor, ref positionIndex);
                    outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                }
            }
            else if (competitor.ColorOfPawn == "Yellow")
            {
                if (posPawn == oppPawn + 3)
                {
                    CompetitorPawnLock(ref competitor, ref positionIndex);
                    outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                }
            }
            else if (competitor.ColorOfPawn == "Green")
            {
                if (posPawn == oppPawn + 1)
                {
                    CompetitorPawnLock(ref competitor, ref positionIndex);
                    outputValue.GetOutput($"{competitor.Name}'s Pawn {positionIndex + 1} Removed.");
                }
            }
        }

        public void CompetitorPawnLock(ref Player competitor, ref int positionIndex)
        {
            competitor.pawn.InsideBoardPawnAmount++;
            competitor.pawn.OutsideBoardPawnAmount--;
            competitor.pawn.Position[positionIndex] = 0;
        }
    }
}
