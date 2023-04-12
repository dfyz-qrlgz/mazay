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
using PRACTICA_5.auction_dbDataSetTableAdapters;

namespace PRACTICA_5
{
    /// <summary>
    /// Логика взаимодействия для bidding_data.xaml
    /// </summary>
    public partial class bidding_data : Window
    {
        bidding_dataTableAdapter bidding_data1 = new bidding_dataTableAdapter();
        public bidding_data()
        {
            InitializeComponent();
            bidding_grid.ItemsSource = bidding_data1.GetData();
        }

        private void biddingchange_Click(object sender, RoutedEventArgs e)
        {
            if (bidding_grid.SelectedItem != null)
            {
                object AthId = (bidding_grid.SelectedItem as DataRowView).Row[0];

                bidding_data1.UpdateQuery(Convert.ToInt32(bidding_tbx1.Text), (string)bidding_tbx3.Text, Convert.ToInt32(bidding_tbx1.Text));
                bidding_grid.ItemsSource = bidding_data1.GetData();
            }
        }

        private void biddingadd_Click(object sender, RoutedEventArgs e)
        {
            string sString = bidding_tbx2.Text;
            string tString = bidding_tbx3.Text;

            if (sString != "" && tString != "")
            {
                bidding_data1.InsertQuery(Convert.ToInt32(bidding_tbx2.Text), (string)bidding_tbx3.Text);
                bidding_grid.ItemsSource = bidding_data1.GetData();
            }
        }

        private void biddingdel_Click(object sender, RoutedEventArgs e)
        {
            if (bidding_grid.SelectedItem != null)
            {
                object bidding_data_id = (bidding_grid.SelectedItem as DataRowView).Row[0];

                bidding_data1.DeleteQuery(Convert.ToInt32(bidding_data_id));
                bidding_grid.ItemsSource = bidding_data1.GetData();
            }
        }

        private void bidding_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bidding_grid.SelectedItem != null)
            {
                bidding_tbx2.Text = (bidding_grid.SelectedItem as DataRowView).Row[1].ToString();
                bidding_tbx3.Text = (bidding_grid.SelectedItem as DataRowView).Row[2].ToString();
            }
        }

        private void bidding_tbx4_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
