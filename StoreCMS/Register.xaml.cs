using System;
using System.Collections.Generic;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
        private void Register_Submit(object sender, EventArgs e)
        {
            if (username.Text != "" && password.Password != "" && email.Text != "" && first_name.Text != "" && last_name.Text != "" && gender.Text != "")
            {
                DataProvider.openConnect();
                string sqlCheckUser = $"select count(*) from customers where username = '{username.Text}'";
                if (DataProvider.exeScalar(sqlCheckUser))
                {
                    MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                string query = "insert into customers (customer_id, first_name, last_name, gender, email, username, password) values " +
                    "(@id, @first_name, @last_name, @gender, @email, @username, @password)";
                string[] name_string = { "@id", "@first_name", "@last_name", "@gender", "@email", "@username", "@password" };
                string id = "";
                string sqlCheckID = "";
                DateTime date = DateTime.Now;
                Random random = new Random();
                do
                {
                    id = $"{date.Day}{date.Second}{random.Next(0, 1000)}";
                    sqlCheckID = $"select count(*) from customers where customer_id = '{id}'";
                } while (DataProvider.exeScalar(sqlCheckID));
                object[] value = { id, first_name.Text, last_name.Text, gender.Text, email.Text, username.Text, password.Password};
                DataProvider.update(query, name_string, value);
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                DataProvider.closeConnect();
            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }   
        private void New (object sender, EventArgs e)
        {
            first_name.Text = "";
            last_name.Text = "";
            gender.Text = "Nam";
            email.Text = "";
            username.Text = "";
            password.Password = "";
        }
    }
}
