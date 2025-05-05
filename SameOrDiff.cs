using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Library;

namespace Project1
{
    internal class SameOrDiff : Game
    {
        public SameOrDiff()
        {
            Name = "Same or Different?";
            Description = "Guess whether the suit of the second card will be the same or different than the first card!";
            SuitsInDeck = 2;
            Rounds = 10;
        }

        public override int Play()
        {
            ClearConsole();
            Initialize();
            int points = 0;

            for (int i = 1; i <= Rounds; i++)
            {
                Print($"---------- Round {i}/{Rounds} ----------\n");

                PrintInline("First card: ");
                Card card1 = DrawCard();

                Print("Will the next card be of the same suit or a different suit?\n");
                Print($"  1) Same ({card1.Suit})");
                Print($"  2) Different\n");

                int choice = 0;
                bool inputLoop = true;
                while (inputLoop)
                {
                    int pendingChoice = GetInputInt();
                    if (pendingChoice == 1 || pendingChoice == 2)
                    {
                        Print("\nInteresting choice! Lets see...");
                        choice = pendingChoice;
                        inputLoop = false;
                    }
                    else
                    {
                        Print("Please type 1 or 2.\n");
                    }
                } //end inputLoop

                Wait("draw");

                PrintInline("Second card: ");
                Card card2 = DrawCard();

                switch (choice)
                {
                    case 1:
                        if (card1.Suit == card2.Suit)
                        {
                            Print(CorrectMsg);
                            points++;
                        }
                        else
                        {
                            Print(IncorrectMsg);
                        }
                        
                        break;
                    case 2:
                        if (card1.Suit != card2.Suit)
                        {
                            Print(CorrectMsg);
                            points++;
                        }
                        else
                        {
                            Print(IncorrectMsg);
                        }
                        break;
                    default:
                        Print("Please type 1 or 2.");
                        break;
                } //end switch loop

                ClearAndDisplayHUD();

            } //end for loop

            DisplayPointsMessage(points);
            Wait("return to the menu");
            ClearConsole();
            return points;

        }//end Play()
    }
}
