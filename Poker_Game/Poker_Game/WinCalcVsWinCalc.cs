using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game
{
    class WinCalcVsWinCalc
    {
        FastWinCalc WinCalc1 = new FastWinCalc();
        WinConditions winCalc2 = new WinConditions();
        List<Card> Player1Cards, Player2Cards, CardsInPlay, Street;
        Card NewCard;


        private void NewCards()
        {
            Player1Cards.Clear();
            Player2Cards.Clear();
            Street.Clear();
            CardsInPlay.Clear();

            
            for (int x = 0; x < 2; x++)
            {
                NewCard = new Card(CardsInPlay);
                CardsInPlay.Add(NewCard);
                Player1Cards.Add(NewCard);
            }

            for (int x = 0; x < 2; x++)
            {
                NewCard = new Card(CardsInPlay);
                CardsInPlay.Add(NewCard);
                Player2Cards.Add(NewCard);
            }
            

            for (int x = 0; x < 5; x++)
            {
                NewCard = new Card(CardsInPlay);
                CardsInPlay.Add(NewCard);
                Street.Add(NewCard);
            }
        }

    }
}
