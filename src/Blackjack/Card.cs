using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Card
    {
        public string Suit { get; set; }
        public string Face { get; set; }
        public int Value { get; set; }
    }
    public class Deck
    {
        //initialize deck of cards
        public List<Card> Cards { get; set; }
        public static string[] Suits = { "Spades", "Clubs", "Hearts", "Diamonds" };
        public static string[] Faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "King", "Queen", "Ace" };
        public static int[] Values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 }; //ace=11 now

        public Deck() //constructor
        {
            Cards = new List<Card>();
            //loop
            for (int i = 0; i < Suits.Length; i++)
            {
                for (int j = 0; j < Faces.Length; j++)
                {
                    Card card = new Card();
                    card.Face = Faces[j];
                    card.Suit = Suits[i];
                    card.Value = Values[j];
                    Cards.Add(card);

                    //Console.WriteLine("{0} of {1}", card.Face, card.Suit); //test
                    //pause
                    //Console.ReadLine();
                }
            }
        }

        // method Shuffle- generates random shuffled card
        public void Shuffle()
        {
            Random Random = new Random();
            int shuf = Cards.Count; //total:52
            for (int i = 0; i < shuf; i++)
            {
                int rand = i + (int)(Random.NextDouble() * (shuf - i));
                Card card = Cards[rand];
                Cards[rand] = Cards[i];
                Cards[i] = card;
            }
        }
        //public class GameUtility
        //{
        //    public void Deal()
        //    {


        //    }
        //}
    }
    public class Have
    {
        public List<Card> HaveCards { get; set; }
        public int TotalValue { get; set; }
    }
    public class Player
    {

        public int Id { get; set; }
        public List<Card> PlayerHave { get; set; }
        public int TotalValue { get; set; }



    }
}

















