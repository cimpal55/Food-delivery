using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using static System.Console;

namespace FoodDelivery
{
    public abstract class Interfeiss
    {
        public abstract void displayOptions();
        public abstract int Run();
        public void Start()
        {
            Title = "Food Delivery";
            RunMenu();
        }

        public void Back()
        {
            Console.WriteLine("To return to the menu press ENTER");

            ConsoleKey keyPressed;
            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;

            if (keyPressed == ConsoleKey.Enter)
            {
                Clear();
                RunMenu();
            }
        }
        public void BackCustomers()
        {
            Console.WriteLine("To return to the menu press ENTER");

            ConsoleKey keyPressed;
            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;

            if (keyPressed == ConsoleKey.Enter)
            {
                Clear();
                RunCustomers();
            }
        }
        public void BackProducts()
        {
            Console.WriteLine("To return to the menu press ENTER");

            ConsoleKey keyPressed;
            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;

            if (keyPressed == ConsoleKey.Enter)
            {
                Clear();
                RunProducts();
            }
        }
        protected void RunMenu()
        {
            StartMenu Menu1 = new StartMenu();
            int Selected = Menu1.Run();

            switch (Selected) 
            {
                case 0:
                    InfoProgramm();
                    Back();
                    break;
                case 1:
                    RunMenu2();
                    break;
                case 2:
                    Exit();
                    break;
            }
        }
        protected void RunMenu2()
        {
            StartMenu Menu1 = new StartMenu();
            MainMenu Menu2 = new MainMenu();
            int Selected2 = Menu2.Run();

            switch (Selected2)
            {
                case 0:
                    RunCustomers();
                    break;
                case 1:
                    RunProducts();
                    break;
                case 2:
                    break;
                case 3:
                    Menu1.RunMenu();
                    break;
            }
        }

        protected void RunCustomers()
        {
            Customers customer = new Customers();
            MainMenu Menu2 = new MainMenu();
            CustomerMenu Menu3 = new CustomerMenu();
            CustomerSort sortMenu = new CustomerSort();
            int Selected3 = Menu3.Run();

            switch (Selected3)
            {
                case 0:
                    customer.CustomersList();
                    BackCustomers();
                    break;
                case 1:
                    int Selected4 = sortMenu.Run();
                    switch (Selected4)
                    {
                        case 0:
                            customer.SortingASC();
                            BackCustomers();
                            break;
                        case 1:
                            customer.SortingDESC();
                            BackCustomers();
                            break;
                    }
                    break;
                case 2:
                    customer.AddCustomer();
                    RunCustomers();
                    break;
                case 3:
                    customer.UpdateCustomer();
                    RunCustomers();
                    break;
                case 4:
                    customer.DeleteCustomer();
                    RunCustomers();
                    break;
                case 5:
                    Menu2.RunMenu2();
                    break;
            }
        }
        protected void RunProducts()
        {
            Products product = new Products();
            MainMenu Menu2 = new MainMenu();
            ProductMenu Menu4 = new ProductMenu();
            int Selected4 = Menu4.Run();

            switch (Selected4)
            {
                case 0:
                    product.ProductsList();
                    BackProducts();
                    break;
                case 1:
                    product.AddProduct();
                    RunProducts();
                    break;
                case 2:
                    product.UpdateProduct();
                    RunProducts();
                    break;
                case 3:
                    product.DeleteProduct();
                    RunProducts();
                    break;
                case 4:
                    Menu2.RunMenu2();
                    break;
            }
        } 
        protected void Exit()
        {
            Console.WriteLine("\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }
        protected void InfoProgramm()
        {
        Clear();
        CursorVisible = false;
        Console.WriteLine(@"
 █████  ██    ██ ████████ ██   ██  ██████  ██████  ███████ 
██   ██ ██    ██    ██    ██   ██ ██    ██ ██   ██ ██      
███████ ██    ██    ██    ███████ ██    ██ ██████  ███████ 
██   ██ ██    ██    ██    ██   ██ ██    ██ ██   ██      ██ 
██   ██  ██████     ██    ██   ██  ██████  ██   ██ ███████                                                       
                                                                                                                                                        
  _     __  __      ____            _       _ 
 / |   |  \/  |_ __|  _ \  _____  _| |_ ___| |
 | |   | |\/| | '__| | | |/ _ \ \/ / __/ _ \ |
 | |_  | |  | | |  | |_| |  __/>  <| ||  __/ |
 |_(_) |_|  |_|_|  |____/ \___/_/\_\\__\___|_|
  ____      _   _                             
 |___ \    | \ | | __ _  ___ _ __ ___         
   __) |   |  \| |/ _` |/ _ \ '__/ __|        
  / __/ _  | |\  | (_| |  __/ |  \__ \        
 |_____(_) |_| \_|\__,_|\___|_|  |___/                                             
");
        for (int i = 0; i < 50; i++)
        {
            if (i == 49)
            {
                Clear();
                ForegroundColor = ConsoleColor.Gray;
                RunMenu();
            }
            for (int y = 0; y < i; y++)
            {
                string pb = "\u2551";
                Console.Write(pb);
            }
            SetCursorPosition(1, 20);
            ForegroundColor = ConsoleColor.DarkGreen;
            System.Threading.Thread.Sleep(50);
            }
        }
    }
}
