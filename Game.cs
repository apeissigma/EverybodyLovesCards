using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Library;

namespace Project1
{
    internal class Game
    {
        protected string Name;
        protected string Description;
        protected int SuitsInDeck;
        protected int Rounds;
        protected List<Card> Deck = new List<Card>();
        Card card = new Card();

        //Premade sentences
        protected string CorrectMsg = "You're correct! One point!";
        protected string IncorrectMsg = "You're incorrect :(";
        protected string WinMsg = "You won!";
        protected string LoseMsg = "You lost...";

        public virtual int Play()
        {
            //override with specific game logic
            return 0;
        }

        protected void Initialize()
        {
            Print(DisplayGameInfo());
            CreateDeck(SuitsInDeck);

        }

        protected string DisplayGameInfo()
        {
            return $"------------------------------------------- {Name} ----------------------------------------------\n{Description}\n";
        }


        protected void CreateDeck(int SuitAmt)
        {
            for (int i = 1; i <= SuitAmt; i++)
            {
                var currentSuit = (SuitType)i;

                foreach (ValueType value in Enum.GetValues(typeof(ValueType)))
                {
                    Deck.Add(new Card(currentSuit, value));
                }
            }
            Shuffle();
        }

        protected void Shuffle()
        {
            for (int i = 0; i < (Deck.Count - 1); i++)
            {
                //get random int
                int rand = RandomInt(Deck.Count);
                //temp = random
                var temp = Deck[rand];
                //random = i
                Deck[rand] = Deck[i];
                //i = temp
                Deck[i] = temp;
            }
        }

        protected string ShowCardInfo(Card card)
        {
            char cardChar = card.SetSuitChar(card);

            return $"{card.Value} of {cardChar}{card.Suit}";
        }

        protected string DisplayCard(Card card)
        {
            char suitChar = card.SetSuitChar(card);
            char valueChar = card.SetValueChar(card);

            string asciiCard = @$"     +-------+
     | {valueChar}     |
     |       |
     |   {suitChar}   |
     |       |
     |     {valueChar} |
     +-------+";

            return asciiCard;
        }

        protected Card DrawCard()
        {
            Card card = Deck[0];
            Deck.Remove(card);
            Print($"{ShowCardInfo(card)}\n{DisplayCard(card)}\n");
            return card;
        }

        protected void ClearAndDisplayHUD()
        {
            Wait("continue");
            ClearConsole();
            Print(DisplayGameInfo());
        }

        protected void DisplayPointsMessage(int points)
        {
            if (points <= 2)
            {
                Print($"{points} points... You can do better...");
            }
            else if (points <= 5)
            {
                Print($"Not bad! You got {points} points!");
            }
            else if (points <= 8)
            {
                Print($"Well done! You got {points} points!");
            }
            else
            {
                Print($"Wow, you're a pro! You got {points} points!");
            }
        }
    }
}
