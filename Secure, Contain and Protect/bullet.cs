using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace Secure__Contain_and_Protect
{

    class bullet
    {

        // V A R I A B L E     L I S T

        public string direction; // creating a public string called direction
        public int speed = 20; // creating a integer called speed and assigning a value of 20. this is for the travel speed of the bullet
        PictureBox Bullet = new PictureBox(); // create a picture box 
        Timer tm = new Timer(); // create a new timer called tm. 

        public int bulletLeft; // create a public integer for the location of the bullet in the x-axis
        public int bulletTop; // create a public integer for the location of the bullet in the y-axis

        // E N D    O F      V A R I A B L E      L I S T

        public void mkBullet(Form form)
        {
            // this function will add the bullet to the game play
            // it is required to be called from the main class

            Bullet.BackColor = System.Drawing.Color.White; // set the colour white for the bullet
            Bullet.Size = new Size(20, 5); // set the size of the bullet
            Bullet.Tag = "bullet"; // set the tag to bullet
            Bullet.Left = bulletLeft; // set the location of the bullet on the x-axis
            Bullet.Top = bulletTop; // set the location of the bullet on the y-axis
            Bullet.BringToFront(); // bring the bullet to front of other objects
            form.Controls.Add(Bullet); // add the bullet to the screen

            tm.Interval = speed; // set the timer interval to speed
            tm.Tick += new EventHandler(tm_Tick); // assign the timer with an event
            tm.Start(); // start the timer
        }
        public void tm_Tick(object sender, EventArgs e)
        {
            // if direction equals to left
            if (direction == "left")
            {
                Bullet.Left -= speed; // move bullet towards the left of the screen
            }
            // if direction equals right
            if (direction == "right")
            {
                Bullet.Left += speed; // move bullet towards the right of the screen
            }

            // if the bullet is less the 1 pixel to the left OR
            // if the bullet is more than 930 pixels to the right
            // IF ANY ONE OF THE CONDITIONS ARE MET THEN THE FOLLOWING CODE WILL BE EXECUTED

            if (Bullet.Left < 1 || Bullet.Left > 930)
            {
                tm.Stop(); // stop the timer
                tm.Dispose(); // dispose the timer event and component from the program
                Bullet.Dispose(); // dispose the bullet
                tm = null; // nullify the timer object
                Bullet = null; // nullify the bullet object
            }
        }
    }
}
