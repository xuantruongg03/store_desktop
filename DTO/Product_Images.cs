using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_StoreComputer
{
    internal class Product_Images
    {
        private int _Image_id;
        private string _Product_id;
        private string _File_path;

        public int Image_id { get => _Image_id; set => _Image_id = value; }
        public string Product_id { get => _Product_id; set => _Product_id = value; }
        public string File_path { get => _File_path; set => _File_path = value; }

        public Product_Images(int image_id, string product_id, string file_path)
        {
            Image_id = image_id;
            Product_id = product_id;
            File_path = file_path;
        }
    }
}
