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
    class CustomerSort : Interfeiss
    {
        private int Selected;
        public string[] Options = { "Alphabetical Ascending order", "Alphabetical Descending order" };

        public CustomerSort()
        {
            Selected = 0;
        }
        public override void displayOptions()
        {
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("");
                Thread.Sleep(1);
            }
            for (int i = 0; i < Options.Length; i++)
            {
                string current = Options[i];
                string prefix1, prefix2;

                if (i == Selected)
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
            Selected = 0;
            ConsoleKey keyPressed;
            do
            {
                Clear();
                displayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    Selected--;
                    if (Selected == -1)
                    {
                        Selected = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    Selected++;
                    if (Selected == Options.Length)
                    {
                        Selected = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return Selected;
        }
    }
}
