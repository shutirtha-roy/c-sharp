using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.InputOutput
{
    public static partial class OutputMessage
    {
        private static readonly string diceChooseMessage = "************************DICE*************************\n" +
                                                            "Please choose the dice number for the game\nFor Six Sided[Press 0]\n" +
                                                            "For Ten Sided[Press 1]" +
                                                            "\n************************DICE*************************";

        private static readonly string gameStartMessage = "The Ludo Game has been started.\nPlayer 1 will start the Dice Roll and will eventually pass others.";

        public static string DiceChooseMessage()
        {
            return diceChooseMessage;
        }

        public static string GameStartMessage()
        {
            return gameStartMessage;
        }
    }
}
