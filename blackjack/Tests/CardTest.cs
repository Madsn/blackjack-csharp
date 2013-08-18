using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Tests
{
    using NUnit.Framework;
    [TestFixture]
    class CardTest
    {

        [Test]
        public void hasRankAndSuit()
        {
            Card card = new Card(1, 1);
            Assert.AreEqual(card.getRank(), 1);
            Assert.AreEqual(card.getSuit(), 1);
        }

        [Test]
        public void suitToString()
        {
            Card c1 = new Card(1, 1);
            Assert.AreEqual(c1.getSuitAsString(), "Clubs");
            Card c2 = new Card(1, 2);
            Assert.AreEqual(c2.getSuitAsString(), "Diamonds");
        }

        [Test]
        public void rankToString()
        {
            Card c1 = new Card(1, 3);
            Assert.AreEqual(c1.getRankAsString(), "Ace");
            Card c2 = new Card(11, 2);
            Assert.AreEqual(c2.getRankAsString(), "Jack");
            Card c3 = new Card(12, 1);
            Assert.AreEqual(c3.getRankAsString(), "Queen");
            Card c4 = new Card(13, 1);
            Assert.AreEqual(c4.getRankAsString(), "King");
        }

        [Test]
        public void cardToString()
        {
            Card c1 = new Card(1, 2);
            Assert.AreEqual(c1.ToString(), "Ace of " + c1.getSuitAsString());
            Card c2 = new Card(11, 3);
            Assert.AreEqual(c2.ToString(), "Jack of " + c2.getSuitAsString());
            Card c3 = new Card(9, 4);
            Assert.AreEqual(c3.ToString(), "9 of " + c3.getSuitAsString());
        }
    }
}
