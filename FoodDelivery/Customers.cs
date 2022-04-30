using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using static System.Console;
using System.Data.SqlClient;

namespace FoodDelivery
{
    public class Customers 
    {
        public Customers() { }
       
        public static void ClearLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
        }
        public void AddCustomer()
            {
                Console.Clear();
                Console.WriteLine("Name of customer: ");
                string Name;
                while (true)
                {
                    Name = Console.ReadLine();
                    if (String.IsNullOrEmpty(Name))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        ClearLine();
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        ClearLine();
                        Console.WriteLine("Write your name correctly.");
                    }
                    else
                    {
                        break;
                    }
                }

                Console.WriteLine("Surname of customer: ");
                string Surname;
                while (true)
                {
                    Surname = Console.ReadLine();
                    if (String.IsNullOrEmpty(Surname))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        ClearLine();
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        ClearLine();
                        Console.WriteLine("Write your surname correctly.");
                    }
                    else
                    {
                        break;
                    }
                }

                Console.WriteLine("Phone number of customer: ");
                int Phonenumber;
                while (true)
                {
                    string strPhonenumber = Console.ReadLine();
                    if (String.IsNullOrEmpty(strPhonenumber) == false && int.TryParse(strPhonenumber, out Phonenumber))
                    {
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        ClearLine();
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        ClearLine();
                        Console.WriteLine("Write your phone number correctly.");
                     }
                }

                Console.WriteLine("Address of customer: ");   
                string Address;
                while (true)
                {
                    Address = Console.ReadLine();
                    if (String.IsNullOrEmpty(Address))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        ClearLine();
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        ClearLine();
                        Console.WriteLine("Write your Address correctly.");
                    }
                    else
                    {
                        break;
                    }
                }

                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dungeon master\source\repos\FoodDelivery\FoodDelivery\Database.mdf;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string insertQuery = "INSERT INTO CUSTOMERS(Name, Surname, Phonenumber, Address) VALUES('" + Name + "', '" + Surname + "', '" + Phonenumber + "', '" + Address + "')";
                string row = "DBCC CHECKIDENT ('Customers', RESEED)";
                SqlCommand command1 = new SqlCommand(row, sqlConnection);
                SqlCommand command2 = new SqlCommand(insertQuery, sqlConnection);
                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                sqlConnection.Close();

                Console.WriteLine("Succesfull!");
                System.Threading.Thread.Sleep(500);
            }
        public void CustomersList()
        {
            Console.Clear();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dungeon master\source\repos\FoodDelivery\FoodDelivery\Database.mdf;Integrated Security=True";
            string display = "SELECT * FROM Customers";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(display, sqlConnection);
            SqlDataReader dataReader = command.ExecuteReader();
            Console.WriteLine("-----------------------------------------------");
            while (dataReader.Read())
            {
                    Console.WriteLine("ID: " + dataReader["Customer_id"]);
                    Console.WriteLine("Name: " + dataReader["Name"]);
                    Console.WriteLine("Surname: " + dataReader["Surname"]);
                    Console.WriteLine("Phone number: " + dataReader["Phonenumber"]);
                    Console.WriteLine("Address: " + dataReader["Address"]);
                    Console.WriteLine("-----------------------------------------------");

                }
                Console.WriteLine();
                dataReader.Close();
                sqlConnection.Close();
                Console.WriteLine("");
            }
        public void UpdateCustomer()
        {
            Console.Clear();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dungeon master\source\repos\FoodDelivery\FoodDelivery\Database.mdf;Integrated Security=True";
            int u_id, u_phonenumber; 
            string u_name, u_surname, u_address;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            Console.WriteLine("Enter the user id, that you would like to update: ");
            u_id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the new name: ");
            while (true)
            {
                u_name = Console.ReadLine();
                if (String.IsNullOrEmpty(u_name))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.WriteLine("Write your name correctly.");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Enter the new surname: ");
            while (true)
            {
                u_surname = Console.ReadLine();
                if (String.IsNullOrEmpty(u_surname))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.WriteLine("Write your surname correctly.");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Enter the new phone number: ");
            while (true)
            {
                string strPhonenumber = Console.ReadLine();
                if (String.IsNullOrEmpty(strPhonenumber) == false && int.TryParse(strPhonenumber, out u_phonenumber))
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.WriteLine("Write your phone number correctly.");
                }
            }

            Console.WriteLine("Enter the new address: ");
            while (true)
            {
                u_address = Console.ReadLine();
                if (String.IsNullOrEmpty(u_address))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.WriteLine("Write your Address correctly.");
                }
                else
                {
                    break;
                }
            }

            string update = "Update Customers SET Name = '" + u_name + "',Surname = '" + u_surname + "',Phonenumber = '" + u_phonenumber + "',Address = '" + u_address + "' WHERE Customer_id = '" + u_id + "'";
            SqlCommand updateCommand = new SqlCommand(update, sqlConnection);
            updateCommand.ExecuteNonQuery();
            Console.WriteLine("Data updated successfully!");
            System.Threading.Thread.Sleep(500);
            sqlConnection.Close();
        }
        public void DeleteCustomer()
        {
            Console.Clear();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dungeon master\source\repos\FoodDelivery\FoodDelivery\Database.mdf;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            Console.WriteLine("Enter the ID of the customer to delete: ");
            int d_id = int.Parse(Console.ReadLine());
            string delete = "DELETE FROM Customers WHERE Customer_id =" + d_id;
            SqlCommand deleteCommand = new SqlCommand(delete, sqlConnection);
            deleteCommand.ExecuteNonQuery();
            Console.WriteLine("Customer successfully was deleted!!");
            System.Threading.Thread.Sleep(500);
            sqlConnection.Close();
        }

        public void SortingASC()
        {
            Console.Clear();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dungeon master\source\repos\FoodDelivery\FoodDelivery\Database.mdf;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            Console.WriteLine("You can sort by: 'Name', 'Surname', 'PhoneNumber', 'Address'");
            Console.WriteLine("Enter the word, what do you want to sort by");
            Console.WriteLine();
            string u_sortby = Console.ReadLine(); 
            string sort = "SELECT * FROM Customers ORDER BY '"+u_sortby+"' ASC";

            SqlCommand sortCommand = new SqlCommand(sort, sqlConnection);
            SqlDataReader dataReader = sortCommand.ExecuteReader();
            Console.WriteLine("-----------------------------------------------");
            while (dataReader.Read())
            {
                Console.WriteLine("ID: " + dataReader["Customer_id"]);
                Console.WriteLine("Name: " + dataReader["Name"]);
                Console.WriteLine("Surname: " + dataReader["Surname"]);
                Console.WriteLine("Phone number: " + dataReader["Phonenumber"]);
                Console.WriteLine("Address: " + dataReader["Address"]);
                Console.WriteLine("-----------------------------------------------");

            }
            Console.WriteLine();
            dataReader.Close();
            sqlConnection.Close();
            Console.WriteLine("");
        }
        public void SortingDESC()
        {
            Console.Clear();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dungeon master\source\repos\FoodDelivery\FoodDelivery\Database.mdf;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            Console.WriteLine("You can sort by: 'Name', 'Surname', 'PhoneNumber', 'Address'");
            Console.WriteLine("Enter the word, what do you want to sort by");
            Console.WriteLine();
            string u_sortby = Console.ReadLine();
            string sort = "SELECT * FROM Customers ORDER BY '" + u_sortby + "' DESC";

            SqlCommand sortCommand = new SqlCommand(sort, sqlConnection);
            SqlDataReader dataReader = sortCommand.ExecuteReader();
            Console.WriteLine("-----------------------------------------------");
            while (dataReader.Read())
            {
                Console.WriteLine("ID: " + dataReader["Customer_id"]);
                Console.WriteLine("Name: " + dataReader["Name"]);
                Console.WriteLine("Surname: " + dataReader["Surname"]);
                Console.WriteLine("Phone number: " + dataReader["Phonenumber"]);
                Console.WriteLine("Address: " + dataReader["Address"]);
                Console.WriteLine("-----------------------------------------------");

            }
            Console.WriteLine();
            dataReader.Close();
            sqlConnection.Close();
            Console.WriteLine("");
        }
    }
}
