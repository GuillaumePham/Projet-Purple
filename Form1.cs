using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace Plateformeur
{
    public partial class Form1 : Form
    {
        bool goLeft, goRight, jump ;
        bool canJump;
        int jumpSpeed { get; set; }
        int score { get; set; } = 0;
        int enemySpeed = 5;
        int enemySpeed2 = 5;
        List<PictureBox> platforms = new List<PictureBox>();
        List<PictureBox> coins = new List<PictureBox>();
        List<PictureBox> ennemie = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();

            foreach (Control control in this.Controls)
            {
                if (control is PictureBox pictureControl)
                {
                    switch ((string)pictureControl.Tag)
                    {
                        case "platform":
                            platforms.Add(pictureControl);
                            break;
                        case "coin":
                            coins.Add(pictureControl);
                            break;
                        case "player":
                            player = pictureControl;
                            break;
                        case "cristian":
                            ennemie.Add(pictureControl);
                            break ;
                    }
                }
                else if (control is Label labelControl)
                {
                    if ((string)labelControl.Tag == "score")
                    {
                        scoreLabel = labelControl;
                    }
                }
            }
        }

        private void PlayerMove()
        {
            if (canJump && jump)
            {
                jumpSpeed = -15;
            }
            else if (jumpSpeed < 10) 
            {
                jumpSpeed++;
            }

            Rectangle newBounds = player.Bounds;

            int horizontalDirection = (goLeft ? -1 : 0) + (goRight ? 1 : 0);

            newBounds.X += horizontalDirection * 5;
            newBounds.Y += jumpSpeed;

            canJump = false;
            foreach ( PictureBox platform in platforms)
            {
                if ( jumpSpeed > 0 && player.Bottom < platform.Bottom && newBounds.IntersectsWith(platform.Bounds))
                {
                    newBounds.Y = platform.Top - player.Size.Height;
                    jumpSpeed = jumpSpeed > 0 ? 0 : jumpSpeed;
                    canJump = true;
                    break;
                }
            }

            player.Bounds = newBounds;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void stateLabel_Click(object sender, EventArgs e)
        {

        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {

            PlayerMove();

            if (player.Bottom > Size.Height || player.Left > Size.Width || player.Left < 0 || player.Top < 0)
            {
      
                RestartGame(); 
            }
            foreach (PictureBox ennemi in ennemie.ToList())
            {
                if (player.Bounds.IntersectsWith(ennemi.Bounds))
                {
                    RestartGame();
                    
                    
                    break;



                }
            }
           
            Bouh.Left -= enemySpeed;
            if(Bouh.Left < Platform.Left || Bouh.Left + Bouh.Width > Platform.Left + Platform.Width)
            {
               enemySpeed = -enemySpeed ;
            }
            Crist.Left -= enemySpeed2;
            if (Crist.Left < platform_final.Left || Crist.Left + Crist.Width > platform_final.Left + platform_final.Width)
            {
                enemySpeed2 = -enemySpeed2;
            }



            foreach (var coin in coins)
            {
                if (coin.Visible && player.Bounds.IntersectsWith(coin.Bounds))
                { 
                    score++;
                    coin.Visible = false;
                    scoreLabel.Text = score.ToString();
                }
            }

            if (player.Bounds.IntersectsWith(finish.Bounds))
            {
                if (score < coins.Count)
                {
                    RestartGame();
                    
                    //MessageBox.Show($"Vous avez gagn?!! Votre score est de {score}");
                    
                    //Temps.Start();

                }
                 else
                {
                   RestartGame();
                    /*Temps.Stop();
                    MessageBox.Show($"Vous avez gagn?!! Votre score est de {score}");
                    Temps.Start();*/




                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Q || e.KeyCode == Keys.A)
            {
                goLeft = true;
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = true;
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Space || e.KeyCode == Keys.Z || e.KeyCode == Keys.W)
            {
                jump = true;
            }
            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void Platform_Click(object sender, EventArgs e)
        {

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Q || e.KeyCode == Keys.A)
            {
                goLeft = false;
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = false;
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Space || e.KeyCode == Keys.Z || e.KeyCode == Keys.W)
            {
                jump = false;
            }
           

        }

        private void RestartGame()
        {
            Temps.Start();
            stateLabel.ForeColor = Color.Black;
            stateLabel.Text = "R?cuperer toutes les pi?ces pour vous enfuir";
            scoreLabel.Text = "0";
            score = 0;
            
            player.Left = 0;
            player.Top = 680;

            foreach (PictureBox coin in coins)
            {
                coin.Visible = true;
                
            }
            
        }
    }

}