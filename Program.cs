using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] board = {'1','2','3','4','5','6','7','8','9'};
            Console.Write("Enter player 1 name: ");
            string name1 = Console.ReadLine();
            Console.Write("Enter player 2 name: ");
            string name2 = Console.ReadLine();
            Console.Write("\n" + name1 + ", Choose 'X' or 'O' : ");
            char coin1 = char.Parse(Console.ReadLine());
            coin1 = Char.ToUpper(coin1);
            char coin2 = ' ';
            while (coin1 != 'X' && coin1 != 'O')
            {
                Console.Write("Please enter either 'X' or 'O': ");
                coin1 = char.Parse(Console.ReadLine());
                coin1 = Char.ToUpper(coin1);
            }
            if (coin1 == 'X')
            {
                coin2 = 'O';
            }
            else if (coin1 == 'O')
            {
                coin2 = 'X';
            }
            string curplayer = " ";
            Console.WriteLine("\n" + name1 + ": " + coin1);
            Console.WriteLine(name2 + ": " + coin2);
            Console.WriteLine("\nBoard Initially:- \n");
            PrintBoard(board);
            if (coin1 == 'X')
            {
                curplayer = name1;
            }
            else
            {
                curplayer = name2;
            }
            char curcoin = ' ';
            if (curplayer == name1)
            {
                curcoin = coin1;
            }
            else if(curplayer == name2)
            {
                curcoin = coin2;
            }
            int w = 0;
            while (w < 9)
            {
                Console.Write(curplayer + ", choose where to place '" + curcoin + "' : ");
                int p = int.Parse(Console.ReadLine());
                while (IsPosGiven(p, board))
                {
                    Console.Write("Place aldready chosen, choose another place: ");
                    p = int.Parse(Console.ReadLine());
                }
                board[p - 1] = curcoin;
                Console.WriteLine();
                PrintBoard(board);
                if (IsFormed(board))
                {
                    Console.WriteLine("CONGRATS " + curplayer + "!! You WON.");
                    break;
                }
                curplayer = SwapCurPlayer(name1, name2, curplayer);
                curcoin = SwapCurCoin(coin1, coin2, curcoin);
                w++;
            }
            if (IsFormed(board) == false)
            {
                Console.WriteLine("Match DRAW");
            }
        }
        public static void PrintBoard(char[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    Console.WriteLine("\n");
                }
                Console.Write(a[i] + "\t");
            }
            Console.WriteLine("\n");
        }
        public static string SwapCurPlayer(string a, string b, string cur)
        {
            if (cur == a)
            {
                cur = b;
            }
            else
            {
                cur = a;
            }
            return cur;
        }
        public static char SwapCurCoin(char a, char b, char cur)
        {
            if (cur == a)
            {
                cur = b;
            }
            else
            {
                cur = a;
            }
            return cur;
        }
        public static bool IsPosGiven(int a, char[] c)
        {
            bool res = false;
            if (c[a-1] == 'X' || c[a-1] == 'O')
            {
                res = true;
            }
            return res;
        }
        public static bool IsFormed(char[] c)
        {
            bool ans = false;

            if (c[0] == c[1] && c[1] == c[2] && c[0] == c[2])
            {
                ans = true;
            }
            else if (c[3] == c[4] && c[4] == c[5] && c[3] == c[5])
            {
                ans = true;
            }
            else if (c[6] == c[7] && c[7] == c[8] && c[6] == c[8])
            {
                ans = true;
            }
            else if (c[0] == c[3] && c[3] == c[6] && c[0] == c[6])
            {
                ans = true;
            }
            else if (c[1] == c[4] && c[4] == c[7] && c[1] == c[7])
            {
                ans = true;
            }
            else if (c[2] == c[5] && c[5] == c[8] && c[2] == c[8])
            {
                ans = true;
            }
            else if (c[0] == c[4] && c[4] == c[8] && c[0] == c[8])
            {
                ans = true;
            }
            else if (c[2] == c[4] && c[4] == c[6] && c[2] == c[6])
            {
                ans = true;
            }


            return ans;
        }
    }
}
