using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LudoGame.Enumerators;

namespace LudoGame.GameComponents
{
    public class Pawn
    {
        public int[] Position { get; set; }
        public int InsideBoardPawnAmount { get; set; }
        public int OutsideBoardPawnAmount { get; set; }

        public Pawn()
        {
            InsideBoardPawnAmount = (int)PawnCondition.AllPawn;
            OutsideBoardPawnAmount = (int)PawnCondition.NoPawn;
            Position = new int[(int)PawnCondition.AllPawn];
            InitializePawn();
        }

        public void InitializePawn()
        {
            for(var i = 0; i < Position.Length; i++)
            {
                Position[i] = (int)PawnCondition.LockedPawn;
            }
        }
    }
}
