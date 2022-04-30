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
    class Program
    {
        static void Main(string[] args)
        {
            Interfeiss interfeiss = new MainMenu();
            Interfeiss nom1 = interfeiss;
            nom1.Start();
        }
    }
}
