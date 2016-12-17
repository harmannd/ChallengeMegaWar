using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeMegaWar {
    public class Game {
        public Deck deck { get; set; }
        public Player player1 { get; set; }
        public Player player2 { get; set; }

        private String dealtCards;
        private String warResults;
        private Random random;
        private bool dealToPlayer2;
        private List<Card> bounty = new List<Card>();

        public Game() {
            deck = new Deck();
            player1 = new Player("Player1");
            player2 = new Player("Player2");
            random = new Random();
        }

        public string dealCards() {
            int randomCard;
            dealToPlayer2 = false;
            dealtCards = "<h2>Dealing cards...</h2>";
            while (deck.cards.Count > 0) {
                randomCard = random.Next(deck.cards.Count);
                alternateDealToPlayers(deck.cards.ElementAt(randomCard));
                deck.cards.RemoveAt(randomCard);
            }         
            return dealtCards;
        }

        private void alternateDealToPlayers(Card card) {
            if (dealToPlayer2) {
                cardDealtTo(card, player2);
                dealToPlayer2 = false;
            }
            else {
                cardDealtTo(card, player1);
                dealToPlayer2 = true;
            }
        }

        private void cardDealtTo(Card card, Player player) {
            player.addCard(card);
            dealtCards += string.Format("<br />{0} is dealt the {1} of {2}", player.name, card.rank, card.suit);
        }

        public String playWar() {
            int rounds = 0;
            warResults = "<h2>Begin battle...</h2>";
            while (rounds < 20) {
                compareCards();
                rounds++;
            }
            return warResults;
        }

        private void compareCards() {
            warResults += String.Format("<br/><br/>Battle Cards: {0} vs {1}", 
                player1.hand.ElementAt(0).ToString(), 
                player2.hand.ElementAt(0).ToString());
            if (player1.hand.ElementAt(0).rank.Equals(player2.hand.ElementAt(0).rank)) {
                warResults += "<br/>*************WAR*************";
                addCardsToBounty(3);
                compareCards();
            }
            else if (player1.hand.ElementAt(0).rank > player2.hand.ElementAt(0).rank) {
                addCardsToBounty(1);
                givePlayerBounty(player1);
            }
            else {
                addCardsToBounty(1);
                givePlayerBounty(player2);
            }
        }

        private void addCardsToBounty(int cardsToAdd) {
            for (int i = 0; i < cardsToAdd; i++) {
                takeCardFromPlayer(player1);
                takeCardFromPlayer(player2);
            }
        }

        private void takeCardFromPlayer(Player player) {
            bounty.Add(player.hand.ElementAt(0));
            player.hand.RemoveAt(0);
        }

        private void givePlayerBounty(Player player) {
            printBounty(player);
            player.hand.AddRange(bounty);
            bounty = new List<Card>();    
        }

        private void printBounty(Player player) {
            warResults += "<br/>Bounty...";
            for (int i = 0; i < bounty.Count; i++) {
                warResults += "<br/>&nbsp;&nbsp;" + bounty.ElementAt(i).ToString();
            }
            warResults += String.Format("<br/><strong>{0} Wins!</strong>", player.name);
        }

        public String printResults() {
            String results;
            if (player1.hand.Count > player2.hand.Count) {
                results = "<br/><br/>" + player1.name + "wins!";
            }
            else {
                results = "<br/><br/>" + player2.name + "wins!";
            }
            results += "<br/>" + player1.name + ":" + player1.hand.Count.ToString()
                + "<br/>" + player2.name + ":" + player2.hand.Count.ToString();
            return results;
        }
    }
}