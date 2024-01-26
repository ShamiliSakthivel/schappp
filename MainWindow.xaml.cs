using System;
using System.Windows;
using Microsoft.Data.SqlClient;

namespace schappp
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtpassword.Text))
            {
                MessageBox.Show("All the values are Required,please enter the value");
            }
            else
            {
                SqlConnection ocon = new SqlConnection();
                ocon.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=login;Data Source=DESKTOP-IS6T1F1\\SQLEXPRESS; Encrypt=false";
                ocon.Open();
                ////SqlCommand sqlc = new SqlCommand();
                ////sqlc.Connection = ocon;
                ////sqlc.CommandText = "create table connect(username nvarchar(30),password nvarchar(20))";
                ////int value = sqlc.ExecuteNonQuery();
                //string query = "create table connect(username nvarchar(30),password nvarchar(20))";
                // string logquery = $"insert into connect values('{txtusername.Text}','{txtpassword.Text}')";
                string logquery = $"select username from connect where username='{txtusername.Text}' and password='{txtpassword.Text}'";
                SqlCommand sqlc = new SqlCommand(logquery, ocon);
                object value = sqlc.ExecuteScalar();
                string username = value.ToString();
                
                if (!string.IsNullOrEmpty(username))
                {
                    Home home = new Home(username) ;
                    home.Show();
                }
                ocon.Close();
            }

        }
    }
}
