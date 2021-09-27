using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLib.BLACKJACKiD;

namespace ClassLib
{
    public class BlackjackHand : Hand
    {
        public int currAce;
       
        public int Score { get; set; }
        public bool IsDealer { get; set; }

        private bool isDealer = false;

       public BlackjackHand(bool IsDealer = false)
       {
            isDealer = IsDealer;
            Console.WriteLine("Dealer Hand");
       }
        public override void addCard(iCard card)
        {
            base.addCard(card);

            if (card.getCardFace == BLACKJACKiD.CardFace.Jack || card.getCardFace == BLACKJACKiD.CardFace.King || card.getCardFace == BLACKJACKiD.CardFace.Queen)
            {
                Score += 10;
            }
            else if (card.getCardFace != BLACKJACKiD.CardFace.Ace) 
            {
               
                Score += (int)card.getCardFace; 
            }                    
            else if (Score <= 21)
            {                     
                        Score += 11;
                        
            }
            if(Score > 21)
            {
                for (int i = currAce; i < hand.Count; i++)
                {
                     if (hand[i].getCardFace == BLACKJACKiD.CardFace.Ace)
                    {
                        currAce = i + 1;

                        Score -= 10;
                       
                        break;
                    }

                }
            }

        }
       
        public override void draw(int x, int y)
        {
            if (IsDealer)
            {
                y = 16;
                emptyCard(x, y);

                for (int i = 1; i < hand.Count; i++)
                {
                    x += 16;
                    Console.SetCursorPosition(x, y);
                    cardBase(i, x, y);
                    
                }
            }
            else
            {
                base.draw(x, y);

            }

        }
        void cardBase(int i, int x, int y)
        {
            string bigshort = getFace(i);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;


            y += 1;
            Console.SetCursorPosition(x, y);
            Console.Write("+---------------+");
            y += 1;
            Console.SetCursorPosition(x, y);
            Console.Write("|       " + getSymbol(i) + "       |");
            y += 1;
            Console.SetCursorPosition(x, y);
            Console.Write("|               |");
            y += 1;
            Console.SetCursorPosition(x, y);
            Console.Write("|       " + bigshort.PadRight(8) + "|");
            y += 1;
            Console.SetCursorPosition(x, y);
            Console.Write("|               |");
            y += 1;
            Console.SetCursorPosition(x, y);
            Console.Write("|               |");
            y += 1;
            Console.SetCursorPosition(x, y);
            Console.Write("+---------------+");
            Console.ResetColor();

        }
        void emptyCard(int x, int y)
        {

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;

            y += 1;
            Console.SetCursorPosition(x, y);
            Console.Write("+---------------+");
            y += 1;
            Console.SetCursorPosition(x, y);
            Console.Write("|               |");
            y += 1;
            Console.SetCursorPosition(x, y);
            Console.Write("|               |");
            y += 1;
            Console.SetCursorPosition(x, y);
            Console.Write("|               |");
            y += 1;
            Console.SetCursorPosition(x, y);
            Console.Write("|               |");
            y += 1;
            Console.SetCursorPosition(x, y);
            Console.Write("|               |");
            y += 1;
            Console.SetCursorPosition(x, y);
            Console.Write("+---------------+");
            Console.ResetColor();

        }

        string getSymbol(int i)
        {
            if ((int)hand[i].getCardSuits == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "♥";
            }
            else if ((int)hand[i].getCardSuits == 1)
            {
                return "♣";
            }
            else if ((int)hand[i].getCardSuits == 2)
            {
                return "♠";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "♦";
            }
        }
        string getFace(int i)
        {
            if ((int)hand[i].getCardSuits == 11)
            {
                return "jack";
            }
            else if ((int)hand[i].getCardSuits == 12)
            {
                return "Queen";
            }
            else if ((int)hand[i].getCardSuits == 13)
            {
                return "King";
            }
            else return hand[i].getCardFace.ToString();
        }
    }
        
        
}
