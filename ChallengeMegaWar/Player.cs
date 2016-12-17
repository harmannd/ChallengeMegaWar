using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeMegaWar {
    public class Player {
        public List<Card> hand { get; set; }
        public String name { get; set; }

        public Player(String name) {
            hand = new List<Card>();
            this.name = name;
        }

        public void addCard(Card card) {
            hand.Add(card);
        }

        public void removeCard(Card card) {
            hand.Remove(card);
        }
    }
}