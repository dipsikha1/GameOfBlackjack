using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Blackjack.Deck;

namespace Blackjack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Deck d = new Deck();//test 1 Deck setup
            //creating a new Deck
            var Deck1 = new Deck();
            //shuffle
            Deck1.Shuffle();

            Console.WriteLine("Welcome to the Game of BlackJack!Press Enter to Start!");
            Console.ReadLine();

            Console.WriteLine("Welcome! Enter the number of Players:");
            int playerCount = int.Parse(Console.ReadLine());

            //new Player list
            List<Player> TotalPlayer = new List<Player>();
            for (int i = 0; i < playerCount; i++)
            {
                Player player = new Player() { Id = i + 1, PlayerHave = Deck1.Cards.GetRange(0, 2), TotalValue = Deck1.Cards[0].Value + Deck1.Cards[1].Value };
                TotalPlayer.Add(player);
                Deck1.Cards.RemoveRange(0, 2);

                //displays each player's Haves and their total value
                Console.WriteLine("Player {0} first card: {1} of {2}", player.Id, player.PlayerHave[0].Face, player.PlayerHave[0].Suit);
                Console.WriteLine("Player {0} second card: {1} of {2}\nPlayer {0} Total:{3}\n", player.Id, player.PlayerHave[1].Face, player.PlayerHave[1].Suit, player.TotalValue);


                //creates dealer and draws 2 cards
                Player dealer = new Player() { Id = 0, PlayerHave = Deck1.Cards.GetRange(0, 2) };
                Deck1.Cards.RemoveRange(0, 2);
                Console.WriteLine("Dealer 1st card: {0} of {1}", dealer.PlayerHave[0].Face, dealer.PlayerHave[0].Suit);
                Console.WriteLine("Dealer 2nd card is face down\n");

                //loop hit or stay
                {
                    foreach (Player p in TotalPlayer)
                    {
                        //if value< 21, ask to hit or stand
                        if (p.TotalValue < 21)
                        {
                            Console.WriteLine("Player {0}, you have {1}. Would you like to hit or stand?", p.Id, p.TotalValue);
                            var response = Console.ReadLine();
                            if (response == "hit")
                            {
                                p.PlayerHave.Add(Deck1.Cards[0]);
                                p.TotalValue += Deck1.Cards[0].Value;
                                Deck1.Cards.Remove(Deck1.Cards[0]);
                                if (p.TotalValue > 21)
                                {
                                    Console.WriteLine("Player {0}, you lose.Dealer Wins! Hit Enter to see your total.");
                                    Console.ReadLine();
                                }
                                //if player has 21, display
                                else if (p.TotalValue == 21)
                                {
                                    Console.WriteLine("Player, you got BlackJack!");
                                    Console.ReadLine();
                                }
                                Console.WriteLine("Player {0} first card: {1} of {2}", p.Id, p.PlayerHave[0].Face, p.PlayerHave[0].Suit);
                                Console.WriteLine("Player {0} second card: {1} of {2}", p.Id, p.PlayerHave[1].Face, p.PlayerHave[1].Suit, p.TotalValue);
                                Console.WriteLine("Player {0} third card: {1} of {2}\nPlayer {0} Total:{3}\n", p.Id, p.PlayerHave[2].Face, p.PlayerHave[2].Suit, p.TotalValue);
                            }
                            else if (response != "hit")
                            {
                                dealer.PlayerHave.Add(Deck1.Cards[0]);
                                p.TotalValue += Deck1.Cards[0].Value;
                                Deck1.Cards.Remove(Deck1.Cards[0]);
                                Console.WriteLine("Dealer  1st card: {0} of {1}", dealer.PlayerHave[0].Face,
                                    dealer.PlayerHave[0].Suit, dealer.TotalValue);
                                Console.WriteLine("Dealer  2nd card: {0} of {1}", dealer.PlayerHave[1].Face,
                                    dealer.PlayerHave[1].Suit, dealer.TotalValue);
                                Console.WriteLine("Dealer  3rd card is face down\n");
                            }

                            //if greater than 21, display
                        }
                    }
                }
                Console.ReadLine();

            }
        }
    }
}

