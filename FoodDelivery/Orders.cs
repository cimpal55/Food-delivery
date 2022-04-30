using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FoodDelivery
{
    class Orders
    {
        public int ID;
        public Orders(int id)
        {
            this.ID = id;
        }

        public void getDate()
        {
            DateTime aData = DateTime.Now;
            aData.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        }



    }
}
