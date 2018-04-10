/*
This forms comes up if the user clicks the create new user button. The from can create a new user.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace A312a_Recommender_System
{
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        //This function scans the file with users, and sees if any of them matches, what the new user inserted.
        //If nothing matches it will create a new user, else it will tell the user to try again with a different name.
        private void button1_Click(object sender, EventArgs e)
        {
            UserChoseGenre genreselect = new UserChoseGenre();
            int i = 1;
            genreselect.NumberOfUsers = 0;

            using (StreamReader file = new StreamReader(Path.GetFullPath("Users/Users.csv"), ASCIIEncoding.ASCII))
            {
                while (!file.EndOfStream)
                {
                    string Line = file.ReadLine();
                    string[] LineWords = Line.Split(' ');
                    if (LineWords[1] == textBox1.Text)
                    {
                        this.label3.Text = ("The chosen username has already been taken. Please try again with a different one.");
                        i = 0;
                    }
                    genreselect.NumberOfUsers++;
                }
            }

            if (i == 1)
            {
                genreselect.UserName = textBox1.Text;
                genreselect.Password = textBox2.Text;
                this.Hide();
                genreselect.Show();
            }    
        }

        //This function takes the user back to the login page.
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login mainlogin = new Login();
            mainlogin.Show();
        }

        //This function closes the program.
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
