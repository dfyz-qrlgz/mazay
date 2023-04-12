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
using PRACTICA_5.auction_dbDataSetTableAdapters;

namespace PRACTICA_5
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
        }

        private void userbtn1_Click(object sender, RoutedEventArgs e)
        {
            bidding_data window = new bidding_data();
            window.ShowDialog();
        }

        private void userbtn2_Click(object sender, RoutedEventArgs e)
        {
            lots_data window = new lots_data();
            window.ShowDialog();
        }

        private void userbtn3_Click(object sender, RoutedEventArgs e)
        {
            bids_data window = new bids_data();
            window.ShowDialog();
        }

        private void userbtn4_Click(object sender, RoutedEventArgs e)
        {
            cheq_data window = new cheq_data();
            window.ShowDialog();
        }
    }
}
