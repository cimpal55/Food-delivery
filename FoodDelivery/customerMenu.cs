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
    class CustomerMenu : Interfeiss
    {
        private int Selected3;
        public string[] Options3 = { "Customers list", "Customers sorting", "Add new customers", "Update customer info", "Delete customers", "Return to the main menu"};
        private string Prompt = @"
 ██████╗██╗   ██╗███████╗████████╗ ██████╗ ███╗   ███╗███████╗██████╗ ███████╗
██╔════╝██║   ██║██╔════╝╚══██╔══╝██╔═══██╗████╗ ████║██╔════╝██╔══██╗██╔════╝
██║     ██║   ██║███████╗   ██║   ██║   ██║██╔████╔██║█████╗  ██████╔╝███████╗
██║     ██║   ██║╚════██║   ██║   ██║   ██║██║╚██╔╝██║██╔══╝  ██╔══██╗╚════██║
╚██████╗╚██████╔╝███████║   ██║   ╚██████╔╝██║ ╚═╝ ██║███████╗██║  ██║███████║
 ╚═════╝ ╚═════╝ ╚══════╝   ╚═╝    ╚═════╝ ╚═╝     ╚═╝╚══════╝╚═╝  ╚═╝╚══════╝   

What would you like to do?";

        public CustomerMenu()
        {
            Selected3 = 0;
        }

        public override void displayOptions()
        {
            for (int i = 0; i < 1; i++)
            {
                Console.Write(Prompt);
                Console.WriteLine("");
                Thread.Sleep(1);
            }
            for (int i = 0; i < Options3.Length; i++)
            {
                string current = Options3[i];
                string prefix1, prefix2;

                if (i == Selected3)
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
            Selected3 = 0;
            ConsoleKey keyPressed;
            do
            {
                Clear();
                displayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    Selected3--;
                    if (Selected3 == -1)
                    {
                        Selected3 = Options3.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    Selected3++;
                    if (Selected3 == Options3.Length)
                    {
                        Selected3 = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return Selected3;
        }
    }
}
