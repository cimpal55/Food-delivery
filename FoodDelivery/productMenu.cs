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
    class productMenu : Interfeiss
    {
        private int Selected4;
        public string[] Options4 = { "Products list", "Add new products", "Update product info", "Delete products", "Return to the main menu"};
        private string Prompt;

        public productMenu(string prompt)
        {
            Prompt = prompt;
            Selected4 = 0;
        }

        public void displayOptions4()
        {
            for (int i = 0; i < 1; i++)
            {
                Console.Write(Prompt);
                Console.WriteLine("");
                Thread.Sleep(1);
            }
            for (int i = 0; i < Options4.Length; i++)
            {
                string current = Options4[i];
                string prefix1, prefix2;

                if (i == Selected4)
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
        public int Run4()
        {
            Selected4 = 0;
            ConsoleKey keyPressed;
            do
            {
                Clear();
                displayOptions4();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    Selected4--;
                    if (Selected4 == -1)
                    {
                        Selected4 = Options4.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    Selected4++;
                    if (Selected4 == Options4.Length)
                    {
                        Selected4 = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return Selected4;
        }
    }
}
