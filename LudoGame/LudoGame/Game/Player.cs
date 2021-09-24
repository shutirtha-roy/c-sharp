using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LudoGame.GameComponents;

namespace LudoGame.Game
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ColorOfPawn { get; set; }
        public Pawn pawn { get; set; }



        public Player()
        {
            Id = 0;
            Name = "Default";
        }
        public Player(int id, string name, string color)
        {
            Id = id;
            Name = name;
            ColorOfPawn = color;
            AddPawn();
        }

        public void AddPawn()
        {
            pawn = new Pawn();
        }

    }
}
