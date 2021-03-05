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

        public IPlayer(int chips, Game game)
        {
            this.currentGame = game;
            this.chips = chips;
        }
        public abstract void onTurn();

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
        public AIPlayer(int chips, Game game) : base(chips, game)
        {

        }

        public override void onTurn()
        {
            Console.WriteLine("Hi");
        }

        public int getID()
        {
            return this.ID;
        }

        public Choice pickChoice()
        {
            Random rnd = new Random();
            if (this.currentGame.canCheck) //if player is able to check
            {
                switch (rnd.Next(1, 5))
                {
                    case (1):
                        return new Fold();
                    case (2):
                        int amountToRaise = rnd.Next(currentGame.getSmallBlind(), chips);
                        this.allIn = (amountToRaise == chips); //set allin value appropriately
                        return new Raise(amountToRaise); //return a raise between the minimum bet and going all in
                    default:
                        return new Fold(); //make them fold in case of error
                }
            }
            switch (rnd.Next(1, 3))
            {
                case (1):
                    return new Fold();
                case (2):

            }
        }
    }

    public class Player : IPlayer
    {

        private Form1 form;

        public Player(Form1 form, int chips, Game game) : base(chips, game)
        {
            this.form = form;
        }

        public override void onTurn()
        {
            Choice choice = showChoiceMenu();

            if(typeof(Fold).IsInstanceOfType(choice)) //if they folded
            {

            }
            if(typeof(Call).IsInstanceOfType(choice))
            {

            }
            if(typeof(Raise).IsInstanceOfType(choice))
            {

            }
        }

        public Choice getChoice()
        {
            form.getPlayerChoice(this);
        }

    }

    //Are these needed? Why not just functions for each choice and then use the Game field to access and do the relative logic
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
        public int amountToCall;
        public Call(int amount)
        {
            this.amountToCall = amount;
        }
    }

}
