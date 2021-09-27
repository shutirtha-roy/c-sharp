using LudoGame.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.GameComponents
{
    public class PawnPosition : Pawn
    {
        public PawnPosition(ref Player people, int positionPawnValue, int pawnPositon, ref List<Player> player)
        {
            this.player = player;
            CheckPawnPosition(ref people, positionPawnValue, pawnPositon);
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


            if (people.ColorOfPawn.Equals("Red"))
            {
                PlayerPawnRed(people, competitor, positionPawnValue, opponentPawnPosition, positionIndex, posPawn, oppPawn);
            }
            else if (people.ColorOfPawn.Equals("Blue"))
            {
                PlayerPawnBlue(people, competitor, positionPawnValue, opponentPawnPosition, positionIndex, posPawn, oppPawn);
            }
            else if (people.ColorOfPawn.Equals("Yellow"))
            {
                PlayerPawnYellow(people, competitor, positionPawnValue, opponentPawnPosition, positionIndex, posPawn, oppPawn);
            }
            else if (people.ColorOfPawn.Equals("Green"))
            {
                PlayerPawnGreen(people, competitor, positionPawnValue, opponentPawnPosition, positionIndex, posPawn, oppPawn);
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

        public void PlayerPawnBlue(Player people, Player competitor, int positionPawnValue, int opponentPawnPosition, int positionIndex, int posPawn, int oppPawn)
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

        public void PlayerPawnYellow(Player people, Player competitor, int positionPawnValue, int opponentPawnPosition, int positionIndex, int posPawn, int oppPawn)
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

        public void PlayerPawnGreen(Player people, Player competitor, int positionPawnValue, int opponentPawnPosition, int positionIndex, int posPawn, int oppPawn)
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



        public void CompetitorPawnLock(ref Player competitor, ref int positionIndex)
        {
            competitor.pawn.InsideBoardPawnAmount++;
            competitor.pawn.OutsideBoardPawnAmount--;
            competitor.pawn.Position[positionIndex] = 0;
        }
    }
}
