using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Secure__Contain_and_Protect
{
    public partial class Form1 : Form
    {
        //V A R I A B L E    L I S T

        bool goleft; // this boolean will be used for the player to go left
        bool goright; // this boolean will be used for the player to go right
        string facing = "right"; // this will be used to determine which side the player is facing as well as to guide the bullets
        double playerHealth = 100; // this will be the player's health
        int speed = 10; // this integer is for the speed of the player
        int zombieSpeed = 3; // this integer will hold the speed which the zombies move in the game
        int score = 0; // this integer will hold the number of kills the player achieved through the game
        bool gameOver = false; // this boolean is false in the beginning and it will be used when the game is finished
        Random rnd = new Random(); // this is an instance of the random class we will use this to create a random number for this game
        List<PictureBox> zombiesList = new List<PictureBox>(); // this is to keep track of the zombies
        // E N D    O F     V A R I A B L E     L I S T

        public Form1()
        {
            InitializeComponent();
        }

        private void gameEngine(object sender, EventArgs e)
        {
           
            if (playerHealth > 1) // if player health is greater than 1
            {
                progressBar1.Value = Convert.ToInt32(playerHealth); // assign the progress bar to the player health integer
            }
            else
            {
                // if the player health is below 1

                if (facing == "left") //if the player is facing left
                {
                    agent.Image = Properties.Resources.agent_death_alternate1_left; // change animation to death facing left
                }
                
                else if (facing == "right") //if the player is facing right
                {
                    agent.Image = Properties.Resources.agent_death_alternate1_right; // change animation to death facing right
                }

                gameTimer.Stop(); // stop the timer
                gameOver = true; // change game over to true


                //Display the GameOver Menu
                DialogResult ans = MessageBox.Show("You are dead... \n\n\n Total Kills: " + score + "\n\n\n Restart?", "GAME OVER!", MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes) //restarts the game when the player selects yes
                    restartGame();
                else if (ans == DialogResult.No) //exits the game when the player selects no
                    Application.Exit();
            }

            label1.Text = "Kills: " + score; // show the total kills on the score

            // if the player health is less than 20
            if (playerHealth < 20)
            {
                progressBar1.ForeColor = System.Drawing.Color.Red; // change the progress bar colour to red. 
            }

            if (goleft && agent.Left > 0) // if the player is facing left and its location is greater than 0 (boundary for the  left side)
            {
                agent.Left -= speed; // then move the player to the LEFT
            }

            if (goright && agent.Left + agent.Width < 960) // if the player is facing right and its location is less than 960 (boundary for the  right side)
            {
                agent.Left += speed; // then move the player to the RIGHT
            }
            
            // run the first for each loop below
            // X is a control and we will search for all controls in this loop
            foreach (Control x in this.Controls)
            {

                // if the bullets hits the 2 borders of the game
                // if x is a picture box and x has the tag of bullet

                    if (x is PictureBox && x.Tag == "bullet")
                {
                    // if the bullet is less the 1 pixel to the left
                    // if the bullet is more then 930 pixels to the right

                    if (((PictureBox)x).Left < 1 || ((PictureBox)x).Left > 930)
                    {
                        this.Controls.Remove(((PictureBox)x)); // remove the bullet from the display
                        ((PictureBox)x).Dispose(); // dispose the bullet from the program
                    }
                }

                // below is the if statement which will be checking if the player hits a zombie

                if (x is PictureBox && x.Tag == "zombie")
                {

                    // below is the if statament thats checking the bounds of the player and the zombie

                    if (((PictureBox)x).Bounds.IntersectsWith(agent.Bounds))
                    {
                        playerHealth -= 1; // if the zombie hits the player then we decrease the health by 1
                    }

                    //move zombie towards the player picture box

                    if (((PictureBox)x).Left > agent.Left) // if the location of the zombie is greater than the player (the zombie is on the right side of the player)
                    {
                        ((PictureBox)x).Left -= zombieSpeed; // move zombie towards the player (zombie goes left || towards right side of the player)
                        ((PictureBox)x).Image = Properties.Resources.zombie_static_left; // change zombie image and make it face towards left
                    }

                    if (((PictureBox)x).Left < agent.Left) // if the location of the zombie is less than the player (the zombie is on the left side of the player)
                    {
                        ((PictureBox)x).Left += zombieSpeed; // move zombie towards the player (zombie goes right || towards left side of the player)
                        ((PictureBox)x).Image = Properties.Resources.zombie_static_right; // change zombie image and make it face towards right
                    }
                    
                }

                // below is the second for loop, this is nexted inside the first one
                // the bullet and zombie needs to be different than each other
                // then we can use that to determine if they hit each other

                foreach (Control j in this.Controls)
                {
                    // below is the selection thats identifying the bullet and zombie

                    if ((j is PictureBox && j.Tag == "bullet") && (x is PictureBox && x.Tag == "zombie"))
                    {
                        // below is the if statement thats checking if bullet hits the zombie
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++; // increase the kill score by 1 
                            this.Controls.Remove(j); // this will remove the bullet from the screen
                            j.Dispose(); // this will dispose the bullet all together from the program
                            this.Controls.Remove(x); // this will remove the zombie from the screen
                            x.Dispose(); // this will dispose the zombie from the program
                            makeZombies(); // this function will invoke the make zombies function to add another zombie to the game
                        }
                    }
                }
            }
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (gameOver)
            {
                return; // if game over is true then do nothing in this event
            }
                

            // if the A key is pressed then do the following
            if (e.KeyCode == Keys.A) // if A key is pressed, go left
            {
                goleft = true; // change go left to true
                facing = "left"; //change facing to left
                agent.Image = Properties.Resources.agent_running_left; // change animation to running facing left
            }

            // end of A key selection

            // if the D key is pressed then do the following
            if (e.KeyCode == Keys.D) // if D key is pressed, go right
            {
                goright = true; // change go right to true
                facing = "right"; // change facing to right
                agent.Image = Properties.Resources.agent_running_right; // change animation to running facing right
            }
            // end of D key selection

        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            if (gameOver) return; // if game is over then do nothing in this event

            // below is the key up selection for the A key
            if (e.KeyCode == Keys.A)
            {
                goleft = false; // change the go left boolean to false
                agent.Image = Properties.Resources.agent_idle_left; // change animation from running to idle facing left
            }

            // below is the key up selection for the right key
            if (e.KeyCode == Keys.D)
            {
                goright = false; // change the go right boolean to false
                agent.Image = Properties.Resources.agent_idle_right; // change animation from running to idle facing right
            }

        }

            private void shoot(string direct)
        {
            // this is the function thats makes the new bullets in this game

            bullet shoot = new bullet(); // create a new instance of the bullet class
            shoot.direction = direct; // assigns the direction of the bullet by passing the value of string "facing"
            shoot.bulletLeft = agent.Left + 100; // place the bullet to left half of the player
            shoot.bulletTop = agent.Top + 35; // place the bullet on top half of the player
            shoot.mkBullet(this); // run the function mkBullet from the bullet class. 
            if (facing == "left") // if the player is facing left
                agent.Image = Properties.Resources.agent_shooting_left; // change animation to shooting facing left
            if (facing == "right") // if the player is facing right
                agent.Image = Properties.Resources.agent_shooting_right; // change animation to shooting facing right
        }

        private void makeZombies()
        {
            // when this function is called it will make zombies in the game

            PictureBox zombie = new PictureBox(); // create a new picture box called zombie
            zombie.Tag = "zombie"; // add a tag to it called zombie
            zombie.Image = Properties.Resources.zombie_static_right; // the default picture for the zombie is facing right. this will change depending on which side the zombie will go
            zombie.Top = 349; // restricts the spawn location of the zombie. it will only spawn on the 349 pixel on the y-axis

            //the do while bellow restricts the zombie from spawning on top of the player
            do
            {
                zombie.Left = rnd.Next(0, 930); // generate a number between 0 and 930 and assign that to the new zombie.left
            } while (zombie.Bounds.IntersectsWith(agent.Bounds)); // while the zombie is within the bounds of the player, it will repeatedly assign a new zombie.left

            zombie.SizeMode = PictureBoxSizeMode.AutoSize; // set auto size for the new picture box
            zombie.BackColor = System.Drawing.Color.Transparent; // set backcolor to transparent
            zombiesList.Add(zombie); // add zombie to zombie list
            this.Controls.Add(zombie); // add the picture box to the screen
            agent.BringToFront(); // bring the player to the front
        }

        private void restartGame()
        {
            // this function is for restarting the game

            // the variable assignment below are for resetting values to default
            agent.Image = Properties.Resources.agent_idle_left; 
            goleft = false;
            goright = false;
            gameOver = false;
            playerHealth = 100;
            score = 0;

            // for each zombie on the zombie list
            foreach (PictureBox z in zombiesList)
            {
                this.Controls.Remove(z); // remove them
            }
            
            zombiesList.Clear(); // clear the zombie list

            makeZombies(); // call makezombie function
            gameTimer.Start(); // restart the timer
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // this is for mouse down event
            shoot(facing); // call shoot function and pass the value of facing
        }
    }
}
