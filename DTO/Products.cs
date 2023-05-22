using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_StoreComputer
{
    internal class Products
    {
        private string _Product_id;
        private string _Product_name;
        private string _Product_description;
        private float _Product_price;
        private float _Product_sale_price;
        private string _Product_type;
        private int _Product_quantity;

        public string Product_id { get => _Product_id; set => _Product_id = value; }
        public string Product_name { get => _Product_name; set => _Product_name = value; }
        public string Product_description { get => _Product_description; set => _Product_description = value; }
        public float Product_price { get => _Product_price; set => _Product_price = value; }
        public float Product_sale_price { get => _Product_sale_price; set => _Product_sale_price = value; }
        public string Product_type { get => _Product_type; set => _Product_type = value; }
        public int Product_quantity { get => _Product_quantity; set => _Product_quantity = value; }

        public Products(string product_id, string product_name, string product_description, float product_price, float product_sale_price, string product_type, int product_quantity)
        {
            Product_id = product_id;
            Product_name = product_name;
            Product_description = product_description;
            Product_price = product_price;
            Product_sale_price = product_sale_price;
            Product_type = product_type;
            Product_quantity = product_quantity;
        }
    }
}
