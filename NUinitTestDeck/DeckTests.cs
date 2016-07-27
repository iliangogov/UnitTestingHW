using NUnit.Framework;
using Santase.Logic;
using Santase.Logic.Cards;
using System.Collections;

namespace NUinitTestDeck
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void GetNextCard_ShouldThrow_InternalGameException_IfIsCalledMoreThan24Times()
        {
            var deck = new Deck();

            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }

            Assert.Throws<InternalGameException>(() => deck.GetNextCard());
        }

        [Test]
        public void GetNextCard_ShouldReduceDeckListOfCardsCountWith1_EachTimeIsCalled()
        {
            var deck = new Deck();
            int initialCardsCount = deck.CardsLeft;
            int expectedCardsCount = initialCardsCount - 1;

            for (int i = 24; i > 0; i--)
            {
                deck.GetNextCard();
                int actualCardsCount = deck.CardsLeft;
                Assert.AreEqual(expectedCardsCount, actualCardsCount);
                expectedCardsCount--;
            }
        }

        [Test]
        public void GetNextCard_ShouldReturnCard()
        {
            var deck = new Deck();

            var card = deck.GetNextCard();

            Assert.IsInstanceOf<Card>(card);

        }

        [Test]
        public void GetNextCard_ShouldReturnNonNullCard()
        {
            var deck = new Deck();

            var card = deck.GetNextCard();

            Assert.IsNotNull(card);

        }

        [Test, TestCaseSource(typeof(DeckTests), "getcard")]
        public void ChangeTrumpCard_ShouldChangeTrumpCardFromTheDeck(Card card)
        {
            var deck = new Deck();
            var trumpCardExpected = new Card(CardSuit.Club, CardType.Nine);

            deck.ChangeTrumpCard(card);
            var trumpCardActual = deck.TrumpCard;

            Assert.AreEqual(trumpCardActual, trumpCardExpected);

        }

        public static IEnumerable getcard
        {
            get
            {
                yield return new TestCaseData(new Card(CardSuit.Club,CardType.Nine));
                
            }
        }

    }
}
