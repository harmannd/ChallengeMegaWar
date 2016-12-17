using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeMegaWar {
    public class Deck {
        public List<Card> cards { get; set; }

        public Deck() {
            cards = new List<Card>();
            fillDeck();
        }

        private void fillDeck() {
            foreach (Suit suit in Enum.GetValues(typeof(Suit))) {
                foreach (Rank rank in Enum.GetValues(typeof(Rank))) {
                    cards.Add(new Card(suit, rank));
                }
            }
        }


    }
}