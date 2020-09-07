using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Net.Mail;
using System.Net;


namespace Assignment1
{
    public class Program
    {
        //define all the variables that used in the Program
        private static string userName = null;
        private static string passWord = null;
        private static string First, Last, Address, Email = null, Pwd;
        private static string accountNo = null;
        private static string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private static string desktopLogin = desktop + "\\" + "login.txt";
        private static string desktopAccount = desktop + "\\" + "UserAccount.txt";

        //private static string accountNoEnter;

        static void Main(string[] args)
        {
            start();
            Console.ReadKey();
        }

        //set the cursor location, set a display method, it can be used later
        public void display(int x, int y, string design)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(design);
        }

        //create a start main
        public static void start()
        {
            Console.Clear();
            //define a new program position, and can use display method
            Program pos = new Program();

            //design a start main for user, they can choose to login or create an account
            pos.display(17, 10, "\t\t--------------------------------------------------------");
            pos.display(17, 11, "\t\t            WELCOME TO SIMPLE BANKING SYSTEM");
            pos.display(17, 12, "\t\t--------------------------------------------------------");
            pos.display(17, 13, "                1. Login in account");
            pos.display(17, 14, "                2. Create a new account");
            pos.display(17, 15, "\t\t--------------------------------------------------------");

            Console.SetCursorPosition(33, 16);
            //the input type is string, need to change to int
            string number = Console.ReadLine();

            //use switch to identify which option that user choose
            switch (number)
            {
                case "1": loginScreen(); break;
                case "2": RegScreen(); break;
                default:
                    pos.display(33, 16, "Wrong option !");
                    Console.ReadKey();
                    start();
                    break;
            }

        }

        //create a loginScreen
        public static void loginScreen()
        {
            //initilize console
            Console.Clear();

            //define a new program position, and can use display method
            Program pos = new Program();

            //design a console screen for login
            pos.display(17, 10, "\t\t--------------------------------------------------------");
            pos.display(17, 11, "\t\t            WELCOME TO SIMPLE BANKING SYSTEM");
            pos.display(17, 12, "\t\t--------------------------------------------------------");
            pos.display(17, 13, "\t\t                   LOGIN TO START");
            pos.display(17, 15, "\t\t       User Name :");
            pos.display(17, 16, "\t\t       Password :");
            pos.display(17, 17, "\t\t--------------------------------------------------------");

            //set Cursor's postion, and get user's input username
            Console.SetCursorPosition(52, 15);
            userName = Console.ReadLine();

            //display * instead of the actual characters
            //define a string type for user input password
            Console.SetCursorPosition(52, 16);
            string input = "*";

            do
            {
                //store what user input, and do not show the character in the input area
                ConsoleKeyInfo press = Console.ReadKey(true);

                //if user's input is not enter or backspace, input in the position(52,16) should be *
                if (press.Key != ConsoleKey.Enter && press.Key != ConsoleKey.Backspace)
                {
                    passWord += press.KeyChar;
                    Console.Write(input);
                }
                //if the input is delete and password length greater than 0, delete should happen
                else if (press.Key == ConsoleKey.Backspace && passWord.Length > 0)
                {
                    passWord = passWord.Substring(0, (passWord.Length - 1));
                    Console.Write("\b \b");
                }
                // once user press enter, the loop should be break
                if (press.Key == ConsoleKey.Enter)
                {
                    break;
                }
            } while (true);

            //create an array to store all the username and password 
            try
            {

                string[] userTxt = File.ReadAllLines(desktopLogin, Encoding.Default);
                foreach (string line in userTxt)
                {
                    string[] elements = line.Split('|');
                    string username = elements[0];
                    string password = elements[1];
                    if (userName == username && passWord == password)
                    {
                        pos.display(33, 18, "Valid Credentials ! ...  Please Enter ");
                        Console.ReadKey();
                        Menu();
                    }
                }

                foreach (string txt in userTxt)
                {
                    string[] elements = txt.Split('|');
                    string username = elements[0];
                    string password = elements[1];
                    if (userName.Equals(username) == false && passWord.Equals(password) == false)
                    {
                        pos.display(33, 18, "Unauthorized login ! ...");
                        Console.ReadKey();
                        LoginFail();
                    }
                    Console.Clear();
                    break;                 
                }
            }
            //catch the fileNotFoundException exception
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

        }

