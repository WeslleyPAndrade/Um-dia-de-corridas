using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Um_dia_de_apostas
{
    public class Grayhound
    {
        public int StartingPosition; // Onde PictureBox inicia
        public int RacetrackLength; //O tamanho da pista de corrida
        public PictureBox MyPictureBox = null; // Meu objeto PictureBox
        public int Location = 0; // Minha posição na pista
        public static Random Randomizer = new Random(); // Uma instância de Random

        public Grayhound(PictureBox imagem)
        {
            this.MyPictureBox = imagem;
            this.StartingPosition = imagem.Location.X;
            this.RacetrackLength = 728;

        }

        public bool Run()
        {
            //Avance 1, 2, 3 ou 4 espaços aleatoriamente
            int distance = Randomizer.Next(1,5);
            // Atualize a posição de PictureBox no formulário
            Point p = MyPictureBox.Location;
            p.X += distance;
            MyPictureBox.Location = p;
            // Retorna true se eu ganhei a corrida
            if(MyPictureBox.Location.X >= RacetrackLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TakeStartingPosition()
        {
            //Redefina minha posição para linha de partida
            Point p = new Point()
            {
                Y = MyPictureBox.Location.Y,
                X = StartingPosition
            };
            MyPictureBox.Location = p;
        }
    }
}
