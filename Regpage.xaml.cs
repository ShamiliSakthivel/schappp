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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace schappp
{
    /// <summary>
    /// Interaction logic for Regpage.xaml
    /// </summary>
    public partial class Regpage : Page
    {
        public Regpage()
        {
        }

        public Regpage(string username)
        {
            InitializeComponent();
            SqlConnection ocon = new SqlConnection();
            ocon.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=login;Data Source=DESKTOP-IS6T1F1\\SQLEXPRESS; Encrypt=false";
            ocon.Open();
            ////SqlCommand sqlc = new SqlCommand();
            ////sqlc.Connection = ocon;
            ////sqlc.CommandText = "create table connect(username nvarchar(30),password nvarchar(20))";
            ////int value = sqlc.ExecuteNonQuery();
            //string query = "create table connect(username nvarchar(30),password nvarchar(20))";
            // string logquery = $"insert into connect values('{txtusername.Text}','{txtpassword.Text}')";
            string logquery = $"select * from connect where username='{ username}'";
            SqlCommand sqlc = new SqlCommand(logquery, ocon);
             SqlDataReader oreader = sqlc.ExecuteReader();
            if(oreader.HasRows)
            {
                while (oreader.Read())
                {
                    txtfirst.Text = oreader[0].ToString();
                    txtsecondname.Text = oreader[1].ToString();
                    txtdateofbirth.Text = oreader[2].ToString();
                    txtemail.Text = oreader[3].ToString();
                    txtusername.Text = oreader[4].ToString();
                    txtpassword.Text = oreader[5].ToString();

                }
            }
            ocon.Close();
 
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
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
            string regquery = $" update registration set firstname = '{txtfirst.Text}', secondname = '{txtsecondname.Text}',  emailid = '{txtemail.Text}', dateofbirth='{txtdateofbirth.Text}', username='{txtusername.Text}', password = '{txtpassword.Text}' where firstname='{txtfirst.Text}'";

            SqlCommand sqlc = new SqlCommand(regquery, ocon);
            int value = sqlc.ExecuteNonQuery();
            if (value == 1)
            {
                MessageBox.Show("Update Sucess");
            }
            else
            {
                MessageBox.Show("update Failed");
            }
            ocon.Close();

        }
    }
}
