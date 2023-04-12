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
    /// Логика взаимодействия для lots_data.xaml
    /// </summary>
    public partial class lots_data : Window
    {
        lots_dataTableAdapter lots_data1 = new lots_dataTableAdapter();
        public lots_data()
        {
            InitializeComponent();
            lots_grid.ItemsSource = lots_data1.GetData();
        }

        private void lots_add_Click(object sender, RoutedEventArgs e)
        {
            string fString = lots_tbx1.Text;
            string sString = lots_tbx2.Text;
            string tString = lots_tbx3.Text;


            if (fString != "" && sString != "" && tString != "")
            {
                lots_data1.InsertQuery(Convert.ToInt32(lots_tbx2.Text), (string)lots_tbx3.Text, Convert.ToInt32(lots_tbx4.Text), Convert.ToInt32(lots_tbx5.Text));
                lots_grid.ItemsSource = lots_data1.GetData();
            }
        }

        private void lots_change_Click(object sender, RoutedEventArgs e)
        {
            if (lots_grid.SelectedItem != null)
            {
                object AthId = (lots_grid.SelectedItem as DataRowView).Row[0];

                lots_data1.UpdateQuery(Convert.ToInt32(lots_tbx1.Text), (string)lots_tbx2.Text, Convert.ToInt32(lots_tbx3.Text), Convert.ToInt32(lots_tbx4.Text), Convert.ToInt32(lots_tbx1.Text));
                lots_grid.ItemsSource = lots_data1.GetData();
            }
        }

        private void lots_del_Click(object sender, RoutedEventArgs e)
        {
            if (lots_grid.SelectedItem != null)
            {
                object Athid = (lots_grid.SelectedItem as DataRowView).Row[0];

                lots_data1.DeleteQuery(Convert.ToInt32(lots_tbx1));
                lots_grid.ItemsSource = lots_data1.GetData();
            }
        }

        private void lots_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lots_grid.SelectedItem != null)
            {
                lots_tbx1.Text = (lots_grid.SelectedItem as DataRowView).Row[0].ToString();
                lots_tbx2.Text = (lots_grid.SelectedItem as DataRowView).Row[1].ToString();
                lots_tbx3.Text = (lots_grid.SelectedItem as DataRowView).Row[2].ToString();
                lots_tbx4.Text = (lots_grid.SelectedItem as DataRowView).Row[3].ToString();
                lots_tbx5.Text = (lots_grid.SelectedItem as DataRowView).Row[4].ToString();
            }
        }
    }
}
