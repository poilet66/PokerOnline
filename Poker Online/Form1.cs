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

        DatabaseHandler db;
        public Form1()
        {
            InitializeComponent();
            pageHandler.SelectedTab = mainScreen;
            this.db = new DatabaseHandler(); //needs to be surrounded in try/catch!!! how will error messaging work?
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
    }
}
