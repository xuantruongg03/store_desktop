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
    /// Interaction logic for Find_Product.xaml
    /// </summary>
    public partial class Find_Product : Window
    {
        public Find_Product()
        {
            InitializeComponent();
            edit.Visibility = Visibility.Collapsed;
        }
        private void Find (object sender, RoutedEventArgs e)
        {
            DataProvider.openConnect();
            if (find.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm cần tìm", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string query = $"select * from products where product_name like '%{find.Text}%'";
                GResult.ItemsSource = DataProvider.getData(query).DefaultView;
            }
            DataProvider.closeConnect();
        }
        public void Edit (object sender, RoutedEventArgs e)
        {
            DataRowView dr = ((DataRowView)GResult.SelectedItem);
            Add_Product add = new Add_Product(dr);
            add.ShowDialog();
        }

        private void Selected_GridView(object sender, SelectionChangedEventArgs e)
        {
            if(GResult.SelectedIndex != -1)
            {
                edit.Visibility = Visibility.Visible;
            } else
            {
                edit.Visibility = Visibility.Collapsed;
            }
        }

        private void GResult_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "product_description")
            {
                e.Column.Width = new DataGridLength(150);
            }
            else if (e.PropertyName == "product_name")
            {
                e.Column.Width = new DataGridLength(150);
            }
        }
    }
}
