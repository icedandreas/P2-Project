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
    public partial class GUI : Form
    {
        int HighestRatedCounter = 0;
        int actionCounter = 0;
        public GUI()
        {
            InitializeComponent();
            LoadHighestRatedList();
            HighestRatedMovieGenre();
        }

        private int IncrementHighestRatedCounter()
        {
            HighestRatedCounter++;
            return HighestRatedCounter;
        }

        private int DecrementHighestRatedCounter()
        {
            HighestRatedCounter--;
            return HighestRatedCounter;
        }

        private int IncrementAction()
        {
            actionCounter++;
            return actionCounter;
        }

        private int DecrementAction()
        {
            actionCounter--;
            return actionCounter;
        }

        public void LoadHighestRatedList()
        {
            HighestRated highestRated = new HighestRated();
            highestRated.HighestRatedMethod();

            string picturePath = Path.GetFullPath("Pictures/" + "Pictures/" + highestRated.Top20MovieID[HighestRatedCounter] + ".jpg");
            pictureBox1.Image = Image.FromFile(picturePath);
            label1.Text = HighestRatedCounter + 1 + ". " + highestRated.Top20MovieName[HighestRatedCounter];
            label6.Text = "Rating: " + highestRated.Top20MovieRating[HighestRatedCounter];

            picturePath = Path.GetFullPath("Pictures/" + "Pictures/" + highestRated.Top20MovieID[HighestRatedCounter + 1] + ".jpg");
            pictureBox2.Image = Image.FromFile(picturePath);
            label2.Text = HighestRatedCounter + 2 + ". " + highestRated.Top20MovieName[HighestRatedCounter + 1];
            label7.Text = "Rating: " + highestRated.Top20MovieRating[HighestRatedCounter + 1];

            picturePath = Path.GetFullPath("Pictures/" + "Pictures/" + highestRated.Top20MovieID[HighestRatedCounter + 2] + ".jpg");
            pictureBox3.Image = Image.FromFile(picturePath);
            label3.Text = HighestRatedCounter + 3 + ". " + highestRated.Top20MovieName[HighestRatedCounter + 2];
            label8.Text = "Rating: " + highestRated.Top20MovieRating[HighestRatedCounter + 2];

            picturePath = Path.GetFullPath("Pictures/" + "Pictures/" + highestRated.Top20MovieID[HighestRatedCounter + 3] + ".jpg");
            pictureBox4.Image = Image.FromFile(picturePath);
            label4.Text = HighestRatedCounter + 4 + ". " + highestRated.Top20MovieName[HighestRatedCounter + 3];
            label9.Text = "Rating: " + highestRated.Top20MovieRating[HighestRatedCounter + 3];

            picturePath = Path.GetFullPath("Pictures/" + "Pictures/" + highestRated.Top20MovieID[HighestRatedCounter + 4] + ".jpg");
            pictureBox5.Image = Image.FromFile(picturePath);
            label5.Text = HighestRatedCounter + 5 + ". " + highestRated.Top20MovieName[HighestRatedCounter + 4];
            label10.Text = "Rating: " + highestRated.Top20MovieRating[HighestRatedCounter + 4];
        }

        private void LeftClickPic_Click(object sender, EventArgs e)
        {
            if (HighestRatedCounter == 0)
            {
                //when HighestRatedCounter = 0, this button has no function and should not react to a click.
            }
            else
            {
                DecrementHighestRatedCounter();
                LoadHighestRatedList();
            }
        }

        private void RightClickPic_Click(object sender, EventArgs e)
        {
            if (HighestRatedCounter == 15)
            {
                //when HighestRatedCounter = 15, this button has no function and should not react to a click.
            }
            else
            {
                IncrementHighestRatedCounter();
                LoadHighestRatedList();
            }
        }

        public void HighestRatedMovieGenre()
        {
            HighesteRatedGenreFunction highestRatedGenreFunction = new HighesteRatedGenreFunction();
            highestRatedGenreFunction.HighestRatedMethod();

            label18.Text = "ACTION MOVIES";
            label17.Text = "TOP RATED ACTION MOVIES";

            string picturePath = Path.GetFullPath("Pictures/" + "Pictures/" + highestRatedGenreFunction.Top20MovieID[actionCounter] + ".jpg");
            pictureBox9.Image = Image.FromFile(picturePath);
            label29.Text = actionCounter + 1 + ". " + highestRatedGenreFunction.Top20MovieName[actionCounter];
            label24.Text = "Rating: " + highestRatedGenreFunction.Top20MovieRating[actionCounter];

            picturePath = Path.GetFullPath("Pictures/" + "Pictures/" + highestRatedGenreFunction.Top20MovieID[actionCounter + 1] + ".jpg");
            pictureBox10.Image = Image.FromFile(picturePath);
            label30.Text = actionCounter + 2 + ". " + highestRatedGenreFunction.Top20MovieName[actionCounter + 1];
            label25.Text = "Rating: " + highestRatedGenreFunction.Top20MovieRating[actionCounter + 1];

            picturePath = Path.GetFullPath("Pictures/" + "Pictures/" + highestRatedGenreFunction.Top20MovieID[actionCounter + 2] + ".jpg");
            pictureBox11.Image = Image.FromFile(picturePath);
            label31.Text = actionCounter + 3 + ". " + highestRatedGenreFunction.Top20MovieName[actionCounter + 2];
            label26.Text = "Rating: " + highestRatedGenreFunction.Top20MovieRating[actionCounter + 2];

            picturePath = Path.GetFullPath("Pictures/" + "Pictures/" + highestRatedGenreFunction.Top20MovieID[actionCounter + 3] + ".jpg");
            pictureBox12.Image = Image.FromFile(picturePath);
            label32.Text = actionCounter + 4 + ". " + highestRatedGenreFunction.Top20MovieName[actionCounter + 3];
            label27.Text = "Rating: " + highestRatedGenreFunction.Top20MovieRating[actionCounter + 3];

            picturePath = Path.GetFullPath("Pictures/" + "Pictures/" + highestRatedGenreFunction.Top20MovieID[actionCounter + 4] + ".jpg");
            pictureBox13.Image = Image.FromFile(picturePath);
            label33.Text = actionCounter + 5 + ". " + highestRatedGenreFunction.Top20MovieName[actionCounter + 4];
            label28.Text = "Rating: " + highestRatedGenreFunction.Top20MovieRating[actionCounter + 4];
        }

        private void ActionLeftClickBtn_Click(object sender, EventArgs e)
        {
            if (actionCounter == 0)
            {
                //when actionCounter = 0, this button has no function and should not react to a click.
            }
            else
            {
                DecrementAction();
                HighestRatedMovieGenre();
            }
        }

        private void ActionRightClickBtn_Click(object sender, EventArgs e)
        {
            if (actionCounter == 15)
            {
                //when actionCounter = 15, this button has no function and should not react to a click.
            }
            else
            {
                IncrementAction();
                HighestRatedMovieGenre();
            }
        }

        public int UserId { get; set; }

        //Create new user.
        private void button2_Click(object sender, EventArgs e)
        {
            CreateUser CreateNewUser = new CreateUser();
            CreateNewUser.Show();
        }

        //Login.
        private void button1_Click(object sender, EventArgs e)
        {
            Login LoginUser = new Login();
            LoginUser.Show();
        }
    }
}
