using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLib.BLACKJACKiD;

namespace ClassLib
{
    public class Hand
    {
        protected List<iCard> hand = new List<iCard>();
       
        public virtual void addCard(iCard card)
        {
            hand.Add(card);
        }
        public virtual void draw(int x, int y)
        {

            for (int i = 0; i < hand.Count; i++)
            {

         
                cardBase(i, x, y);
                x += 16;
            }
        }
        void cardBase(int i, int x, int y)
        {
            string bigshort = getFace(i).ToString();
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
