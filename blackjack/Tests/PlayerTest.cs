using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Tests
{
    using NUnit.Framework;
    [TestFixture]
    class PlayerTest
    {
        Player player;
        Deck deck;
        int startingBalance = 5000;

        private void setupPlayerAndDeck()
        {
            player = new Player(startingBalance);
            deck = new Deck();
        }

        [Test]
        public void playerSetup()
        {
            setupPlayerAndDeck();
            Assert.AreEqual(player.getChipBalance(), startingBalance);
        }

        [Test]
        public void chipGiveAndTake()
        {
            setupPlayerAndDeck();
            player.loseChips(1500);
            Assert.AreEqual(player.getChipBalance(), startingBalance-1500);
            player.obtainChips(2000);
            Assert.AreEqual(player.getChipBalance(), startingBalance-1500+2000);
        }

        private void dealCards(Player player, Deck deck, int n)
        {
            while (n > 0)
            {
                n--;
                player.getCard(deck.getNextCard());
            }
        }

        [Test]
        public void receiveCardsAndResetHand()
        {
            setupPlayerAndDeck();
            Assert.AreEqual(player.hand.Count, 0);
            dealCards(player, deck, 2);
            Assert.AreEqual(player.hand.Count, 2);
            dealCards(player, deck, 3);
            Assert.AreEqual(player.hand.Count, 5);
            player.resetHand();
            Assert.AreEqual(player.hand.Count, 0);
        }

        [Test]
        public void getScore()
        {
            setupPlayerAndDeck();
            player.getCard(new Card(2, 2));
            player.getCard(new Card(5, 3));
            Assert.AreEqual(player.getScore(), 7);
            player.getCard(new Card(1, 2)); // An Ace is worth 14 when beneficial
            Assert.AreEqual(player.getScore(), 21);
            player.getCard(new Card(1, 1)); // But only 1 when otherwise bust
            Assert.AreEqual(player.getScore(), 9);
        }
    }
}
