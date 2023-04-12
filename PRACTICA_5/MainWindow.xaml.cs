using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using PRACTICA_5.auction_dbDataSetTableAdapters;
using PRACTICA_5;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using static PRACTICA_5.auction_dbDataSet;

namespace PRACTICA_5
{
    public partial class MainWindow : Window
    {
        peopleTableAdapter people = new peopleTableAdapter();
        acc_infoTableAdapter acc_info = new acc_infoTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                lblErrorMessage.Content = "Please enter login and password.";
                return;
            }

            if (!Regex.IsMatch(login, @"^[a-zA-Z0-9]+$") || !Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"))
            {
                lblErrorMessage.Content = "Please enter only letters and numbers for login and password.";
                return;
            }

            bool isValid = ValidateLoginAndPassword(login, password);

            if (!isValid)
            {
                lblErrorMessage.Content = "Invalid login or password. Please try again.";
                return;
            }

            if (isAdmin(login, password))
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
            }
            else
            {
                UserWindow userWindow = new UserWindow();
                userWindow.Show();
            }
            Close();
        }

        private bool ValidateLoginAndPassword(string login, string password)
        {
            bool isValid = false;

            acc_infoTableAdapter tableAdapter = new acc_infoTableAdapter();

            auction_dbDataSet.acc_infoDataTable dataTable = new auction_dbDataSet.acc_infoDataTable();

            tableAdapter.Fill(dataTable);

            foreach (auction_dbDataSet.acc_infoRow row in dataTable.Rows)
            {
                if (row.login == login && row.password == password)
                {
                    isValid = true;
                    break;
                }
            }

            return isValid;
        }



        private bool isAdmin(string login, string password)
        {
            acc_infoTableAdapter acc_infoTA = new acc_infoTableAdapter();

            acc_infoDataTable acc_infoDT = new acc_infoDataTable();
            acc_infoTA.Fill(acc_infoDT);

            acc_infoRow[] rows = (acc_infoRow[])acc_infoDT.Select(string.Format("login = '{0}' AND password = '{1}'", login, password));

            if (rows.Length == 1)
            {
                if (rows[0].role_id == 1)
                {
                    return true;
                }
            }

            return false;
        }

    }
}