        //after user login, a main menu need to show up
        public static void Menu()
        {
            Console.Clear();
            Program pos = new Program();

            pos.display(17, 10, "\t\t--------------------------------------------------------");
            pos.display(17, 11, "\t\t            WELCOME TO SIMPLE BANKING SYSTEM");
            pos.display(17, 12, "\t\t--------------------------------------------------------");
            pos.display(17, 13, "                1. Create a new account");
            pos.display(17, 14, "                2. Search for an account");
            pos.display(17, 15, "                3. Deposit");
            pos.display(17, 16, "                4. Withdraw");
            pos.display(17, 17, "                5. A/C statement");
            pos.display(17, 18, "                6. Delete account");
            pos.display(17, 19, "                7. Exit");
            pos.display(17, 20, "\t\t--------------------------------------------------------");

            Console.SetCursorPosition(33, 21);
            string number = Console.ReadLine();
            switch (number)
            {
                case "1": RegScreen(); break;
                case "2": SearchScreen(); break;
                case "3": DepositScreen(); break;
                case "4": WithdrawScreen(); break;
                case "5": ACScreen(); break;
                case "6": DeleteScreen(); break;
                case "7": Exit(); break;
                default:
                    pos.display(33, 21, "Wrong option !");
                    Console.ReadKey();
                    Exit();
                    break;
            }
        }

        //once the login failed, the user needs to know what to do
        public static void LoginFail()
        {
            Console.Clear();
            Program pos = new Program();

            pos.display(17, 10, "\t\t--------------------------------------------------------");
            pos.display(17, 11, "\t\t            WELCOME TO SIMPLE BANKING SYSTEM");
            pos.display(17, 12, "\t\t--------------------------------------------------------");
            pos.display(17, 13, "                1. Create a new account");
            pos.display(17, 14, "                2. Exit");
            pos.display(17, 15, "\t\t--------------------------------------------------------");

            Console.SetCursorPosition(33, 16);
            string number = Console.ReadLine();
            switch (number)
            {
                case "1": RegScreen(); break;
                case "2": Exit(); break;
                default:
                    pos.display(33, 16, "Wrong option !");
                    Console.ReadKey();
                    LoginFail();
                    break;

            }
        }

        //create a registration screen
        public static void RegScreen()
        {
            Console.Clear();
            //string First, Last, Address, Email, Pwd, Phone;
            Program pos = new Program();

            pos.display(17, 10, "\t\t--------------------------------------------------------");
            pos.display(17, 11, "\t\t            WELCOME TO SIMPLE BANKING SYSTEM");
            pos.display(17, 12, "\t\t--------------------------------------------------------");
            pos.display(17, 13, "                First Name:");
            pos.display(17, 14, "                Last Name:");
            pos.display(17, 15, "                Password:");
            pos.display(17, 16, "                Address:");
            pos.display(17, 17, "                Phone:");
            pos.display(17, 18, "                Email:");
            pos.display(17, 19, "\t\t--------------------------------------------------------");

            //let cursor be in the right position, and set variables
            Console.SetCursorPosition(45, 13);
            First = Console.ReadLine();
            Console.SetCursorPosition(45, 14);
            Last = Console.ReadLine();
            Console.SetCursorPosition(45, 15);
            Pwd = Console.ReadLine();
            Console.SetCursorPosition(45, 16);
            Address = Console.ReadLine();

            //field check for phone number
            Console.SetCursorPosition(45, 17);
            string Phone = "";
            do
            {
                char enter = Console.ReadKey().KeyChar;
                //if user uses enter, the loop should break
                if (enter == '\r')
                {
                    break;
                }
                //users only can type integer in phone number field
                else if (enter >= 48 && enter <= 58)
                {
                    Phone += enter;
                }
                //if users enter other key rather than integer key
                else
                {
                    pos.display(17, 20, "                Please enter the right Phone Number");
                    Console.ReadKey();
                    RegScreen();
                }
                //limit to 10 chars
            } while (Phone.Length < 10);

            //identify the format of email that user entering
            Console.SetCursorPosition(45, 18);
            Email = Console.ReadLine();
            if (EmailVerify(Email) == false)
            {
                Console.ReadKey();
                RegScreen();
            }
            else
            {
                pos.display(65, 18, "           Valid Email Address");
            }

            //after the information has been fulfilled, users' name and password should be go in to the login.txt for login purpose
            //and an email will be send to the user's email address

            //add firstname lastname and password into login.txt, the information is needed for login
            string filePath = desktopLogin;
            //the format that added should be the same as login.txt format
            string content = First + Last + '|' + Pwd;
            List<string> lines = File.ReadAllLines(filePath).ToList();
            lines.Add(content);
            File.WriteAllLines(filePath, lines);

            //create a user's information text file to desktop
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //define variables for a new fileName, filePosition, and accountNumber name
            string fileName, filePos;
            //generate a unique account number (6-8 digits) for file name
            Random rd = new Random();
            int num = rd.Next(100000, 99999999);
            accountNo = Convert.ToString(num);

            //a text file name should be <account_number>.txt
            fileName = accountNo + ".txt";
            filePos = folderPath + "\\" + fileName;

            //make sure the file is exit or not
            if (File.Exists(filePos))
            {
                Console.WriteLine("File exists !");

            }

            Console.ReadKey();

            //create a text file
            using (StreamWriter outputFile = new StreamWriter(filePos))
                //write user's personal information into the file
                outputFile.WriteLine("Account Number:" + accountNo + "\n" + "First Name:" + First + "\n" + "Last Name:" + Last + "\n" + "Password:" + Pwd + "\n" + "Address:" + Address + "\n" + "Phone:" + Phone + "\n" + "Email:" + Email);
            //once user enter the right information, they should know the file is created
            pos.display(33, 20, "File Created !");
            Console.ReadKey();

            string AccountfilePath = desktopAccount;
            //the format that added should be the same as login.txt format
            string AccountDetail = First + Last + '|' + accountNo;
            List<string> AccountLines = File.ReadAllLines(AccountfilePath).ToList();
            AccountLines.Add(AccountDetail);
            File.WriteAllLines(AccountfilePath, AccountLines);

            //send email
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("hanchen1609@gmail.com");
            mail.To.Add(Email);
            mail.Subject = "Registration Successful !";
            mail.Body = "Please find the attachment below";

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(filePos);
            mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("hanchen1609@gmail.com", "plmplm12@");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);


