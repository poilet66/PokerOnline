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
        public Form1()
        {
            InitializeComponent();
            pageHandler.SelectedTab = mainScreen;
            
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            pageHandler.SelectedTab = signupScreen;
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
            try
            {
                DatabaseHandler db = new DatabaseHandler();
                MySqlDataReader rdr = db.select("username", "users");
                while (rdr.Read())
                {
                    if(rdr.GetString(0) == signupUserTextbox.Text) //if username is already in database (dont want two people with same username)
                    {
                        MessageBox.Show("This username is already taken! Try another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else
                    {
                        
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
