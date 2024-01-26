using System.Windows;

namespace schappp
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        
       
        public Home(string username)
        {
         
          

            InitializeComponent();
           
          lblname.Text = $"Welcome {username}";
        }

        private void upadteprofile_Click(object sender, RoutedEventArgs e)
        {
            Update update = new Update();
            update.Show();
        }


    }
}

