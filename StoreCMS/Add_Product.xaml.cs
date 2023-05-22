using Google.Protobuf.WellKnownTypes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StoreCMS
{
    /// <summary>
    /// Interaction logic for Add_Product.xaml
    /// </summary>
    public partial class Add_Product : Window
    {
        
        private List<string> selectFile;
        private DataTable dataTable;
        private DataRowView dataRowView;
       
        public Add_Product()
        {
            InitializeComponent();
            dataTable = new DataTable();
            DataColumn key = new DataColumn("tên", typeof(string));
            DataColumn value = new DataColumn("noidung", typeof(string));
            dataTable.Columns.Add(key);
            dataTable.Columns.Add(value);
            edit.Visibility = Visibility.Collapsed;
        }
        public Add_Product(DataRowView dataRowView)
        {
            InitializeComponent();
            DataProvider.openConnect();
            add.Visibility = Visibility.Collapsed;
            this.dataRowView = dataRowView;
            string product_id = dataRowView["product_id"].ToString();
            string query_iamge = $"select file_path from product_images where product_id = '{product_id}'";
            string query_details = $"select detail_name, detail_value from product_details where product_id = '{product_id}'";
            DataTable image = DataProvider.getData(query_iamge);
            if (image != null)
            {
                selectFile= new List<string>();
                foreach (DataRow row in image.Rows)
                {
                    string filePath = row["file_path"].ToString();
                    selectFile.Add(filePath);
                    lv.Items.Add(new BitmapImage(new Uri(filePath)));

                }
            }
            name.Text = dataRowView["product_name"].ToString();
            //dataTable = DataProvider.getData(query_details);
            DataTable temp = DataProvider.getData(query_details);
            dataTable = new DataTable();
            DataColumn key = new DataColumn("ten", typeof(string));
            DataColumn value = new DataColumn("noidung", typeof(string));
            dataTable.Columns.Add(key);
            dataTable.Columns.Add(value);
            foreach(DataRow row in temp.Rows)
            {
                dataTable.Rows.Add(row["detail_name"], row["detail_value"]);
            }
            GRDetails.ItemsSource = dataTable.DefaultView;
            des.Text = dataRowView["product_description"].ToString();
            price.Text = dataRowView["product_price"].ToString();
            sale.Text = dataRowView["product_sale_price"].ToString();
            quantity.Text = dataRowView["product_quantity"].ToString();
            type.Text = dataRowView["product_type"].ToString();
            DataProvider.closeConnect();
        }
        private void Select_Image(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = true;
            file.Filter = "Image Files(*.jpg; *.jpeg, *.png;)|*.jpg; *.jpeg; *.gif; *.png";
            if (file.ShowDialog() == true)
            {
                selectFile = new List<string>();
                foreach (string s in file.FileNames)
                {
                    selectFile.Add(s);
                    BitmapImage bitmap = new BitmapImage(new Uri(s));
                    lv.Items.Add(bitmap);
                }
            }
        }
        private void Delete_Imgae_Select(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lv.SelectedIndex;
            if (selectedIndex != -1)
            {
                lv.Items.RemoveAt(selectedIndex);
                selectFile.RemoveAt(selectedIndex);
            }
        }

        private void Add_Detail (object sender, RoutedEventArgs e)
        {
            Details dt = new Details();
            bool? result = dt.ShowDialog();
            if(result == true)
            {
                
                string value = dt.value.Text;
                string key = dt.key.Text;
                DataRow dr = dataTable.NewRow();
                dr["ten"] = key;
                dr["noidung"] = value;
                dataTable.Rows.Add(dr);
                GRDetails.ItemsSource = dataTable.DefaultView;
            }
        }
        private void Add_Product_Submit (object sender, RoutedEventArgs e)
        {
            DataProvider.openConnect();
            //Product
            string query_product = "insert into products (product_id, product_name, product_description, product_price, product_sale_price, product_type, product_quantity) " +
                "values (@id, @name, @des, @price, @sale, @type, @quantity)";
            string[] name_string_product = { "@id", "@name", "@des", "@price", "@sale", "@type", "@quantity" };

            //Details
            string query_details = "insert into product_details (product_id, detail_name, detail_value) values (@id, @key, @value)";
            string[] name_string_details = { "@id", "@key", "@value" };

            //Images
            string query_images = "insert into product_images (product_id, file_path) value (@id, @path)";
            string[] name_string_images = { "@id", "@path" };

            string id = "";
            string sqlCheckID = "";
            DateTime date = DateTime.Now;
            Random random = new Random();
            
            do
            {
                id = $"{type.Text.ToUpper()[0]}{date.Day}{date.Second}{random.Next(0, 1000)}";
                sqlCheckID = $"select count(*) from products where product_id = '{id}'";
            } while (DataProvider.exeScalar(sqlCheckID));

            try
            {
                //Product
                object[] value_product = { id, name.Text, des.Text, float.Parse(price.Text), float.Parse(sale.Text), type.Text, Int32.Parse(quantity.Text) };
                DataProvider.update(query_product, name_string_product, value_product);

                //Details
                foreach (DataRow dr in dataTable.Rows)
                {
                    object[] value_details = { id, dr["ten"].ToString(), dr["noidung"].ToString() };
                    DataProvider.update(query_details, name_string_details, value_details);
                }

                //Images
                foreach (string s in selectFile)
                {
                    object[] value_images = { id, s };
                    DataProvider.update(query_images, name_string_images, value_images);
                }
                MessageBox.Show("Them thanh cong!");
            } catch(Exception ex)
            {
                MessageBox.Show("Co loi!");
            }
            DataProvider.closeConnect();
        }
        private void Update_Product_Submit(object sender, RoutedEventArgs e)
        {
            try
            {
                DataProvider.openConnect();
                string id = dataRowView["product_id"].ToString();
                //Product
                string query_product = $"update products set product_name = @name, product_description = @des, product_price = @price, product_sale_price = @sale, product_type = @type, product_quantity = @quantity where product_id = '{id}'";
                string[] name_string_product = { "@name", "@des", "@price", "@sale", "@type", "@quantity" };

                //Details
                string query_details = "insert into product_details (product_id, detail_name, detail_value) values (@id, @key, @value)";
                string[] name_string_details = { "@id", "@key", "@value" };

                //Images
                string query_images = "insert into product_images (product_id, file_path) value (@id, @path)";
                string[] name_string_images = { "@id", "@path" };

                //Product
                object[] value_product = { name.Text, des.Text, float.Parse(price.Text), float.Parse(sale.Text), type.Text, Int32.Parse(quantity.Text) };
                DataProvider.update(query_product, name_string_product, value_product);

                //Details
                string query_delete_details = $"delete from product_details where product_id = '{id}'";
                DataProvider.executeNonQuery(query_delete_details);

                foreach (DataRow dr in dataTable.Rows)
                {
                    object[] value_details = { id, dr["ten"].ToString(), dr["noidung"].ToString() };
                    DataProvider.update(query_details, name_string_details, value_details);
                }

                //Images
                string query_delete_images = $"delete from product_images where product_id = '{id}'";
                DataProvider.executeNonQuery(query_delete_images);
                foreach (string path in selectFile)
                {
                    object[] value_images = { id, path };
                    DataProvider.update(query_images, name_string_images, value_images);
                }
                MessageBox.Show("Cap nhat thanh cong!");
                DataProvider.closeConnect();
            } catch (Exception ex)
            {
                MessageBox.Show("Co loi!");
            }
        }
        private void New (object sender, EventArgs e)
        {
            name.Text = "";
            des.Text = "";
            price.Text = "";
            sale.Text = "";
            type.Text = "";
            quantity.Text = "";
            dataTable.Clear();
            selectFile.Clear();
            lv.Items.Clear();
        }
    }
}
