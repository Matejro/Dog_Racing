using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;


namespace DzieńNaWyścigach
{
    public partial class Form1 : Form
    {
        Random Randomizer = new Random();
        Greyhound[] GreyhoundArray = new Greyhound[4];
        Guy[] Guys = new Guy[3];
        int BettorNumber=0;
        int WinningDog = 0;
        public Form1()
        {
            InitializeComponent();
            InitializeObjects(); 
            ZeroBet();

        }

        public void InitializeObjects()
        {

            Guys[0] = new Guy() { Name = "Janek", Cash = 50, MyRadioButton = joeradioButton, MyLabel = joeBetLabel };
            Guys[1] = new Guy() { Name = "Bartek", Cash = 75, MyRadioButton = bobradioButton, MyLabel = bobBetLabel };
            Guys[2] = new Guy() { Name = "Arek", Cash = 100, MyRadioButton = alradioButton, MyLabel = alBetLabel };
            GreyhoundArray[0] = new Greyhound() { MyPictureBox = pictureBox1, StartingPosition = pictureBox1.Left, RacetrackLength = racetrackpictureBox.Width - pictureBox1.Width, MyRandom = Randomizer };
            GreyhoundArray[1] = new Greyhound() { MyPictureBox = pictureBox2, StartingPosition = pictureBox2.Left, RacetrackLength = racetrackpictureBox.Width - pictureBox2.Width, MyRandom = Randomizer };
            GreyhoundArray[2] = new Greyhound() { MyPictureBox = pictureBox3, StartingPosition = pictureBox3.Left, RacetrackLength = racetrackpictureBox.Width - pictureBox3.Width, MyRandom = Randomizer };
            GreyhoundArray[3] = new Greyhound() { MyPictureBox = pictureBox4, StartingPosition = pictureBox4.Left, RacetrackLength = racetrackpictureBox.Width - pictureBox4.Width, MyRandom = Randomizer };
        }

        public void ZeroBet()
        {      
            for (int i = 0; i < 3; i++)
            {
                Guys[i].ClearBet();
                Guys[i].UpdateLabels();
            }
        }
        

        
        
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (GreyhoundArray[i].Run())
                {
                    timer1.Stop();
                    WinningDog = i + 1;
                    MessageBox.Show("Zwycieżył pies numer " +WinningDog+"!", "WYNIK WYŚCIGU", MessageBoxButtons.OK);
                    for (int j = 0; j < 3; j++)
                    {
                        Guys[j].Collect(WinningDog);
                    }
                    ZeroBet();

                    for (int k = 0; k < 4; k++)
                    {
                        GreyhoundArray[k].TakeStartingPosition();
                    }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void stawia_Click(object sender, EventArgs e)
        {
            if(Guys[BettorNumber].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value) == true)
            {
                Guys[BettorNumber].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                Guys[BettorNumber].UpdateLabels();
            }
            else
            {
                MessageBox.Show("Niewystarczająca ilość środków na koncie", "Zmniejsz wartośc zakładu", MessageBoxButtons.OK);
            }
        }

        private void joeradioButton_CheckedChanged(object sender, EventArgs e)
        {
            BettorNumber = 0;
        }

        private void bobradioButton_CheckedChanged(object sender, EventArgs e)
        {
            BettorNumber = 1;         
        }

        private void alradioButton_CheckedChanged(object sender, EventArgs e)
        {
            BettorNumber = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
