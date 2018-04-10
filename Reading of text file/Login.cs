/*
This form for for creating the login system.
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //This is for logging the user into the system.
        private void button1_Click(object sender, EventArgs e)
        {
            string line;
            string userpath = Path.GetFullPath("Users/") + "Users.csv";
            using (StreamReader file =
                        new StreamReader(userpath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] LineWords = line.Split(' ');

                    //The system takes one line at a time. If it hits a line where the username and password is correct it logs the user in
                    //And sends the user id to GUI.
                    if (LineWords[1] == textBox1.Text && LineWords[2] == textBox2.Text)
                    {                                              
                        int OutputUserId;
                        Int32.TryParse(LineWords[0], out OutputUserId);
                        GUI.ActiveForm.Disposed += new EventHandler(closeForm2);
                        GUI MakeGUI = new GUI();
                        MakeGUI.UserId = OutputUserId;                        
                        MakeGUI.Show();     //This is the form that opens after the user login succesfully.
                        this.Close();
                    }
                }
            }
            this.label3.Text = ("Incorrect username / password. Please try again.");
        }

        private void closeForm2(object sender, EventArgs e)
        {
            GUI.ActiveForm.Dispose();
        }

        //This is for closing the program.
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //This is for creating a new user.
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateUser newuser = new CreateUser();
            newuser.Show();  //Form3 is the form for making a new user.  
        }
    }
}
