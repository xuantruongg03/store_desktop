using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_StoreComputer
{
    internal class Product_Details
    {
        private int _Detail_id;
        private string _Product_id;
        private string _Detail_name;
        private string _Detail_value;

        public int Detail_id { get => _Detail_id; set => _Detail_id = value; }
        public string Product_id { get => _Product_id; set => _Product_id = value; }
        public string Detail_name { get => _Detail_name; set => _Detail_name = value; }
        public string Detail_value { get => _Detail_value; set => _Detail_value = value; }

        public Product_Details(int detail_id, string product_id, string detail_name, string detail_value)
        {
            Detail_id = detail_id;
            Product_id = product_id;
            Detail_name = detail_name;
            Detail_value = detail_value;
        }
    }
}
