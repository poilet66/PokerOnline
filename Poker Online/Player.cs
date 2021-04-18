using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Poker_Online
{
    public abstract class IPlayer
    {

        /**
         * =============================
         * Fields
         * =============================
         **/

        protected Hand hand;
        protected Hand originalHand;
        protected int currentBet;
        protected int chips;
        public bool allIn, areOut;
        protected Game currentGame;

        /**
         * =============================
         * Constructors
         * =============================
         **/

        public IPlayer(int chips)
        {
            this.hand = new Hand();
            this.chips = chips;
        }

        /**
         * =============================
         * Getters / Setters
         * =============================
         **/
        public int getChips()
        {
            return chips;
        }
        public void setOriginalHand(Hand hand)
        {
            this.originalHand = hand;
        }

        public Hand getOriginalHand()
        {
            return originalHand;
        }
        public void setChips(int amount)
        {
            chips = amount;
        }

        public void setGame(Game game)
        {
            this.currentGame = game;
        }

        public Game getGame()
        {
            return currentGame;
        }

        public int getCurrentBet()
        {
            return currentBet;
        }

        public void setCurrentBet(int amount)
        {
            currentBet = amount;
        }

        public Hand getHand()
        {
            return hand;
        }

        /**
         * =============================
         * Game Logic
         * =============================
         **/

        /**
         * Returns true if they raised
         **/
        public bool onTurn()
        {
            Choice choice = pickChoice();
            if (typeof(Fold).IsInstanceOfType(choice)) //if they folded
            {
                areOut = true;
                return false;
            }
            if (typeof(Call).IsInstanceOfType(choice))
            {
                getGame().bet(getGame().getCurrentBetToPlay(), this);
                return false;
            }
            if (typeof(Raise).IsInstanceOfType(choice))
            {
                Raise raise = (Raise)choice;
                getGame().setCurrentBetToPlay(getGame().getCurrentBetToPlay() + raise.byHowMuch);
                getGame().bet(getGame().getCurrentBetToPlay() + raise.byHowMuch, this);
                return true;
            }
            return false;
        }

        public abstract Choice pickChoice();
        public bool isBust()
        {
            return (chips <= 0) && (allIn == false);
        }

        public bool isOutForRound()
        {
            return areOut;
        }

    }

    public class AIPlayer : IPlayer
    {
        /**
         * =============================
         * Fields
         * =============================
         **/
        private int ID;

        /**
         * =============================
         * Construct
         * =============================
         **/
        public AIPlayer(int chips, Game game) : base(chips)
        {
            this.setGame(game);
            Random rnd = new Random();
            this.ID = rnd.Next(1, 10000); //give random ID so they can be identified by player easier
        }

        /**
         * =============================
         * Getters / Setters
         * =============================
         **/
        public int getID()
        {
            return this.ID;
        }

        /**
         * =============================
         * Game Logic / OVERRIDE
         * =============================
         **/

        //AIPlayer choice algorithm, weighted more towards not folding so that games will last longer
        public override Choice pickChoice()
        {
            Random rnd = new Random();
            int choicePercent = rnd.Next(1, 101); //generate random from 1-100
            if (choicePercent >= 1 && choicePercent <= 10) //10 percent chance to raise
            {
                int raiseAmount = rnd.Next(currentGame.getSmallBlind(), chips + 1); //make them raise a random amount
                return new Raise(raiseAmount);
            }
            if (choicePercent > 10 && choicePercent <= 10) //10 percent chance to fold
            {
                return new Fold();
            }
            else //will most likely call
            {
                return new Call();
            }
        }
    }

    public class Player : IPlayer
    {
        /**
         * =============================
         * Fields
         * =============================
         **/
        private string username;
        private Form1 form;

        /**
         * =============================
         * Constructors
         * =============================
         **/
        public Player(Form1 form, int chips, string username) : base(chips)
        {
            this.username = username;
            this.form = form;
        }

        /**
         * =============================
         * Getters / Setters
         * =============================
         **/
        public string getUsername()
        {
            return username;
        }
        public override Choice pickChoice()
        {
            return form.getPlayerChoice(this);
        }

        public Form1 getForm()
        {
            return form;
        }

        /**
         * =============================
         * Utility Methods
         * =============================
         **/

        public void updateChips(int amount)
        {
            form.updatePlayerChips(username, amount);
        }

        public void showWinnerText(string name, int pot)
        {
            form.showWinnerText(name, pot);
        }
    }

    /**
     * Choice classes
     **/
    public abstract class Choice
    {

    }
    
    public class Fold : Choice
    {

    }

    public class Raise : Choice
    {
        public int byHowMuch;
        public Raise(int byHowMuch)
        {
            this.byHowMuch = byHowMuch;
        }
    }

    public class Call : Choice //check is just call of 0
    {
        public Call()
        {

        }
    }

}
