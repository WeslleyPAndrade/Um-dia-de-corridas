using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Um_dia_de_apostas
{
    public class Bet
    {
        public int Amount; //Quantidade de dinheiro apostada
        public int Dog; // Nímero do cão em que apostamos
        public Guy Bettor; // O cara que fez a aposta

        public Bet(int Amount, int Dog, Guy Bettor)
        {
            this.Amount = Amount;
            this.Dog = Dog;
            this.Bettor = Bettor;
        }
        public Bet(Guy Bettor)
        {
            this.Amount = 0;
            this.Bettor = Bettor;
        }

        public string GetDescription()
        {
            //retorne uma string que diga quem fez a aposta, quanto
            //dinheiro foi apostado e em qual cão ("João apostou 8
            // no cão #4"). Se a quantidade for zero, a aposta não foi feita
            // ("João não apostou")
            if(Amount != 0)
            {
                return Bettor.Name + " apostou " + Amount + " no cão #" + Dog;
            }
            else
            {
                return Bettor.Name + " não apostou";
            }
        }

        public int PayOut(int Winner)
        {
            //O parâmetro é o vencedor da corrida. Se o cão venceu,
            // retorne a quantia apostada. De outra forma, retorne um valor
            //negativo do valor apostado.
            if (Dog == Winner)
            {
                return Amount;
            }else
            {
                return -Amount;
            }
        }

    }
}
