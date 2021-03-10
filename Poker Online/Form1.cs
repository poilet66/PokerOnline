using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Poker_Online
{
    public partial class Form1 : Form
    {
        int raiseAmount = 0;
        int playersPlaying = 2;
        Choice menuBoxChoice;
        bool betMenuOpen = false;
        DatabaseHandler db;
        Player player;
        Game game;
        public Form1()
        {
            InitializeComponent();
            pageHandler.SelectedTab = mainScreen;
            this.db = new DatabaseHandler(); 
        }

        private void Form1_Closing(object sender, EventArgs e)
        {
            db.close();
        }

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
            if(!db.userExists("users",userNameTextbox.Text,passwordTextBox.Text))
            {
                loginLabel.Text = "That username and password does not exist! Check your credentials";
                loginLabel.Show();
                return;
            }
            this.player = new Player(this, db.getUserChips(userNameTextbox.Text));
            playerChipLabel.Text = "You have " + player.getChips() + " chips";
            pageHandler.SelectedTab = loggedInMainScreen;
            trackBar2.Minimum = 2;
            trackBar2.Maximum = 5;
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

            var sql = "INSERT INTO users(username, password) VALUES(@username, @password)";
            using var cmd = new MySqlCommand(sql, db.getConnection());
            cmd.Parameters.AddWithValue("@username", signupUserTextbox.Text);
            cmd.Parameters.AddWithValue("@password", signupPasswordTextbox.Text);
            cmd.Prepare();  
            cmd.ExecuteNonQuery();

            signupUserTextbox.Text = "";
            signupPasswordTextbox.Text = "";
            signupStatusLabel.Text = "Account registered!";
            signupStatusLabel.Show();
        }

        public Choice getPlayerChoice(Player player)
        {
            menuBox.Show();
            betMenuOpen = true;
            setButtonsInMenu(true);
            trackBar1.Minimum = player.getGame().getCurrentBetToPlay();
            trackBar1.Maximum = player.getChips();
            while(menuBoxChoice == null) //wait until a choice has been made, not sure if this is the best way to do things maybe add a short delay in
            {
                continue;
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
            pageHandler.SelectedTab = loggedInMainScreen;
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

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            playerCountLbl.Text = trackBar2.Value.ToString() + " players playing";
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            pageHandler.SelectedTab = gameScreen;
            this.game = new Game(50, trackBar2.Value, player);
            
            //TODO: do all the GUI stuff such as player card icons here
        }

        public void startGame(Game game)
        {
            
        }
    }
}
