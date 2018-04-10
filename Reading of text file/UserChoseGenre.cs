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
    public partial class UserChoseGenre : Form
    {
        public UserChoseGenre()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateUser user = new CreateUser();
            user.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int LeastTwoChosen = 0;

            //Makes an array of strings of genre's.
            string[] genre = new string[] {
        "Action", "Adventure", "Animation", "Children",
        "Comedy", "Crime", "Documentary", "Drama",
        "Fantasy", "Film-Noir", "Horror", "Musical",
        "Mystery", "Romance", "Sci-Fi", "Thriller",
        "War", "Western"};

            //Creates a textfile that contains information on which genre's the user likes.
            //Sometimes it can write the user info without any favoured genre's if it crashes.
            using (StreamWriter file = new StreamWriter(Path.GetFullPath("Users/UsersGenreChoice.csv"), true))
            {
                //file.Write(NumberOfUsers);
                //int j = 0;

                foreach (Control c in this.Controls)
                {
                    if (c is CheckBox)
                    {
                        if (((CheckBox)c).Checked == true)
                        {
                            //file.Write(" " + genre[j]);       //Its hard making this work. If it can be made to work, it would be better, but for now a simpler aproach must be made.
                            LeastTwoChosen++;
                            //Console.WriteLine(LeastTwoChosen);
                        }
                    }
                    //j++;
                    //Console.WriteLine(j);
                }
                //file.WriteLine(" ");    Cannot be used without the above line which is commented out.

                //This is a very poor solution, its ineffective and looks ugly. But until the above is made to work this must be used.

                if (LeastTwoChosen > 1)
                {
                    NumberOfUsers = NumberOfUsers + 1;
                    file.WriteLine("");
                    file.Write(NumberOfUsers);
                    if (checkBox1.Checked)
                    {
                        file.Write(" " + genre[0]);
                    }
                    if (checkBox2.Checked)
                    {
                        file.Write(" " + genre[1]);
                    }
                    if (checkBox3.Checked)
                    {
                        file.Write(" " + genre[2]);
                    }
                    if (checkBox4.Checked)
                    {
                        file.Write(" " + genre[3]);
                    }
                    if (checkBox5.Checked)
                    {
                        file.Write(" " + genre[4]);
                    }
                    if (checkBox6.Checked)
                    {
                        file.Write(" " + genre[5]);
                    }
                    if (checkBox7.Checked)
                    {
                        file.Write(" " + genre[6]);
                    }
                    if (checkBox8.Checked)
                    {
                        file.Write(" " + genre[7]);
                    }
                    if (checkBox9.Checked)
                    {
                        file.Write(" " + genre[8]);
                    }
                    if (checkBox10.Checked)
                    {
                        file.Write(" " + genre[9]);
                    }
                    if (checkBox11.Checked)
                    {
                        file.Write(" " + genre[10]);
                    }
                    if (checkBox12.Checked)
                    {
                        file.Write(" " + genre[11]);
                    }
                    if (checkBox13.Checked)
                    {
                        file.Write(" " + genre[12]);
                    }
                    if (checkBox14.Checked)
                    {
                        file.Write(" " + genre[13]);
                    }
                    if (checkBox15.Checked)
                    {
                        file.Write(" " + genre[14]);
                    }
                    if (checkBox16.Checked)
                    {
                        file.Write(" " + genre[15]);
                    }
                    if (checkBox17.Checked)
                    {
                        file.Write(" " + genre[16]);
                    }
                    if (checkBox18.Checked)
                    {
                        file.Write(" " + genre[17]);
                    }
                }
                else
                {
                    this.label1.Text = "You did not chose two genre's that you liked. Please try again.";
                }
            }
            if (LeastTwoChosen > 1)
            {
                //Creates the users profile.
                using (StreamWriter file = new StreamWriter(Path.GetFullPath("Users/Users.csv"), true))
                {
                    file.WriteLine(NumberOfUsers + " " + UserName + " " + Password);
                }
                this.Hide();
                Login mainlogin = new Login();
                mainlogin.Show();
            }
        }

        //This is for keeping the users data in the memory while they are logged in.
        public string UserName { get; set; }
        public string Password { get; set; }
        public int NumberOfUsers { get; set; }
    }
}
