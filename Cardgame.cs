using System;
using System.Collections.Generic;


namespace Cardgame
{
    class Card
    {
        public string Name { get; set; }
        public string Suit { get; set; }
        public int Val { get; set; }
        public Card(string name, string suit, int val)
        {
            Name = name;
            Suit = suit;
            Val = val;
        }
        public void Print()
        {
            Console.WriteLine($"{Name} of {Suit}");
        }
    }

    class Deck
    {
        public List<Card> Cards = new List<Card>();

        public Deck()
        {
            string[] name = new string[] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            string[] suit = new string[] { "Clubs", "Spades", "Hearts", "Diamonds" };
            for (int i = 0; i < suit.Length; i++)
            {
                for (int j = 0; j < name.Length; j++)
                {
                    Card card = new Card(name[j], suit[i], j + 1);
                    Cards.Add(card);

                }
            }
        }

        public List<Card> Shuffel()
        {
            Random rnd = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                int index = rnd.Next(Cards.Count);
                Card randomCard = Cards[index];
                Cards[index] = Cards[i];
                Cards[i] = randomCard;
            }
            Console.WriteLine("Shuffeling");
            return Cards;
        }

        public Card Deal()
        {
            Card topcard = Cards[0];
            Cards.RemoveAt(0);
            return topcard;
        }

        public List<Card> Reset()
        {
            Deck newDeck = new Deck();
            this.Cards = newDeck.Cards;
            return this.Cards;
        }
    }

    class Player
    {
        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }
        
        public List<Card> Hand { get; set; }
        public String Name { get; set; }

        public Card Draw(Deck deck)
        {
            Card card = deck.Deal();
            Hand.Add(card);
            return card;
        }

        public Card discard(int num)
        {
            if (num >= Hand.Count || num < 0)
            {
                return null;
            }
            Card handCard = Hand[num];
            Hand.RemoveAt(num);
            return handCard;
        }

    }
}