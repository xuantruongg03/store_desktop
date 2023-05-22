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
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Window
    {
        class Detail
        {
            public string key { get; set; }
            public string value { get; set; }
        }
        public Details()
        {
            InitializeComponent();
        }

        private void Close_Add_Detail (object sender, RoutedEventArgs e)
        {
            Detail dt = new Detail();
            dt.key = this.key.Text;
            dt.value = this.value.Text;
            this.DataContext = dt;
            this.DialogResult = true;
            this.Close();
        }
    }
}
