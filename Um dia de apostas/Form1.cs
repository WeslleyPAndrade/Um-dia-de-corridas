using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Um_dia_de_apostas
{
    public partial class Form1 : Form
    {
        Guy[] Guys = new Guy[3];
        Grayhound[] Dogs = new Grayhound[4];

        
        public Form1()
        {
            InitializeComponent();
            Guys[0] = new Guy("Joe", 50, radBettor1, lblBet1);
            Guys[1] = new Guy("Bob", 75, radBettor2, lblBet2);
            Guys[2] = new Guy("Al", 45, radBettor3, lblBet3);

            Dogs[0] = new Grayhound(picDog1);
            Dogs[1] = new Grayhound(picDog2);
            Dogs[2] = new Grayhound(picDog3);
            Dogs[3] = new Grayhound(picDog4);

            lblBettor.Text = radBettor1.Text;

        }

        private void radBettor1_CheckedChanged(object sender, EventArgs e)
        {          
            lblBettor.Text = Guys[0].Name;
        }


        private void radBettor2_CheckedChanged(object sender, EventArgs e)
        {          
            lblBettor.Text = Guys[1].Name;
        }

        private void radBettor3_CheckedChanged(object sender, EventArgs e)
        {   
            lblBettor.Text = Guys[2].Name;
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            if (radBettor1.Checked)
            {
                Guys[0].PlaceBet(Convert.ToInt16(nudBet.Value), Convert.ToInt16(nudDog.Value));
                Guys[0].UpdateLabels();
            }
            if (radBettor2.Checked)
            {
                Guys[1].PlaceBet(Convert.ToInt16(nudBet.Value), Convert.ToInt16(nudDog.Value));
                Guys[1].UpdateLabels();
            }
            if (radBettor3.Checked)
            {
                Guys[2].PlaceBet(Convert.ToInt16(nudBet.Value), Convert.ToInt16(nudDog.Value));
                Guys[2].UpdateLabels();
            }
        }

        private void btnRace_Click(object sender, EventArgs e)
        {
            bool win=false;
            int winner=0;

            while(winner==0)
            {
                for(int i=0;i<4;i++)
                {
                    win = Dogs[i].Run();
                    if (win)
                    {
                        winner = ++i;
                    }
                }
            }

            MessageBox.Show("Temos um vencedor o cachorro #" + winner);

            for(int i=0;i<3;i++)
            {
                Guys[i].Collect(winner);
                Guys[i].ClearBet();
                Guys[i].UpdateLabels();
            }
            for(int i = 0;i<4;i++)
            {
                Dogs[i].TakeStartingPosition();
            }
        }
    }
}
