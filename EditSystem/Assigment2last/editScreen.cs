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
    public partial class editScreen : Form
    {
        
        
        OpenFileDialog newOpenFile = new OpenFileDialog();
        //get variable from the login screen, first need to define the variables name
        string usernameEnter = string.Empty;
        string userTypeEnter = string.Empty;
        public editScreen(string usernameInput, string userType) //use the username input from login screen
        {
            InitializeComponent();
            toolFontSize.SelectedIndex = 0;
            toolFontSize.DropDownStyle = ComboBoxStyle.DropDownList; //user cannot change the drop down item
            usernameEnter = usernameInput;
            userTypeEnter = userType;
            tooLabel.Text = "Username :" + usernameEnter + "\0" + userType; //replace the label info by username input
        }

        private void EditScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        //design the button from toolStrip
        //open file button design
        private void ToolOpen_Click(object sender, EventArgs e)
        {
            //only can open text and rtf file
            newOpenFile.Filter = "Text Files (*.txt)|*.txt| Rich Text Format (*.rtf)|*.rtf| All Files (*.*)|*.*";

            if (newOpenFile.ShowDialog() == DialogResult.OK)
            {
                //loadFile cannot open txt file, therefore using switch to know when we open txt or rtf
                string fileName = new FileInfo(newOpenFile.FileName).Extension;
                switch (fileName.ToLower())
                {
                    //type is different for txt and rtf
                    case ".txt":
                        textBoxEdit.LoadFile(newOpenFile.FileName, RichTextBoxStreamType.PlainText);
                        break;
                    case ".rtf":
                        textBoxEdit.LoadFile(newOpenFile.FileName, RichTextBoxStreamType.RichText);
                        break;
                }
            }
        }

        //the difference between save and save as is that save cannot change the file's path
        private void ToolSave_Click(object sender, EventArgs e)
        {
            if (userTypeEnter == "Edit") //identify the user type, if it is view only, user cannot save or save as
            {
                StreamWriter write = new StreamWriter(File.Create(newOpenFile.FileName));
                write.Write(textBoxEdit.Text);
                write.Dispose();
            }
            else
            {
                MessageBox.Show("You are not allowed to change the file !", "Warning", MessageBoxButtons.OK);
            }

        }

        private void ToolSaveAs_Click(object sender, EventArgs e)
        {
            if (userTypeEnter == "Edit") //only user's type is edit can do some change to the file
            {
                //save the file by using saveFileDialog method
                SaveFileDialog saveAs = new SaveFileDialog();

                saveAs.InitialDirectory = "c:\\";
                saveAs.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf| All files (*.*)|*.*";
                saveAs.RestoreDirectory = true;
                if (saveAs.ShowDialog() == DialogResult.OK && saveAs.FileName.Length > 0)
                {
                    //different format leads to the different save option              
                    string fileName = new FileInfo(saveAs.FileName).Extension;
                    switch (fileName.ToLower())
                    {
                        //type is different for txt and rtf
                        case ".txt":
                            textBoxEdit.SaveFile(saveAs.FileName, RichTextBoxStreamType.PlainText);
                            break;
                        case ".rtf":
                            textBoxEdit.SaveFile(saveAs.FileName, RichTextBoxStreamType.RichText);
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("You are not allowed to change the file !", "Warning", MessageBoxButtons.OK);
            }
        }

        //clear the richTextBox by clicking new
        private void ToolNew_Click(object sender, EventArgs e)
        {
            textBoxEdit.Clear();
        }

        //cut function
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBoxEdit.SelectionLength > 0)
                textBoxEdit.Cut();
        }

        //copy function
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBoxEdit.SelectionLength > 0)
                textBoxEdit.Copy();
        }

        //paste function
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                textBoxEdit.Paste();
            }
        }

        //bold function
        private void ToolBold_Click(object sender, EventArgs e)
        {
            //when bold, click button to cancel
            Font oldFont;
            Font newFont;
            oldFont = textBoxEdit.SelectionFont;
            if (oldFont.Bold)
            {
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            }
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);

            textBoxEdit.SelectionFont = newFont;
            textBoxEdit.Focus();
        }

        //italic function
        private void ToolItalic_Click(object sender, EventArgs e)
        {
            //also need to know the font is italic or not 
            Font oldFont;
            Font newFont;
            oldFont = textBoxEdit.SelectionFont;
            if (oldFont.Italic)
            {
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic);
            }
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);

            textBoxEdit.SelectionFont = newFont;
            textBoxEdit.Focus();
        }

        //underline function
        private void ToolUnderline_Click(object sender, EventArgs e)
        {
            //also need to know the font is underline or not 
            Font oldFont;
            Font newFont;
            oldFont = textBoxEdit.SelectionFont;
            if (oldFont.Underline)
            {
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Underline);
            }
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Underline);

            textBoxEdit.SelectionFont = newFont;
            textBoxEdit.Focus();
        }

        //design the button from toolStripMenu
        //new button design
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxEdit.Clear();
        }

        //open button design
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //the code copied from above
            newOpenFile.Filter = "Text Files (*.txt)|*.txt| Rich Text Format (*.rtf)|*.rtf| All Files (*.*)|*.*";

            if (newOpenFile.ShowDialog() == DialogResult.OK)
            {
                //loadFile cannot open txt file, therefore using switch to know when we open txt or rtf
                string fileName = new FileInfo(newOpenFile.FileName).Extension;
                switch (fileName.ToLower())
                {
                    //type is different for txt and rtf
                    case ".txt":
                        textBoxEdit.LoadFile(newOpenFile.FileName, RichTextBoxStreamType.PlainText);
                        break;
                    case ".rtf":
                        textBoxEdit.LoadFile(newOpenFile.FileName, RichTextBoxStreamType.RichText);
                        break;
                }
            }
        }

        //save button design
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //the code copied from above
            StreamWriter write = new StreamWriter(File.Create(newOpenFile.FileName));
            write.Write(textBoxEdit.Text);
            write.Dispose();
        }

        //save As button design
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //the code copied from above
            SaveFileDialog saveAs = new SaveFileDialog();

            saveAs.InitialDirectory = "c:\\";
            saveAs.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf| All files (*.*)|*.*";
            saveAs.RestoreDirectory = true;
            if (saveAs.ShowDialog() == DialogResult.OK && saveAs.FileName.Length > 0)
            {
                //different format leads to the different save option              
                string fileName = new FileInfo(saveAs.FileName).Extension;
                switch (fileName.ToLower())
                {
                    //type is different for txt and rtf
                    case ".txt":
                        textBoxEdit.SaveFile(saveAs.FileName, RichTextBoxStreamType.PlainText);
                        break;
                    case ".rtf":
                        textBoxEdit.SaveFile(saveAs.FileName, RichTextBoxStreamType.RichText);
                        break;
                }
            }
        }

        //logout button design, user should go back to the login screen by clicking
        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginScreen loginScreen = new loginScreen();
            loginScreen.Show();
            this.Hide();
        }

        //design about button
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("-Text Editor\n-Version: 1.0\n-Designer: Han Chen", "About", MessageBoxButtons.OK);
        }

        //design for font size change, define an array for all the size need
        public string[] FontSizeName = { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
        public float[] FontSize = { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        //after the editScreen showing up, font size should be a default value
        private void editScreen_Load(object sender, EventArgs e)
        {
            foreach (string name in FontSizeName)
                this.toolFontSize.Items.Add(name);
        }

        //design Font Size combobox, once the select index changed, the font size need to be changed accordingly 
        private void ToolFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBoxEdit.SelectionFont = new Font(this.textBoxEdit.SelectionFont.FontFamily, FontSize[this.toolFontSize.SelectedIndex], this.textBoxEdit.SelectionFont.Style);
        }

        //design for left toolStrip
        //design cut button
        private void leftCut_Click(object sender, EventArgs e)
        {
            if (textBoxEdit.SelectionLength > 0)
                textBoxEdit.Cut();
        }

        //design copy button
        private void leftCopy_Click(object sender, EventArgs e)
        {
            if (textBoxEdit.SelectionLength > 0)
                textBoxEdit.Copy();
        }

        //design paste button
        private void LeftPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                textBoxEdit.Paste();
            }
        }
    }
}
