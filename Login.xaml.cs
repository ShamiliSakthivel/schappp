using Microsoft.Data.SqlClient;
using System.Windows;

namespace schappp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        
        public Login()
        {
            InitializeComponent();
          
        }

       
        private void chkreset_Click_1(object sender, RoutedEventArgs e)
        {
            string value = txtusername.Text;
            Reset reset = new Reset(value);
            reset.Show();
        }

        private void btnsign_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
            Reg reg = new Reg();
            reg.Show();
        }
    }
}
