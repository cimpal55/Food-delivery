using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace FoodDelivery
{
    class mainMenu : Interfeiss
    {
        public int Selected2;
        public string[] Options2 = { "Customers", "Products", "Orders", "Back to the start menu" };
        private string Prompt;

        public mainMenu(string prompt)
        {
            Prompt = prompt;
            Selected2 = 0;
        }

        public void displayOptions2()
        {
            for (int i = 0; i < 1; i++)
            {
                Console.Write(Prompt);
                Console.WriteLine("");
                Thread.Sleep(1);
            }
            for (int i = 0; i < Options2.Length; i++)
            {
                string current = Options2[i];
                string prefix1, prefix2;

                if (i == Selected2)
                {
                    prefix1 = "<<";
                    prefix2 = ">>";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.DarkGreen;
                }
                else
                {
                    prefix1 = " ";
                    prefix2 = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{prefix1} {current} {prefix2}");
            }
            ResetColor();
        }
        public int Run2()
        {
            Selected2 = 0;
            ConsoleKey keyPressed;
            do
            {
                Clear();
                displayOptions2();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    Selected2--;
                    if (Selected2 == -1)
                    {
                        Selected2 = Options2.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    Selected2++;
                    if (Selected2 == Options2.Length)
                    {
                        Selected2 = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return Selected2;
        }
    }
}
