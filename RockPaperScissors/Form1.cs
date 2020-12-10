using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

/// <summary>
/// A rock, paper, scissors game that utilizes basic methods
/// for repetitive tasks.
/// </summary>

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        int playerChoice, cpuChoice;
        int wins = 0;
        int losses = 0;
        int ties = 0;
        int choicePause = 1000;
        int outcomePause = 3000;

        Random randGen = new Random();

        SoundPlayer jabPlayer = new SoundPlayer(Properties.Resources.jabSound);
        SoundPlayer gongPlayer = new SoundPlayer(Properties.Resources.gong);

        Image rockImage = Properties.Resources.rock168x280;
        Image paperImage = Properties.Resources.paper168x280;
        Image scissorImage = Properties.Resources.scissors168x280;
        Image winImage = Properties.Resources.winTrans;
        Image loseImage = Properties.Resources.loseTrans;
        Image tieImage = Properties.Resources.tieTrans;

        Point playerLocation = new Point(168, 70);
        Point cpuLocation = new Point(360, 70);
        Point outcomeLocation = new Point(225, 5);

        Graphics g;

        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void rockButton_Click(object sender, EventArgs e)
        {
            playerChoice = 1;
            g.DrawImage(rockImage, playerLocation);
            ComputerTurn();
            DetermineWinner();
        }

        private void paperButton_Click(object sender, EventArgs e)
        {
            playerChoice = 2;
            g.DrawImage(paperImage, playerLocation);
            ComputerTurn();
            DetermineWinner();
        }

        private void scissorsButton_Click(object sender, EventArgs e)
        {
            playerChoice = 3;
            g.DrawImage(scissorImage, playerLocation);
            ComputerTurn();
            DetermineWinner();
        }

        public void ComputerTurn()
        {
            jabPlayer.Play();
            Thread.Sleep(choicePause);
            cpuChoice = randGen.Next(1, 4);
            if (cpuChoice == 1)
            {
                g.DrawImage(rockImage, cpuLocation);
            }
            else if (cpuChoice == 2)
            {
                g.DrawImage(paperImage, cpuLocation);
            }
            else if (cpuChoice == 3)
            {
                g.DrawImage(scissorImage, cpuLocation);
            }
        }

        public void DetermineWinner()
        {
            if (playerChoice == cpuChoice)
            {
                ties++;
                g.DrawImage(tieImage, outcomeLocation);
            }
            else if (cpuChoice - playerChoice == 1 || playerChoice - cpuChoice == 2)
            {
                losses++;
                g.DrawImage(loseImage, outcomeLocation);
            }
            else if (playerChoice - cpuChoice == 1 || cpuChoice - playerChoice == 2)
            {
                wins++;
                g.DrawImage(winImage, outcomeLocation);
            }
            winsLabel.Text = $"Wins: {wins}";
            lossesLabel.Text = $"Losses: {losses}";
            tiesLabel.Text = $"Ties: {ties}";
            gongPlayer.Play();
            Thread.Sleep(outcomePause);
            g.Clear(Color.Transparent);
            this.BackgroundImage = Properties.Resources.dojo700x390;
        }
    }
}