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
using Microsoft.Data.SqlClient;
namespace schappp
{
    /// <summary>
    /// Interaction logic for Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtfirst.Text) || string.IsNullOrEmpty(txtsecondname.Text) || string.IsNullOrEmpty(txtemail.Text) || string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtpassword.Text))
            {
                MessageBox.Show("All the values are Required,please enter the value");
            }
            else
            {
                SqlConnection ocon = new SqlConnection();
                ocon.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=login;Data Source=DESKTOP-IS6T1F1\\SQLEXPRESS;Encrypt=false";
                ocon.Open();
                //SqlCommand sqlc = new SqlCommand();
                //sqlc.Connection = ocon;
                //sqlc.CommandText = "create table registration( firstname nvarchar(20),secondname nvarchar(20),gender nvarchar(20),emailid nvarchar(40),username nvarchar(30),password nvarchar(20))";
                //////int value = sqlc.ExecuteNonQuery();
                //string query = "create table connect(username nvarchar(30),password nvarchar(20))";
                /* int value = sqlc.ExecuteNonQuery()*/
                
                string regquery = $"insert into registration values('{txtfirst.Text}','{txtsecondname.Text}','{txtemail.Text}','{txtdateofbirth.Text}','{txtusername.Text}','{txtpassword.Text}')";

                SqlCommand sqlc = new SqlCommand(regquery, ocon);
                int value = sqlc.ExecuteNonQuery();
                if (value == 1)
                {
                    MessageBox.Show("Registration Sucess");
                }
                ocon.Close();
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
