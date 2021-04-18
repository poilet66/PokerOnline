using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Poker_Online
{
    public partial class Form1 : Form
    {
        /**
         * =============================
         * Fields
         * =============================
         **/
        //this is used to know where to place player's cards
        public static readonly List<Tuple<int,int>> playerLocations = new List<Tuple<int, int>> { Tuple.Create(86,468), Tuple.Create(150,80), Tuple.Create(424, 75), Tuple.Create(720, 150), Tuple.Create(750, 350) };
        private int raiseAmount = 0;
        public Choice menuBoxChoice;
        private bool betMenuOpen = false;
        private DatabaseHandler db;
        private System.Timers.Timer timer;
        private Player player;
        private Game game;

        /**
         * =============================
         * Constructors
         * =============================
         **/
        public Form1()
        {
            InitializeComponent();
            pageHandler.SelectedTab = mainScreen;
            this.db = new DatabaseHandler(); 
        }

        /**
         * =============================
         * General Methods
         * =============================
         **/
        public void updatePlayerChips(string user, int newAmount)
        {
            db.updatePlayerChips(user, newAmount);
        }

        private void Form1_Closing(object sender, EventArgs e)
        {
            db.close();
        }

        /**
         * =============================
         * Event Handlers
         * =============================
         **/

        private void newUserButton_Click(object sender, EventArgs e)
        {
            pageHandler.SelectedTab = signupScreen;
            signupStatusLabel.Hide();
        }

        private void existUserButton_Click(object sender, EventArgs e)
        {
            pageHandler.SelectedTab = loginScreen;
        }

        private void loginPageGoBackButton_Click(object sender, EventArgs e)
        {
            pageHandler.SelectedTab = mainScreen;
        }

        private void signupGoBackButton_Click(object sender, EventArgs e)
        {
            pageHandler.SelectedTab = mainScreen;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            loginLabel.Hide();
            if(!db.userExists(userNameTextbox.Text,passwordTextBox.Text))
            {
                loginLabel.Text = "That username and password does not exist! Check your credentials";
                loginLabel.Show();
                return;
            }
            this.player = new Player(this, db.getUserChips(userNameTextbox.Text), userNameTextbox.Text); //create our sessions player object
            player.setChips(db.getUserChips(player.getUsername())); //restore player chips saved in database
            playerChipLabel.Text = "You have " + player.getChips() + " chips";
            pageHandler.SelectedTab = loggedInMainScreen;
            trackBar2.Minimum = 2;
            trackBar2.Maximum = 5;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            raiseChipsLbl.Text = "" + trackBar1.Value;
            raiseAmount = trackBar1.Value;
        }

        private void raiseButton_Click(object sender, EventArgs e)
        {
            menuBoxChoice = new Raise(trackBar1.Value);
        }

        private void callButton_Click(object sender, EventArgs e)
        {
            menuBoxChoice = new Call();
        }

        private void foldButton_Click(object sender, EventArgs e)
        {
            menuBoxChoice = new Fold();

        }

        private void signupRegisterButton_Click(object sender, EventArgs e)
        {
            if (StringUtils.isEmptyString(signupUserTextbox.Text))
            {
                MessageBox.Show("Cannot have an empty username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                MySqlDataReader rdr = db.select("username", "users");
                while (rdr.Read())
                {
                    if(rdr.GetString(0) == signupUserTextbox.Text) //if username is already in database (dont want two people with same username)
                    {
                        MessageBox.Show("This username is already taken! Try another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rdr.Close();
                        return;
                    }
                }
                rdr.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            if (StringUtils.isEmptyString(signupPasswordTextbox.Text))
            {
                MessageBox.Show("Cannot have an empty password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!(StringUtils.isValidPassword(signupPasswordTextbox.Text)))
            {
                MessageBox.Show("Password must have atleast 1 upper case character, special character £$&(*)@#, one number and be atleast 8 letters long");
                return;
            }

            db.registerPlayer(signupUserTextbox.Text, signupPasswordTextbox.Text);

            signupUserTextbox.Text = "";
            signupPasswordTextbox.Text = "";
            signupStatusLabel.Text = "Account registered!";
            signupStatusLabel.Show();
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            playerCountLbl.Text = trackBar2.Value.ToString() + " players playing";
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            pageHandler.SelectedTab = gameScreen;
            this.game = new Game(50, trackBar2.Value, player);
        }

        /**
         * =============================
         * Utility Methods
         * =============================
         **/
        public Choice getPlayerChoice(Player player)
        {
            menuBox.Show();
            betMenuOpen = true; 
            setButtonsInMenu(true);
            trackBar1.Minimum = player.getGame().getCurrentBetToPlay();
            trackBar1.Maximum = player.getChips();
            while(menuBoxChoice == null)
            {
                var t = Task.Delay(1000); //wait a bit before checking again
                t.Wait();
            }
            setButtonsInMenu(false);
            menuBox.Hide();
            return menuBoxChoice;
        }

        public void showWinnerText(string name, int pot)
        {
            winnerLbl.Text = name + " won $" + pot;
            winnerLbl.Show();
            var t = Task.Delay(5000); //wait 5 seconds and change back to main screen
            t.Wait();
            winnerLbl.Hide();
            playerChipLabel.Text = "You have " + player.getChips() + " chips"; //update player chips in game too
            pageHandler.SelectedTab = loggedInMainScreen;
        }

        private void setButtonsInMenu(bool enabled)
        {
            foreach (Control component in menuBox.Controls)
            {
                if (component is Button)
                {
                    Button button = (Button)component;
                    button.Enabled = enabled;
                }
            }
        }

        //Method used to show players' cards, if 'blank' bool is set to true, it will only show the backsides of cards and if set to false, will show the cards actual pictures
        public void showPlayersCards(Game game, bool blank)
        {
            int count = 0;
            int cardXOffset = 0;
            foreach (IPlayer player in game.getPlayers())
            {
                if (typeof(AIPlayer).IsInstanceOfType(player))
                {
                    cardXOffset = 0;
                    foreach (Card card in player.getOriginalHand().getCards())
                    {
                        Tuple<int, int> loc = playerLocations[count];
                        PictureBox box = new PictureBox();
                        box.Size = new System.Drawing.Size(50, 80); //create box size of the images
                        box.SizeMode = PictureBoxSizeMode.StretchImage;
                        box.Location = new Point(loc.Item1 + cardXOffset, loc.Item2);
                        box.Visible = true;
                        box.Image = (blank) ? Image.FromFile( System.AppDomain.CurrentDomain.BaseDirectory + @"Images\blankcard.png") : Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + @"Images\" + card.getFileName() + ".png"); //Get card image, either blank or actual
                        gameScreen.Controls.Add(box);
                        cardXOffset += 50 + 10; //shift card over to the right so cards dont overlap, have 10 pixel 'buffer' between
                    }
                    count++;
                }
                else //if an actual player just draw their cards dont bother blanking them out
                {
                    cardXOffset = 0;
                    foreach(Card card in player.getOriginalHand().getCards())
                    {
                        PictureBox box = new PictureBox();
                        box.Size = new System.Drawing.Size(50, 80); //create box size of the images
                        box.SizeMode = PictureBoxSizeMode.StretchImage;
                        box.Location = new Point(340 + cardXOffset, 562);
                        box.Visible = true;
                        box.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + @"Images\" + card.getFileName() + ".png"); //Get card image, either blank or actual
                        gameScreen.Controls.Add(box);
                        cardXOffset += 50 + 10; //shift card over to the right so cards dont overlap, have 10 pixel 'buffer' between
                    }
                }
            }
        }

    }
}
