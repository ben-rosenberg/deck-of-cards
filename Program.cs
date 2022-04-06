using System; 
using Cardgame;

namespace Deckcards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck=new Deck();
            deck.Shuffel();
            
            Player player=new Player("Ben");
            Card card= player.Draw(deck);
            Card card2= player.Draw(deck);
            Card card3= player.Draw(deck);

            
            foreach(Card cards in player.Hand){
                cards.Print();
            }

            player.discard(3);
            
            foreach(Card cards in player.Hand){
                cards.Print();
            }
        }
    }
}