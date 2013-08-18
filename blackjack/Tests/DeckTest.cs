using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Tests
{
    using NUnit.Framework;
    [TestFixture]
    class DeckTest
    {

        [Test]
        public void DeckSetup()
        {
            Deck deck = new Deck();
            Assert.AreEqual(deck.cards.Count, 52); // Newly initialized deck should contain 52 cards
        }

        [Test]
        public void CardRemoval()
        {
            Deck deck = new Deck();
            Card card = deck.getNextCard();
            // confirm that card is removed from deck
            Assert.AreEqual(deck.cards.Count, 51);
            Assert.IsFalse(deck.cards.Contains(card));
        }
    }
}
