using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Library;

namespace Project1
{
    internal class HighOrLow : Game
    {
        public HighOrLow()
        {
            Name = "Higher or Lower?";
            Description = "Guess whether the drawn card will be higher or lower than the previous card!";
            SuitsInDeck = 4;
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

                Print("Will the next card be higher or lower?\n");
                Print("  1) Higher");
                Print("  2) Lower\n");

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
                        if ((int)card2.Value > (int)card1.Value)
                        {
                            Print(CorrectMsg);
                            points++;
                        }
                        else if ((int)card2.Value == (int)card1.Value)
                        {
                            Print("Hmm, it's the same number. No point for you :(\n");
                        }
                        else
                        {
                            Print(IncorrectMsg);
                        }
                        break;
                    case 2:
                        if ((int)card2.Value < (int)card1.Value)
                        {
                            Print(CorrectMsg);
                            points++;
                        }
                        else if ((int)card2.Value == (int)card1.Value)
                        {
                            Print("Hmm, it's the same number. No point for you :(\n");
                        }
                        else
                        {
                            Print(IncorrectMsg);
                        }
                        break;
                } //end switch loop

                ClearAndDisplayHUD();

            } //end for loop

            DisplayPointsMessage(points);
            Wait("exit");
            ClearConsole();
            return points;

        }//end Play()
    }
}
