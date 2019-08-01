using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Um_dia_de_apostas
{
    public class Guy
    {
        public string Name; //Nome do cara
        public Bet MyBet; // Uma instância de Bet() que tem sua aposta
        public int Cash; // Quanto dinheiro ele tem

        //Os dois campos são os controles no formulário da GUI dos caras
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public Guy(string name, int cash, RadioButton radioButton, Label label)
        {
            Name = name;
            Cash = cash;
            MyRadioButton = radioButton;
            MyLabel = label;
            MyBet = new Bet(this);
            UpdateLabels();
        }

        public void UpdateLabels()
        {
            //Defina minha etiqueta para a descrição da minha aposta e a etiqueta em
            //meu botão de rádio para mostrar meu dinheiro ("João tem 43 reais")
            MyLabel.Text = MyBet.GetDescription();
            MyRadioButton.Text = Name + " tem " + Cash + " reais.";
        }

        public void ClearBet()
        {
            //Redefina minha aposta para que seja zero
            MyBet = new Bet(this);
        }

        public bool PlaceBet(int Amount, int Dog)
        {
            //Faça uma nova aposta e armazena-a no meu campo de aposta
            //Retorne true se o cara teve dinheiro suficiente para apostar
            if (Amount <= Cash)
            {
               MyBet = new Bet(Amount, Dog, this);
               return true;
            }
            else
            {
                return false;
            }
        }

        public void Collect(int Winner)
        {
            //Cobre minha aposta se ganhei
            Cash += MyBet.PayOut(Winner);
           
        }
    }
}
