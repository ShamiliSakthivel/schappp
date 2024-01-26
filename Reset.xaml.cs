using Microsoft.Data.SqlClient;
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

namespace schappp
{
    /// <summary>
    /// Interaction logic for Reset.xaml
    /// </summary>
    public partial class Reset : Window
    {
        string val;
        public Reset(string value)
        {
            InitializeComponent();
            val = value;
        }

        private void btnreset_Click(object sender, RoutedEventArgs e)
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

            //string regquery = $"insert into registration values('{txtfirst.Text}','{txtsecondname.Text}','{txtemail.Text}','{txtdateofbirth.Text}','{txtusername.Text}','{txtpassword.Text}')";
            string regquery = $" update connect set  username='{txtusername.Text}', password = '{txtpassword.Text}' where username='{val}'";

            SqlCommand ocmd = new SqlCommand(regquery, ocon);
            object value = ocmd.ExecuteNonQuery();

            ocon.Close();
        }
    }
}
