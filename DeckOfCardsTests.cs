using DeckOfPlayingCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeckOfPlayingCardsTests
{
    [TestClass()]
    public class DeckOfCardsTests
    {
        [TestMethod()]
        public void CardsInitializedCorrectly()
        {
            var cards = new DeckOfCards.Cards(5, "Sprades");
            Assert.IsInstanceOfType(cards, typeof(DeckOfCards.Cards));
        }

        [TestMethod()]
        public void DeckInitializedCorrectly()
        {
            var deck = new DeckOfCards();
            Assert.IsInstanceOfType(deck, typeof(DeckOfCards));
        }

        [TestMethod()]
        public void DeckInitialized52Cards()
        {
            var deck = new DeckOfCards();
            Assert.AreEqual(52, deck.CardsArray.Length);
        }

        [TestMethod()]
        public void GetCardsFromDeckReturnsCorrectSuitAndValues()
        {
            var deck = new DeckOfCards();
            var clubs = deck.CardsArray[0].suit;
            var rank = deck.CardsArray[0].rank;

            Assert.AreEqual("Clubs", clubs);
            Assert.AreEqual(1, rank);

        }

        [TestMethod()]
        public void SortBySuit()
        {
            var doc = new DeckOfCards();
            var doc2 = new DeckOfCards();

            for (var i = 0; i < doc.CardsArray.Length; i++)
            {
                Assert.AreEqual(doc.CardsArray[i].suit, doc2.CardsArray[i].suit);
            }

            doc.Shuffle();
            doc.Sort("S");

            for (var i = 0; i < 52; i++)
            {
                Assert.AreEqual(doc.CardsArray[i].suit, doc2.CardsArray[i].suit);
               
            }
            
        }

        [TestMethod()]
        public void SortByRank()
        {
            var doc = new DeckOfCards();
            var doc2 = new DeckOfCards();

            for (var i = 0; i < doc.CardsArray.Length; i++)
            {
                Assert.AreEqual(doc.CardsArray[i].rank, doc2.CardsArray[i].rank);
            }

            doc.Shuffle();
            doc.Sort("R");

            for (var i = 0; i < doc.CardsArray.Length - 1; i++)
            {
                Assert.IsTrue(doc.CardsArray[i].rank <= doc.CardsArray[i++].rank);
            }

        }

       [TestMethod()]
        public void ShuffleMakesDeckUnordered()
        {
            var doc = new DeckOfCards();
            var doc2 = new DeckOfCards();

            for (var i = 0; i < doc.CardsArray.Length; i++)
            {
                Assert.AreEqual(doc.CardsArray[i].rank, doc2.CardsArray[i].rank);
                Assert.AreEqual(doc.CardsArray[i].suit, doc2.CardsArray[i].suit);
            }

            doc.Shuffle();

            var notEqual = false;
            for (var i = 0; i < doc.CardsArray.Length - 1; i++)
            {
                if (!doc.CardsArray[i].suit.Equals(doc2.CardsArray[i].suit))
                {
                    notEqual = true;
                    break;
                }
            }

            if(!notEqual)
                Assert.Fail("The array is not shuffled");
        }

    }
}