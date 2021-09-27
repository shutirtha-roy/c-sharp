using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.InputOutput
{
    public static partial class OutputMessage
    {
        
        private static readonly string welcomeMessage = "Hello! Welcome to the Ludo Game\nPress any key to get started";
        private static readonly string homeMessage = "**************************HOME**************************\n" +
                                                    "Please press the following numbers for starting the game\n" +
                                                    "Start [0]\nInstructions [1]\nAbout [2]" +
                                                     "\n**************************HOME**************************";
        private static readonly string instructionMessage = "***********************Instruction***********************\n" +
                                                            "Press numbers for selecting the menus\nPress any key for rolling the dice.\n" +
                                                            "***********************Instruction***********************\n";
        private static readonly string aboutMessage = "**************************About**************************\n" +
                                                      "This game is regarding the dice game with the help of console.\n" +
                                                      "**************************About**************************\n";
        private static readonly string anyKeyMessage = "Press any key to continue for returning to Home";
        private static readonly string noOfPlayerChooseMessage = "Please choose the number of players for playing the game. The colours of the Pawn will" +
                                                                 "be set randomly to each player.\n" +
                                                                 "2 Players[2]\n3 Players[3]\n4 Players[4]\nPlease write the number of player.";
        private static readonly string playerName = "Enter Player Names One by One for a Total of ";
        private static readonly string totalPlayerMessage = "These are the players registered for the Ludo Game";


        public static string WelcomeMessage()
        {
            return welcomeMessage;
        }
        public static string HomeMessage()
        {
            return homeMessage;
        }
        public static string InstructionMessage()
        {
            return instructionMessage;
        }
        public static string AboutMessage()
        {
            return aboutMessage;
        }
        public static string AnyKeyMessage()
        {
            return anyKeyMessage;
        }
        public static string NoOfPlayerChooseMessage()
        {
            return noOfPlayerChooseMessage;
        }
        public static string PlayerName()
        {
            return playerName;
        }

        public static string TotalPlayerMessage()
        {
            return totalPlayerMessage;
        }
    }
}
