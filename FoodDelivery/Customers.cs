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
        public int Id;
        public int PhoneNumber;
        public int selected;
        public string KlientaName;
        public string KlientaSurname;
        public string Address;
        public Customers(int id, int phoneNumber, string klientaName, string klientaSurname, string address)
        {
                this.Id = id;
                this.PhoneNumber = phoneNumber;
                this.KlientaName = klientaName;
                this.KlientaSurname = klientaSurname;
                this.Address = address;
        }
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
                string Name = Console.ReadLine(); 
                while (String.IsNullOrEmpty(Name))
                {
                    Console.WriteLine("Write your name correctly.");
                    Name = Console.ReadLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    ClearLine();
                }

                Console.WriteLine("Surname of customer: ");
                string Surname = Console.ReadLine();
                while (String.IsNullOrEmpty(Surname))
                {
                    Console.WriteLine("Write your surname correctly.");
                    Surname = Console.ReadLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    ClearLine();
                }

                Console.WriteLine("Phone number of customer: ");
                string Phonenumber = Console.ReadLine();
                bool isNumber = int.TryParse(Phonenumber, out int n);
                while (String.IsNullOrEmpty(Phonenumber) || isNumber == false)
                {
                    Console.WriteLine("Write your phone number correctly.");
                    Phonenumber = Console.ReadLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    ClearLine();
                }

                Console.WriteLine("Address of customer: ");
                string Address = Console.ReadLine();
                while (String.IsNullOrEmpty(Address))
                {
                    Console.WriteLine("Write your address correctly.");
                    Address = Console.ReadLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    ClearLine();
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
            u_name = Console.ReadLine();
            Console.WriteLine("Enter the new surname: ");
            u_surname = Console.ReadLine();
            Console.WriteLine("Enter the new phone number: ");
            u_phonenumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new address: ");
            u_address = Console.ReadLine();

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
