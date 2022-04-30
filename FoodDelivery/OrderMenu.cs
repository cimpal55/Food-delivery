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
    class OrderMenu : Interfeiss
    {
        private int Selected5;
        public string[] Options5 = { "Create a new order", "Orders list", "Update order info", "Delete orders", "Return to the main menu"};
        private string Prompt;

        public OrderMenu(string prompt)
        {
            Prompt = prompt;
            Selected5 = 0;
        }

        public override void displayOptions()
        {
            for (int i = 0; i < 1; i++)
            {
                Console.Write(Prompt);
                Console.WriteLine("");
                Thread.Sleep(1);
            }
            for (int i = 0; i < Options5.Length; i++)
            {
                string current = Options5[i];
                string prefix1, prefix2;

                if (i == Selected5)
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
        public override int Run()
        {
            Selected5 = 0;
            ConsoleKey keyPressed;
            do
            {
                Clear();
                displayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    Selected5--;
                    if (Selected5 == -1)
                    {
                        Selected5 = Options5.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    Selected5++;
                    if (Selected5 == Options5.Length)
                    {
                        Selected5 = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return Selected5;
        }
    }
}
