////06/19/2016
//Smahane Douyeb
//
//Coding Excercice for the ShiftWise Interview Process
//
//This project Sorts and Shuffles a Deck of 52 cards 
//in ascending order using C# and MsTest

using System;

namespace DeckOfPlayingCards
{
    class Program
    {
        static void Main(string[] args)
        {
            var deckOfCards = new DeckOfCards();

            DisplayResults(deckOfCards);

            Console.ReadLine();

        }

        private static void DisplayResults(DeckOfCards deckOfCards)
        {
            string userInput;
            do
            {

                Console.WriteLine("Press enter to display the Deck of Cards!");
                Console.ReadLine();
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine();

                Console.WriteLine("Deck of Cards");
                Console.WriteLine();
                OutPutDeck(deckOfCards);
                Console.WriteLine();

                Console.WriteLine("Press enter to shuffle Cards");
                Console.ReadLine();
                deckOfCards.Shuffle();
                OutPutDeck(deckOfCards);
                Console.WriteLine();

                Console.WriteLine("Pleae enter S to sort by Suit, R to sort by rank, or B to sort by both ");
                userInput = Console.ReadLine();
                deckOfCards.Sort(userInput);
                OutPutDeck(deckOfCards);

                Console.WriteLine("Press enter enter to try again or Q to exit");
                userInput = Console.ReadLine();
                if(userInput != null && userInput.ToLower() == "q")
                    Environment.Exit(0);

            } while (userInput != null && userInput.ToLower() != "q");
            
        }

        private static void OutPutDeck(DeckOfCards deckOfCards)
        {
            foreach (var cards in deckOfCards.CardsArray)
            {
                switch (cards.rank)
                {
                    case 1:
                        Console.WriteLine("{0,-10} {1, -10} {2,-10}", "Ace", "of",  cards.suit);
                        break;
                    case 11:
                        Console.WriteLine("{0,-10} {1, -10} {2,-10}", "Jack" , "of",  cards.suit);
                        break;
                    case 12:
                        Console.WriteLine("{0,-10} {1, -10} {2,-10}", "Queen", "of", cards.suit);
                        break;
                    case 13:
                        Console.WriteLine("{0,-10} {1, -10} {2,-10}", "King", "of", cards.suit);
                        break;
                    default:
                        Console.WriteLine("{0,-10} {1, -10} {2,-10}", cards.rank , "of",  cards.suit);
                        break;
                }
            }
        }
    }
}
