using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Online
{
    public abstract class IPlayer
    {
        protected Hand hand;
        protected int currentBet;
        protected int chips;
        public bool allIn, areOut;
        protected Game currentGame;

        public IPlayer(int chips)
        {
            this.hand = new Hand();
            this.chips = chips;
        }

        /**
         * Returns true if they raised
         **/
        public abstract bool onTurn();

        public bool isBust()
        {
            return (chips <= 0) && (allIn == false);
        }

        public bool isOutForRound()
        {
            return areOut;
        }
        public int getChips()
        {
            return chips;
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
    }

    public class AIPlayer : IPlayer
    {
        private int ID;
        Game game;
        public AIPlayer(int chips, Game game) : base(chips)
        {
            this.game = game;
        }

        public override bool onTurn()
        {
            return true;
        }

        public int getID()
        {
            return this.ID;
        }

        public Choice pickChoice()
        {
            //TODO: AIPlayer choice AI, can just be random, but weight towards not folding so games don't end prematurely
            return new Fold();
        }
    }

    public class Player : IPlayer
    {

        private Form1 form;

        public Player(Form1 form, int chips) : base(chips)
        {
            this.form = form;
        }

        /**
         * Player choice logic
         **/
        public override bool onTurn()
        {
            Choice choice = getChoice();

            if(typeof(Fold).IsInstanceOfType(choice)) //if they folded
            {
                areOut = true;
                return false;
            }
            if(typeof(Call).IsInstanceOfType(choice))
            {
                getGame().bet(getGame().getCurrentBetToPlay(), this);
                return false;
            }
            if(typeof(Raise).IsInstanceOfType(choice))
            {
                Raise raise = (Raise) choice;
                getGame().setCurrentBetToPlay(getGame().getCurrentBetToPlay() + raise.byHowMuch);
                getGame().bet(getGame().getCurrentBetToPlay() + raise.byHowMuch, this);
                return true;
            }
            return false;
        }

        public Choice getChoice()
        {
            return form.getPlayerChoice(this);
        }

        public void showWinnerText(string name, int pot)
        {
            form.showWinnerText(name, pot);
        }

        public void startGame()
        {
            form.startGame(getGame());
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
