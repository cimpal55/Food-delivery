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
    class Interfeiss
    {
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
            string prompt = @"
███████╗ ██████╗  ██████╗ ██████╗     ██████╗ ███████╗██╗     ██╗██╗   ██╗███████╗██████╗ ██╗   ██╗
██╔════╝██╔═══██╗██╔═══██╗██╔══██╗    ██╔══██╗██╔════╝██║     ██║██║   ██║██╔════╝██╔══██╗╚██╗ ██╔╝
█████╗  ██║   ██║██║   ██║██║  ██║    ██║  ██║█████╗  ██║     ██║██║   ██║█████╗  ██████╔╝ ╚████╔╝ 
██╔══╝  ██║   ██║██║   ██║██║  ██║    ██║  ██║██╔══╝  ██║     ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗  ╚██╔╝  
██║     ╚██████╔╝╚██████╔╝██████╔╝    ██████╔╝███████╗███████╗██║ ╚████╔╝ ███████╗██║  ██║   ██║   
╚═╝      ╚═════╝  ╚═════╝ ╚═════╝     ╚═════╝ ╚══════╝╚══════╝╚═╝  ╚═══╝  ╚══════╝╚═╝  ╚═╝   ╚═╝   
                                                                                                   
Welcome to the food delivery programm. What would you like to do?
(To select options use the arrow keys and press enter to select an option.)";
            startMenu Menu1 = new startMenu(prompt);
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
            string prompt = @"
███╗   ███╗ █████╗ ██╗███╗   ██╗    ███╗   ███╗███████╗███╗   ██╗██╗   ██╗
████╗ ████║██╔══██╗██║████╗  ██║    ████╗ ████║██╔════╝████╗  ██║██║   ██║
██╔████╔██║███████║██║██╔██╗ ██║    ██╔████╔██║█████╗  ██╔██╗ ██║██║   ██║
██║╚██╔╝██║██╔══██║██║██║╚██╗██║    ██║╚██╔╝██║██╔══╝  ██║╚██╗██║██║   ██║
██║ ╚═╝ ██║██║  ██║██║██║ ╚████║    ██║ ╚═╝ ██║███████╗██║ ╚████║╚██████╔╝
╚═╝     ╚═╝╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝    ╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝ 

What would you like to do?";
            startMenu Menu1 = new startMenu(prompt);
            mainMenu Menu2 = new mainMenu(prompt);
            customerMenu Menu3 = new customerMenu(prompt);
            int Selected2 = Menu2.Run2();

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
            string prompt = @"
 ██████╗██╗   ██╗███████╗████████╗ ██████╗ ███╗   ███╗███████╗██████╗ ███████╗
██╔════╝██║   ██║██╔════╝╚══██╔══╝██╔═══██╗████╗ ████║██╔════╝██╔══██╗██╔════╝
██║     ██║   ██║███████╗   ██║   ██║   ██║██╔████╔██║█████╗  ██████╔╝███████╗
██║     ██║   ██║╚════██║   ██║   ██║   ██║██║╚██╔╝██║██╔══╝  ██╔══██╗╚════██║
╚██████╗╚██████╔╝███████║   ██║   ╚██████╔╝██║ ╚═╝ ██║███████╗██║  ██║███████║
 ╚═════╝ ╚═════╝ ╚══════╝   ╚═╝    ╚═════╝ ╚═╝     ╚═╝╚══════╝╚═╝  ╚═╝╚══════╝   

What would you like to do?";
            Customers customer = new Customers(1, 20318705, "Vladislavs", "Suspanovs", "Satiksmes iela 33-64");
            mainMenu Menu2 = new mainMenu(prompt);
            customerMenu Menu3 = new customerMenu(prompt);
            customerSort sortMenu = new customerSort();
            int Selected3 = Menu3.Run3();

            switch (Selected3)
            {
                case 0:
                    customer.CustomersList();
                    BackCustomers();
                    break;
                case 1:
                    int Selected4 = sortMenu.Run4();
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
            string prompt = @"
██████╗ ██████╗  ██████╗ ██████╗ ██╗   ██╗ ██████╗████████╗███████╗
██╔══██╗██╔══██╗██╔═══██╗██╔══██╗██║   ██║██╔════╝╚══██╔══╝██╔════╝
██████╔╝██████╔╝██║   ██║██║  ██║██║   ██║██║        ██║   ███████╗
██╔═══╝ ██╔══██╗██║   ██║██║  ██║██║   ██║██║        ██║   ╚════██║
██║     ██║  ██║╚██████╔╝██████╔╝╚██████╔╝╚██████╗   ██║   ███████║
╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚═════╝  ╚═════╝  ╚═════╝   ╚═╝   ╚══════╝                                                          
What would you like to do?";
            Products product = new Products(1, "Fujiwara", "VERY GOOD AND TASTE");
            mainMenu Menu2 = new mainMenu(prompt);
            productMenu Menu4 = new productMenu(prompt);
            int Selected4 = Menu4.Run4();

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