            pos.display(33, 21, "Email Send ! Registration Complete !");
            Console.ReadKey();
            loginScreen();
        }

        //define a function that limit the email's format
        static public bool EmailVerify(string Email)
        {
            //if the email format does not contain @
            if (Email.IndexOf("@") == -1)
            {
                Console.SetCursorPosition(60, 18);
                Console.WriteLine("Email format is wrong !");
                return false;
            }

            return true;
        }

        //create a exit screen
        public static void Exit()
        {
            Console.Clear();
            Program pos = new Program();

            pos.display(17, 10, "\t\t--------------------------------------------------------");
            pos.display(17, 11, "\t\t            WELCOME TO SIMPLE BANKING SYSTEM");
            pos.display(17, 12, "\t\t--------------------------------------------------------");
            pos.display(17, 13, "                THANK YOU !");
            pos.display(17, 14, "\t\t--------------------------------------------------------");
            Console.ReadKey();
            Environment.Exit(0);
        }

        //create a search account screen
        public static void SearchScreen()
        {
            Console.Clear();
            Program pos = new Program();
            string accountNoEnter;

            pos.display(17, 10, "\t\t--------------------------------------------------------");
            pos.display(17, 11, "\t\t                  SEARCH AN ACCOUNT");
            pos.display(17, 12, "\t\t--------------------------------------------------------");
            pos.display(17, 13, "                                 ENTER THE DETAILS");
            pos.display(17, 15, "                Account Number:");
            pos.display(17, 16, "\t\t--------------------------------------------------------");

            //user needs to enter the account number first to identify the existence of an account
            Console.SetCursorPosition(50, 15);
            accountNoEnter = Console.ReadLine();

            //if the account is exit, show account detail, check another account, back to main screen
            //if the account not found, check another account, or back to main screen
            //AccountNo == Account number that generated from registration
            string[] userTxt = File.ReadAllLines(desktopAccount, Encoding.Default);
            foreach (var line in userTxt)
            {
                string[] elements = line.Split('|');
                string accountNumber = elements[1];
                if (accountNoEnter == accountNumber)
                {
                    pos.display(17, 18, "                Account Found !");
                    Console.ReadKey();
                    pos.display(17, 19, "\t\t--------------------------------------------------------");
                    pos.display(17, 20, "\t\t                  ACCOUNT DETAILS");
                    pos.display(17, 21, "\t\t--------------------------------------------------------");

                    string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string AccountFilePath = accountNoEnter + ".txt";
                    string AccountFilePos = folderPath + "\\" + AccountFilePath;
                    String[] accountTxt = File.ReadAllLines(AccountFilePos);
                    foreach (var detail in accountTxt)
                    {
                        Console.Write(detail);
                    }

                    Console.ReadKey();
                    Menu();
                }
               
            }
            foreach (string txt in userTxt)
            {
                string[] elements = txt.Split('|');
                string accountNumber1 = elements[1];
                if (accountNoEnter.Equals(accountNumber1) == false)
                {

                    pos.display(17, 17, "                Account Not Found !");
                    Console.ReadKey();
                    pos.display(17, 18, "                Check another account (y/n)?");
                    Console.SetCursorPosition(70, 18);
                    string option = Console.ReadLine();
                    if (option == "y")
                    {
                        SearchScreen();
                    }
                    else if (option == "n")
                    {
                        Menu();
                    }
                    else
                    {
                        pos.display(17, 19, "                Wrong Option, Please check again !");
                        Console.ReadKey();
                        SearchScreen();
                    }


                }
              
            }
        }

        //create a deposit screen
        public static void DepositScreen()
        {
            Console.Clear();
            Program pos = new Program();
            int Amount;
            string accountNoEnter;

            pos.display(17, 10, "\t\t--------------------------------------------------------");
            pos.display(17, 11, "\t\t                       DEPOSIT");
            pos.display(17, 12, "\t\t--------------------------------------------------------");
            pos.display(17, 13, "                                 ENTER THE DETAILS");
            pos.display(17, 15, "                Account Number:");
            pos.display(17, 16, "                Amount: $");
            pos.display(17, 17, "\t\t--------------------------------------------------------");

            Console.SetCursorPosition(50, 15);
            accountNoEnter = Console.ReadLine();
            Console.SetCursorPosition(42, 16);
            Amount = int.Parse(Console.ReadLine());

            //if the account number exists, enter the deposit amount, update the account balance and info, return to main
            //if not exists, retry, back to main
            string[] userTxt = File.ReadAllLines(@"desktopAccount", Encoding.Default);
            foreach (var line in userTxt)
            {
                string[] elements = line.Split('|');
                string accountNumber = elements[1];
                if (accountNoEnter == accountNumber)
                {
                    pos.display(17, 18, "               Account Found !");
                    Console.ReadKey();
                    pos.display(17, 19, "               Deposit successfull !");
                    Console.ReadKey();

                    //update the account balance and update the information in the files for the account
                    int balance = 0;
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + accountNoEnter + ".txt";
                    string content = "Deposit: $" + Convert.ToString(balance + Amount) + "\n" + "Balance: $" + Convert.ToString(balance + Amount);
                    File.AppendAllText(path, content);
                    Menu();
                }
            }
            foreach (string txt in userTxt)
            {
                string[] elements = txt.Split('|');
                string accountNumber2 = elements[1];
                if (accountNoEnter.Equals(accountNumber2) == false)
                {
                    pos.display(17, 18, "                Account Not Found !");
                    Console.ReadKey();
                    pos.display(17, 19, "                Retry (y/n)?");
                    Console.SetCursorPosition(70, 19);
                    string option = Console.ReadLine();
                    if (option == "y")
                    {
                        DepositScreen();
                    }
                    else if (option == "n")
                    {
                        Menu();
                    }
                    else
                    {
                        pos.display(17, 20, "                Wrong Option, Please check again !");
                        Console.ReadKey();
                        DepositScreen();
                    }
                }
                
            }

            Console.ReadKey();
        }
        //create a withdraw screen
        public static void WithdrawScreen()
        {
            Console.Clear();
            Program pos = new Program();
            int Amount;
            string accountNoEnter;

            pos.display(17, 10, "\t\t--------------------------------------------------------");
            pos.display(17, 11, "\t\t                       WITHDRAW");
            pos.display(17, 12, "\t\t--------------------------------------------------------");
            pos.display(17, 13, "                                 ENTER THE DETAILS");
            pos.display(17, 15, "                Account Number:");
            pos.display(17, 16, "                Amount: $");
            pos.display(17, 17, "\t\t--------------------------------------------------------");

            Console.SetCursorPosition(50, 15);
            accountNoEnter = Console.ReadLine();
            Console.SetCursorPosition(42, 16);
            Amount = int.Parse(Console.ReadLine());

            //if the account number exists, enter the withdraw amount, update the account balance and info, return to main
            //if not exists, retry, back to main
            string[] userTxt = File.ReadAllLines(desktopAccount, Encoding.Default);
            foreach (var line in userTxt)
            {
                string[] elements = line.Split('|');
                string accountNumber = elements[1];
                if (accountNoEnter == accountNumber)
                {
                    pos.display(17, 18, "                Account Found !");
                    Console.ReadKey();
                    pos.display(17, 19, "                Withdraw successfull !");
                    Console.ReadKey();

                    //update the account balance and update the information in the files for the account
                    int balance = 0;
                    int money = Amount;
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + accountNoEnter + ".txt";
                    string content = "\n" + "Withdraw: $" + Convert.ToString(balance - Amount);
                    File.AppendAllText(path, content);
                    Menu();
                }
            }
            foreach (string txt in userTxt)
            {
                string[] elements = txt.Split('|');
                string accountNumber3 = elements[1];
                if (accountNoEnter.Equals(accountNumber3) == false)
                {
                    pos.display(17, 18, "                Account Not Found !");
                    Console.ReadKey();
                    pos.display(17, 19, "                Retry (y/n)?");
                    Console.SetCursorPosition(70, 19);
                    string option = Console.ReadLine();
                    if (option == "y")
                    {
                        DepositScreen();
                    }
                    else if (option == "n")
                    {
                        Menu();
                    }
                    else
                    {
                        pos.display(17, 20, "                Wrong Option, Please check again !");
                        Console.ReadKey();
                        DepositScreen();
                    }
                }
                
            }
        }

        //create an account statement screen
        public static void ACScreen()
        {
            Console.Clear();
            Program pos = new Program();
            string accountNoEnter;

            pos.display(17, 10, "\t\t--------------------------------------------------------");
            pos.display(17, 11, "\t\t                       STATEMENT");
            pos.display(17, 12, "\t\t--------------------------------------------------------");
            pos.display(17, 13, "                                 ENTER THE DETAILS");
            pos.display(17, 15, "                Account Number:");
            pos.display(17, 16, "\t\t--------------------------------------------------------");

            Console.SetCursorPosition(50, 15);
            accountNoEnter = Console.ReadLine();


            //if the account number exists, provide the account statement and info, return to main
            //if not exists, retry, back to main
            string[] userTxt = File.ReadAllLines(desktopAccount, Encoding.Default);
            foreach (var line in userTxt)
            {
                string[] elements = line.Split('|');
                string accountNumber = elements[1];
                if (accountNoEnter == accountNumber)
                {
                    pos.display(17, 18, "               Account Found ! The statement is displayed below...");
                    Console.ReadKey();
                    pos.display(17, 19, "\t\t--------------------------------------------------------");
                    pos.display(17, 20, "\t\t                  SIMPLE BANKING SYSTEM");
                    pos.display(17, 21, "\t\t--------------------------------------------------------");
                    pos.display(17, 22, "               Account Statement: ");

                    string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string AccountFilePath = accountNoEnter + ".txt";
                    string AccountFilePos = folderPath + "\\" + AccountFilePath;
                    String[] accountTxt = File.ReadAllLines(AccountFilePos);
                    foreach (var detail in accountTxt)
                    {
                        Console.Write(detail);
                    }

                    pos.display(17, 32, "\t\t--------------------------------------------------------");
                    pos.display(17, 34, "               Email statement (y/n) ?");
                    Console.SetCursorPosition(70, 34);
                    string choice = Console.ReadLine();
                    if (choice == "y")
                    {
                        //sending statement to email address
                        String EmailAdd;
                        pos.display(17, 35, "               Please enter your email address:");
                        Console.SetCursorPosition(65, 35);
                        EmailAdd = Console.ReadLine();
                        string StatementPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string fileName, filePos;
                        fileName = accountNoEnter + ".txt";
                        filePos = StatementPath + "\\" + fileName;
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                        mail.From = new MailAddress("hanchen1609@gmail.com");
                        mail.To.Add(EmailAdd);
                        mail.Subject = "Account Statement Send Successful !";
                        mail.Body = "Please find the attachment below";

                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(filePos);
                        mail.Attachments.Add(attachment);

                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("hanchen1609@gmail.com", "plmplm12@");
                        SmtpServer.EnableSsl = true;
                        SmtpServer.Send(mail);

                        pos.display(17, 36, "           Email sent successfully !...");
                        Console.ReadKey();
                        Menu();
                    }
                    else if (choice == "n")
                    {
                        Menu();
                    }
                    else
                    {
                        pos.display(17, 36, "                Wrong Option, Please check again !");
                        Console.ReadKey();
                        ACScreen();
                    }
                }
            }
            foreach (string txt in userTxt)
            {
                string[] elements = txt.Split('|');
                string accountNumber4 = elements[1];
                if (accountNoEnter.Equals(accountNumber4) == false)
                {
                    pos.display(17, 17, "                Account Not Found !");
                    Console.ReadKey();
                    pos.display(17, 18, "                Check another account (y/n)?");
                    Console.SetCursorPosition(70, 18);
                    string option = Console.ReadLine();
                    if (option == "y")
                    {
                        ACScreen();
                    }
                    else if (option == "n")
                    {
                        Menu();
                    }
                    else
                    {
                        pos.display(17, 19, "                Wrong Option, Please check again !");
                        Console.ReadKey();
                        ACScreen();
                    }
                }
               
            }
        }

        //create an account delete screen
        public static void DeleteScreen()
        {
            Console.Clear();
            Program pos = new Program();
            string accountNoEnter;

            pos.display(17, 10, "\t\t--------------------------------------------------------");
            pos.display(17, 11, "\t\t                    DELETE ACCOUNT");
            pos.display(17, 12, "\t\t--------------------------------------------------------");
            pos.display(17, 13, "                                 ENTER THE DETAILS");
            pos.display(17, 15, "                Account Number:");
            pos.display(17, 16, "\t\t--------------------------------------------------------");

            Console.SetCursorPosition(50, 15);
            accountNoEnter = Console.ReadLine();

            //if the account number exists, display account details, delete (y/n), return to main
            //if not exists, retry, back to main
            string[] userTxt = File.ReadAllLines(desktopAccount, Encoding.Default);
            foreach (var line in userTxt)
            {
                string[] elements = line.Split('|');
                string accountNumber = elements[1];
                if (accountNoEnter == accountNumber)
                {
                    pos.display(17, 18, "               Account Found ! Details displayed below...");
                    Console.ReadKey();
                    pos.display(17, 19, "\t\t--------------------------------------------------------");
                    pos.display(17, 20, "\t\t                  ACCOUNT DETAILS");
                    pos.display(17, 21, "\t\t--------------------------------------------------------");

                    string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string AccountFilePath = accountNoEnter + ".txt";
                    string AccountFilePos = folderPath + "\\" + AccountFilePath;
                    String[] accountTxt = File.ReadAllLines(AccountFilePos);
                    foreach (var detail in accountTxt)
                    {
                        Console.Write(detail);
                    }

                    pos.display(17, 32, "\t\t--------------------------------------------------------");
                    pos.display(17, 34, "               Delete (y/n) ?");
                    Console.SetCursorPosition(70, 34);
                    string choice = Console.ReadLine();
                    if (choice == "y")
                    {
                        //delete an account, file
                        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + accountNoEnter + ".txt";
                        File.Delete(path);
                        pos.display(17, 35, "           Account Deleted !...");
                        Console.ReadKey();
                        loginScreen();
                    }
                    else if (choice == "n")
                    {
                        Menu();
                    }
                    else
                    {
                        pos.display(17, 36, "                Wrong Option, Please check again !");
                        Console.ReadKey();
                        DeleteScreen();
                    }
                }
            }

            foreach (string txt in userTxt)
            {
                string[] elements = txt.Split('|');
                string accountNumber5 = elements[1];
                if (accountNoEnter.Equals(accountNumber5) == false)
                {
                    pos.display(17, 17, "                Account Not Found !");
                    Console.ReadKey();
                    pos.display(17, 18, "                Check another account (y/n)?");
                    Console.SetCursorPosition(70, 18);
                    string option = Console.ReadLine();
                    if (option == "y")
                    {
                        DeleteScreen();
                    }
                    else if (option == "n")
                    {
                        Menu();
                    }
                    else
                    {
                        pos.display(17, 19, "                Wrong Option, Please check again !");
                        Console.ReadKey();
                        DeleteScreen();
                    }
                }
              
            }

        }
    }
}