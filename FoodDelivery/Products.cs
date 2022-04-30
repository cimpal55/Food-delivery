using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace FoodDelivery
{
    class Products
    {
        public Products() { }
        public static void ClearLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
        }
        public void ProductsList()
        {
            Console.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            string display = "SELECT * FROM Products";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(display, sqlConnection);
            SqlDataReader dataReader = command.ExecuteReader();
            Console.WriteLine("-----------------------------------------------");
            while (dataReader.Read())
            {
                Console.WriteLine("ID: " + dataReader["Product_id"]);
                Console.WriteLine("Title: " + dataReader["Title"]);
                Console.WriteLine("Description: " + dataReader["Description"]);
                Console.WriteLine("-----------------------------------------------");

            }
            Console.WriteLine();
            dataReader.Close();
            sqlConnection.Close();
            Console.WriteLine("");
        }

        public void AddProduct()
        {
            Console.Clear();
            Console.WriteLine("Title of the product: ");
            string productTitle;
            while (true)
            {
                productTitle = Console.ReadLine();
                if (String.IsNullOrEmpty(productTitle))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.WriteLine("Write product title correctly.");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Description of the product: ");
            string productDescription;
            while (true)
            {
                productDescription = Console.ReadLine();
                if (String.IsNullOrEmpty(productDescription))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.WriteLine("Write product description correctly.");
                }
                else
                {
                    break;
                }
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string insertQuery = "INSERT INTO PRODUCTS(Title, Description) VALUES('" + productTitle + "', '" + productDescription + "')";
            string row = "DBCC CHECKIDENT ('Customers', RESEED)";
            SqlCommand command1 = new SqlCommand(row, sqlConnection);
            SqlCommand command2 = new SqlCommand(insertQuery, sqlConnection);
            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            sqlConnection.Close();

            Console.WriteLine("Succesfull!");
            System.Threading.Thread.Sleep(500);
        }
        public void UpdateProduct()
        {
            Console.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            int u_id;
            double u_price;
            string u_title, u_description;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            Console.WriteLine("Enter the product id, that you would like to update: ");
            u_id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the new title: ");
            while (true)
            {
                u_title = Console.ReadLine();
                if (String.IsNullOrEmpty(u_title))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.WriteLine("Write product title correctly.");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Enter the new description: ");
            while (true)
            {
                u_description = Console.ReadLine();
                if (String.IsNullOrEmpty(u_description))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.WriteLine("Write product title correctly.");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Enter the new price: ");
            while (true)
            {
                u_price = int.Parse(Console.ReadLine());
                if (String.IsNullOrEmpty(Convert.ToString(u_price)))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.WriteLine("Write product title correctly.");
                }
                else
                {
                    break;
                }
            }

            string update = "Update Products SET Title = '" + u_title + "',Description = '" + u_description + "',Price = '" + u_price + "' WHERE Customer_id = '" + u_id + "'";
            SqlCommand updateCommand = new SqlCommand(update, sqlConnection);
            updateCommand.ExecuteNonQuery();
            Console.WriteLine("Data updated successfully!");
            System.Threading.Thread.Sleep(500);
            sqlConnection.Close();
        }
        public void DeleteProduct()
        {
            Console.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            Console.WriteLine("Enter the ID of the customer to delete: ");
            int d_id = int.Parse(Console.ReadLine());
            string delete = "DELETE FROM Products WHERE Product_id =" + d_id;
            SqlCommand deleteCommand = new SqlCommand(delete, sqlConnection);
            deleteCommand.ExecuteNonQuery();
            Console.WriteLine("Product successfully was deleted!!");
            System.Threading.Thread.Sleep(500);
            sqlConnection.Close();
        }

    }
}
