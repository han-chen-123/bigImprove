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
    public partial class newScreen : Form
    {
        public newScreen()
        {
            InitializeComponent();
            userType.SelectedIndex = 0;
            userType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void NewScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            loginScreen loginScreen = new loginScreen();
            loginScreen.Show();
            this.Hide();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            //define all the variables 
            string userInput = textUser.Text;
            string pwdInput = textPwd.Text;
            string rePwdInput = textRePwd.Text;
            string firstInput = textFirst.Text;
            string lastInput = textLast.Text;
            string birthInput = PickerBirth.Value.ToString("dd-MM-yyyy"); //the format for datePicker should be customized 
            string userTypeInput = userType.Text;

            // make sure the textbox cannot be null, if some textbox is null, the message should show up
            foreach (Control empty in this.Controls) //use a loop to check the status of each textbox
            {
                if (empty is TextBox)
                {
                    if (string.IsNullOrEmpty((empty as TextBox).Text))
                    {
                        MessageBox.Show("The information is not complete !", "Error", MessageBoxButtons.OK);
                        break;
                    }
                    else
                    {
                        //need to make sure the password input equals to re-password input
                        if (pwdInput == rePwdInput)
                        {
                            //using streamWriter to add new information into the text file
                            string path = @"..\..\..\login.txt";
                            FileStream fs = new FileStream(path, FileMode.Append);
                            StreamWriter sw = new StreamWriter(fs);
                            sw.Write("\r\n" + userInput + "," + pwdInput + "," + userTypeInput + "," + firstInput + "," + lastInput + "," + birthInput);
                            sw.Close();
                            fs.Close();

                            //after the information been added, message should be shown to allow user to know
                            MessageBox.Show("New Account Created !", "Successful", MessageBoxButtons.OK);
                            loginScreen loginScreen = new loginScreen();
                            loginScreen.Show();
                            this.Hide();
                        }
                        //once not match, no information will be added into the text file and error showing up
                        else
                        {
                            MessageBox.Show("Please Check Password Again !", "Error", MessageBoxButtons.OK);
                            newScreen newScreen = new newScreen();
                            newScreen.Show();
                            this.Hide();
                        }
                        break;
                    }
                }
            }
        }


    }
}
