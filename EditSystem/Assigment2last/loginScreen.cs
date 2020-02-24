using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assigment2last
{
    public partial class loginScreen : Form
    {
        public loginScreen()
        {
            InitializeComponent();
            //display of the password should be blocked by *
            textPassword.PasswordChar = '*';
            textPassword.MaxLength = 15;
        }

        string usernameInput = string.Empty;
        string userType = string.Empty;
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //store the content in the textbox
            usernameInput = textUsername.Text;
            //string usernameInput = textUsername.Text;
            string passwordInput = textPassword.Text;
            string path = @"..\..\..\login.txt";

            //read the login.txt file, get the username and password for login
            StreamReader sr = new StreamReader(path);
            string line;
            //each line should be splited by ,
            while((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split(',');
                //first and second elements are all need for login process
                string user = components[0];
                string pass = components[1];
                string type = components[2];
                userType = type;

                //if the username and password matches, it will show the editScreen
                if (user == usernameInput && pass == passwordInput)
                {
                    this.Hide();                 
                    editScreen editScreen = new editScreen(usernameInput, userType); //need to pass the username input to the edit screen
                    editScreen.Show();
                }

                //if not matches, textbox should be empty for new entering               
                else
                {
                    //MessageBox.Show("Unauthorized Login !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textUsername.Clear();
                    textPassword.Clear();

                    textUsername.Focus();
                }
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            this.Hide();
            newScreen newUserScreen = new newScreen();
            newUserScreen.Show();
        }

        private void LoginScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
