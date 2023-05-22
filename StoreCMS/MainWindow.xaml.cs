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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using MySql.Data.MySqlClient;


namespace StoreCMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        private void Login_Submit(object sender, EventArgs e)
        {
            if(username.Text != "" && password.Password != "")
            {
                DataProvider.openConnect();
                string query = $"select count(*) from customers where username = '{username.Text}' and password = '{password.Password}'";
                bool rs = DataProvider.exeScalar(query);
                if(rs)
                {
                    this.Hide();
                    Start st = new Start();
                    st.Show();
                } else
                {
                    MessageBox.Show("Thông tin đăng nhập không chính xác", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                DataProvider.closeConnect();
            } else
            {
                MessageBox.Show("Vui lòng điền thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void Register (object sender, EventArgs e)
        {
            Register rg = new Register();
            rg.ShowDialog();
        }
    }
}
