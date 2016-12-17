using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeMegaWar {
    public class Card {
        public Suit suit { get; private set; }
        public Rank rank { get; private set; }

        public Card(Suit suit, Rank rank) {
            this.suit = suit;
            this.rank = rank;
        }

        override
        public String ToString() {
            return String.Format("{0} of {1}", rank, suit);
        }
    }
}