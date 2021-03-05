using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Online
{
    public class Game
    {

        /**
         * Fields
         **/

        private Deck deck;
        private List<IPlayer> players = new List<IPlayer>();
        private bool inProgress;
        private int highestBet = 0;
        int turn = 1;
        int pot = 0;
        int smallBlind;
        public bool canCheck;
        IPlayer lastPlayerToRaise; //if we go a whole rotation around players and come back to lastplayer to raise we know to go to next round
        int round = 1;

        /**
         * Constructor
         **/
        public Game(int smallBlind, int amountOfAI)
        {
            this.smallBlind = smallBlind;
            this.inProgress = false;
            this.deck = new Deck();
            for(int i = 1; i <= amountOfAI; i++)
            {
                players.Add(new AIPlayer(5000, this)); //hard coded that all aiplayers start with 5000 chips but this can change
            }
            foreach(IPlayer player in players) //deal each player 2 cards
            {
                for(int i = 1; i <= 2; i++)
                {
                    player.getHand().addCard(deck.drawCard());
                }
            }
            onStart();
        }

        /**
         * Getters and setter
         **/
        public IPlayer getLastPlayerToRaise()
        {
            return lastPlayerToRaise;
        }

        public void setLastPlayerToRaise(IPlayer player)
        {
            this.lastPlayerToRaise = player;
        }

        public void bet(int amount, IPlayer player)
        {
            if(amount > player.getChips())
            {
                this.pot += player.getChips();
                player.allIn = true;
                player.setChips(0);
            }
            else
            {
                this.pot += amount;
                player.setChips(player.getChips() - amount);
            }
        }

        public void resetPot()
        {
            this.pot = 0;
        }

        /**
         * General methods
         **/
        public void removePlayer(IPlayer player)
        {
            if(!inProgress)
            {
                players.Remove(player);
            }
        }

        public int getSmallBlind()
        {
            return smallBlind;
        }

        /**
         * Will run every round, returns false if was the final round and game is over
         **/
        public bool onRound()
        {

            //Field logic
            bool everyPlayerMet = false;
            int playerNumber = 0;
            highestBet = 0;

            //Round logic
            if(round > 4)
            {
                return false;
            }
            if(round == 1)
            {
                bet(smallBlind, players[playerNumber]);
                playerNumber++;
                bet(smallBlind, players[playerNumber]);
                playerNumber++; //skip to third player as first two have already bet
            }
            if(round == 2) //draw 3 cards on second round 
            {
                List<Card> cardsDrawn = new List<Card>();
                for (int i = 1; i <= 3; i++)
                {
                    cardsDrawn.Add(deck.drawCard());
                }
                foreach (Card card in cardsDrawn)
                {
                    foreach (IPlayer player in players)
                    {
                        player.getHand().addCard(card);
                    }
                }
            }
            if(round > 2 && round < 5) //draw 1 card per round after
            {
                Card cardDrawn = deck.drawCard();
                foreach(IPlayer player in players)
                {
                    player.getHand().addCard(cardDrawn);
                }
            }

            //Reset every players bet for this round of betting
            foreach(IPlayer participant in players)
            {
                participant.setCurrentBet(0); //set all players current bet to 0
            }

            //Choice Logic
            while(!everyPlayerMet) //keep looping through players doing their turn until every player is met
            {
                for (int i = playerNumber; i <= players.Count; i++)
                {
                    IPlayer player = players[i];
                    if (player.isBust() || player.allIn || player.isOutForRound()) continue; //if player is bust, all in or out for this hand of cards just skip them
                    player.onTurn();
                }
                playerNumber = 0;
            }
            return true;
        }

        public void onStart()
        {
            inProgress = true;
            resetPot();
            while(inProgress) //main game loop
            {
                inProgress = onRound();
            }
        }

        public void onEnd()
        {
            inProgress = false;
            round = 1;
        }
    }

}
