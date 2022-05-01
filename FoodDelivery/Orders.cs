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
    class Orders
    {
        public Orders() { }
        public string getDate()
        {
            DateTime aData = DateTime.Now;
            return aData.ToString("MM/dd/yyyy HH:mm:ss");
        }
        public static void ClearLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
        }
        public void AddOrder()
        {
            int Customer_id, Product_id;
            Customers customer = new Customers();
            Products product = new Products();
            Console.Clear();

            customer.CustomersList();
            Console.WriteLine("Select your Customer id from the list: ");
            while (true)
            {
                string strCustomer_id = Console.ReadLine();
                if (String.IsNullOrEmpty(strCustomer_id) == false && int.TryParse(strCustomer_id, out Customer_id))
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.WriteLine("Write customer id correctly.");
                }
            }

            product.ProductsList();
            Console.WriteLine("Select your Product id from the list: ");
            while (true)
            {
                string strProduct_id = Console.ReadLine();
                if (String.IsNullOrEmpty(strProduct_id) == false && int.TryParse(strProduct_id, out Product_id))
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearLine();
                    Console.WriteLine("Write customer id correctly.");
                }
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string insertQuery = "INSERT INTO Orders(Customer_id, Product_id, OrderDate) VALUES('" + Customer_id + "', '" + Product_id + "', '" + getDate() + "')";
            string row = "DBCC CHECKIDENT ('Orders', RESEED)";
            SqlCommand command1 = new SqlCommand(row, sqlConnection);
            SqlCommand command2 = new SqlCommand(insertQuery, sqlConnection);
            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            sqlConnection.Close();

            Console.WriteLine("Succesfull!");
            System.Threading.Thread.Sleep(500);
        }
        public void OrdersList()
        {
            Console.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            string display = "SELECT * FROM Orders";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(display, sqlConnection);
            SqlDataReader dataReader = command.ExecuteReader();
            Console.WriteLine("-----------------------------------------------");
            while (dataReader.Read())
            {
                Console.WriteLine("Order ID: " + dataReader["Order_id"]);
                Console.WriteLine("Customer: " + dataReader["Customer_id"]);
                Console.WriteLine("Product: " + dataReader["Product_id"]);
                Console.WriteLine("Ordering date: " + dataReader["OrderDate"]);
                Console.WriteLine("-----------------------------------------------");

            }
            Console.WriteLine();
            dataReader.Close();
            sqlConnection.Close();
            Console.WriteLine("");
        }
        public void DeleteOrder()
        {
            Console.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            Console.WriteLine("Enter the ID of the order to delete: ");
            int d_orderid = int.Parse(Console.ReadLine());
            string delete = "DELETE FROM Orders WHERE Order_id =" + d_orderid;
            SqlCommand deleteCommand = new SqlCommand(delete, sqlConnection);
            deleteCommand.ExecuteNonQuery();
            Console.WriteLine("Customer successfully was deleted!!");
            System.Threading.Thread.Sleep(500);
            sqlConnection.Close();
        }
        public void OrdersCustomersSummary()
        {
            Console.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string summary = @"SELECT Customer_id, Count(Orders.Order_id) AS TotalOrder FROM [Orders] Where Customer_id = Customer_id GROUP BY Customer_id Order BY Count(Orders.Order_id) DESC;";
            SqlCommand sqlCommand = new SqlCommand(summary, sqlConnection);
            
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            Console.WriteLine("-----------------------------------------------");
            while (dataReader.Read())
            {
                Console.WriteLine("Customer: " + dataReader["Customer_id"]);
                Console.WriteLine("Total orders: " + dataReader["TotalOrder"]);
                Console.WriteLine("-----------------------------------------------");

            }
            Console.WriteLine();
            dataReader.Close();
            sqlConnection.Close();
            Console.WriteLine("");
        }
        public void OrdersProductsSummary()
        {
            Console.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string summary = @"SELECT Product_id, Count(Orders.Order_id) AS TotalProducts FROM [Orders] Where Product_id = Product_id GROUP BY Product_id Order BY Count(Orders.Order_id) DESC;";
            SqlCommand sqlCommand = new SqlCommand(summary, sqlConnection);

            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            Console.WriteLine("-----------------------------------------------");
            while (dataReader.Read())
            {
                Console.WriteLine("Product: " + dataReader["Product_id"]);
                Console.WriteLine("Total orders: " + dataReader["TotalProducts"]);
                Console.WriteLine("-----------------------------------------------");

            }
            Console.WriteLine();
            dataReader.Close();
            sqlConnection.Close();
            Console.WriteLine("");
        }
    }
}
