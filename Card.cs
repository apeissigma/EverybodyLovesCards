using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Library;

namespace Project1
{
    enum SuitType : int
    {
        Spades = 1,
        Hearts = 2,
        Diamonds = 3,
        Clubs = 4
    }

    enum ValueType : int
     {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    internal class Card
    {
        public SuitType Suit;
        public ValueType Value;

        public Card()
        {

        }

        public Card(SuitType suit, ValueType value)
        {
            Suit = suit;
            Value = value;
        }

        public char SetSuitChar(Card card)
        {
            var currentSuit = card.Suit;
            char cardChar = 'a';
            EnableUnicodeEncoding();

            if (currentSuit == SuitType.Spades)
            {
                cardChar = SpadeChar;
            }
            if (currentSuit == SuitType.Hearts)
            {
                cardChar = HeartChar;
            }
            if (currentSuit == SuitType.Diamonds)
            {
                cardChar = DiamondChar;
            }
            if (currentSuit == SuitType.Clubs)
            {
                cardChar = ClubChar;
            }

            return cardChar;
        }

        public char SetValueChar (Card card)
        {
            var currentValue = card.Value;
            char valueChar = '1';
            EnableUnicodeEncoding();

            if ((int)card.Value == 1)
            {
                valueChar = 'A';
            }
            else if ((int)card.Value == 10)
            {
                valueChar = TenChar; 
            }
            else if ((int)card.Value == 11)
            {
                valueChar = 'J';
            }
            else if ((int)card.Value == 12)
            {
                valueChar = 'Q';
            }
            else if ((int)card.Value == 13)
            {
                valueChar = 'K';
            }
            else
            {
                for (int i = 1; i <= (int)card.Value; i++)
                {
                    valueChar = (char)('0' + i);
                }
            }

            return valueChar;
        }

    }
}
