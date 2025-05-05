using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Project1.Library;

namespace Project1
{
    internal class HighestMatch : Game
    {
        Person player = new Person("Player", 0);
        Person dealer = new Person("Mr. Dealer", 0);

        public HighestMatch()
        {
            Name = "Highest Match";
            Description = "Build your hand with the highest total value of cards!";
            SuitsInDeck = 4;
            Rounds = 10; 
        }

        public override int Play()
        {
            ClearConsole();
            Initialize();
            int points = 0; 

            CreateHand(player);
            CreateHand(dealer);

            Print($"{dealer.Name}:");
            Print($" > Welcome! I've dealt us both 10 cards...");
            Print($" > You have 10 rounds to get the highest total value of cards in your hand.");
            Print($" > Build your hand by drawing a new card from the deck and swapping it with a different card in your hand.");
            Print($" > If you draw a card you don't want to use, you can discard it.");
            Print($" > Are you ready? Let's start!");

            ClearAndDisplayHUD();

            //rounds 
            int currentRound = 1;
            if (currentRound <= 9)
            {
                for (int i = 1; i <= Rounds - 1; i++)
                {
                    Round(i);

                    Print($"{dealer.Name}: I'll draw too... Alright, your turn...");

                    ClearAndDisplayHUD();
                    currentRound++;
                }
            }

            //last round
            Round(10);
            Print($"{dealer.Name}: Last round! Let's see what you've got...");
            ClearAndDisplayHUD();

            Print("---------- Final Score ----------\n");

            int playerFinalTotal = 0;
            playerFinalTotal = CalculateTotal(playerFinalTotal, player);
            Print($"Player total: {playerFinalTotal}");

            int dealerFinalTotal = 0;
            dealerFinalTotal = CalculateTotal(dealerFinalTotal, dealer);
            Print($"{dealer.Name}'s total: {dealerFinalTotal}\n");

            if (playerFinalTotal > dealerFinalTotal)
            {
                Print(WinMsg);
                points =+ 10; 
            }
            else if (playerFinalTotal < dealerFinalTotal)
            {
                Print(LoseMsg);
            }
            else if (playerFinalTotal == dealerFinalTotal)
            {
                Print($"{dealer.Name}: Huh, looks like we tied!\n");
            }

            DisplayPointsMessage(points);
            Wait("return to the menu");
            ClearConsole();
            return points;

        } //end Play()


        private void Round(int round)
        {
            Print($"---------- Round {round}/{Rounds} ----------\n");
            ShowHand(player);

            PrintInline("\nYou draw this card: ");
            Card card = DrawCard();

            Print("What do you want to do?\n");
            Print("  1) Take this card and exchange it for one in your deck");
            Print("  2) Discard this card\n");

            var choice = GetInputInt();

            switch (choice)
            {
                case 1:
                    Print("You chose to add this card to your hand.\n");
                    AddCardToHand(card);
                    break;
                case 2:
                    Print("You chose not to use this card...\n");
                    break;
                default:
                    Print("Please enter 1 or 2.");
                    break;
            }
            //dealer's turn
            DealerAI();
        }


        private void CreateHand(Person person)
        {
            for (int i = 0; i < 10; i++)
            {
                Card card = Deck[0];
                Deck.Remove(card);
                person.Hand.Add(card);
            }
        }

        private void ShowHand(Person person)
        {
            int i = 1;
            int currentTotal = 0;

            Print("---------- Your hand ----------");

            PrintInline("Total value in hand: ");
            Print($"{CalculateTotal(currentTotal, person)}");

            foreach (Card card in person.Hand)
            {
                Print($"  > {i}: {ShowCardInfo(card)}");
                i++;
            }
        }

        private void AddCardToHand(Card newCard)
        {
            PrintInline("  Enter the index of the card in your hand you would like to swap: ");
            int choice = GetInputInt();

            Print($"\n  You chose this card to swap: {player.Hand[choice - 1].Value} of {player.Hand[choice-1].Suit}\n");

            RemoveCardFromHand(player, choice);

            player.Hand.Add(newCard);
        }

        private void RemoveCardFromHand(Person person, int indexChoice)
        {
            person.Hand.Remove(person.Hand[indexChoice - 1]);
        }

        private int CalculateTotal(int handTotal, Person person)
        {
            foreach (Card card in person.Hand)
            {
                handTotal += (int)card.Value;
            }
            return handTotal;
        }

        private void DealerAI()
        {
            Card card = Deck[0];
            Deck.Remove(card);

            if ((int)card.Value >= 5)
            {
                RemoveCardFromHand(dealer, RandomInt(2, 10));
                dealer.Hand.Add(card);
            }
        }
    }
}
