namespace Plateformeur
{
    public partial class Form1 : Form
    {
        bool goLeft, goRight, jump, endGame;
        int jumpSpeed;
        int score=0;    
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }  
            
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

        }
        private void RestartGame()
        {
            goLeft = false;
            goRight = false;
            jump = false;   
            score= 0;
            endGame = false;
            foreach (Control coins in this.Controls)
            {
                if (coins is  PictureBox && coins.Visible == false)
                {
                    coins.Visible = true;
                }
                
            }
        }
    }
}